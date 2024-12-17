// MySqlConnection 사용을 위함
using MySqlConnector;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
	public string dbIp = "127.0.0.1";
	public int port = 3306;
	private string dbName = "game";
	private string tableName = "users";
	private string rootPasswd = "0909";
	// mysqlDB(mariaDB)와 연결 상태를 유지하는 객체
	private MySqlConnection conn;

	public static DatabaseManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		DBConnect();
	}

	// 데이터 베이스에 접속
	private async void DBConnect()
	{
		// 데이터 베이스 접속 설정
		// config 파일은 포맷이 정해져 있다.
		// 아래처럼 직접 작성하는 방법이 있고, 다른방법도 있다.
		string config = $"server={dbIp};port={port};database={dbName};uid=root;pwd={rootPasswd};charset=utf8;";

		conn = new MySqlConnection(config);
		print($"mysql 접속 시작. state: {conn.State}");
		await conn.OpenAsync();
		print($"mysql 접속 성공. state: {conn.State}");
	}

	public async void SignUp(string email, string userName, string passwd)
	{
		// 비밀번호를 해쉬 키로 변경할 stringBuilder
		StringBuilder pwhash = new StringBuilder();
		// SHA256 해쉬 알고리즘을 사용해 비밀번호를 해쉬 키로 변경
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwd));
			foreach (byte b in hashArray)
			{
				// stringBuilder에 추가
				pwhash.Append($"{b:X2}");
				// 아래는 위와 같다
				//pwhash.Append(b.ToString("X2"));
			}
		}

		//print(pwhash.ToString());
		using (MySqlCommand cmd = new MySqlCommand())
		{
			cmd.Connection = conn;
			cmd.CommandText = $"INSERT INTO {tableName} VALUES('{email}','{pwhash}','{userName}','초보자',1)";
			int rowsAffected = 0;
			try
			{
				rowsAffected = await cmd.ExecuteNonQueryAsync();
			}
			finally
			{
				// 회원 가입 완료
				if (rowsAffected > 0)
				{
					UIManager.Instance.PageOpen("Popup");
					UIManager.Instance.popup.PopupOpen("알림", "회원 가입 성공", () => { UIManager.Instance.PageOpen("LogIn"); });
				}
				// 회원 가입 실패
				else
				{
					UIManager.Instance.PageOpen("Popup");
					UIManager.Instance.popup.PopupOpen("알림", "회원 가입 실패", () => { UIManager.Instance.PageOpen("LogIn"); });
				}
			}
		}
	}

	public async void LogIn(string email, string passwd)
	{
		// 비밀번호를 해쉬 키로 변경할 stringBuilder
		StringBuilder pwhash = new StringBuilder();
		// SHA256 해쉬 알고리즘을 사용해 비밀번호를 해쉬 키로 변경
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwd));
			foreach (byte b in hashArray)
			{
				// stringBuilder에 추가
				pwhash.Append($"{b:X2}");
				// 아래는 위와 같다
				//pwhash.Append(b.ToString("X2"));
			}
		}

		using (MySqlCommand cmd = new MySqlCommand())
		{
			cmd.Connection = conn;
			cmd.CommandText = $"SELECT email, username, class, level FROM {tableName} WHERE email='{email}' AND pw='{pwhash}';";

			MySqlDataReader reader = await cmd.ExecuteReaderAsync();

			// 로그인 성공
			if (reader.Read())
			{
				print($"로그인 성공. email: {reader[0]}, 이름: {reader[1]}, 직업: {reader[2]}, level: {reader[3]}");

				UserData userData = new UserData(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), (int)reader[3]);

				UIManager.Instance.PageOpen("UserInfo");
				UIManager.Instance.userInfo.UserInfoOpen(userData);
			}
			// 로그인 실패
			else
			{
				//print("로그인 실패");
				UIManager.Instance.PageOpen("Popup");
				UIManager.Instance.popup.PopupOpen("알림", "로그인 실패", () => UIManager.Instance.PageOpen("LogIn"));
			}
		}
	}

	// 데이터 조회가 가능한 지 테스트
	public void SelectAll()
	{
		// 질의(query)를 수행할 command 객체 생성
		MySqlCommand cmd = new MySqlCommand();

		// 연결할 db를 입력
		cmd.Connection = conn;
		// users 테이블 조회
		cmd.CommandText = $"SELECT * FROM {tableName};";

		// 쿼리 결과 데이터 셋을 c#에서 사용할 수 있는 형태로 맞춰줌
		MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
		DataSet set = new DataSet();
		dataAdapter.Fill(set);

		// 데이터가 성공적으로 조회되었는 지 여부를 DataSet의 데이블 개수와 행 개수를 통해 확인
		bool isSelectSucceed = set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0;

		// 조회 성공
		if (isSelectSucceed)
		{
			print("데이터 조회 성공");
			foreach (DataRow row in set.Tables[0].Rows)
			{
				print($"이메일: {row["email"]}, 이름: {row["username"]}, 직업: {row["class"]}, 레벨: {row["level"]}");
			}
		}
		// 조회 실패
		else
		{
			print("데이터 조회 실패");
		}
	}
}

// MySqlConnection ����� ����
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
	// mysqlDB(mariaDB)�� ���� ���¸� �����ϴ� ��ü
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

	// ������ ���̽��� ����
	private async void DBConnect()
	{
		// ������ ���̽� ���� ����
		// config ������ ������ ������ �ִ�.
		// �Ʒ�ó�� ���� �ۼ��ϴ� ����� �ְ�, �ٸ������ �ִ�.
		string config = $"server={dbIp};port={port};database={dbName};uid=root;pwd={rootPasswd};charset=utf8;";

		conn = new MySqlConnection(config);
		print($"mysql ���� ����. state: {conn.State}");
		await conn.OpenAsync();
		print($"mysql ���� ����. state: {conn.State}");
	}

	public async void SignUp(string email, string userName, string passwd)
	{
		// ��й�ȣ�� �ؽ� Ű�� ������ stringBuilder
		StringBuilder pwhash = new StringBuilder();
		// SHA256 �ؽ� �˰����� ����� ��й�ȣ�� �ؽ� Ű�� ����
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwd));
			foreach (byte b in hashArray)
			{
				// stringBuilder�� �߰�
				pwhash.Append($"{b:X2}");
				// �Ʒ��� ���� ����
				//pwhash.Append(b.ToString("X2"));
			}
		}

		//print(pwhash.ToString());
		using (MySqlCommand cmd = new MySqlCommand())
		{
			cmd.Connection = conn;
			cmd.CommandText = $"INSERT INTO {tableName} VALUES('{email}','{pwhash}','{userName}','�ʺ���',1)";
			int rowsAffected = 0;
			try
			{
				rowsAffected = await cmd.ExecuteNonQueryAsync();
			}
			finally
			{
				// ȸ�� ���� �Ϸ�
				if (rowsAffected > 0)
				{
					UIManager.Instance.PageOpen("Popup");
					UIManager.Instance.popup.PopupOpen("�˸�", "ȸ�� ���� ����", () => { UIManager.Instance.PageOpen("LogIn"); });
				}
				// ȸ�� ���� ����
				else
				{
					UIManager.Instance.PageOpen("Popup");
					UIManager.Instance.popup.PopupOpen("�˸�", "ȸ�� ���� ����", () => { UIManager.Instance.PageOpen("LogIn"); });
				}
			}
		}
	}

	public async void LogIn(string email, string passwd)
	{
		// ��й�ȣ�� �ؽ� Ű�� ������ stringBuilder
		StringBuilder pwhash = new StringBuilder();
		// SHA256 �ؽ� �˰����� ����� ��й�ȣ�� �ؽ� Ű�� ����
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwd));
			foreach (byte b in hashArray)
			{
				// stringBuilder�� �߰�
				pwhash.Append($"{b:X2}");
				// �Ʒ��� ���� ����
				//pwhash.Append(b.ToString("X2"));
			}
		}

		using (MySqlCommand cmd = new MySqlCommand())
		{
			cmd.Connection = conn;
			cmd.CommandText = $"SELECT email, username, class, level FROM {tableName} WHERE email='{email}' AND pw='{pwhash}';";

			MySqlDataReader reader = await cmd.ExecuteReaderAsync();

			// �α��� ����
			if (reader.Read())
			{
				print($"�α��� ����. email: {reader[0]}, �̸�: {reader[1]}, ����: {reader[2]}, level: {reader[3]}");

				UserData userData = new UserData(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), (int)reader[3]);

				UIManager.Instance.PageOpen("UserInfo");
				UIManager.Instance.userInfo.UserInfoOpen(userData);
			}
			// �α��� ����
			else
			{
				//print("�α��� ����");
				UIManager.Instance.PageOpen("Popup");
				UIManager.Instance.popup.PopupOpen("�˸�", "�α��� ����", () => UIManager.Instance.PageOpen("LogIn"));
			}
		}
	}

	// ������ ��ȸ�� ������ �� �׽�Ʈ
	public void SelectAll()
	{
		// ����(query)�� ������ command ��ü ����
		MySqlCommand cmd = new MySqlCommand();

		// ������ db�� �Է�
		cmd.Connection = conn;
		// users ���̺� ��ȸ
		cmd.CommandText = $"SELECT * FROM {tableName};";

		// ���� ��� ������ ���� c#���� ����� �� �ִ� ���·� ������
		MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
		DataSet set = new DataSet();
		dataAdapter.Fill(set);

		// �����Ͱ� ���������� ��ȸ�Ǿ��� �� ���θ� DataSet�� ���̺� ������ �� ������ ���� Ȯ��
		bool isSelectSucceed = set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0;

		// ��ȸ ����
		if (isSelectSucceed)
		{
			print("������ ��ȸ ����");
			foreach (DataRow row in set.Tables[0].Rows)
			{
				print($"�̸���: {row["email"]}, �̸�: {row["username"]}, ����: {row["class"]}, ����: {row["level"]}");
			}
		}
		// ��ȸ ����
		else
		{
			print("������ ��ȸ ����");
		}
	}
}

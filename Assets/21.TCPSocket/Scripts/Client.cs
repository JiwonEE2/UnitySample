using System;
using System.Collections;
using System.Collections.Generic;
// StreamReader, StreamWriter 사용을 위함
using System.IO;
// IPAddress, IPEndPoint 사용을 위함
using System.Net;
// TcpClient 사용을 위함
using System.Net.Sockets;
// Thread 사용을 위함
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
	[Header("IP Input")]
	public TMP_InputField ip;
	public TMP_InputField port;
	public Button connect;

	[Header("Message Input")]
	public TMP_InputField message;
	public Button send;

	[Header("Text Area")]
	public RectTransform textArea;
	public TextMeshProUGUI textPrefab;

	private Thread clientThread;
	private StreamReader reader;
	private StreamWriter writer;

	private bool isConnected;

	public static Queue<string> log = new Queue<string>();

	private void Awake()
	{
		connect.onClick.AddListener(ConnectButtonClick);
		send.onClick.AddListener(() => SendSubmit(message.text));
		// onEndEdit : enter키 입력 시 호출
		message.onEndEdit.AddListener(SendSubmit);
	}

	private void Update()
	{
		// 출력하는 부분
		if (log.Count > 0)
		{
			TextMeshProUGUI logText = Instantiate(textPrefab, textArea);
			logText.text = log.Dequeue();
		}
	}

	private void ClientThread()
	{
		try
		{
			// 클라이언트 객체 생성
			TcpClient tcpClient = new TcpClient();
			// ip 입력 란의 텍스트를 ip 주소로 파싱
			IPAddress serverAddress = IPAddress.Parse(ip.text);
			// 0~65535 까지의 번호를 사용. ushort로 사용하면 효율적이겠지만, C#에서 주로 쓰이는 정수 자료형이 int이므로 port 번호는 int로 취급
			// 즉, port는 int기 때문에 캐스팅의 번거로움을 피하기 위해 바로 int로 파싱
			int portNum = int.Parse(port.text);

			// IPEndPoint : 도착 지점의 ip와 port로 destination을 설정하는 클래스
			IPEndPoint endPoint = new IPEndPoint(serverAddress, portNum);

			// 서버로 연결 시도
			tcpClient.Connect(endPoint);

			// 여기까지 코드가 실행되었으면 서버 접속 성공
			log.Enqueue("서버 접속 성공");

			reader = new StreamReader(tcpClient.GetStream());
			writer = new StreamWriter(tcpClient.GetStream());
			// 자동으로 밀어넣기
			writer.AutoFlush = true;

			while (tcpClient.Connected)
			{
				string receiveMessage = reader.ReadLine();
				log.Enqueue(receiveMessage);
			}
		}
		// ApplicationException일 경우
		catch (ApplicationException e)
		{
			log.Enqueue("어플리케이션 예외 발생");
			log.Enqueue(e.Message);
		}
		// ApplicationException을 제외한 모든 Exception
		catch (Exception e)
		{
			log.Enqueue("문제 발생");
			log.Enqueue(e.Message);
		}
		// try 문 내의 구문이 실행이 됐건 exception에 의해 끊겼건 반드시 호출
		finally
		{
			//reader = new StreamReader(tcpClient.GetStream());
			//writer = new StreamWriter(tcpClient.GetStream());
			// 위의 두 개 이후에 exception 발생하게 되면 아래처럼 닫아줘야 한다.
			if (reader != null) reader.Close();
			if (writer != null) writer.Close();
			// 접속 끊기
			clientThread.Abort();
			isConnected = false;
		}
	}

	private void ConnectButtonClick()
	{
		// 접속 중이 아닐 경우
		if (false == isConnected)
		{
			// 접속 시도
			// 멀티쓰레딩. Action(delegate) 형태로 
			clientThread = new Thread(ClientThread);
			// 백그라운드에서 동작
			clientThread.IsBackground = true;
			// 쓰레드 시작
			clientThread.Start();
			isConnected = true;
		}
		// 접속 중일 경우
		else
		{
			// 접속 해제
			clientThread.Abort();
			isConnected = false;
		}
	}

	private void SendSubmit(string message)
	{
		writer.WriteLine(message);
		this.message.text = "";
	}
}

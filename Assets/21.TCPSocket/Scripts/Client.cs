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
		message.onEndEdit.AddListener(SendSubmit);
	}

	private void Update()
	{
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
			int portNum = int.Parse(port.text);

			IPEndPoint endPoint = new IPEndPoint(serverAddress, portNum);

			// 서버로 연결 시도
			tcpClient.Connect(endPoint);

			// 여기까지 코드가 실행되었으면 서버 접속 성공
			log.Enqueue("서버 접속 성공");

			reader = new StreamReader(tcpClient.GetStream());
			writer = new StreamWriter(tcpClient.GetStream());
			writer.AutoFlush = true;

			while (tcpClient.Connected)
			{
				string receiveMessage = reader.ReadLine();
				log.Enqueue(receiveMessage);
			}
		}
		catch (ApplicationException e)
		{
			log.Enqueue("어플리케이션 예외 발생");
			log.Enqueue(e.Message);
		}
		catch (Exception e)
		{
			log.Enqueue("문제 발생");
			log.Enqueue(e.Message);
		}
		// try 문 내의 구문이 실행이 됐건 exception에 의해 끊겼건 반드시 호출
		finally
		{
			if (reader != null) reader.Close();
			if (writer != null) writer.Close();
			clientThread.Abort();
			isConnected = false;
		}
	}

	private void ConnectButtonClick()
	{
		// 접속중이 아니면
		if (false == isConnected)
		{
			// 접속 시도
			clientThread = new Thread(ClientThread);
			clientThread.IsBackground = true;
			clientThread.Start();
			isConnected = true;
		}
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

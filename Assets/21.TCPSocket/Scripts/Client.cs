using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
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

	private void Awake()
	{
		connect.onClick.AddListener(ConnectButtonClick);
		send.onClick.AddListener(() => SendSubmit(message.text));
		message.onEndEdit.AddListener(SendSubmit);
	}

	private void ClientThread()
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
		print("서버 접속 성공");

		reader = new StreamReader(tcpClient.GetStream());
		writer = new StreamWriter(tcpClient.GetStream());
		writer.AutoFlush = true;

		while (tcpClient.Connected)
		{
			string receiveMessage = reader.ReadLine();
			print($"메시지 받음:{receiveMessage}");
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

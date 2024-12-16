using System.Collections;
using System.Collections.Generic;
// StreamReader, StreamWriter 사용을 위함
using System.IO;
// IPAddress 사용을 위함
using System.Net;
// TcpClient 사용을 위함
using System.Net.Sockets;
// Thread 사용을 위함
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Server : MonoBehaviour
{
	public Button connect;
	public RectTransform textArea;
	public TextMeshProUGUI textPrefab;
	// localhost : 내 단말의 ip
	private string ipAddress = "127.0.0.1";
	public int port = 9999;
	// 0~65535 까지의 숫자 중 1개를 사용. 80번 이전의 port는 이미 대부분 선점이 되어 있다.

	private bool isConnected = false;
	private Thread serverMainThread;
	private int clientId = 0;

	private List<ClientHandler> clients = new List<ClientHandler>();

	public static Queue<string> log = new Queue<string>();

	private void Awake()
	{
		connect.onClick.AddListener(ConnectButtonClick);
	}

	private void Update()
	{
		// log에 메시지가 있으면
		if (log.Count > 0)
		{
			// TMP로 생성하고
			TextMeshProUGUI logText = Instantiate(textPrefab, textArea);
			// log에서 삭제
			logText.text = log.Dequeue();
		}
	}

	private void ConnectButtonClick()
	{
		if (false == isConnected)
		{
			serverMainThread = new Thread(ServerThread);
			serverMainThread.IsBackground = true;
			serverMainThread.Start();
			isConnected = true;
		}
		else
		{
			serverMainThread.Abort();
			isConnected = false;
		}
	}

	private void ServerThread()
	{
		try
		{
			TcpListener tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
			tcpListener.Start();
			log.Enqueue("서버 시작");
			while (true)
			{
				// TCP client가 접속할 때까지 대기
				// 이 리스너는 누군가 accept 할 때까지 대기
				// 새로운 tcpClient가 내 ip로 와서 붙을 때까지 대기
				TcpClient tcpClient = tcpListener.AcceptTcpClient();
				ClientHandler handler = new ClientHandler();
				handler.Connect(clientId++, this, tcpClient);
				clients.Add(handler);
				// 아래는 오류. Main Thread 에서만 호출될 수 있다.
				//Instantiate(textPrefab, textArea).text = $"{clientId}번 클라이언트가 접속됨";
				log.Enqueue($"{clientId}번 클라이언트가 접속됨");
			}
		}
		catch
		{
			// 예외처리 해보기
			log.Enqueue("무슨 일?");
		}
		finally
		{
			foreach (ClientHandler client in clients)
			{
				client.Disconnect();
			}
			serverMainThread.Abort();
			isConnected = false;
		}
	}

	public void Disconnect(ClientHandler client)
	{
		// 브로드캐스트할 대상에서 삭제
		clients.Remove(client);
	}

	public void BroadcastToClients(string message)
	{
		// 메시지를 받으면 클라이언트들에게 뿌려주기도 할 건데, 서버에서도 한 번 확인하고 싶다
		log.Enqueue(message);
		foreach (ClientHandler client in clients)
		{
			client.MessageToClient(message);
		}
	}
}

public class ClientHandler
{
	public int id;
	public Server server;
	public TcpClient tcpClient;
	public Thread clientThread;
	public StreamReader reader;
	public StreamWriter writer;

	public void Connect(int id, Server server, TcpClient tcpClient)
	{
		//this.id = id;
		// id 안맞는 문제 해결을 위해 내가 임의로 수정함
		this.id = id + 1;
		this.server = server;
		this.tcpClient = tcpClient;
		reader = new StreamReader(tcpClient.GetStream());
		writer = new StreamWriter(tcpClient.GetStream());
		writer.AutoFlush = true;
		clientThread = new Thread(Run);
		clientThread.IsBackground = true;
		clientThread.Start();
	}

	public void Disconnect()
	{
		clientThread.Abort();
		writer.Close();
		reader.Close();
		tcpClient.Close();
		server.Disconnect(this);
	}

	public void MessageToClient(string message)
	{
		writer.WriteLine(message);
	}

	public void Run()
	{
		try
		{
			while (tcpClient.Connected)
			{
				string receiveMessage = reader.ReadLine();
				// 유효성 검사
				if (string.IsNullOrEmpty(receiveMessage))
				{
					// 아무 것도 하지 않기
					continue;
				}
				// 유효한 메시지를 받음 (continue로 빠지지 않음)
				server.BroadcastToClients($"{id}님의 말: {receiveMessage}");
			}
		}
		finally
		{
			Server.log.Enqueue($"{id}번 클라이언트 연결 종료");
			// Server에서 호출하기 때문에 여기서 또 호출할 필요 없다.
			//Disconnect();
		}
	}
}
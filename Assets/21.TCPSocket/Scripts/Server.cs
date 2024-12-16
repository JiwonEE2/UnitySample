using System.Collections;
using System.Collections.Generic;
// StreamReader, StreamWriter ����� ����
using System.IO;
// IPAddress ����� ����
using System.Net;
// TcpClient ����� ����
using System.Net.Sockets;
// Thread ����� ����
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Server : MonoBehaviour
{
	public Button connect;
	public RectTransform textArea;
	public TextMeshProUGUI textPrefab;
	// localhost : �� �ܸ��� ip
	private string ipAddress = "127.0.0.1";
	public int port = 9999;
	// 0~65535 ������ ���� �� 1���� ���. 80�� ������ port�� �̹� ��κ� ������ �Ǿ� �ִ�.

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
		// log�� �޽����� ������
		if (log.Count > 0)
		{
			// TMP�� �����ϰ�
			TextMeshProUGUI logText = Instantiate(textPrefab, textArea);
			// log���� ����
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
			log.Enqueue("���� ����");
			while (true)
			{
				// TCP client�� ������ ������ ���
				// �� �����ʴ� ������ accept �� ������ ���
				// ���ο� tcpClient�� �� ip�� �ͼ� ���� ������ ���
				TcpClient tcpClient = tcpListener.AcceptTcpClient();
				ClientHandler handler = new ClientHandler();
				handler.Connect(clientId++, this, tcpClient);
				clients.Add(handler);
				// �Ʒ��� ����. Main Thread ������ ȣ��� �� �ִ�.
				//Instantiate(textPrefab, textArea).text = $"{clientId}�� Ŭ���̾�Ʈ�� ���ӵ�";
				log.Enqueue($"{clientId}�� Ŭ���̾�Ʈ�� ���ӵ�");
			}
		}
		catch
		{
			// ����ó�� �غ���
			log.Enqueue("���� ��?");
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
		// ��ε�ĳ��Ʈ�� ��󿡼� ����
		clients.Remove(client);
	}

	public void BroadcastToClients(string message)
	{
		// �޽����� ������ Ŭ���̾�Ʈ�鿡�� �ѷ��ֱ⵵ �� �ǵ�, ���������� �� �� Ȯ���ϰ� �ʹ�
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
		// id �ȸ´� ���� �ذ��� ���� ���� ���Ƿ� ������
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
				// ��ȿ�� �˻�
				if (string.IsNullOrEmpty(receiveMessage))
				{
					// �ƹ� �͵� ���� �ʱ�
					continue;
				}
				// ��ȿ�� �޽����� ���� (continue�� ������ ����)
				server.BroadcastToClients($"{id}���� ��: {receiveMessage}");
			}
		}
		finally
		{
			Server.log.Enqueue($"{id}�� Ŭ���̾�Ʈ ���� ����");
			// Server���� ȣ���ϱ� ������ ���⼭ �� ȣ���� �ʿ� ����.
			//Disconnect();
		}
	}
}
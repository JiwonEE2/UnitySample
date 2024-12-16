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
		// Ŭ���̾�Ʈ ��ü ����
		TcpClient tcpClient = new TcpClient();
		// ip �Է� ���� �ؽ�Ʈ�� ip �ּҷ� �Ľ�
		IPAddress serverAddress = IPAddress.Parse(ip.text);
		// 0~65535 ������ ��ȣ�� ���. ushort�� ����ϸ� ȿ�����̰�����, C#���� �ַ� ���̴� ���� �ڷ����� int�̹Ƿ� port ��ȣ�� int�� ���
		int portNum = int.Parse(port.text);

		IPEndPoint endPoint = new IPEndPoint(serverAddress, portNum);

		// ������ ���� �õ�
		tcpClient.Connect(endPoint);

		// ������� �ڵ尡 ����Ǿ����� ���� ���� ����
		print("���� ���� ����");

		reader = new StreamReader(tcpClient.GetStream());
		writer = new StreamWriter(tcpClient.GetStream());
		writer.AutoFlush = true;

		while (tcpClient.Connected)
		{
			string receiveMessage = reader.ReadLine();
			print($"�޽��� ����:{receiveMessage}");
		}
	}

	private void ConnectButtonClick()
	{
		// �������� �ƴϸ�
		if (false == isConnected)
		{
			// ���� �õ�
			clientThread = new Thread(ClientThread);
			clientThread.IsBackground = true;
			clientThread.Start();
			isConnected = true;
		}
		else
		{
			// ���� ����
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

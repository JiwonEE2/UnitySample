using System;
using System.Collections;
using System.Collections.Generic;
// StreamReader, StreamWriter ����� ����
using System.IO;
// IPAddress, IPEndPoint ����� ����
using System.Net;
// TcpClient ����� ����
using System.Net.Sockets;
// Thread ����� ����
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
		// onEndEdit : enterŰ �Է� �� ȣ��
		message.onEndEdit.AddListener(SendSubmit);
	}

	private void Update()
	{
		// ����ϴ� �κ�
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
			// Ŭ���̾�Ʈ ��ü ����
			TcpClient tcpClient = new TcpClient();
			// ip �Է� ���� �ؽ�Ʈ�� ip �ּҷ� �Ľ�
			IPAddress serverAddress = IPAddress.Parse(ip.text);
			// 0~65535 ������ ��ȣ�� ���. ushort�� ����ϸ� ȿ�����̰�����, C#���� �ַ� ���̴� ���� �ڷ����� int�̹Ƿ� port ��ȣ�� int�� ���
			// ��, port�� int�� ������ ĳ������ ���ŷο��� ���ϱ� ���� �ٷ� int�� �Ľ�
			int portNum = int.Parse(port.text);

			// IPEndPoint : ���� ������ ip�� port�� destination�� �����ϴ� Ŭ����
			IPEndPoint endPoint = new IPEndPoint(serverAddress, portNum);

			// ������ ���� �õ�
			tcpClient.Connect(endPoint);

			// ������� �ڵ尡 ����Ǿ����� ���� ���� ����
			log.Enqueue("���� ���� ����");

			reader = new StreamReader(tcpClient.GetStream());
			writer = new StreamWriter(tcpClient.GetStream());
			// �ڵ����� �о�ֱ�
			writer.AutoFlush = true;

			while (tcpClient.Connected)
			{
				string receiveMessage = reader.ReadLine();
				log.Enqueue(receiveMessage);
			}
		}
		// ApplicationException�� ���
		catch (ApplicationException e)
		{
			log.Enqueue("���ø����̼� ���� �߻�");
			log.Enqueue(e.Message);
		}
		// ApplicationException�� ������ ��� Exception
		catch (Exception e)
		{
			log.Enqueue("���� �߻�");
			log.Enqueue(e.Message);
		}
		// try �� ���� ������ ������ �ư� exception�� ���� ����� �ݵ�� ȣ��
		finally
		{
			//reader = new StreamReader(tcpClient.GetStream());
			//writer = new StreamWriter(tcpClient.GetStream());
			// ���� �� �� ���Ŀ� exception �߻��ϰ� �Ǹ� �Ʒ�ó�� �ݾ���� �Ѵ�.
			if (reader != null) reader.Close();
			if (writer != null) writer.Close();
			// ���� ����
			clientThread.Abort();
			isConnected = false;
		}
	}

	private void ConnectButtonClick()
	{
		// ���� ���� �ƴ� ���
		if (false == isConnected)
		{
			// ���� �õ�
			// ��Ƽ������. Action(delegate) ���·� 
			clientThread = new Thread(ClientThread);
			// ��׶��忡�� ����
			clientThread.IsBackground = true;
			// ������ ����
			clientThread.Start();
			isConnected = true;
		}
		// ���� ���� ���
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

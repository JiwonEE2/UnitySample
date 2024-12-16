using System.Collections;
using System.Collections.Generic;
// HttpClient ����� ����
using System.Net.Http;
// Task ����� ����
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WebRequestDotnet : MonoBehaviour
{
	public string imageURL = "https://picsum.photos/500";
	public Image targetImage;
	public RawImage targetRawImage;

	//private void Start()
	//{
	//	//HttpClient client = new HttpClient();
	//	//client.Dispose();
	//	// HttpClient�� IDiposable? �� ��ӹ޴´�. �׷��� Dispose�� �ؾ��ϴµ�,
	//	// dispose �� �ʿ� ���� using ���� ����ϸ� �߰�ȣ�� ������ ������ �ڵ����� Dispose ó���ȴ�.
	//	// �Ʒ��� GetTexture �Լ��� using �� ����
	//	GetTexture();
	//	print("GetTexture() ȣ��");
	//}

	//private async void GetTexture()
	//{
	//	using (HttpClient client = new HttpClient())
	//	{
	//		// await Ű���尡 ������ ���⼭ ������ ��ȯ�� ������ �񵿱� ���·� ���
	//		byte[] response = await client.GetByteArrayAsync(imageURL);

	//		Texture2D texture = new Texture2D(1, 1);
	//		texture.LoadImage(response);
	//		targetRawImage.texture = texture; // �Ͻ��� ����ȯ

	//		// sprite�� ��ȯ �˾Ƽ� �غ���

	//		print("Textrue �ٿ�ε� �Ϸ�");
	//	}
	//}

	// �Ʒ��� �ڷ�ƾ�� ����ϴ�. ���� �Լ����� ȣ��������, �Ʒ��� �ٿ�ε� �� �Լ� ȣ���ϵ��� �Ѵ�.
	private async void Start()
	{
		//HttpClient client = new HttpClient();
		//client.Dispose();
		// HttpClient�� IDiposable? �� ��ӹ޴´�. �׷��� Dispose�� �ؾ��ϴµ�,
		// dispose �� �ʿ� ���� using ���� ����ϸ� �߰�ȣ�� ������ ������ �ڵ����� Dispose ó���ȴ�.
		// �Ʒ��� GetTexture �Լ��� using �� ����

		// �񵿱������� GetTexture �޼��带 ȣ���Ͽ� �̹����� ������
		await GetTexture();
		print("GetTexture() ȣ��");
	}

	private async Task GetTexture()
	{
		// HttpClient�� ����Ͽ� HTTP ��û�� ����
		using (HttpClient client = new HttpClient())
		{
			// await Ű���尡 ������ ���⼭ ������ ��ȯ�� ������ �񵿱� ���·� ���
			// URL�κ��� ����Ʈ �迭�� �񵿱������� ������
			byte[] response = await client.GetByteArrayAsync(imageURL);

			// ���ο� Texture2D ��ü ����
			Texture2D texture = new Texture2D(1, 1);
			// ����Ʈ �迭�κ��� �ؽ�ó �ε�
			texture.LoadImage(response);
			// UI RawImage�� �ؽ�ó ����
			targetRawImage.texture = texture; // �Ͻ��� ����ȯ

			// sprite�� ��ȯ �˾Ƽ� �غ���

			print("Textrue �ٿ�ε� �Ϸ�");
		}
	}
}

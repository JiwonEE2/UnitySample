using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// UnityWebRequest ����� ���� ����
using UnityEngine.Networking;

public class WebRequestTest : MonoBehaviour
{
	public string imageURL = "https://picsum.photos/500";
	public Image targetImage;
	public RawImage targetRawImage;

	private void Start()
	{
		_ = StartCoroutine(GetWebTexture(imageURL));
	}

	IEnumerator GetWebTexture(string url)
	{
		// http�� �� ��û(Request)�� ���� ��ü ����
		// URL�κ��� �ؽ�ó�� ��û�ϴ� UnityWebRequest ����
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

		// �ڷ�ƾ�� ���� �����κ��� ��û�� ���� ����(Response)�� ���� ������ �񵿱�� ����ϴ� ��ü�� �޾ƿ�
		// �񵿱� ��û�� ����
		UnityWebRequestAsyncOperation operation = www.SendWebRequest();
		// ��û�� �Ϸ�� ������ ���
		yield return operation;

		// ��û�� �����ߴ��� Ȯ��
		if (www.result != UnityWebRequest.Result.Success)
		{
			// �� ��� ���� �߻�
			print($"Http ��� ����: {www.error}");
		}
		// �ؽ��� �ٿ�ε� ����
		else
		{
			// �ٿ�ε��� �ؽ�ó�� ������
			Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
			// �ؽ��ĸ� ��Ÿ�ӿ��� Sprite�� ��ȯ
			// �ؽ�ó�κ��� ��������Ʈ ����
			Sprite sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			// image�� sprite ��ü
			// UI Image�� ��������Ʈ ����
			targetImage.sprite = sprite;

			// UI RawImage�� �ؽ�ó ����
			targetRawImage.texture = texture;
		}
	}
}

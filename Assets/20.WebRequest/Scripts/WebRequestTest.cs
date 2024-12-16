using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
		// http로 웹 요청(Request)을 보낼 객체 생성
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

		// 코루틴을 통해 웹으로부터 요청에 대한 응답(Response)를 받을 때까지 비동기로 대기하는 객체를 받아옴
		UnityWebRequestAsyncOperation operation = www.SendWebRequest();
		yield return operation;

		if (www.result != UnityWebRequest.Result.Success)
		{
			// 웹 통신 문제 발생
			print($"Http 통신 실패: {www.error}");
		}
		else
		{
			// 텍스쳐 다운로드 성공
			Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
			// 텍스쳐를 런타임에서 Sprite로 변환
			Sprite sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			// image의 sprite 교체
			targetImage.sprite = sprite;

			targetRawImage.texture = texture;
		}
	}
}

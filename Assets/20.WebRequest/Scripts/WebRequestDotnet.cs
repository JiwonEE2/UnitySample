using System.Collections;
using System.Collections.Generic;
// HttpClient 사용을 위함
using System.Net.Http;
// Task 사용을 위함
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
	//	// HttpClient는 IDiposable? 을 상속받는다. 그래서 Dispose를 해야하는데,
	//	// dispose 할 필요 없이 using 문을 사용하면 중괄호가 끝나는 시점에 자동으로 Dispose 처리된다.
	//	// 아래의 GetTexture 함수의 using 문 참고
	//	GetTexture();
	//	print("GetTexture() 호출");
	//}

	//private async void GetTexture()
	//{
	//	using (HttpClient client = new HttpClient())
	//	{
	//		// await 키워드가 있으니 여기서 리턴이 반환될 때까지 비동기 상태로 대기
	//		byte[] response = await client.GetByteArrayAsync(imageURL);

	//		Texture2D texture = new Texture2D(1, 1);
	//		texture.LoadImage(response);
	//		targetRawImage.texture = texture; // 암시적 형변환

	//		// sprite로 변환 알아서 해보기

	//		print("Textrue 다운로드 완료");
	//	}
	//}

	// 아래는 코루틴과 비슷하다. 위는 함수먼저 호출하지만, 아래는 다운로드 후 함수 호출하도록 한다.
	private async void Start()
	{
		//HttpClient client = new HttpClient();
		//client.Dispose();
		// HttpClient는 IDiposable? 을 상속받는다. 그래서 Dispose를 해야하는데,
		// dispose 할 필요 없이 using 문을 사용하면 중괄호가 끝나는 시점에 자동으로 Dispose 처리된다.
		// 아래의 GetTexture 함수의 using 문 참고

		// 비동기적으로 GetTexture 메서드를 호출하여 이미지를 가져옴
		await GetTexture();
		print("GetTexture() 호출");
	}

	private async Task GetTexture()
	{
		// HttpClient를 사용하여 HTTP 요청을 보냄
		using (HttpClient client = new HttpClient())
		{
			// await 키워드가 있으니 여기서 리턴이 반환될 때까지 비동기 상태로 대기
			// URL로부터 바이트 배열을 비동기적으로 가져옴
			byte[] response = await client.GetByteArrayAsync(imageURL);

			// 새로운 Texture2D 객체 생성
			Texture2D texture = new Texture2D(1, 1);
			// 바이트 배열로부터 텍스처 로드
			texture.LoadImage(response);
			// UI RawImage에 텍스처 설정
			targetRawImage.texture = texture; // 암시적 형변환

			// sprite로 변환 알아서 해보기

			print("Textrue 다운로드 완료");
		}
	}
}

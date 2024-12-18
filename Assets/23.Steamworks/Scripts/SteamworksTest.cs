using Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityImage = UnityEngine.UI.Image;
using SteamImage = Steamworks.Data.Image;
using UnityColor = UnityEngine.Color;
using SteamColor = Steamworks.Data.Color;

public class SteamworksTest : MonoBehaviour
{
	public UnityImage imagePrefab;

	private async void Start()
	{
		// 스팀 클라이언트 초기화
		// 스팀에서 개발자에게 제공하는 테스트 앱 ID : 480 (Spacewar)
		SteamClient.Init(480);

		print(SteamClient.Name);

		// 내 초상화 가져오기
		SteamImage? myAvatar = await SteamFriends.GetLargeAvatarAsync(SteamClient.SteamId);

		UnityImage myAvaterImage = Instantiate(imagePrefab, transform);

		if (myAvatar.HasValue)
		{
			// UI에 생성된 Image의 Source image를 가져온 내 초상화로 교체
			myAvaterImage.sprite = SteamImageToSprite(myAvatar.Value);
		}

		foreach (Friend friend in SteamFriends.GetFriends())
		{
			// foreach문 돌면서 친구 초상화 찍기
			SteamImage? friendAvatar = await SteamFriends.GetLargeAvatarAsync(friend.Id);
			UnityImage friendAvatarImage = Instantiate(imagePrefab, transform);
			if (friendAvatar.HasValue)
			{
				friendAvatarImage.sprite = SteamImageToSprite(friendAvatar.Value);
			}
		}
	}

	private void OnApplicationQuit()
	{
		// 앱이 종료될 때 스팀 클라이언트 앱도 닫음.
		SteamClient.Shutdown();
	}

	// 이미지 변환 메소드
	public Sprite SteamImageToSprite(SteamImage image)
	{
		// Texture2D 객체 생성
		Texture2D texture = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, false);

		texture.filterMode = FilterMode.Trilinear;

		// steam image와 unity sprite 텍스쳐의 픽셀 표시 순서가 달라서 반전 필요
		for (int x = 0; x < image.Width; x++)
		{
			for (int y = 0; y < image.Height; y++)
			{
				SteamColor steamPixel = image.GetPixel(x, y);
				UnityColor unityPixel = new UnityColor(steamPixel.r / 255f, steamPixel.g / 255f, steamPixel.b / 255f, steamPixel.a / 255f);
				texture.SetPixel(x, (int)image.Height - y, unityPixel);
			}
		}
		texture.Apply();
		Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

		return sprite;
	}
}

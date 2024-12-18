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
		// ���� Ŭ���̾�Ʈ �ʱ�ȭ
		// �������� �����ڿ��� �����ϴ� �׽�Ʈ �� ID : 480 (Spacewar)
		SteamClient.Init(480);

		print(SteamClient.Name);

		// �� �ʻ�ȭ ��������
		SteamImage? myAvatar = await SteamFriends.GetLargeAvatarAsync(SteamClient.SteamId);

		UnityImage myAvaterImage = Instantiate(imagePrefab, transform);

		if (myAvatar.HasValue)
		{
			// UI�� ������ Image�� Source image�� ������ �� �ʻ�ȭ�� ��ü
			myAvaterImage.sprite = SteamImageToSprite(myAvatar.Value);
		}

		foreach (Friend friend in SteamFriends.GetFriends())
		{
			// foreach�� ���鼭 ģ�� �ʻ�ȭ ���
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
		// ���� ����� �� ���� Ŭ���̾�Ʈ �۵� ����.
		SteamClient.Shutdown();
	}

	// �̹��� ��ȯ �޼ҵ�
	public Sprite SteamImageToSprite(SteamImage image)
	{
		// Texture2D ��ü ����
		Texture2D texture = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, false);

		texture.filterMode = FilterMode.Trilinear;

		// steam image�� unity sprite �ؽ����� �ȼ� ǥ�� ������ �޶� ���� �ʿ�
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

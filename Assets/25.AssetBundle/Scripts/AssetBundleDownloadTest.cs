using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleDownloadTest : MonoBehaviour
{
	public string url =
		"https://drive.google.com/uc?export=download&id=1WqOUg3asDEIgYSiJxOXo87NaPP6uA7Aw";

	IEnumerator Start()
	{
		// 웹으로부터 Asset Bundle을 다운로드할 때, 버전을 사용하지 않으면
		// 로컬에 캐쉬 파일을 생성하지 않고, 매번 다시 다운로드함.
		// UnityEngine.Networking.UnityWebRequestAssetBundle
		// UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url, crc:0);

		// 버전을 사용하면 로컬 캐쉬로부터 불러오므로
		// 최초 다운로드 이후에는 로드가 거의 즉시 완료
		UnityWebRequest www =
			UnityWebRequestAssetBundle.GetAssetBundle(url, version: 0, crc: 0);

		print("번들 다운로드 시작..");
		yield return www.SendWebRequest();

		// Asset Bundle 다운로드 완료
		if (www.result == UnityWebRequest.Result.Success)
		{
			print("번들 다운로드 완료!");

			// Web Request의 결과(Response)로부터 Asset Bundle을 로드
			DownloadHandlerAssetBundle.GetContent(www);

			AssetBundle prefabBundle =
				AssetBundle.LoadFromFile("./Bundle/prefabs/bat");
			AssetBundle.LoadFromFile("./Bundle/material/monster");
			AssetBundle.LoadFromFile("./Bundle/texture");

			GameObject prefab = prefabBundle.LoadAsset<GameObject>("Bat");
			Instantiate(prefab);
		}
		else
		{
			print($"번들 다운로드 실패: {www.error}");
			yield break;
		}

		yield return null;
	}
}
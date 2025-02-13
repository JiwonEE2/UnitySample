using UnityEngine;

public class AssetBundleTest : MonoBehaviour
{
	private void Start()
	{
		string bundlePath = "./Bundle";
		string targetBundle = "prefabs/bat";
		string assetName = "Bat";

		// Asset Bundle을 로드. Asset Bundle은 번들 단위로(통째로만) 로드할 수 있음.
		// LoadFromFile: 실제 파일이 있는 시스템 경로를 참조해야 함.
		AssetBundle assetBun =
			AssetBundle.LoadFromFile($"{bundlePath}/{targetBundle}");

		if (assetBun == null)
		{
			Debug.LogError("Asset Bundle 참조 실패!");
		}

		// Asset Bundle의 단점: 종속성이 있는 번들을 로드하지 않으면 참조되지 않을 수 있다.
		AssetBundle.LoadFromFile($"{bundlePath}/material/monster");
		AssetBundle.LoadFromFile($"{bundlePath}/model/bat");
		AssetBundle.LoadFromFile($"{bundlePath}/texture");

		GameObject batPrefab = assetBun.LoadAsset<GameObject>(assetName);
		Instantiate(batPrefab);
	}
}
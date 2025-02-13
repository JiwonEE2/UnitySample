using System.Collections;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{
	// public GameObject prefab;

	IEnumerator Start()
	{
		// yield return new WaitForSeconds(30f);

		// 리소스 매니저를 통해 GameObject와 Material을 로드
		// GameObject prefab = Resources.Load("Prefabs/TestPrefab") as GameObject;
		// 위와 같음.
		GameObject prefab = Resources.Load<GameObject>("Prefabs/TestPrefab");
		// 필요한 시점에 로드 및 언로드.
		// Resources.LoadAsync도 있다.

		GameObject instance = Instantiate(prefab);
		yield return new WaitForSeconds(3);

		Material mat = Resources.Load<Material>("Materials/TestMaterial");
		instance.GetComponent<Renderer>().material = mat;

		yield return new WaitForSeconds(3);
		Resources.UnloadAsset(mat);
		print("mat 언로드 완료.");

		// Prefab은 unloadAsset을 통해 명시적으로 언로드할 수 없음.
		Resources.UnloadAsset(prefab);
		print("prefab 언로드 완료.");

		// 사용하지 않는 모든 리소스를 언로드. async 리턴.
		// yield return Resources.UnloadUnusedAssets();
		// print("사용하지 않는 리소스 언로드 완료.");
	}
}
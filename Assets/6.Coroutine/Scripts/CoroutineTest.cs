using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
	MeshRenderer mr;
	public Material woodMaterial;
	public Material redMaterial;
	private Material stoneMateiral;

	public Transform transformTest;


	private void Awake()
	{
		mr = GetComponent<MeshRenderer>();
		stoneMateiral = mr.material;
	}

	// Start is called before the first frame update
	void Start()
	{
		// 정확히 3초 후에 MeshRenderer의 Material을 woodMaterial로 교체
		//var enumerator = StringEnumerator();
		//while (enumerator.MoveNext())
		//{
		//	print(enumerator.Current);
		//}

		//List<int> intList = new List<int>() { 1, 2, 3 };
		//foreach(int someInt in intList)
		//{
		//	print(someInt);
		//}

		//foreach (Transform someTransform in transformTest)
		//{
		//	print(someTransform.name);
		//}

		// 하수용
		//StartCoroutine("MaterialChange");
		// 고수용
		materialChangeCoroutine = StartCoroutine(MaterialChange(redMaterial, 1f));
	}
	private Coroutine materialChangeCoroutine;

	// Update is called once per frame
	void Update()
	{
		//	if (Time.time > 3f)
		//	{
		//		mr.material = woodMaterial;
		//	}

		if (Input.GetButtonDown("Jump"))
		{
			mr.material = stoneMateiral;
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			print("코루틴 스탑");
			// 하수용
			//StopCoroutine("MaterialChange");
			// 고수용
			StopCoroutine(materialChangeCoroutine);
		}
	}

	private IEnumerator<string> StringEnumerator()
	{
		//IEnumerator를 반환하는 함수는 yield return 키워드를 통해 값을 순차적으로 반환할 수 있다
		yield return "a";
		yield return "b";
		yield return "c";
	}

	private IEnumerator MaterialChange(Material mat, float interval)
	{
		while (true)
		{
			//코루틴이 3초 동안 대기합니다.
			yield return new WaitForSeconds(interval);
			mr.material = mat;
		}
	}
}

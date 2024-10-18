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
		// ��Ȯ�� 3�� �Ŀ� MeshRenderer�� Material�� woodMaterial�� ��ü
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

		// �ϼ���
		//StartCoroutine("MaterialChange");
		// �����
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
			print("�ڷ�ƾ ��ž");
			// �ϼ���
			//StopCoroutine("MaterialChange");
			// �����
			StopCoroutine(materialChangeCoroutine);
		}
	}

	private IEnumerator<string> StringEnumerator()
	{
		//IEnumerator�� ��ȯ�ϴ� �Լ��� yield return Ű���带 ���� ���� ���������� ��ȯ�� �� �ִ�
		yield return "a";
		yield return "b";
		yield return "c";
	}

	private IEnumerator MaterialChange(Material mat, float interval)
	{
		while (true)
		{
			//�ڷ�ƾ�� 3�� ���� ����մϴ�.
			yield return new WaitForSeconds(interval);
			mr.material = mat;
		}
	}
}

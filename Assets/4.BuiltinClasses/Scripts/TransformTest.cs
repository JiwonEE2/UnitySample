using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
	// Transform : ���� ��ü�� ���� ��� GameObject���� ������ 1���� Transform�� ����
	public GameObject yourObject;
	public Transform parent;
	public Transform grandParent;

	private void Start()
	{
		// ��� GameObject, Component Ŭ������ tranform�̶�� ������Ƽ�� �ش� ��ü�� Transform ������Ʈ�� ��ȯ
		print($"my transform : {transform}");
		print($"your transform : {yourObject.transform}");
		print($"my transform's transform : {transform.transform}");

		string someChildsName = parent.Find("ThirdChild").GetChild(0).name;
		print(someChildsName);

		parent.SetParent(grandParent, false);
		//parent.parent = grandParent;		// ���� �Ȱ��� �����ϳ� �Ϲ������� SetParent �Լ��� ȣ��
	}
}

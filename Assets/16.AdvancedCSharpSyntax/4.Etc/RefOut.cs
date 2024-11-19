using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefOut : MonoBehaviour
{
	// ref Ű���� : Value Ÿ��(enum, struct, literial) �����͸� �Ķ���͸� ����
	// �Լ��� ������ ��� �޸𸮿� ���� �����Ͽ� �����ϴµ�,
	// �̸� �����ͷ� ��ü�ϴ� �Ķ���͸� ������ ��쿡 ���
	// ������ ��ü��

	private void Start()
	{
		int a = 10;
		int b = 20;
		Swap(ref a, ref b);
		print($"a : {a}, b : {b}");

		GameObject obj1 = new GameObject("No.1");
		obj1.transform.position = new Vector3(1, 0, 0);
		GameObject obj2 = new GameObject("No.2");
		SwapObj(obj1, obj2);
		print($"obj1 : {obj1.name}, obj2 : {obj2.name}");

		GameObject outObj1 = new GameObject("Out");
		outObj1.transform.position = new Vector3(1, 2, 3);
		GameObject outObj2 = new GameObject("Not Out");
		outObj2.transform.position = new Vector3(3, 2, 1);
		//Vector3 outPos = new Vector3(0, 1, 2);
		//Vector3 outPos;	// ���� out�� ����ϸ� �Ǳ� ������ �ʱ�ȭ���� ����

		// out Ű���� �Ķ���ʹ� Ư���� ���� �� �ʱ�ȭ�� ���� �ǹ̰� ���� ������
		// �Լ� ȣ��� ���� ���ο��� ������ ����
		if (TryGetPosition(outObj1, out Vector3 outPos))
		{
			print($"Out : {outPos}");
		}
		if (TryGetPosition(outObj2, out Vector3 outPos2))
		{
			print($"Out : {outPos2}");
		}
	}

	void Swap(ref int a, ref int b)
	{
		int temp = a;
		a = b;
		b = temp;
	}

	void SwapObj(GameObject obj1, GameObject obj2)
	{
		//GameObject temp = obj1;
		//obj1 = obj2;
		//obj2 = temp;

		string temp = obj1.name;
		obj1.name = obj2.name;
		obj2.name = temp;
	}

	// out : �������� ���α׷��� �������� ������ �� �ϳ�
	// �ٵ� �Լ� ���� ��� �ް� ���� �����Ͱ� ���� ���� ��쿡��?

	object[] TryGetComponent(Type type) // Even ���� ���� ����
	{
		Component comp = GetComponent(type);
		bool boolReturn = comp is not null;
		return new object[2] { boolReturn, comp };
	}

	// return�� �⺻���� ��ȯ�� �ϰ�, �߰����� �����ʹ� out �Ķ���ͷ� ���޵� ������
	// �����ϴ� �ɷ� ��ü
	// �Լ��� out Ű���尡 ���ԵǾ� ���� ���, �ش� �Լ��� ������ 
	// �� �Ķ���͸� �ʱ�ȭ�ؾ� ��

	bool TryGetPosition(GameObject target, out Vector3 pos)
	{
		// ���� target.name�� "Out"�̸� Pos�� target.transform.position�� ����
		// �ƴϸ� Vector3.zero�� ����
		if (target.name == "Out")
		{
			pos = target.transform.position;
			return true;
		}
		else
		{
			pos = Vector3.zero;
			return false;
		}
	}
}

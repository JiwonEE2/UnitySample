using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using SAA = SuperAwesomeAttribute;

// Reflection : System.Reflection ���ӽ����̽��� ���Ե� ��� ����
// ������ Ÿ�ӿ��� ������ Ŭ����, �޼ҵ�, ��� ���� �� ���� ���ؽ�Ʈ�� ���� �����͸�
// �����ϰ� ����ϴ� ���
// Attribute�� ������ Ÿ�ӿ��� �����ϴ� ��Ÿ�������̹Ƿ� ���÷����� ���� �����͸� ������ �� ����

[RequireComponent(typeof(AttributeTest))]
public class ReflectionTest : MonoBehaviour
{
	AttributeTest attTest;
	private void Awake()
	{
		attTest = GetComponent<AttributeTest>();
	}

	private void Start()
	{
		// attTest�� Ÿ���� Ȯ��
		MonoBehaviour attTestBoxingForm = attTest;
		Type attTestType = attTestBoxingForm.GetType();
		print(attTestType);

		// AttributeTest ��� Ŭ������ ������?
		BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
		// public���� ������ ������ ���ÿ� static�� �ƴ϶� ��ü ���� ������ feild �Ǵ� property
		// attTestType : attTest�� GetType�� ���� Ŭ���� ���� ���� �����͸� ������ ����
		FieldInfo[] fieldInfos = attTestType.GetFields(bind);

		foreach (FieldInfo fieldInfo in fieldInfos)
		{
			SAA attribute = fieldInfo.GetCustomAttribute<SAA>();
			print($"{fieldInfo.Name}�� Ÿ���� {fieldInfo.FieldType}");
			if (attribute is null)
			{
				print($"{fieldInfo.Name}���� ���� ��� ��Ʈ����Ʈ�� ����");
				continue;
			}

			print($"{fieldInfo.Name}���� ���� ��� ��Ʈ����Ʈ�� ����");
			print($"{attribute.getAwesomeMessage}, {attribute.message}");
			print($"{fieldInfo.GetValue(attTest)}");
		}
	}
}

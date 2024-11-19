using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using SAA = SuperAwesomeAttribute;

// Reflection : System.Reflection 네임스페이스에 포함된 기능 전반
// 컴파일 타임에서 생성된 클래스, 메소드, 멤버 변수 등 여러 컨텍스트에 대한 데이터를
// 색인하고 취급하는 기능
// Attribute는 컴파일 타임에서 생성하는 메타데이터이므로 리플렉션을 통해 데이터를 가져올 수 있음

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
		// attTest의 타입을 확인
		MonoBehaviour attTestBoxingForm = attTest;
		Type attTestType = attTestBoxingForm.GetType();
		print(attTestType);

		// AttributeTest 라는 클래스의 데이터?
		BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
		// public으로 접근이 가능한 동시에 static이 아니라 객체 별로 생성할 feild 또는 property
		// attTestType : attTest의 GetType을 통해 클래스 명세에 대한 데이터를 가지고 있음
		FieldInfo[] fieldInfos = attTestType.GetFields(bind);

		foreach (FieldInfo fieldInfo in fieldInfos)
		{
			SAA attribute = fieldInfo.GetCustomAttribute<SAA>();
			print($"{fieldInfo.Name}의 타입은 {fieldInfo.FieldType}");
			if (attribute is null)
			{
				print($"{fieldInfo.Name}에는 슈퍼 어썸 어트리뷰트가 없음");
				continue;
			}

			print($"{fieldInfo.Name}에는 슈퍼 어썸 어트리뷰트가 있음");
			print($"{attribute.getAwesomeMessage}, {attribute.message}");
			print($"{fieldInfo.GetValue(attTest)}");
		}
	}
}

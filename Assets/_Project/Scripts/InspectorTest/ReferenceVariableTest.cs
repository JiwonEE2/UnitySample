using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]    // C# Attribute : 특정 요소(클래스, 변수, 함수)에 대한 메타데이터를 정의
public class MyClass    // 이 클래스의 값을 다른 어셈블리에서 접근하기 위해서는 "직렬화"가 필요
{
	public string name;
	public int id;
	public Sprite sprite;
}

public class ReferenceVariableTest : MonoBehaviour
{
	public MyClass myClass;

	public List<MyClass> myClasses;

	// Start is called before the first frame update
	void Start()
	{
		print(myClass);   // print() : Debug.Log()와 같다. MonoBehaviour에 포함되어 있는 함수
		print(myClass.name);
	}

	// Update is called once per frame
	void Update()
	{

	}
}

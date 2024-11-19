using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

// attribute : �Ӽ�, Ư��, Ư¡���� ����(������ ����)
// C#������ attribute : Ư�� ���ؽ�Ʈ(Ŭ���� ����, �Լ� ����, ������ ����)�� ���� ������ Ÿ�ӿ��� �־����� ��Ÿ������

public class AttributeTest : MonoBehaviour
{
	//[SerializeField]
	//private int imPrivate;
	//public MyColor color;

	// Attribute�� ����ϴ� ��� : ��� ���ؽ�Ʈ �� [] ���̿� Attribute Ŭ������ ����� Ŭ������ �̸�
	// (���� Attribute�� �� �̸�)�� ������ �ȴ�.

	[TextArea(4, 15)]
	// ��ȣ ���� ������ ������ ȣ��
	public string someText;

	//[SuperAwesome("you are not awesome.")]
	[SuperAwesome(message = "not awesome", getAwesomeMessage = "not cool")]
	public int awesomeInt;
}

// �����ڰ� �ۼ��� custom attribute (System.Attribute�� ����� Ŭ����) �տ�
// AttributeUsageAttribute��� ��Ʈ����Ʈ�� �߰��Ͽ� �ش� ��Ʈ����Ʈ�� �����
// �����ϰų� �߰� ������ ����
// AttributeUsage : Custom Attribute�� �߰� ������ ���� ����
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
public class SuperAwesomeAttribute : Attribute
{
	public string message;
	public string getAwesomeMessage;

	public SuperAwesomeAttribute()
	{
		message = "I'm Super Awesome";
		getAwesomeMessage = "Super Awesome!";
	}

	public SuperAwesomeAttribute(string message)
	{
		this.message = message;
	}
}

//[Serializable]
//public class MyColor
//{
//	public float red;
//	public float green;
//	public float blue;
//	public float alpha;
//}
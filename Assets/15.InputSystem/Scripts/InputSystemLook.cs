using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemLook : MonoBehaviour
{
	public void OnLook(InputValue value)
	{
		print($"OnLook ȣ��. �Ķ���� : {value.Get<Vector2>()}");
		if (SimpleMouseControl2.isFocusing == false) return;
		// esc �����ų� ��Ŀ�� ����� ���콺 �ν� ����
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemLook : MonoBehaviour
{
	public Transform cameraRig;
	public float mouseSensitivity;
	private float rigAngle = 0f;

	public void OnLook(InputValue value)
	{
		print($"OnLook ȣ��. �Ķ���� : {value.Get<Vector2>()}");
		if (SimpleMouseControl2.isFocusing == false) return;
		// esc �����ų� ��Ŀ�� ����� ���콺 �ν� ����

		Vector2 mouseDelta = value.Get<Vector2>();
		transform.Rotate(0, mouseDelta.x * mouseSensitivity * Time.deltaTime, 0);
		rigAngle -= mouseDelta.y * mouseSensitivity * Time.deltaTime;
	}
}

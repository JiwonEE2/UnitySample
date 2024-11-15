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
		print($"OnLook 호출. 파라미터 : {value.Get<Vector2>()}");
		if (SimpleMouseControl2.isFocusing == false) return;
		// esc 누르거나 포커스 벗어나면 마우스 인식 안함

		Vector2 mouseDelta = value.Get<Vector2>();
		transform.Rotate(0, mouseDelta.x * mouseSensitivity * Time.deltaTime, 0);
		rigAngle -= mouseDelta.y * mouseSensitivity * Time.deltaTime;
	}
}

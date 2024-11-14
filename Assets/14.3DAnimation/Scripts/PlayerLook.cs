using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	public Transform cameraRig;
	public float mouseSensivity;
	private float rigAngle = 0f;

	private void Update()
	{
		//if(SimpleMouseControl.isFocusing == false)
		float mouseX = Input.GetAxis("Mouse X");  // mouse�� ������ delta
		float mouseY = Input.GetAxis("Mouse Y");

		// mouse �¿� �����ӿ� ���� ĳ������ Transform�� Rotate
		transform.Rotate(0, mouseX * mouseSensivity * Time.deltaTime, 0);

		rigAngle -= mouseY * mouseSensivity * Time.deltaTime;

		// ī�޶��� x�� ������ ����
		rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);

		// ���ѵ� ������ŭ ī�޶��� Rotation�� ����
		cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);

		// mouse�� ���� �����ӿ� ���� ī�޶� ������ Transform�� Rotate
		//cameraRig.Rotate(-mouseY * mouseSensivity * Time.deltaTime, 0, 0);
	}
}

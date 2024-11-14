using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseControl2 : MonoBehaviour
{
	private void Start()
	{
		// 마우스 락
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			isFocusing = false;
		}
	}

	public static bool isFocusing = true;

	private void OnApplicationFocus(bool focus)
	{
		isFocusing = focus;
		if (isFocusing)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else
		{
			//Cursor.lockState=
		}
	}
}

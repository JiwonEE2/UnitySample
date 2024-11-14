using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseControlHW : MonoBehaviour
{
	private void Start()
	{
		OnApplicationFocus(true);
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
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}

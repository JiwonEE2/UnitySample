using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemMove : MonoBehaviour
{
	Vector2 moveDir;

	private void OnMove(InputValue value)
	{
		moveDir = value.Get<Vector2>();
		print($"OnMove ȣ�� ��. �Ķ���� : {moveDir}");
	}

	private void Update()
	{

	}
}

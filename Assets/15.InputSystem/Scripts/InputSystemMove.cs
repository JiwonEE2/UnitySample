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
		print($"OnMove 호출 됨. 파라미터 : {moveDir}");
	}

	private void Update()
	{

	}
}

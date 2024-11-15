using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class InputSystemMove : MonoBehaviour
{
	CharacterController charCtrl;
	Animator animator;

	public float walkSpeed;
	public float runSpeed;

	Vector2 inputValue;

	private void Awake()
	{
		charCtrl = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	private void OnMove(InputValue value)
	{
		inputValue = value.Get<Vector2>();
		print($"OnMove 호출 됨. 파라미터 : {inputValue}");
	}

	private void Update()
	{
		Vector3 inputMoveDir = new Vector3(inputValue.x, 0, inputValue.y) * walkSpeed;
		Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);

		charCtrl.Move(actualMoveDir * Time.deltaTime);

		animator.SetFloat("Xdir", inputValue.x);
		animator.SetFloat("Ydir", inputValue.y);
		animator.SetFloat("Speed", inputValue.magnitude);
	}
}

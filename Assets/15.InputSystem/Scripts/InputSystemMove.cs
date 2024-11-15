using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class InputSystemMove : MonoBehaviour
{
	CharacterController charCtrl;
	Animator animator;

	public float walkSpeed;
	public float runSpeed;

	Vector2 inputValue;

	public InputActionAsset controlDefine;

	InputAction moveAction;

	private void Awake()
	{
		charCtrl = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		controlDefine = GetComponent<PlayerInput>().actions;
		moveAction = controlDefine.FindAction("Move");
	}

	// 이벤트 등록을 위함
	private void OnEnable()
	{
		// moveAction.started -> XXDown
		moveAction.performed += OnMoveEvent;  // XX
		moveAction.canceled += OnMoveEvent;   // -> XXUp
	}

	private void OnDisable()
	{
		moveAction.performed -= OnMoveEvent;
		moveAction.canceled -= OnMoveEvent;
	}

	public void OnMoveEvent(Context context)
	{
		print($"OnMoveEvent 호출. context : {context.ReadValue<Vector2>()}");
		inputValue = context.ReadValue<Vector2>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;

public class InputSystemLook : MonoBehaviour
{
	public Transform cameraRig;
	public float mouseSensitivity;
	private float rigAngle = 0f;

	public InputActionAsset controlDefine;
	InputAction lookAction;

	private void Awake()
	{
		controlDefine = GetComponent<PlayerInput>().actions;
		lookAction = controlDefine.FindAction("Look");
	}

	private void OnEnable()
	{
		lookAction.performed += OnLookEvent;
		lookAction.canceled += OnLookEvent;
	}

	private void OnDisable()
	{
		lookAction.performed -= OnLookEvent;
		lookAction.canceled -= OnLookEvent;
	}

	public void OnLookEvent(Context context)
	{
		if (SimpleMouseControl2.isFocusing) return;
		Look(context.ReadValue<Vector2>());
	}

	public void OnLook(InputValue value)
	{
		print($"OnLook ȣ��. �Ķ���� : {value.Get<Vector2>()}");
		if (SimpleMouseControl2.isFocusing == false) return;
		// esc �����ų� ��Ŀ�� ����� ���콺 �ν� ����
		Vector2 mouseDelta = value.Get<Vector2>();
		Look(mouseDelta);
	}

	private void Look(Vector2 mouseDelta)
	{
		transform.Rotate(0, mouseDelta.x * mouseSensitivity * Time.deltaTime, 0);
		rigAngle -= mouseDelta.y * mouseSensitivity * Time.deltaTime;
		rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);
		cameraRig.localEulerAngles = new Vector3(rigAngle, 0, 0);
	}
}

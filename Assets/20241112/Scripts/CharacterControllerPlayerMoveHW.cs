using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerPlayerMoveHW : MonoBehaviour
{
	public float moveSpeed;
	public float turnSpeed;
	private CharacterController cc;

	private void Awake()
	{
		cc = GetComponent<CharacterController>();
	}

	private void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Move(inputY * Time.fixedDeltaTime * moveSpeed);
		Turn(inputX * Time.fixedDeltaTime * turnSpeed);
	}

	private void Move(float speed)
	{
		cc.Move(transform.forward * speed - transform.up * 9.81f * Time.fixedDeltaTime);
	}

	private void Turn(float angle)
	{
		transform.Rotate(new Vector3(0, angle, 0));
	}
}
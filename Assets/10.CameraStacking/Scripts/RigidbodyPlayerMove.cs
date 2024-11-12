using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyPlayerMove : MonoBehaviour
{
	public float moveSpeed;
	public float turnSpeed;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
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
		rb.MovePosition(rb.position + transform.forward * speed);
	}

	private void Turn(float angle)
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler(0, angle, 0));
	}
}

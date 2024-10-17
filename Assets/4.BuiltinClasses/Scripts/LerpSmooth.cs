using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSmooth : MonoBehaviour
{
	public Transform followTarget;
	public float moveSpeed;

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, followTarget.position, Time.deltaTime * moveSpeed);
	}
}

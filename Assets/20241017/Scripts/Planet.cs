using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	public float radius = 1;
	public float distance = 1;
	public float revolutionSpeed = 1;
	public float rotationSpeed = 1;
	private float revolutionTime = 0;
	private float rotationTime = 0;
	private void Update()
	{
		// scale(크기)
		transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);

		// revolution(공전)
		revolutionTime += Time.deltaTime * revolutionSpeed;
		float x = distance * Mathf.Cos(revolutionTime);
		float z = distance * Mathf.Sin(revolutionTime);
		transform.position = new Vector3(x, 0, z);

		// rotation(자전)
		rotationTime += Time.deltaTime * rotationSpeed;
		transform.rotation = Quaternion.Euler(0, rotationTime, 0);
	}
}

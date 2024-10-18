using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float moveSpeed = 1;
	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
	}
}

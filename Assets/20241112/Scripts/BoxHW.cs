using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHW : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		print($"{gameObject.name}��(��) {collision.collider.name}��(��) �ε���");
	}
}

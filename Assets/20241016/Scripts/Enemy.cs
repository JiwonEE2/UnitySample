using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		// ������ ����� ������ �ٽ� �帣��
		if (transform.position.y < -10f)
		{
			transform.position = new Vector3(transform.position.x, 10f);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		// 범위를 벗어나면 위에서 다시 흐르게
		if (transform.position.y < -10f)
		{
			transform.position = new Vector3(transform.position.x, 10f);
		}
	}
}

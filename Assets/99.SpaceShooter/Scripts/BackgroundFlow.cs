using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
	public class BackgroundFlow : MonoBehaviour
	{
		public float flowSpeed;
		// Update is called once per frame
		void Update()
		{
			// transform : �� ������Ʈ�� ������ ������Ʈ�� Transform ������Ʈ
			// Transform.Translate : ���� Position���� �Ķ������ Vector�� ��ŭ Position�� �̵�
			// Vector3.down : new Vector3(0, -1. 0)
			transform.Translate(Vector3.down * Time.deltaTime * flowSpeed);
			if (transform.position.y < -2.55f)
			{
				transform.position = Vector3.zero;
			}
		}
	}
}
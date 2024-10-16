using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
	public class Player : MonoBehaviour
	{
		public float moveSpeed;
		public float boundaryMinSize = -3.5f;
		public float boundaryMaxSize = 3.5f;
		// Update is called once per frame

		public GameObject gameOverMessage;

		private void Update()
		{
			// Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����
			// Input.GetAxis() : �̸� ���ǵǾ� �ִ� �Է� ���� ���� ������
			// ex) Horizontal : X��, Vertical : Y��

			float x = Input.GetAxis("Horizontal");
			transform.Translate(new Vector3(x, 0) * Time.deltaTime * moveSpeed);

			if (transform.position.x < boundaryMinSize)
			{
				transform.position = new Vector3(boundaryMinSize, transform.position.y);
			}
			else if (transform.position.x > boundaryMaxSize)
			{
				transform.position = new Vector3(boundaryMaxSize, transform.position.y);
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Enemy"))
			{
				//print("���� ����");
				GameOver();
			}
		}

		public void GameOver()
		{
			gameOverMessage.SetActive(true);
			Time.timeScale = 0f;
		}
	}
}
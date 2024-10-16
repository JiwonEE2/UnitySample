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
			// Input : InputManager의 기능을 활용하여 입력 처리를 할 수 있는 클래스
			// Input.GetAxis() : 미리 정의되어 있는 입력 축의 값을 가져옴
			// ex) Horizontal : X축, Vertical : Y축

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
				//print("게임 오버");
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
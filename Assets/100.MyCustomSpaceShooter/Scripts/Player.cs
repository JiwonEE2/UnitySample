using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveSpeed;
	public float boundaryMinSizeX = -3.5f;
	public float boundaryMaxSizeX = 3.5f;
	// y 추가
	public float boundaryMinSizeY = -10f;
	public float boundaryMaxSizeY = 10f;

	// Update is called once per frame

	public GameObject gameOverMessage;

	private void Update()
	{
		// Input : InputManager의 기능을 활용하여 입력 처리를 할 수 있는 클래스
		// Input.GetAxis() : 미리 정의되어 있는 입력 축의 값을 가져옴
		// ex) Horizontal : X축, Vertical : Y축

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		transform.Translate(new Vector3(x, y) * Time.deltaTime * moveSpeed);

		if (transform.position.x < boundaryMinSizeX)
		{
			transform.position = new Vector3(boundaryMinSizeX, transform.position.y);
		}
		else if (transform.position.x > boundaryMaxSizeX)
		{
			transform.position = new Vector3(boundaryMaxSizeX, transform.position.y);
		}
		if (transform.position.y < boundaryMinSizeY)
		{
			transform.position = new Vector3(transform.position.x, boundaryMinSizeY);
		}
		else if (transform.position.y > boundaryMaxSizeY)
		{
			transform.position = new Vector3(transform.position.x, boundaryMaxSizeY);
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
		//bool isFinded = gameOverMessage.TryGetComponent<Text>(out Text t);
		//if (isFinded)
		//{
		//	print($"찾음");

		//	// 스코어 출력 기능 넣어보고 싶은데 안되네..
		//	//t = gameOverMessage.GetComponent<TextMeshProUGUI>();
		//	//t.text = $"Game Over\nScore : {Time.time}";
		//}

		gameOverMessage.SetActive(true);
		Time.timeScale = 0f;
	}
}

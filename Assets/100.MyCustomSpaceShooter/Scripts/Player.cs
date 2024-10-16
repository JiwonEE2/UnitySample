using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveSpeed;
	public float boundaryMinSizeX = -3.5f;
	public float boundaryMaxSizeX = 3.5f;
	// y �߰�
	public float boundaryMinSizeY = -10f;
	public float boundaryMaxSizeY = 10f;

	// Update is called once per frame

	public GameObject gameOverMessage;

	private void Update()
	{
		// Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����
		// Input.GetAxis() : �̸� ���ǵǾ� �ִ� �Է� ���� ���� ������
		// ex) Horizontal : X��, Vertical : Y��

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
			//print("���� ����");
			GameOver();
		}
	}

	public void GameOver()
	{
		//bool isFinded = gameOverMessage.TryGetComponent<Text>(out Text t);
		//if (isFinded)
		//{
		//	print($"ã��");

		//	// ���ھ� ��� ��� �־�� ������ �ȵǳ�..
		//	//t = gameOverMessage.GetComponent<TextMeshProUGUI>();
		//	//t.text = $"Game Over\nScore : {Time.time}";
		//}

		gameOverMessage.SetActive(true);
		Time.timeScale = 0f;
	}
}

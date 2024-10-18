using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveSpeed;
	public GameObject gameOverMessage;
	private Rigidbody2D rb;
	public float bulletCycle = 1;
	public GameObject bullet;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(BulletShot(bulletCycle));
	}

	private void Update()
	{
		// Input : InputManager의 기능을 활용하여 입력 처리를 할 수 있는 클래스
		// Input.GetAxis() : 미리 정의되어 있는 입력 축의 값을 가져옴
		// ex) Horizontal : X축, Vertical : Y축

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		//transform.Translate(new Vector3(x, y) * Time.deltaTime * moveSpeed);
		rb.MovePosition(rb.position + (new Vector2(x, y) * Time.deltaTime * moveSpeed));
	}

	private IEnumerator BulletShot(float interval)
	{
		while (true)
		{
			yield return new WaitForSeconds(interval);
			// bullet 생성
			GameObject bull = Instantiate(bullet, transform.position, Quaternion.identity);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Enemy"))
		{
			//print("게임 오버");
			//GameOver();
			// 플레이어가 밀려나야함
			rb.AddForce(Vector2.down * 10f, ForceMode2D.Force);
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

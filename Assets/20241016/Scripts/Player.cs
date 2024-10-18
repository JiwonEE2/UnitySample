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
		// Input : InputManager�� ����� Ȱ���Ͽ� �Է� ó���� �� �� �ִ� Ŭ����
		// Input.GetAxis() : �̸� ���ǵǾ� �ִ� �Է� ���� ���� ������
		// ex) Horizontal : X��, Vertical : Y��

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
			// bullet ����
			GameObject bull = Instantiate(bullet, transform.position, Quaternion.identity);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Enemy"))
		{
			//print("���� ����");
			//GameOver();
			// �÷��̾ �з�������
			rb.AddForce(Vector2.down * 10f, ForceMode2D.Force);
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

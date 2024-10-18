using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
	// 이 스크립트가 달려 있는 물체를 움직이고 싶을 때
	public float moveSpeed;
	private Rigidbody rb;
	public float jumpPower;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		// 물리 연산이 일어나는 시점에서 Update 에서 이동한 위치와 간섭이 일어나면 다음 프레임의 값이 Rigidbody에 의해 변함
		//transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * moveSpeed);
		rb.MovePosition(rb.position + (new Vector3(x, 0, z) * Time.deltaTime * moveSpeed));
		if (Input.GetButtonDown("Jump"))
		{
			//transform.Translate(Vector3.up);
			//rb.velocity = Vector3.up * jumpPower;
			rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);

			// 힘을 가할 때 AddForce 함수를 사용
			// [ ForceMode ]
			//								중량 적용				중량 무시
			// 가속도 추가			.Force				.Acceleration
			// 운동량 추가			.Impulse			.VelocityChange

			//rb.AddTorque();					// 회전
			//rb.angularVelocity			// 회전 운동량
			//rb.maxAngularVelocity		// 최대 회전 운동량을 제한
			//rb.maxLinearVelocity		// 최대 직선 운동량을 제한
			//rb.drag									// (공기)저항
			//rb.angularDrag					// 회전 저항
		}
		// Physics.Raycast
		if (Input.GetButtonDown("Fire1"))
		{
			// 전방 (+z방향)에 있는 콜라이더를 감지해서 만약 Enemy이면 Enemy 태그를 없애고 싶음
			Ray ray = new Ray(transform.position, Vector3.forward);
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 0.2f);
			if (Physics.Raycast(ray, out RaycastHit hit, 10, 1 << LayerMask.NameToLayer("Default")))
			{
				print($"콜라이더 감지됨 : {hit.collider.name}");
				if (hit.collider.CompareTag("Enemy"))
				{
					Destroy(hit.collider.gameObject);
				}
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Enemy"))
		{
			// Enemy 태그를 가진 오브젝트와 충돌하면 -z 방향으로 튕겨나가고 싶다
			rb.AddForce(Vector3.back * 10f, ForceMode.Impulse);
		}
	}

	private void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		// 점프
		//InputManager를 통한 입력 제어를 하려고 할 경우
		// 모든 입력 처리는 Update에서 이루어지기 때문에 FixedUpdate에서는 정확한 시점을 알기 어려움
		//if (Input.GetButtonDown("Jump"))
		//{
		//	//transform.Translate(Vector3.up);
		//	rb.velocity = Vector3.up * jumpPower;
		//}
		//transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * moveSpeed);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformContolTest : MonoBehaviour
{
	public Transform target;

	// 기본적으로 Transform의 position, rotation, localScale 프로퍼티를 통해 해당 오브젝트의 위치, 각도, 크기 등을 제어 가능
	private void Start()
	{
		//ControlStraightly();
		//ControlByDirection();
		ControlByMethod();
	}

	// 값을 직접 대입하여 Transform을 제어
	private void ControlStraightly()
	{
		transform.position = new Vector3(3, 2, 1);
		//transform.rotation = new Quaternion(0.3f, 0.02f, 0.001f, 0);
		transform.rotation = Quaternion.Euler(30, 20, 10);
		print(transform.rotation);
		transform.localScale = new Vector3(4, 5, 6);
	}

	// 방향(좌우상하전후)에 방향벡터를 대입하여 Rotation 제어
	private void ControlByDirection()
	{
		Vector3 lookDir = target.position - transform.position;
		// 내 위치에서 Target 위치로 이동하기 위해 향해야 하는 방향 벡터를 구함

		//transform.up = target.position - transform.position;		// 해당 방향이 나의 up이 됨

		// 해당 방향이 나의 right가 되려면?
		//transform.right = lookDir;
		// 해당 방향이 나의 forward가 되려면?
		//transform.forward = lookDir;

		// 해당 방향이 나의 down이 되려면?
		//transform.up = -lookDir;
		// 해당 방향이 나의 left가 되려면?
		//transform.right = -lookDir;
		// 해당 방향이 나의 backward가 되려면?
		//transform.forward = -lookDir;
	}

	// Transform의 제어 함수를 호출
	private void ControlByMethod()
	{
		// Translate : Position을 제어하는 함수
		transform.Translate(5, 0, 0);
		// Rotate : Rotation을 제어하는 함수
		transform.Rotate(30, 0, 0);

		// Translate, Rotate 함수를 사용하여 제어하는 것은
		// transform.posion, rotation 에 값을 직접 할당하는 것과 달리 현재 psition, rotation 기준으로 상대적인 연산이 이루어진다.
	}

	private void Update()
	{
		//Vector3 lookDir = target.position - transform.position;
		//transform.up = lookDir;
		//transform.position = transform.position + new Vector3(3, 2, 1) * Time.deltaTime;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(30, 20, 10) * Time.deltaTime);

		transform.Translate(new Vector3(3, 2, 1) * Time.deltaTime);
		transform.Rotate(new Vector3(30, 20, 10) * Time.deltaTime);
	}
}

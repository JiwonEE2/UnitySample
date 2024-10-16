using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentFindTest : MonoBehaviour
{
	// 게임 오브젝트를 알고 있는 상태에서 해당 오브젝트가 가진 컴포넌트를 찾으려할 경우
	public GameObject target;

	private FindMe findMe;
	private void Start()
	{
		// target 오브젝트에서 FindMe 컴포넌트를 찾으려할 때
		findMe = target.GetComponent<FindMe>();
		print(findMe.message);

		bool isFinded = target.TryGetComponent<BoxCollider>(out BoxCollider boxCollider);

		if (isFinded)
		{
			print($"Box Collider를 찾았습니다. {boxCollider}");
		}
		else
		{
			print($"Box Collider를 찾지 못했습니다. {boxCollider}");
		}

		FindMe[] children = target.GetComponentsInChildren<FindMe>();
		foreach(FindMe child in children)
		{
			print(child.message);
		}

		FindMe newFindMe = target.AddComponent<FindMe>();
		newFindMe.message = "다시 나를 찾으셨군요";

		// Destroy 함수를 통해 게임 오브젝트가 아닌 컴포넌트 만을 삭제할 수도 있다
		Destroy(findMe.gameObject, 2f);
	}
}

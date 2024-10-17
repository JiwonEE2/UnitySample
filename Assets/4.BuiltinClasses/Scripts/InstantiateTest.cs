using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTest : MonoBehaviour
{
	public GameObject original;

	// Start is called before the first frame update
	void Start()
	{
		// original 객체와 똑같이 생긴 오브젝트를 하나 더 만들어 옆에 배치하고 싶은데
		//GameObject clone = new GameObject("Clone");
		//MeshFilter mf = clone.AddComponent<MeshFilter>();
		//MeshRenderer mr = clone.AddComponent<MeshRenderer>();
		//mf.mesh = original.GetComponent<MeshFilter>().mesh;
		//mr.material = original.GetComponent<MeshRenderer>().material;
		//clone.transform.position = original.transform.position + Vector3.right;

		//Instantiate : 파라미터 객체를 똑같이 복제하는 함수
		//Instantiate(original).transform.position = original.transform.position + Vector3.right;
		//복사와 동시에 Hierachy 상에서 특정 객체의 자식이 되어야 할 경우
		//Instantiate(original, transform);
		// 복사와 동시에 특정 위치에 특정 각도값으로 생성되어야 할 경우
		//Instantiate(original, Vector3.right, Quaternion.identity);

		//Instantiate 함수는 파라미터를 통해 복제된 객체를 Return
		GameObject clone = Instantiate(original, Vector3.right, Quaternion.identity);
		clone.name = "this is clone";
		//clone.GetComponent<MeshRenderer>().material.color = Color.gray;
	}
}

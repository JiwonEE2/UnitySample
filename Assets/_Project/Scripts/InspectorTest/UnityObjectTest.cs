using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityObjectTest : MonoBehaviour
{
	public GameObject testObject;

	public Transform cubeTransform;

	public MeshRenderer cubeMeshRenderer;

	public MeshFilter cubeMeshFilter;

	public BoxCollider cubeBoxCollider1;

	public BoxCollider cubeBoxCollider2;

	public object systemObject;   // C#의 object : 모든 클래스의 Parent

	public Object unityObject;		// Unity엔진에서 활용하는 모든 object

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log($"Test Object value : {testObject}");

		Debug.Log($"collider1.center.z : {cubeBoxCollider1.center.z}");
		Debug.Log($"collider2.center.z : {cubeBoxCollider2.center.z}");
	}

	// Update is called once per frame
	void Update()
	{

	}
}

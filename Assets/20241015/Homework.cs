using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyObject
{
	public Color tColor;
	public Renderer tRenderer;
	public MeshFilter tMeshFilter;

	public Vector3 tPosition;
	public Mesh tMesh;
	public Transform tTransform;

	public Vector3 tRotation;
}

public class Homework : MonoBehaviour
{
	public List<MyObject> myObjects;
	// Start is called before the first frame update
	void Start()
	{
		foreach(MyObject obj in myObjects)
		{
			obj.tRenderer.material.color = obj.tColor;
			obj.tMeshFilter.mesh = obj.tMesh;
			obj.tTransform.position = obj.tPosition;
			obj.tTransform.rotation = Quaternion.Euler(obj.tRotation);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShapeData
{
	public enum Shape
	{
		Cube,
		Capsule,
		Sphere
	}
	public Shape shape;
	public float scale;
	public Color color;
}

public class PhysicsRaycasterTest : MonoBehaviour
{
	public ShapeData shapeData;
	private void Start()
	{
		GetComponent<Renderer>().material.color = shapeData.color;
		transform.localScale = Vector3.one * shapeData.scale;
	}
}

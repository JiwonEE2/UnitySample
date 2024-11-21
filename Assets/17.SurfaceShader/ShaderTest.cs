using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ShaderTest : MonoBehaviour
{
	private new Renderer renderer;

	//[Range(0, 1)]
	public float ColorMultiplier { get; set; }
	// Getter/Setter 메소드

	// 시간에 따라 변화하도록
	public float timeSpeed;

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		float timeSine = Mathf.Sin(Time.time * timeSpeed * Mathf.Deg2Rad);
		timeSine = Mathf.Abs(timeSine);
		renderer.material.SetFloat("_ColorMultiple", ColorMultiplier);
	}

	//public void OnValueChange(float value)
	//{
	//	colorMultiplier = value;
	//}
}

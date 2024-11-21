using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ShaderTest : MonoBehaviour
{
	private new Renderer renderer;

	//[Range(0, 1)]
	public float ColorMultiplier { get; set; }
	// Getter/Setter ¸Þ¼Òµå

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		renderer.material.SetFloat("_ColorMultiple", ColorMultiplier);
	}

	//public void OnValueChange(float value)
	//{
	//	colorMultiplier = value;
	//}
}

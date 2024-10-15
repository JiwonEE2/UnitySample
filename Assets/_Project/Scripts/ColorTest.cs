using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
	public Color targetColor;
	public Renderer targetRenderer;		// meshrenderer는 renderer 상속 뭐 나머지 렌더러 마찬가지

	// Start is called before the first frame update
	void Start()
	{
		targetRenderer.material.color = targetColor;
	}

	// Update is called once per frame
	void Update()
	{

	}
}

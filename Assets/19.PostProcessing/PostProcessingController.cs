using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
	public PostProcessVolume volume;
	public float grainSize;
	private Grain grainEffect;

	private void Start()
	{
		grainEffect = volume.profile.GetSetting<Grain>();
	}

	private void Update()
	{
		grainEffect.size.Override(grainSize);
	}
}

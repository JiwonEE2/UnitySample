using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
	public LayerMask targetLayer;
	private Renderer childRenderer;
	private Sequence jumpSequence;

	private void Awake()
	{
		childRenderer = GetComponentInChildren<Renderer>();
		transform.GetChild(0).DOLocalJump(Vector3.zero, 10f, 2, 0.5f)
			.OnStart(() => childRenderer.enabled = true)
			.OnComplete(() => childRenderer.enabled = false);

	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit, targetLayer))
			{
				transform.position = hit.point;
				childRenderer.enabled = true;
				jumpSequence.Play();
			}
		}
	}
}

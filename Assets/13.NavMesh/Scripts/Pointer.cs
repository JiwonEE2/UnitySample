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
	private Tweener jumpTween;

	private void Awake()
	{
		childRenderer = GetComponentInChildren<Renderer>();
	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit, targetLayer))
			{
				transform.position = hit.point;
				if (jumpTween != null)
				{
					jumpTween.Complete();
				}
				childRenderer.enabled = true;
				jumpTween = transform.GetChild(0)
					.DOPunchPosition(Vector3.up * 2f, 0.5f)
					.OnComplete(() => childRenderer.enabled = false).SetEase(Ease.InOutBack);
			}
		}
	}
}

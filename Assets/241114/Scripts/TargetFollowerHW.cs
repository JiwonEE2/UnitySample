using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowerHW : MonoBehaviour
{
	public Transform target;
	public bool followPosition;
	public bool followRotation;

	private void Update()
	{
		if (target == null) return;
		if (followPosition) transform.position = target.position;
		if (followRotation) transform.rotation = target.rotation;
	}
}

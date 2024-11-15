using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator), typeof(RigBuilder))]
public class InputSystemAction : MonoBehaviour
{
	Animator animator;
	Rig rig;
	WaitUntil untilReload;
	WaitForSeconds waitSec;
	bool isReloading;
	public AnimationClip reloadClip;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		rig = GetComponent<RigBuilder>().layers[0].rig;
	}

	private IEnumerator Start()
	{
		untilReload = new WaitUntil(() => isReloading);
		waitSec = new WaitForSeconds(reloadClip.length);
		// 이렇게 사용하면 메모리를 적게 사용하지만, 실시간으로 조정될 경우에는 불가능
		while (true)
		{
			yield return untilReload;
			//yield return new WaitForSeconds(reloadClip.length);
			yield return waitSec;
			isReloading = false;
			rig.weight = 1f;
		}
	}

	private void OnReload(InputValue value)
	{
		print($"OnReload 호출. isPressed : {value.isPressed}{value.Get<Single>()}");
		if (isReloading) return;
		rig.weight = 0f;
		isReloading = true;
		animator.SetTrigger("Reload");
	}
}

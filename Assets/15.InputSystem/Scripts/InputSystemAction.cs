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
		while (true)
		{
			yield return untilReload;
			yield return new WaitForSeconds(reloadClip.length);
			isReloading = false;
			rig.weight = 1f;
		}
	}

	private void OnReload(InputValue value)
	{
		//rig.weight = 0f;
		//isReloading = true;
		//animator.SetTrigger("Reload");
	}
}

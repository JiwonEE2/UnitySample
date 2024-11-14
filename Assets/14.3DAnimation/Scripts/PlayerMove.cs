using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
	private CharacterController charCtrl;
	public Animator animator;
	private void Awake()
	{
		charCtrl = GetComponent<CharacterController>();
	}
}

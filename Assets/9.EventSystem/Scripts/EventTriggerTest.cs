using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour
{
	public void OnClick()
	{
		print("click!");
	}

	public void OnEnter()
	{
		print("enter!");
	}

	public void OnExit()
	{
		print("exit!");
	}
}

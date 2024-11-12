using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventSystemTestManager : MonoBehaviour
{
	public static EventSystemTestManager instance;
	public TextMeshProUGUI text;
	private void Awake()
	{
		instance = this;
	}
}

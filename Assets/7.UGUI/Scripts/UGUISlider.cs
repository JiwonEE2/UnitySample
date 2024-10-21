using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUISlider : MonoBehaviour
{
	public void OnValueChange(float value)
	{
		print($"슬라이더 값 바뀜 : {value}");
	}
}

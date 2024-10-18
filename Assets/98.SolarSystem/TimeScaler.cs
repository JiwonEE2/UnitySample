using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
	[Range(0, 100)]
	public float timeScale;
	// Update is called once per frame
	void Update()
	{
		// TimeScale : 게임의 진행 속도를 0~100 배속 사이의 속도로 조절
		Time.timeScale = timeScale;
	}
}

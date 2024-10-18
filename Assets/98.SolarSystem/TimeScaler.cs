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
		// TimeScale : ������ ���� �ӵ��� 0~100 ��� ������ �ӵ��� ����
		Time.timeScale = timeScale;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseControl : MonoBehaviour
{
	private void Start()
	{
		// ���콺 Ŀ�� ȭ�鿡 ���
		// Locked : ȭ�� �߾ӿ� ���
		// Confined : ȭ�� �׵θ� �ȿ� ����
		// None : �����
		Cursor.lockState = CursorLockMode.Locked;
		// Ŀ�� ���̴� ����. Editor�� ��쿡 ���� �������� �ʾƵ� ESC Ű�� ������ ���콺�� ����
		Cursor.visible = false;
	}
}

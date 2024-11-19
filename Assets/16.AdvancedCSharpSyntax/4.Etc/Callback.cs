using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Լ��� ȣ���ϰ� �� ��� � �ٸ� �Լ��� ȣ��Ǿ�� �� ��, �װ� �ݹ��Լ���� �θ�
public class Callback : MonoBehaviour
{
	// ������ Ư�� �Լ� ���� �Ŀ� �ٸ� �Լ��� ȣ��Ǳ� ���� ��, �� �Լ���
	// C# ver: �븮�� ���·� �ѱ�
	// javascript ver : �Լ� �����ͷ� �ѱ�

	public GameObject destroyTarget;
	public CallbackTestPopup popup;

	public Action callback;

	public void OnDestroyButtonClick()
	{
		//popup.ShowPopup((yes) =>
		//{
		//	if (yes)
		//	{
		//		Destroy(destroyTarget);
		//	}
		//	else
		//	{
		//		print("�ı� �ȵ�");
		//	}
		//});

		popup.ShowPopup(OnYes);
	}

	// �̷��� �ϰų� ���� ���ٽ����� �ϰų�
	public void OnYes(bool yes)
	{
		if (yes)
		{
			Destroy(destroyTarget);
		}
		else
		{
			print("�ı� �ȵ�");
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 함수를 호출하고 난 결과 어떤 다른 함수가 호출되어야 할 때, 그걸 콜백함수라고 부름
public class Callback : MonoBehaviour
{
	// 보통은 특정 함수 수행 후에 다른 함수가 호출되길 원할 때, 그 함수를
	// C# ver: 대리자 형태로 넘김
	// javascript ver : 함수 포인터로 넘김

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
		//		print("파괴 안됨");
		//	}
		//});

		popup.ShowPopup(OnYes);
	}

	// 이렇게 하거나 위의 람다식으로 하거나
	public void OnYes(bool yes)
	{
		if (yes)
		{
			Destroy(destroyTarget);
		}
		else
		{
			print("파괴 안됨");
		}
	}
}

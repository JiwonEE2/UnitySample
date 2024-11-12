using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
	// LayerMask는 비트 flag 사용
	// 00000000 : nothing
	// 00000001 : Default					1 << 0
	// 00000010 : TransparentFX		1 << 1
	// 00001000 : Ignore Physics	1 << 3
	// 00001001 : Default, Ignore Physics	9(8+1)
	public LayerMask customMask;

	private void Start()
	{
		print($"Default Layer : {LayerMask.NameToLayer("Default")}");
		print($"TransparentFX Layer : {LayerMask.NameToLayer("TransparentFX")}");
		print($"Ignore Physics Layer : {LayerMask.NameToLayer("Ignore Physics")}");
		print($"Custom Layer Mask : {customMask.value}");
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			// Camera.ScreenPointToRay : 해당 카메라 시점에서 스크린의 마우스 위치에서 카메라가 보는 방향으로 레이블 생성
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if (Physics.Raycast(ray, out RaycastHit hit))
			//{
			//	print(hit.collider.name);
			//}
			// Raycast 위가 기본이며 Layer도 지정할 수 있다.
			// 1000f : maxDistance
			// LayerMask <<...
			// Physics.Raycast 함수 호출 시, Layer Mask를 파라미터로 명시하지 않으면 자동으로 Ignore Raycast 레이어는 무시
			//if (Physics.Raycast(ray, out RaycastHit hit, 1000f, 1 << LayerMask.NameToLayer("Ignore Raycast")))
			//{
			//	print(hit.collider.name);
			//}
			if (Physics.Raycast(ray, out RaycastHit hit, 1000f, 1 << LayerMask.NameToLayer("Ignore Physics")))
			{
				hit.collider.GetComponentInParent<Renderer>().material.color = Color.red;
			}
		}
	}
}

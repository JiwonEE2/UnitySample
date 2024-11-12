using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
	// LayerMask�� ��Ʈ flag ���
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
			// Camera.ScreenPointToRay : �ش� ī�޶� �������� ��ũ���� ���콺 ��ġ���� ī�޶� ���� �������� ���̺� ����
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if (Physics.Raycast(ray, out RaycastHit hit))
			//{
			//	print(hit.collider.name);
			//}
			// Raycast ���� �⺻�̸� Layer�� ������ �� �ִ�.
			// 1000f : maxDistance
			// LayerMask <<...
			// Physics.Raycast �Լ� ȣ�� ��, Layer Mask�� �Ķ���ͷ� ������� ������ �ڵ����� Ignore Raycast ���̾�� ����
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

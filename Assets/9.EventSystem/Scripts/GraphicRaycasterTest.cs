using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphicRaycasterTest : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	// drag start
	public void OnBeginDrag(PointerEventData eventData)
	{
		EventSystemTestManager.instance.text.text = name;
	}

	// draging..
	public void OnDrag(PointerEventData eventData)
	{
		// eventData.delta : ���� �����Ӱ� ���� �������� ������ ��ġ ����(�̵���)
		GetComponent<RectTransform>().anchoredPosition += eventData.delta;
	}

	// drag end
	public void OnEndDrag(PointerEventData eventData)
	{
		EventSystemTestManager.instance.text.text = "Nothing";
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		print("Mouse over");
	}
}

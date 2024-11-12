using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventSystemTestManager : MonoBehaviour
{
	public static EventSystemTestManager instance;
	public TextMeshProUGUI text;
	public Tooltip tooltip;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		HideTooltip();
	}

	public void ShowTooltip(ShapeData data)
	{
		tooltip.SetData(data);
		tooltip.gameObject.SetActive(true);
	}

	public void HideTooltip()
	{
		tooltip.gameObject.SetActive(false);
	}
}

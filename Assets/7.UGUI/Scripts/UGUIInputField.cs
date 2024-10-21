using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UGUIInputField : MonoBehaviour
{
	private TextMeshProUGUI text;
	private TMP_InputField inputField;

	private void Awake()
	{
		text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
		inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
	}
	public void InputFieldOnEndEdit(string value)
	{
		text.text = value;
	}
}

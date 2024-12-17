using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogIn : MonoBehaviour
{
	public TMP_InputField email;
	public TMP_InputField passwd;
	public Button logInButton;
	public Button signUpButton;

	private void Awake()
	{
		logInButton.onClick.AddListener(LogInButtonClick);
		signUpButton.onClick.AddListener(SignUpButtonClick);
	}

	private void OnEnable()
	{
		logInButton.interactable = true;
	}

	private void LogInButtonClick()
	{
		DatabaseManager.Instance.LogIn(email.text, passwd.text);
		logInButton.interactable = false;
	}

	private void SignUpButtonClick()
	{
		UIManager.Instance.PageOpen("SignUp");
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISignUp : MonoBehaviour
{
	public TMP_InputField email;
	public TMP_InputField userName;
	public TMP_InputField passwd;
	public Button signUpButton;
	public Button logInButton;

	private void Awake()
	{
		signUpButton.onClick.AddListener(SignUpButtonClick);
		logInButton.onClick.AddListener(LogInButtonClick);
	}

	private void OnEnable()
	{
		signUpButton.interactable = true;
	}

	private void LogInButtonClick()
	{
		UIManager.Instance.PageOpen("LogIn");
	}

	private void SignUpButtonClick()
	{
		DatabaseManager.Instance.SignUp(email.text, userName.text, passwd.text);
		// 중복 클릭 방지
		signUpButton.interactable = false;
	}
}

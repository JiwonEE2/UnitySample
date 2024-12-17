using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	// 회원가입 페이지
	public UISignUp signUp;
	// 로그인 페이지
	public UILogIn logIn;
	// 사용자 정보 페이지
	public UIUserInfo userInfo;
	// 팝업(회원가입 완료)
	public UIPopup popup;

	private Dictionary<string, GameObject> pages = new Dictionary<string, GameObject>();

	// 현재 열려있는 페이지
	private GameObject currentPage;

	public static UIManager Instance;

	private void Awake()
	{
		Instance = this;
		pages.Add("SignUp", signUp.gameObject);
		pages.Add("LogIn", logIn.gameObject);
		pages.Add("UserInfo", userInfo.gameObject);
		pages.Add("Popup", popup.gameObject);
	}

	private void Start()
	{
		foreach (GameObject page in pages.Values)
		{
			page.SetActive(false);
		}
		PageOpen("LogIn");
	}

	public void PageOpen(string pageName)
	{
		if (pages.ContainsKey(pageName))
		{
			currentPage?.SetActive(false);
			currentPage = pages[pageName];
			currentPage.SetActive(true);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	// ȸ������ ������
	public UISignUp signUp;
	// �α��� ������
	public UILogIn logIn;
	// ����� ���� ������
	public UIUserInfo userInfo;
	// �˾�(ȸ������ �Ϸ�)
	public UIPopup popup;

	private Dictionary<string, GameObject> pages = new Dictionary<string, GameObject>();

	// ���� �����ִ� ������
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

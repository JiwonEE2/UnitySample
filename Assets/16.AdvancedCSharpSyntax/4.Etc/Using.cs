// using Ű����
// 1. �ܺ��� ���̺귯�� �� ���� ����� ���̺귯���� �߰�
// C / C++�� #include�� ����ϰ�, Java�� import�� �Ȱ���
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
// 2. �� �ؽ�Ʈ ���Ͽ����� ����� ���ؽ�Ʈ(Ŭ����, ����ü, �븮��, �������̽� ��)
// �̸��� ������ �� �ִ�.
using Rn = UnityEngine.Random;

public class Using : MonoBehaviour
{
	// ~ : C++�� �Ҹ��ڿ� ���� �Ҹ��� ��ü�� C#������ ���ǰ� �����ϳ�
	// �⺻������ IDisposable �������̽��� ���� Dispose()�� ȣ���ϵ��� ��
	private void Start()
	{
		// 3. IDisposable �������̽��� ������ ��ü�� Ư�� ��� �������� ������ �� �Ŀ�
		// ��� ������ �Ͻ������� �޸𸮸� �����ϵ��� �ϴ� ���
		using (HttpClient httpClient = new HttpClient())
		{
			// ~~~
		}

		// ��
		HttpClient client = new HttpClient();
		// ~~~
		client.Dispose();
	}
}

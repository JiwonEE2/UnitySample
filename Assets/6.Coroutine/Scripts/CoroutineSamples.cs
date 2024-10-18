using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSamples : MonoBehaviour
{
	private void Start()
	{
		//StartCoroutine(ReturnNull());
		//StartCoroutine(ReturnWaitForSeconds(1f, 5));
		//StartCoroutine(ReturnWaitForSecondsRealtime(1f, 5));
		//StartCoroutine(ReturnUntilWhile());
		//StartCoroutine(ReturnEndOfFrame());
		StartCoroutine(_1st());
	}

	//yield return null
	private IEnumerator ReturnNull()
	{
		print("Return Null �ڷ�ƾ ����");
		while (true)
		{
			yield return null;
			print($"Return Null �ڷ�ƾ ����. {Time.time}");
		}
	}

	// yield return new WaitForSeconds(param) : �ڷ�ƾ�� yield return Ű���带 ������ �Ķ���͸�ŭ ��� �� ����
	private IEnumerator ReturnWaitForSeconds(float interval, int count)
	{
		print("Return Wait For Seconds �ڷ�ƾ ����");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSeconds(interval);
			print($"Wait For Seconds {i + 1}�� ȣ���. {Time.time}");
		}
		print("Return Wait For Seconds �ڷ�ƾ ��");
	}

	// yield return new WaitForSecondsRealtime(param) : WaitForSeconds�� ������ ������ TimeScale�� ���� ���� �ʴ´�
	private IEnumerator ReturnWaitForSecondsRealtime(float interval, int count)
	{
		print("Return Wait For Seconds Realtime �ڷ�ƾ ����");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSecondsRealtime(interval);
			print($"Wait For Seconds Realtime {i + 1}�� ȣ���. {Time.time}");
		}
		print("Return Wait For Seconds Realtime �ڷ�ƾ ��");
	}

	public bool continueKey;
	private bool IsContinue()
	{
		return continueKey;
	}
	// yield return new WaitUntil / WaitWhile (param) : Ư�� ������ True/False�� �� ������ ���
	private IEnumerator ReturnUntilWhile()
	{
		print("Return Until While �ڷ�ƾ ����");
		while (true)
		{
			// new WaitUntil : �Ű������� �Ѿ �Լ�(�븮��)�� return�� false�� ���� ���, true�� �Ѿ
			yield return new WaitUntil(() => continueKey);
			print("continueKey : True");
			// new WaitWhile : �Ű������� �Ѿ �Լ�(�븮��)�� return�� true�� ���� ���, false�� �Ѿ
			yield return new WaitWhile(IsContinue);
			print("continueKey : False");
		}
	}
	// yield return new (Frame �迭) : �� ������ Ư�� ������ �ڿ� �����
	private IEnumerator ReturnEndOfFrame()
	{
		// EndOfFrame : �ش� �������� ���� ���������� ��ٸ�
		yield return new WaitForEndOfFrame();
		print("End of Frame");
		isFirstFrame = false;
	}

	private IEnumerator ReturnFixedUpdate()
	{
		// FixedUpdate : ���� ������ ���� ������ ��ٸ�
		yield return new WaitForFixedUpdate();
	}

	bool isFirstFrame = false;

	private void Update()
	{
		if (isFirstFrame)
		{
			print("Update �޽��� �Լ� ȣ��");
		}
	}

	private void LateUpdate()
	{
		if (isFirstFrame)
		{
			print("LateUpdate �޽��� �Լ� ȣ��");
		}
	}

	// yield return �ڷ�ƾ : �ش� �ڷ�ƾ�� ���� ������ ���
	private IEnumerator _1st()
	{
		print("1��° �ڷ�ƾ ����");
		for (int i = 0; i < 3; i++)
		{
			print($"1��° �ڷ�ƾ {i + 1}��° ����");
			yield return new WaitForSeconds(1f);
		}
		print("1��° �ڷ�ƾ�� 2��° �ڷ�ƾ�� �����ϰ� ���");
		yield return StartCoroutine(_2nd());
		print("1��° �ڷ�ƾ ��");
	}

	Coroutine _3rdCoroutine;

	private IEnumerator _2nd()
	{
		print("2��° �ڷ�ƾ ����");
		print("2��° �ڷ�ƾ�� 3��° �ڷ�ƾ�� �����ϰ� ���");
		_3rdCoroutine = StartCoroutine(_3rd());
		yield return _3rdCoroutine;
		for (int i = 0; i < 5; i++)
		{
			print($"2��° �ڷ�ƾ {i + 1}��° ����");
			yield return new WaitForSeconds(1f);
		}
		print("2��° �ڷ�ƾ ��");

	}

	private IEnumerator _3rd()
	{
		print("3��° �ڷ�ƾ ����");
		for (int i = 0; i < 5; i++)
		{
			yield return new WaitForSeconds(1f);
			print($"3��° �ڷ�ƾ {i}��° ����");
		}
		print("3��° �ڷ�ƾ ��");
	}
}

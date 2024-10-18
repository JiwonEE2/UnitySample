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
		print("Return Null 코루틴 시작");
		while (true)
		{
			yield return null;
			print($"Return Null 코루틴 수행. {Time.time}");
		}
	}

	// yield return new WaitForSeconds(param) : 코루틴이 yield return 키워드를 만나면 파라미터만큼 대기 후 수행
	private IEnumerator ReturnWaitForSeconds(float interval, int count)
	{
		print("Return Wait For Seconds 코루틴 시작");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSeconds(interval);
			print($"Wait For Seconds {i + 1}번 호출됨. {Time.time}");
		}
		print("Return Wait For Seconds 코루틴 끝");
	}

	// yield return new WaitForSecondsRealtime(param) : WaitForSeconds와 동작은 같으나 TimeScale에 영향 받지 않는다
	private IEnumerator ReturnWaitForSecondsRealtime(float interval, int count)
	{
		print("Return Wait For Seconds Realtime 코루틴 시작");
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSecondsRealtime(interval);
			print($"Wait For Seconds Realtime {i + 1}번 호출됨. {Time.time}");
		}
		print("Return Wait For Seconds Realtime 코루틴 끝");
	}

	public bool continueKey;
	private bool IsContinue()
	{
		return continueKey;
	}
	// yield return new WaitUntil / WaitWhile (param) : 특정 조건이 True/False가 될 때까지 대기
	private IEnumerator ReturnUntilWhile()
	{
		print("Return Until While 코루틴 시작");
		while (true)
		{
			// new WaitUntil : 매개변수로 넘어간 함수(대리자)의 return이 false인 동안 대기, true면 넘어감
			yield return new WaitUntil(() => continueKey);
			print("continueKey : True");
			// new WaitWhile : 매개변수로 넘어간 함수(대리자)의 return이 true인 동안 대기, false면 넘어감
			yield return new WaitWhile(IsContinue);
			print("continueKey : False");
		}
	}
	// yield return new (Frame 계열) : 인 게임의 특정 프레임 뒤에 수행됨
	private IEnumerator ReturnEndOfFrame()
	{
		// EndOfFrame : 해당 프레임의 가장 마지막까지 기다림
		yield return new WaitForEndOfFrame();
		print("End of Frame");
		isFirstFrame = false;
	}

	private IEnumerator ReturnFixedUpdate()
	{
		// FixedUpdate : 물리 연산이 끝날 때까지 기다림
		yield return new WaitForFixedUpdate();
	}

	bool isFirstFrame = false;

	private void Update()
	{
		if (isFirstFrame)
		{
			print("Update 메시지 함수 호출");
		}
	}

	private void LateUpdate()
	{
		if (isFirstFrame)
		{
			print("LateUpdate 메시지 함수 호출");
		}
	}

	// yield return 코루틴 : 해당 코루틴이 끝날 때까지 대기
	private IEnumerator _1st()
	{
		print("1번째 코루틴 시작");
		for (int i = 0; i < 3; i++)
		{
			print($"1번째 코루틴 {i + 1}번째 수행");
			yield return new WaitForSeconds(1f);
		}
		print("1번째 코루틴이 2번째 코루틴을 시작하고 대기");
		yield return StartCoroutine(_2nd());
		print("1번째 코루틴 끝");
	}

	Coroutine _3rdCoroutine;

	private IEnumerator _2nd()
	{
		print("2번째 코루틴 시작");
		print("2번째 코루틴이 3번째 코루틴을 시작하고 대기");
		_3rdCoroutine = StartCoroutine(_3rd());
		yield return _3rdCoroutine;
		for (int i = 0; i < 5; i++)
		{
			print($"2번째 코루틴 {i + 1}번째 수행");
			yield return new WaitForSeconds(1f);
		}
		print("2번째 코루틴 끝");

	}

	private IEnumerator _3rd()
	{
		print("3번째 코루틴 시작");
		for (int i = 0; i < 5; i++)
		{
			yield return new WaitForSeconds(1f);
			print($"3번째 코루틴 {i}번째 수행");
		}
		print("3번째 코루틴 끝");
	}
}

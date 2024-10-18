using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using Random = UnityEngine.Random;    // Random은 무조건 UnityEngine의 Random을 사용하겠습니다

public class BuiltinClassesTest : MonoBehaviour
{
	// 유니티 엔진에서 제공하는 라이브러리에 내장된 클래스를 활용
	// Debug : 디버깅에 사용되는 기능을 제공하는 클래스

	// Start is called before the first frame update
	void Start()
	{
		//Debug.Log($"Log{1}");
		//Debug.LogWarning("");
		//Debug.LogError("");
		//Debug.LogFormat("{0}, {1}", 3, 5.0);    // XXFormat으로 끝나는 함수들(printf) : 파라미터를 포맷에 따라 치환하는 문자열
		//Debug.DrawLine(Vector3.zero, new Vector3(0, 3), Color.yellow, 5f);

		//Mathf : UnityEngine에서 제공하는 다양한 수학 연산 함수가 포함된 클래스
		//Mathf.Abs : 절대값을 반환
		float a = -0.3f;
		a = Mathf.Abs(a);
		print(a);
		a = Mathf.Abs(+0.3f);
		print(a);

		//Mathf.Approximately : 근사값 비교. 실수의 근사값 비교. 정확히 같은 지를 검사할 수 없으므로
		print(1.1f + 0.1f == 1.2f);
		print(Mathf.Approximately(1.1f + 0.1f, 1.2f));

		//Mathf.Lerp(a, b, t) : 선형보간(Linear Interpolation)
		//a값과 b값 사이의 t의 비율만큼에 위치하는 값(0<t<1)
		print(Mathf.Lerp(-1f, 1f, 0.5f));
		//Lerp(선형보간함수)는 Color, Vector(2,3,4), Material 클래스에도 존재
		Mathf.InverseLerp(0, 0, 0);   // Lerp의 a,b 파라미터가 반대

		//Mathf.Ceil, Floor, Round : 올림, 내림, 반올림
		float ceil = Mathf.Ceil(5.5f);
		float floor = Mathf.Floor(5.5f);
		float round = Mathf.Round(5.5f);
		print($"5.5, Ceil : {ceil}, Floor : {floor}, Round : {round}");

		//Mathf.Sign();		// 부호
		//Mathf.Sin();		// 삼각함수 사인
		//Mathf.Pow();		// 거듭제곱

		//Random : 난수를 생성하는 클래스. 시스템에도 있기 때문에 위에 유니티엔진을 사용하겠다 선언 후 사용하면 모호함의 문제가 해결된다.
		int intRandom = Random.Range(-1, 1);                      // -1, 0

		// float를 반환하는 Range함수는 최대값과 간주되는 값이 반환될 수도 있다
		float floatRandom = Random.Range(-1f, 1f);                //-1.00.....1 ~ 0. 999...99 : 1이 올 수도 있다
		float randomValue = Random.value;                         // == Random.Range(0f, 1f); : 백분율을 얻기 편함
		Vector3 randomPosition = Random.insideUnitSphere * 5f;    //Vector3(-1~1, -1~1, -1~1); : 랜덤한 위치를 뽑고 싶을 때 효율적
		Vector3 randomDirection = Random.onUnitSphere;            // 랜덤한 Vector3가 오는 데, 길이가 항상 1. 랜덤한 "방향"을 뽑고 싶을 때 효율적
		Vector2 randomPosition2D = Random.insideUnitCircle;       // 2D용 Random Vector

		//Random.rotation;
		Random.InitState(12313);                                  // 난수의 시드값 초기화. 연산 부하가 많이 걸리는 함수. 제한적으로(씬 로딩 초기쯤에나) 사용할 것
	}

	// Gizmo : Scene 창에서만 볼 수 있는 "기즈모"를 그리는 클래스 (Debug.DrawXX의 확장기능과 비슷)
	private void Update()
	{
		Gizmos.DrawCube(Vector3.zero, Vector3.one);   // 의미없다
	}

	// Gizmo 클래스는 OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI 등 Scene 창과 에디터에서만 활성화되는 메시지 함수에서만 유효하게 기능
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(Vector3.zero, Mathf.PI);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(Vector3.one, 0.5f);
	}
}

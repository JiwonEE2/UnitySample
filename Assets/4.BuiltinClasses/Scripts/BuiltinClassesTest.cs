using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using Random = UnityEngine.Random;    // Random�� ������ UnityEngine�� Random�� ����ϰڽ��ϴ�

public class BuiltinClassesTest : MonoBehaviour
{
	// ����Ƽ �������� �����ϴ� ���̺귯���� ����� Ŭ������ Ȱ��
	// Debug : ����뿡 ���Ǵ� ����� �����ϴ� Ŭ����

	// Start is called before the first frame update
	void Start()
	{
		//Debug.Log($"Log{1}");
		//Debug.LogWarning("");
		//Debug.LogError("");
		//Debug.LogFormat("{0}, {1}", 3, 5.0);    // XXFormat���� ������ �Լ���(printf) : �Ķ���͸� ���˿� ���� ġȯ�ϴ� ���ڿ�
		//Debug.DrawLine(Vector3.zero, new Vector3(0, 3), Color.yellow, 5f);

		//Mathf : UnityEngine���� �����ϴ� �پ��� ���� ���� �Լ��� ���Ե� Ŭ����
		//Mathf.Abs : ���밪�� ��ȯ
		float a = -0.3f;
		a = Mathf.Abs(a);
		print(a);
		a = Mathf.Abs(+0.3f);
		print(a);

		//Mathf.Approximately : �ٻ簪 ��. �Ǽ��� �ٻ簪 ��. ��Ȯ�� ���� ���� �˻��� �� �����Ƿ�
		print(1.1f + 0.1f == 1.2f);
		print(Mathf.Approximately(1.1f + 0.1f, 1.2f));

		//Mathf.Lerp(a, b, t) : ��������(Linear Interpolation)
		//a���� b�� ������ t�� ������ŭ�� ��ġ�ϴ� ��(0<t<1)
		print(Mathf.Lerp(-1f, 1f, 0.5f));
		//Lerp(���������Լ�)�� Color, Vector(2,3,4), Material Ŭ�������� ����
		Mathf.InverseLerp(0, 0, 0);   // Lerp�� a,b �Ķ���Ͱ� �ݴ�

		//Mathf.Ceil, Floor, Round : �ø�, ����, �ݿø�
		float ceil = Mathf.Ceil(5.5f);
		float floor = Mathf.Floor(5.5f);
		float round = Mathf.Round(5.5f);
		print($"5.5, Ceil : {ceil}, Floor : {floor}, Round : {round}");

		//Mathf.Sign();		// ��ȣ
		//Mathf.Sin();		// �ﰢ�Լ� ����
		//Mathf.Pow();		// �ŵ�����

		//Random : ������ �����ϴ� Ŭ����. �ý��ۿ��� �ֱ� ������ ���� ����Ƽ������ ����ϰڴ� ���� �� ����ϸ� ��ȣ���� ������ �ذ�ȴ�.
		int intRandom = Random.Range(-1, 1);                      // -1, 0

		// float�� ��ȯ�ϴ� Range�Լ��� �ִ밪�� ���ֵǴ� ���� ��ȯ�� ���� �ִ�
		float floatRandom = Random.Range(-1f, 1f);                //-1.00.....1 ~ 0. 999...99 : 1�� �� ���� �ִ�
		float randomValue = Random.value;                         // == Random.Range(0f, 1f); : ������� ��� ����
		Vector3 randomPosition = Random.insideUnitSphere * 5f;    //Vector3(-1~1, -1~1, -1~1); : ������ ��ġ�� �̰� ���� �� ȿ����
		Vector3 randomDirection = Random.onUnitSphere;            // ������ Vector3�� ���� ��, ���̰� �׻� 1. ������ "����"�� �̰� ���� �� ȿ����
		Vector2 randomPosition2D = Random.insideUnitCircle;       // 2D�� Random Vector

		//Random.rotation;
		Random.InitState(12313);                                  // ������ �õ尪 �ʱ�ȭ. ���� ���ϰ� ���� �ɸ��� �Լ�. ����������(�� �ε� �ʱ��뿡��) ����� ��
	}

	// Gizmo : Scene â������ �� �� �ִ� "�����"�� �׸��� Ŭ���� (Debug.DrawXX�� Ȯ���ɰ� ���)
	private void Update()
	{
		Gizmos.DrawCube(Vector3.zero, Vector3.one);   // �ǹ̾���
	}

	// Gizmo Ŭ������ OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI �� Scene â�� �����Ϳ����� Ȱ��ȭ�Ǵ� �޽��� �Լ������� ��ȿ�ϰ� ���
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

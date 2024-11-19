using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAs : MonoBehaviour
{
	// is as : ���� Ÿ���� ĳ����(����ȯ)�� ������ ����
	class A
	{
		public static implicit operator GameObject(A a) => GameObject.Find("A");

		// ������ �����ε�
		public static object operator ==(A a, object b) { return true; }
		public static object operator !=(A a, object b) { return true; }
	}
	class B : A { }

	private void Start()
	{
		A a = new A();
		//B b = (B)a; // ��ӹ��� ������ ���� ���谡 ���� ĳ���� �Ұ�
		B b = a as B;
		// as : ()�� ����� ����� ĳ���ð� �޸� ĳ���� �Ұ����ϴ���
		// Exception�� ���� ����. ��� null ��ȯ
		// () �� ����� ����� ĳ���ú��� ȿ������ ����
		// ��� ����� ���� ����� �� �Ͻ��� ��ȯ �����ڸ� Ȱ�� �Ұ�

		//print(b.GetType());
		print(b?.GetType().ToString() ?? "b is null");

		// is : as�� ���� ĳ������ ��ü�� ����� ���� ���,
		// ĳ���� ������ �� ���θ� true/false�� ����
		print(a is A);
		print(b is B);

		print(b is null);
		// == �����ں��� ȿ����.
		// ��� ����� ���� �����ڸ� ������� ����(�����ε� �Ұ�)

		print(b == null);
	}
}

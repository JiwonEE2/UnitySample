using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFindTest : MonoBehaviour
{
	// ������ ���۵Ǳ� �� ������ ������ �� �ִ� ������Ʈ�� Inspector���� �Ҵ��Ͽ� ������ �� ����
	public GameObject target;
	// �׷��� ������ ���۵Ǳ� ���� ������ �� ���ų�, Inspector���� ���� �Ҵ��� �� ���� ��ü��?
	private GameObject privateTarget;
	private GameObject findedTarget;
	private GameObject newTarget;
	private GameObject namedNewTarget;
	private GameObject componentAttachedTarget;

	private void Start()
	{
		// privateTarget�� ã�´�
		// 1. ��ü ������ �̸����� Ÿ���� ã�´�
		privateTarget = GameObject.Find("PrivateTarget");
		print(privateTarget.name);
		// �� ����� ���� ������Ʈ�� �������� ���ϰ� ũ�� �ɸ�
		// ���� �̸��� ������Ʈ�� ���� �� ���� ��� � ������Ʈ�� Ž���� �� Ȯ���� �� ����

		// 2. ��ü ������ Ư�� ������Ʈ�� ������ �ִ� ��ü�� ã�´�.
		//findedTarget = (FindObjectOfType(typeof(FindMe)) as Component).gameObject;
		findedTarget = FindObjectOfType<FindMe>().gameObject;
		print(findedTarget.name);

		// 3. �ƿ� ��ü�� ���� �����ϰ� �ش� ��ü�� ������ �����ص� �ȴ�
		newTarget = new GameObject();
		namedNewTarget = new GameObject("New Target");
		componentAttachedTarget = new GameObject("Component Attached GameObject", typeof(FindMe), typeof(SpriteRenderer));

		// 4. Destroy �Լ��� ���� ��ü�� �ƿ� ���ֹ��� ���� �ִ�.
		Destroy(privateTarget, 2f);
	}
}

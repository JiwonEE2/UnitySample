using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultParameter : MonoBehaviour
{
	// �⺻ �Ű����� : �Ű������� ������ ���� �Ҵ����� �ʾƵ� �⺻������ Ư�� ���� ���޵ǵ��� �� �� �ִ�.
	// ��Ÿ���� �ƴ� ������Ÿ�ӿ��� �� �� �ִ� ���̾�� ��(���ͷ�)
	// [��ȯ��] �Լ��̸�(Ÿ�� �Ű������� = �⺻��) { }
	public Player newPlayer;

	private void Start()
	{
		GameObject a = CreateNewObject();
		//a.name = "New Obj";

		GameObject b = CreateNewObject("New Obj2");

		//newPlayer = CreatePlayer("������", obj: b);
		//newPlayer = CreatePlayer("���Ѱ�", 0, 1, 2, 3, 4);
		newPlayer = CreatePlayer("����", new int[] { 0, 1, 2, 3, 4 });
	}

	//private GameObject CreateNewObject()
	//{
	//	return new GameObject();
	//}

	private GameObject CreateNewObject(string name = "Some Obj")
	{
		GameObject returnObject = new GameObject();
		returnObject.name = name;
		return returnObject;
	}

	// ���丮 ����
	private Player CreatePlayer(string name, int level = 1, float damage = 5f, Vector2 position = default, GameObject obj = null)
	{
		// Vector2.zero�� ����� �ƴ�. const�� �پ��ִ� �͸� ����. ������Ÿ�ӿ��� Ȯ���� ������ �͵鸸
		// reference Ÿ���� default�� null�� ����.
		Player returnPlayer = new Player();
		returnPlayer.name = name;
		returnPlayer.level = level;
		returnPlayer.damage = damage;
		returnPlayer.position = position;
		returnPlayer.rendererObject = obj;
		return returnPlayer;
	}

	// params Ű���� : �Ķ���Ϳ� �迭�� �ް� ���� ���, �� ������ �迭 �Ķ���Ϳ� params Ű���带 �ٿ��θ�, �迭 ���� ��� ��ǥ(,)�� �����Ͽ� �迭�� �ڵ� ������ �� �ִ� �Ķ����
	// ����. �򰥸� �� �ִ�.
	//private Player CreatePlayer(string name, int level = 1, params int[] items)
	//{
	//	Player returnPlayer = CreatePlayer(name, level);
	//	returnPlayer.items = items;
	//	return returnPlayer;
	//}

	private Player CreatePlayer(string name, int[] items)
	{
		Player returnPlayer = CreatePlayer(name);
		returnPlayer.items = items;
		return returnPlayer;
	}

	[Serializable]
	public class Player
	{
		public string name;
		public int level;
		public float damage;
		public Vector2 position;
		public GameObject rendererObject;
		public int[] items;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionVariableTest : MonoBehaviour
{
	public string[] stringArray;    // 초기화 안 한 상태
	public List<string> stringList;
	public LinkedList<string> stringLList;
	public Queue<string> stringQueue;
	public Stack<string> stringStack;
	public Dictionary<string, string> stringDic;

	// Start is called before the first frame update
	void Start()
	{
		//foreach (string str in stringList)
		//{
		//	stringQueue.Enqueue(str);
		//}

		//stringArray[1].Tostring();
		//stringArray = new string[5];

		foreach (string str in stringArray)
		{
			Debug.Log(str);
		}

		Debug.Log(stringList);
		Debug.Log(stringList.Count);
	}

	// Update is called once per frame
	void Update()
	{

	}
}

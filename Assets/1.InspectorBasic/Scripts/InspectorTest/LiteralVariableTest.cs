using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteralVariableTest : MonoBehaviour
{
	public int intVar;
	public float floatVar = 0.1f;
	public bool boolVar = true;

	public short shortVar = short.MinValue;
	public ushort ushortVar = ushort.MaxValue;

	public uint uintVar;
	public long longVar;
	public uint ulongVar;
	public double doubleVar;
	public decimal decVar = decimal.MaxValue;

	public char charVar = 'A';
	public string strVar = null;

	// Start is called before the first frame update
	void Start()
	{
		//Debug.Log(strVar);
	}

	// Update is called once per frame
	void Update()
	{

	}

	//private void Reset()
	//{
	//	strVar = "Unity";
	//}
}

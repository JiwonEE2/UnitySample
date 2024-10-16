using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityStructTest : MonoBehaviour
{
	// 유니티 내장 구조체 : 유니티가 생성한 게임 공간 상에서 빈번하게 쓰이는 데이터 구조체
	// 1. Vector2 : 2차원 상에서의 좌표 또는 힘의 크기를 나타내기 위한 구조체
	public Vector2 vector2;

	// 2. Vector3 : 3차원 (상동)
	public Vector3 vector3;

	// 3. Vector4 : 4차원 (상동)
	public Vector4 vector4;

	// 4. Quaternion : 4원수. 3차원 축의 값과 1개의 허수부를 이용하여 3차원 공간에서 각도 변경 값이 겹치는 "짐벌락"현상을 방지하기 위해 Rotation 값으로 사용
	public Quaternion quat;

	// 5. Vector2(3)Int : 2(3)차원 상에서의 정수인 좌표
	public Vector2Int v2Int;
	public Vector3Int v3Int;

	// 6. Color : 색
	public Color color;

	// Start is called before the first frame update
	void Start()
	{
		print($"{name}'s position : {transform.position}");
		print($"{name}'s rotation : {transform.rotation.eulerAngles}");
		print($"{name}'s scale : {transform.localScale}");
	}

	// Update is called once per frame
	void Update()
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMessageTest : MonoBehaviour
{
	// 1. Update : 매 프레임의 가장 처음 호출
	private float preFrameTime = 0;		// 이전 프레임이 호출된 시간
	private void Update()
	{
		// Time.time : 게임이 시작된 뒤로 1초 당 1f의 속도로 누적
		print($"Update 호출됨. 호출 시간 : {Time.time}, 이전 프레임과 시간 차이 : {Time.time - preFrameTime}");
		preFrameTime = Time.time;
		print($"deltaTime : {Time.deltaTime}");
	}

	// 2. FixedUpdate : 게임 로직 상 프레임과 별개로 물리 연산이 수행될 때마다 호출. 호출 주기가 일정
	private float preFramePhysicsTime = 0;
	private void FixedUpdate()
	{
		print($"FixedUpdate 호출됨. 호출 시간 : {Time.time}, 이전 프레임과 시간 차이 : {Time.time - preFramePhysicsTime}");
		preFramePhysicsTime = Time.time;
		print($"FixeddeltaTime : {Time.fixedDeltaTime}");
	}

	private float preFrameLateTime = 0;
	// 3. LateUpdate : 매 프레임의 가장 나중에 호출.
	// 동일 프레임에서 호출되므로 Update와 호출 순서는 다르지만 시간 차이는 크기 않음
	private void LateUpdate()
	{
		print($"LateUpdate 호출됨. 호출 시간 : {Time.time}, 이전 프레임과 시간 차이 : {Time.time - preFrameLateTime}");
		preFrameLateTime = Time.time;
	}
}

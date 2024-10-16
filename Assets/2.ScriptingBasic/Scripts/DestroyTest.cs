using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour
{
	public GameObject destroyTarget;
	public Component destroyComponentTarget;
	public GameObject destroyTargetWithDelay;
	public GameObject destroyTargetOnImmediately;

	// 객체를 제거하는 4가지 방법

	// Start is called before the first frame update
	void Start()
	{
		// 1. GameObject를 Destroy
		Destroy(destroyTarget);
		// 2. Component를 비롯한 Object를 파괴
		Destroy(destroyComponentTarget);
		// Destroy 함수는 호출 이후에도 파라미터로 전달한 오브젝트에 참조가 가능(객체가 아직 파괴되지 않는다)
		FindMe findMe = destroyComponentTarget as FindMe;
		print(findMe.message);
		// Destroy 함수의 파라미터로 전달된 오브젝트는 즉시 파괴되는 것이 아닌, 파괴될 리스트에 업 한 후에 다음 프레임이 시작되기 전에 파괴됨. 따라서 해당 프레임에는 아직 객체가 존재하는 것

		// 3. 그렇기 때문에, Destroy 함수는 딜레이를 설정하는 것이 가능
		Destroy(destroyTargetWithDelay, 3f);

		// 4. 만약, 같은 프레임이라도 특정 객체가 즉시 파괴되기를 원한다면 DestroyImmediate() 함수를 사용할 것
		DestroyImmediate(destroyTargetOnImmediately);
		// 이 함수가 호출된 이후의 코드라인에서는 해당 객체를 참조할 수 없음
		//print(destroyTargetOnImmediately.name);		// 에러
	}
}

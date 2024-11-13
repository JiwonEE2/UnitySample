using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentControllerHW : MonoBehaviour
{
	public Transform target;
	private NavMeshAgent agent;
	public bool isStop;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		// AI에게 특정 지점으로 이동하도록 하는 함수
		agent.SetDestination(target.position);
		if (isStop)
		{
			agent.isStopped = isStop;
		}
	}
}

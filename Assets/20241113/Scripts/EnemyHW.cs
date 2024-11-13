using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyHW : MonoBehaviour
{
	private Transform player;
	private NavMeshAgent agent;
	public bool isStop;
	public State state;
	public float maxDistance;
	public Vector3 initPosition;
	public float idleRange;
	private NavMeshPath pathToPlayer;
	private float pathToPlayerDistance;
	[SerializeField]
	private Vector3 idlePosition;

	public float moveSpeed;

	public enum State
	{
		Idle, Chase, Attack, Return
	}

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.Find("Player").GetComponent<Transform>();
		pathToPlayer = new NavMeshPath();
		agent.speed = moveSpeed;
		state = State.Idle;
	}

	private void Update()
	{
		CalcuratePlayerDist();

		if (pathToPlayerDistance > maxDistance)
		{
			state = State.Return;
		}
		else
		{
			state = State.Chase;
		}


		agent.isStopped = isStop;
		switch (state)
		{
			case State.Idle:
				// 플레이어와의 거리가 일정 이상 가까워지면
				//if (pathToPlayer.< maxDistance)
				// 상태를 chase로 변경하고, 아니라면
				// 주변 지역을 배회
				if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
				{
					idlePosition = new Vector3(Random.Range(-Mathf.Abs(idleRange), Mathf.Abs(idleRange)), 1, Random.Range(-Mathf.Abs(idleRange), Mathf.Abs(idleRange)));
					agent.SetDestination(idlePosition);
				}
				break;
			case State.Chase:
				agent.SetDestination(player.position);
				break;
			case State.Attack:
				// 플레이어를 공격
				break;
			case State.Return:
				// 귀환
				agent.SetDestination(initPosition);
				if (agent.remainingDistance <= 0)
				{
					state = State.Idle;
				}
				break;
		}
	}

	private void CalcuratePlayerDist()
	{
		agent.CalculatePath(player.position, pathToPlayer);

		if (pathToPlayer.corners.Length < 2)
		{
			pathToPlayerDistance = 0;
		}

		float distance = 0;
		for (int i = 0; i < pathToPlayer.corners.Length - 1; i++)
		{
			distance += Vector3.Distance(pathToPlayer.corners[i], pathToPlayer.corners[i + 1]);
		}
		pathToPlayerDistance = distance;
	}
}

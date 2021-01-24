using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Character
{
    public enum eState  //FSM
    {
        Idle, 
        Flee, //적을 쫓다가 일정거리 이상 벗어나서 원래 위치로 돌아가는 상태
        Patrol, //정찰
        Chase,  //적을 발견해서 쫓아가는 상태
        Attack, //적을 공격하는 상태
        Dead,  //사망 상태

    }

    public eState curState = eState.Idle;
    public NavMeshAgent aiAgent;
    private Vector3 _startPos;
    

    private void Update()
    {
        OnUpdateState(curState);
    }

    private void Start()
    {
        OnEnterState(eState.Idle);
    }


    /// <summary>
    /// 상태를 변경합니다.
    /// </summary>
    /// <param name="targetChange">변경 하려는 상태</param>
    /// <param name="isDuplicatable">같은 상태로 변경될 떄 로직을 돌릴것인가?</param>
    public void ChangeState(eState targetState, bool isDuplicatable = false)
    {
        if(isDuplicatable == false && curState == targetState)
        {
            return;
        }
        OnExitState(curState);
        OnEnterState(targetState);
        curState = targetState;
        
    }

    private void OnEnterState(eState targetState)
    {
        switch(targetState)
        {
            case eState.Idle:
                {
                    aiAgent.speed = this.moveSpeed;
                    aiAgent.angularSpeed = 720;
                    aiAgent.stoppingDistance = 2;
                    aiAgent.acceleration = 100;
                    aiAgent.isStopped = true;
                    _startPos = transform.position;
                    StartCoroutine(DelayChangeState(eState.Patrol, 2));
                    break;
                }
            case eState.Flee:
                {
                    break;
                }
            case eState.Patrol:
                {
                    
                    break;
                }
            case eState.Chase:
                {
                    if(_target == null)
                    {
                        ChangeState(eState.Flee);
                        return;
                    }
                    aiAgent.isStopped = false;
                    aiAgent.destination = _target.transform.position;
                    break;
                }
            case eState.Attack:
                {
                    break;
                }
            case eState.Dead:
                {
                    break;
                }
        }
    }


    private void OnExitState(eState targetState)
    {
        switch (targetState)
        {
            case eState.Idle:
                {
                    break;
                }
            case eState.Flee:
                {
                    break;
                }
            case eState.Patrol:
                {
                    break;
                }
            case eState.Chase:
                {
                    break;
                }
            case eState.Attack:
                {
                    break;
                }
            case eState.Dead:
                {
                    break;
                }
        }
    }

    private void OnUpdateState(eState targetState)
    {
        switch (targetState)
        {
            case eState.Idle:
                {
                    break;
                }
            case eState.Flee:
                {
                    break;
                }
            case eState.Patrol:
                {
                    Collider[] targets = Physics.OverlapSphere(transform.position, 3, LayerMask.GetMask("Player"));
                    if (targets != null && targets.Length > 0) //적인식
                    {
                        _target = targets[0].GetComponent<Character>();
                        ChangeState(eState.Chase);
                    }
                    break;
                }
            case eState.Chase:
                {
                    if (_target != null)
                        aiAgent.destination = _target.transform.position;
                    break;
                }
            case eState.Attack:
                {
                    break;
                }
            case eState.Dead:
                {
                    break;
                }
        }
    }

    private IEnumerator Patrolling()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
            aiAgent.isStopped = false;
            Vector3 _offset = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            aiAgent.destination = _startPos + _offset;
        }
    }
    private IEnumerator DelayChangeState(eState targetState, float delay)
    {
        yield return new WaitForSeconds(delay);
        ChangeState(targetState);
    }




}

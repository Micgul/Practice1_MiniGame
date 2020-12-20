using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Transform _curWayPoint; //private 변수는 언더바
    private Transform _targetWayPoint;
    private float _progress;
    private int _waypointIndex;
    private float _moveSpeed = 0.15f;

    private int _hp = 100;

    private void Awake()
    {
        _curWayPoint = SpawnManager.Instance.wayPoints[_waypointIndex];
        _targetWayPoint = SpawnManager.Instance.wayPoints[_waypointIndex + 1];
    }

    private void Update()
    {
        this.transform.position
            = Vector3.Lerp(_curWayPoint.position, _targetWayPoint.position, _progress);
        // Lerp는 A에서부터 B로 가게끔 한다. _progress를 통해 0->1로 가게끔 한다.
        _progress += Time.deltaTime * _moveSpeed; //속도조절
        if(_progress >= 1f)
        {
            //웨이포인트 이동
            changeWayPoints();
            _progress = 0;
        }
    }

    private void changeWayPoints()
    {
        _waypointIndex += 1;

        if(_waypointIndex >= SpawnManager.Instance.wayPoints.Length)
        {
            _waypointIndex = 0;
            _curWayPoint = SpawnManager.Instance.wayPoints[_waypointIndex];
            _targetWayPoint = SpawnManager.Instance.wayPoints[_waypointIndex + 1];
        }
        else
        {
            _curWayPoint = SpawnManager.Instance.wayPoints[_waypointIndex];
            if (_waypointIndex + 1 >= SpawnManager.Instance.wayPoints.Length)
            {
                _targetWayPoint = SpawnManager.Instance.wayPoints[0];
            }
            else
            {
                _targetWayPoint = SpawnManager.Instance.wayPoints[_waypointIndex + 1];           
            }
        }
    }

    private void OnHit(Missile missile)
    {
        _hp -= 1;
        if(_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

}

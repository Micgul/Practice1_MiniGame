using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    /// <summary>
    /// 상수값 설정(보통 대문자)
    /// 빌드할 때 치환되는 상수
    /// const는 string이 아닌 값을 상수로 넣을 때 사용
    /// </summary>
    public const float DEAD_LINE = -400;
    /// <summary>
    /// static readonly는 게임이 시작될 때 할당되는 변수 readonly이기 때문에 변하지 않아서 상수
    /// string인 데이터를 상수로 표현할 때 주로 사용
    /// </summary>
    //public static readonly float DEAD_LINE = -400;
        

    //초당 떨어지는 속도
    public float speed = -100;
    public KeyCode targetKeyCode;

    
    void Update()
    {
        // 초당 speed 만큼 더해준다.
        this.transform.localPosition += Vector3.up * speed * Time.deltaTime;

        
        if(this.transform.localPosition.y <= DEAD_LINE)
        {
            OnMiss();
        }
    }

    void OnMiss()
    {
        Destroy(gameObject);
    }
}

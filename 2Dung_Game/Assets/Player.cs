using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Gordo의 애니메이터
    public Animator animator;
    public float moveSpeed = 10; //기본값 초당 10초

    private void Awake()
    {
        animator.SetTrigger("Idle_01");
    }
    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.transform.localScale = new Vector3(-0.25f, 0.25f, 1f);
        }
    }
    private void Move()
    {
        animator.ResetTrigger("Run_01");
        animator.ResetTrigger("Idle_01");

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            animator.SetTrigger("Run_01");
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            animator.SetTrigger("Run_01");
        }

        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
        {
            animator.SetTrigger("Idle_01");
        }
    }
}

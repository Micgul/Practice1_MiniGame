using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    private void Awake()
    {
        //스크립트가 꺼져있어도 실행이됨
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        //활성화 되어있을 때 실행이 됨.
        Debug.Log("OneEnable");
    }

    void Start()
    {
        Debug.Log("Start");
        Debug.Log(string.Format("1+2 = {0}", 1+2));
        Debug.Log($"1 + 2 = {1 + 2}");

    }

    void Update()
    {
        Debug.Log("hi");
    }
}

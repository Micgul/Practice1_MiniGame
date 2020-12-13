using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public Text _targetText;

    void Update()
    {
        if(Input.anyKeyDown == true)
        {
            // 동기 씬 로드
            // 해당 씬이 로드 될때까지 게임이 멈춥니다.
            // 로딩 진행바 구현 X
            //SceneManager.LoadScene("Scenes/Game");

            // 비동기 씬 로드
            // 해당 씬이 로드가 안되더라도 게임이 안 멈춘다.
            // 로딩 진행바 구현 O
            // 로딩속도가 조금 느림
            StartCoroutine(LoadScene());
        }
    }
    
    IEnumerator LoadScene()
    {

        Asyncoperation oper = Sc; eneManager.LoadSceneAsync("Scenes/Game");
        Debug.Log("로딩 시작")
        while(oper.isDone == false)
        {
            //Slider를 이용해서 로딩바 구현
            Debug.Log("로딩 중")
            yield return null;
        }
        //씬 로드 완료 시 코루틴의 오브젝트가 삭제되어서 코루틴이 멈춰서 아래 로그는 안나옴.
        Debug.Log("로딩 끝");
    }
        



    void Start()
    {
        DontDestroyOnLoad()
        StartCoroutine(StartFadeAnimation());
    }

    IEnumerator StartFadeAnimation()
    {
        bool isInverse = false;

        while(true)
        {
            if (isInverse == false)
            {
                _targetText.color = new Color(_targetText.color.r, _targetText.color.g, _targetText.color.b, _targetText.color.a - (1 - Time.deltaTime));
            }
            else
            {
                _targetText.color = new Color(_targetText.color.r, _targetText.color.g, _targetText.color.b, _targetText.color.a - (1 - Time.deltaTime));
            }

            if(_targetText.color.a <= 0f)
            {
                isInverse == true;
            }
            else if (_targetText.color.a >= 1f)
            {
                isInverse == false;
            }
            
            yield return null;
        }
    }
}

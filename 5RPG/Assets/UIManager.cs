using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI요소들을 관리하는 매니저클래스
public class UIManager : MonoBehaviour
{
    // 언제어디서든 접근가능하도록 해야하기 떄문에 싱글톤패턴으로 작성한다.
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIManager>();
            return _instance;
        }
    }
    private static UIManager _instance;
    // UI매니저 싱글톤은 여기까지

    public Canvas canvas;
    public GameObject damageUIPrefab;

    /// <summary>
    /// 필요데이터
    /// 1. 데미지 UI 프리팹
    /// 2. 데미지 UI 표시할 위치
    /// 3. 데미지 정보(데미지가 몇인지)
    /// </summary>


    public void MakeDamageUI(Transform targetTransform, float damage)
    {
        //프리팹 복사체
        GameObject obj = Instantiate(damageUIPrefab, canvas.transform);
        UIDamageText script = obj.GetComponent<UIDamageText>();
        script.SetUI(targetTransform, damage);

    }

}

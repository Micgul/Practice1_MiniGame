using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHitter : MonoBehaviour
{
    public KeyCode targetKeyCode;
    public Image targetImage;
    public Color pressColor, releaseColor;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(targetKeyCode) == true) // 특정키를 눌렀을 때
        {
            targetImage.color = pressColor;
        }
        else
        {
            targetImage.color = releaseColor;
        }
    }
}

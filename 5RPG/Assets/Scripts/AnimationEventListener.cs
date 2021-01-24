using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEventListener : MonoBehaviour
{
    //�ܺο��� �ش� �̺�Ʈ�� ����/������ �� �ְ� �ش� �̺�Ʈ�� ȣ�� �� ������ ��� �޼ҵ���� ȣ���Ѵ�.
    public event Action<EventType> onAnimationEvent; // void �޼ҵ� + string �Ķ���Ͱ� ���� �޼ҵ� �̺�Ʈ

    //string ���ٴ� enum�� ��ȣ�϶� -> �޸� ������ �߻� , �Ǽ�����
    public enum EventType
    {
        MeleeAttackStart,
        MeleeAttackEnd,
        OnAttack
    }

    public void OnAttack()
    {
        if (onAnimationEvent != null) // null�̸� �ƹ��� �������� �ʴ� �����Դϴ�.
        {
            onAnimationEvent(EventType.OnAttack);
        }
    }

    public void MeleeAttackStart()
    {
        if (onAnimationEvent != null) // null�̸� �ƹ��� �������� �ʴ� �����Դϴ�.
        {
            onAnimationEvent(EventType.MeleeAttackStart);
        }
    }

    public void MeleeAttackEnd()
    {
        if (onAnimationEvent != null) // null�̸� �ƹ��� �������� �ʴ� �����Դϴ�.
        {
            onAnimationEvent(EventType.MeleeAttackEnd);
        }
    }
}

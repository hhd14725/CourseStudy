using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvincibleBuff", menuName = "Buff/new InvincibleBuff")]
public class InvincibleBuff : BuffData
{

    [Header("���ӽð�")]
    public float duration = 5f;

    public override float Duration => duration;
    public override string GetDisplayValue()
    {
        return $"{duration}�� ����";
    }


    public override IEnumerator ApplyBuff(PlayerBuffHandler handler)
    {
        handler.IsInvincible = true;
        Debug.Log("�����߻�");
        yield return new WaitForSeconds(duration);
        Debug.Log("��������");
        handler.IsInvincible = false;

    }

}

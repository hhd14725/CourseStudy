using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvincibleBuff", menuName = "Buff/new InvincibleBuff")]
public class InvincibleBuff : BuffData
{

    [Header("瘤加矫埃")]
    public float duration = 5f;

    public override float Duration => duration;
    public override string GetDisplayValue()
    {
        return $"{duration}檬 公利";
    }


    public override IEnumerator ApplyBuff(PlayerBuffHandler handler)
    {
        handler.IsInvincible = true;
        Debug.Log("公利惯积");
        yield return new WaitForSeconds(duration);
        Debug.Log("公利秦力");
        handler.IsInvincible = false;

    }

}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvincibleBuff", menuName = "Buff/new InvincibleBuff")]
public class InvincibleBuff : BuffData
{

    [Header("Duration")]
    public float duration = 5f;


    public override IEnumerator ApplyBuff(PlayerBuffHandler handler)
    {
        handler.IsInvincible = true;
        Debug.Log("公利惯积");
        yield return new WaitForSeconds(duration);
        Debug.Log("公利秦力");
        handler.IsInvincible = false;

    }

}

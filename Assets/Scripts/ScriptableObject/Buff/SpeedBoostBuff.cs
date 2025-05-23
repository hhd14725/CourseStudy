using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoostBuff", menuName = "Buff/new SpeedBoostBuff")]
public class SpeedBoostBuff : BuffData
{
    [Header("Speed Multiplier")]
    public float multiplier = 1.5f;

    [Header("Duration")]
    public float duration = 5f;

    public override IEnumerator ApplyBuff(PlayerBuffHandler handler)
    {
      
        float originalSpeed = handler.Controller.moveSpeed;
        handler.Controller.moveSpeed *= multiplier;
        Debug.Log($"Applying Speed Boost Buff {handler.Controller.moveSpeed}");
        yield return new WaitForSeconds(duration);
        handler.Controller.moveSpeed = originalSpeed;
    }
}

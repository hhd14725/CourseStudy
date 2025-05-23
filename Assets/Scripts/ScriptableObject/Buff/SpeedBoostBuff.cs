using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoostBuff", menuName = "Buff/new SpeedBoostBuff")]
public class SpeedBoostBuff : BuffData
{
    [Header("이동속도 배수")]
    public float multiplier = 1.5f;

    [Header("지속시간")]
    public float duration = 5f;

    public override float Duration => duration;
    public override string GetDisplayValue()
    {
      return $"{multiplier}배";
    }

    public override IEnumerator ApplyBuff(PlayerBuffHandler handler)
    {
      
        float originalSpeed = handler.Controller.moveSpeed;
        handler.Controller.moveSpeed *= multiplier;        
        yield return new WaitForSeconds(duration);
        handler.Controller.moveSpeed = originalSpeed;
    }
}

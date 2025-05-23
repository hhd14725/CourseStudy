using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoubleJumpBuff", menuName = "Buff/new DoubleJumpBuff")]
public class DoubleJumpBuff : BuffData
{
    [Header("Max Jump Count")]
    public int maxJumpCount = 1;

    [Header("Duration")]
    public float duration = 5f;
    public override IEnumerator ApplyBuff(PlayerBuffHandler handler)
    {
        handler.MaxExtraJumps += maxJumpCount;
        Debug.Log("�������� �ߵ�");
        yield return new WaitForSeconds(duration);
        Debug.Log("�������� ����");
        handler.MaxExtraJumps -= maxJumpCount;
    }


}

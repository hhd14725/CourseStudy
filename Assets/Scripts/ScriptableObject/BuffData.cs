using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffData : ScriptableObject
{
    [Tooltip("효과 이름")]
    public string buffName;

    public abstract IEnumerator ApplyBuff(PlayerBuffHandler handler);

}

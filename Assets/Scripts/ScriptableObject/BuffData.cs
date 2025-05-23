using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffData : ScriptableObject
{
    [Tooltip("ȿ�� �̸�")]
    public string buffName;

    public abstract IEnumerator ApplyBuff(PlayerBuffHandler handler);

}

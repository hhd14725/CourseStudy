using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffData : ScriptableObject
{
    [Header("UI")]
    [Tooltip("ȿ�� �̸�")]
    public string buffName;
    [Tooltip("Icon")]
    public Sprite icon;

    public abstract float Duration { get; }
    public abstract string GetDisplayValue();

    public abstract IEnumerator ApplyBuff(PlayerBuffHandler handler);

}

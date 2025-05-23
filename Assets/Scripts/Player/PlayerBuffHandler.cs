using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerBuffHandler : MonoBehaviour
{
    public PlayerController Controller { get; private set; }

    public bool IsInvincible { get; set; }
    public int MaxExtraJumps { get; set; }

    public event Action<BuffData> OnBuffStart;
    public event Action<BuffData> OnBuffEnd;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
    }

    public void ApplyBuff(BuffData buff)
    {
        if(buff != null)
        {
            Debug.Log("Apply Buff");
            OnBuffStart?.Invoke(buff);           
            StartCoroutine(EndBuffCoroutine(buff));

        }
    }

    private IEnumerator EndBuffCoroutine(BuffData buff)
    {
       
        yield return StartCoroutine(buff.ApplyBuff(this));
        Debug.Log("End Buff");
        OnBuffEnd?.Invoke(buff);
    }
}



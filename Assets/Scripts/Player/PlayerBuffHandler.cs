using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerBuffHandler : MonoBehaviour
{
    public PlayerController Controller { get; private set; }

    public bool IsInvincible { get; set; }
    public int MaxExtraJumps { get; set; }

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
    }

    public void ApplyBuff(BuffData buff)
    {
        if(buff != null)
        {
            StartCoroutine(buff.ApplyBuff(this));
          
        }
    }
}



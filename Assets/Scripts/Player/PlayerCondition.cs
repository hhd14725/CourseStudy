using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour , IDamageable
{
    public UICondition uiCondition;
    Condition Health { get { return uiCondition.health; } }
    Condition Hunger { get { return uiCondition.hunger; } }
    Condition Stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;
    public event Action onTakeDamage;

    private void Update()
    {
        Hunger.Subtract(Hunger.passiveValue * Time.deltaTime);
        Stamina.Add(Stamina.passiveValue * Time.deltaTime);

        if(Hunger.curValue == 0f)
        {
            Health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if(Health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        Health.Add(amount);
    }

    public void Eat(float amount)
    {
        Hunger.Add(amount);
    }

    public void Die()
    {
        Debug.Log("Player has died");
     
    }

    public void TakePhysicalDamage(int damage)
    {
        Health.Subtract(damage);
        onTakeDamage?.Invoke();

    }
}

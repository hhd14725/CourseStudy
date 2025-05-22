using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegainZone : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCondition playerCondition = other.GetComponent<PlayerCondition>();
            if (playerCondition != null)
            {
                playerCondition.Heal(0.05f); 
                playerCondition.Eat(0.2f);
                Debug.Log("Player entered the regain zone. Health and hunger restored.");
            }
        }
    }

}

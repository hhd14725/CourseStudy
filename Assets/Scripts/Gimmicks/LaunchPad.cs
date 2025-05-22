using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    [Header("LaunchPad Settings")]
    public float launchForce;
    Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = CharacterManager.Instance.Player.GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Player"))
        {
            if(_rigidbody != null)
            {
              
                _rigidbody.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
            }
        }
    }
 

}

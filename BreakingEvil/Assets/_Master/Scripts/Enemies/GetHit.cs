using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private float _damagePerHit=30;
    [SerializeField] private string _tagToHit = "Bullet";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tagToHit))
        {
         _enemyHealth.maxHealth -= _damagePerHit;
        }
    }
}

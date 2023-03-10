using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
  public  UnityEvent onDeath;
  

   public float _enemyHealth;
    private void Update()
    {
        onEnemyDeath();
    }
    public void onEnemyDeath()
    {
        if (_enemyHealth<=0) {onDeath.Invoke();}       
    }
}

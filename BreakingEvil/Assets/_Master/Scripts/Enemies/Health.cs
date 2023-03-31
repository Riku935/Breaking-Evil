using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
  public  UnityEvent onDeath;
  public float maxHealth;
    private void Update()
    {
        Death();
    }
    public void Death()
    {
        if (maxHealth<=0) {onDeath.Invoke();}       
    }
}

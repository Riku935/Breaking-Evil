using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void PlayAnim(string animation)
    {
        _animator.Play(animation);
    }

}

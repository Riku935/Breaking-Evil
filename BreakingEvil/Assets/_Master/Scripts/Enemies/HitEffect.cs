using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private ParticleSystem _hitEffects;
    [SerializeField] private string _hitTag="Bullet";
    [SerializeField] private string _axeTag="Axe";
    [SerializeField] private string _effectTag;

    private void Start()
    {
        _hitEffects = GameObject.FindGameObjectWithTag(_effectTag).GetComponent<ParticleSystem>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_hitTag))
        {
            PlayEffect();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_axeTag))
        {
            PlayEffect();
        }
    }

    private void PlayEffect()
    { 
     _hitEffects.transform.position = transform.position;
     _hitEffects.Play(); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetHit : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private bool _canDismember=false;
    [SerializeField] private GameObject _toDismember;
    [SerializeField] private int _shootsToDismember = 1;
    [SerializeField] private float _damagePerHit=30;
    [SerializeField] private ParticleSystem _bloodSplash;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")&&_canDismember)
        {
            _bloodSplash.transform.position = transform.position;
            _bloodSplash.Play();
            _enemy._enemyHealth -= _damagePerHit;
            this.gameObject.SetActive(false);
            _toDismember.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Bullet")&&!_canDismember)
        {
            _bloodSplash.transform.position = transform.position;
            _bloodSplash.Play();
            _enemy._enemyHealth -= _damagePerHit;
        }
    }
}

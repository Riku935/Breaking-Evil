using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateHit : MonoBehaviour
{
    [SerializeField] string _bulletTag = "Bullet";
    [SerializeField] string _axeTag = "Axe";
    [SerializeField] bool _isExternal= false;
    [SerializeField] GameObject _toDeactivate;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_bulletTag)&&_isExternal)
        {
            _toDeactivate.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_axeTag) && _isExternal)
        {
            _toDeactivate.SetActive(false);
        }
    }
}

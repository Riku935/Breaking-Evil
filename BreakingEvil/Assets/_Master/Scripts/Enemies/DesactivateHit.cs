using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateHit : MonoBehaviour
{
    [SerializeField] string _tag = "Bullet";
    [SerializeField] bool _isExternal= false;
    [SerializeField] GameObject _toDeactivate;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tag)&&_isExternal)
        {
            _toDeactivate.SetActive(false);
        }
    }
}

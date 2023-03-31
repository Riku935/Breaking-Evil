using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateHit : MonoBehaviour
{
    [SerializeField] string _tag = "Bullet";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            this.gameObject.SetActive(false);
        }
    }
}

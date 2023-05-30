using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gun")
        {
            GunManager.obj.Reload();
        }
    }
}

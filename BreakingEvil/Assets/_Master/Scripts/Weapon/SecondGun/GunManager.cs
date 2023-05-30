using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public static GunManager obj;
    public bool canReload = false;
    private void Awake()
    {
        obj = this;
    }
    public void Reload()
    {
        canReload = true;
    }
    
    private void OnDestroy()
    {
        obj = null;
    }
}

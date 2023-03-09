using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Object_Interaction
{
    public override void Use()
    {
        base.Use();
        Debug.Log("IsShooting");

    }

}

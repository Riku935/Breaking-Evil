using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Functions : Object_Interaction
{
    public int identifier = 1;
    public Transform keyPosition;
    void UseKey()
    {
        transform.position = Vector3.Lerp(transform.position, keyPosition.position, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public override void Use()
    {
        base.Use();
        print("hola");
        UseKey();
    }
}

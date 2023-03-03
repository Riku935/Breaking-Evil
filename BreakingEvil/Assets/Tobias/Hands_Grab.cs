using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands_Grab : MonoBehaviour
{
    public float interactDistance;
    Transform object_ToGrab;
    Rigidbody object_Rb;
    public bool isGrab=false;

    public void Grab_Object(Transform toParent)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, LayerMask.GetMask("Grabable"))&!isGrab)
        {
           
            Grab(hit, toParent);
            isGrab = true;
        }
      
    }

    public void Throw()
    {
        if (isGrab)
        {
            object_ToGrab.transform.parent = null;
            object_Rb.constraints = RigidbodyConstraints.None;
            isGrab = false;
        }
    }
    public void Grab(RaycastHit raycastHit, Transform parent)
    {
        object_ToGrab = raycastHit.transform.GetComponent<Transform>();
        object_Rb = raycastHit.transform.GetComponent<Rigidbody>();
        object_ToGrab.transform.SetParent(parent);
        object_ToGrab.transform.position = Vector3.Lerp(object_ToGrab.transform.position, transform.position, 10);
        object_ToGrab.transform.rotation = Quaternion.Lerp(object_ToGrab.transform.rotation, transform.rotation, 10);
        object_Rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}

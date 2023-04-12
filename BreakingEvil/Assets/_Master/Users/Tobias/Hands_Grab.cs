using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands_Grab : MonoBehaviour
{
    public float interactDistance;
    Transform object_ToGrab;
    Rigidbody object_Rb;
    public bool isGrab = false;

    public void Grab_Object(Transform toParent)
    {

        RaycastHit hit;
        //Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, interactDistance);
        //if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, LayerMask.GetMask("Grabable"))&!isGrab)
        if (Physics.BoxCast(transform.position, transform.localScale*2, transform.forward, out hit, transform.rotation, interactDistance, LayerMask.GetMask("Grabable")) & !isGrab)
        {

            Grab(hit);
            isGrab = true;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x,transform.position.y,transform.position.z+interactDistance/8) , new Vector3(0.2f, 0.2f, transform.localScale.x * interactDistance));
    }
    public void Throw()
    {
        if (isGrab)
        {
            object_ToGrab.transform.parent = null;
            object_Rb.constraints = RigidbodyConstraints.None;
            object_Rb.velocity = Vector3.zero;
            isGrab = false;
        }
    }
    public void Grab(RaycastHit raycastHit)
    {
        object_ToGrab = raycastHit.transform.GetComponent<Transform>();
        object_Rb = raycastHit.transform.GetComponent<Rigidbody>();
        object_ToGrab.transform.SetParent(this.transform);
        object_ToGrab.transform.position = Vector3.Lerp(object_ToGrab.transform.position, transform.position, 10);
        object_ToGrab.transform.rotation = Quaternion.Lerp(object_ToGrab.transform.rotation, transform.rotation, 10);
        object_Rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Interaction()
    {
        object_ToGrab.transform.GetComponent<Object_Interaction>().Use();

    }
}

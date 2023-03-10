using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Functions : Object_Interaction
{
    public Hands_Grab obj;
    public Player_Controller player;
    public int identifier = 2;
    public bool canOff = false;
    public GameObject keyPosition;
    private Rigidbody rb;
    private Animator anim;


    public GameObject door;
    public GameObject doorposition;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void UseKey()
    {
        if (identifier == 1)
        {
            player.left_Hand.Throw();
            transform.position = Vector3.Lerp(transform.position, keyPosition.transform.position, 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, keyPosition.transform.rotation , 10);
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            anim.Play("Key_Function");
            if(canOff == true)
            {
                gameObject.SetActive(false);
            }
            StartCoroutine(Door());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "interactable")
        {
            identifier = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "interactable")
        {
            identifier = 2;
        }
    }

    public override void Use()
    {
        base.Use();
        print(identifier);
        UseKey();
    }
    IEnumerator Door()
    {
        yield return new WaitForSeconds(2);
        //door.transform.position = Vector3.Lerp(door.transform.position, doorposition.transform.position, 10);
        //door.transform.rotation = Quaternion.Lerp(door.transform.rotation, doorposition.transform.rotation, 10);
        door.transform.Rotate(0,90,0, Space.World);

    }
}

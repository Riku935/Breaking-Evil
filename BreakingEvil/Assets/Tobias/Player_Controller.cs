using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
	CharacterController characterController;

	[Header("Player Values")]
	public float walkSpeed = 6;
	public float runSpeed = 10;
	public float jumpSpeed = 8;
	public float gravity = 20;
	public float interactDistance = 4;

	private Vector3 movement = Vector3.zero;

	[Header("Camera Settings")]
	public Camera cam;
	public Transform cam_pos;
	public float mouseHorizontal = 3;
	public float mouseVertical = 2;
	public float minRotation = -60;
	public float maxRotation = 60;
	float h_mouse, v_mouse;

	[Header("Hands Settings")]
	public Transform righ_Hand;
	public Transform left_Hand;
	void Start()
	{
		characterController = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
		v_mouse += mouseVertical * Input.GetAxis("Mouse Y");//el += es para darle un limite de rotación
		v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);//limite

		cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0); //negativo porque si es positivo se mueve invertido (logica rara)
		transform.Rotate(0, h_mouse, 0); //Rotacion a los lados

		if (characterController.isGrounded)//esta función ya está predeterminada en el Character controller
		{
			movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //actualiza conforme a los axis

			if (Input.GetKey(KeyCode.LeftShift))
			{
				movement = transform.TransformDirection(movement) * runSpeed; //corre con el shift
			}
			else
			{
				movement = transform.TransformDirection(movement) * walkSpeed;//transformdirection es lo que teniamos que usar para que el movimiento sea global y no local, como al principio que no se movia hacia donde veia
			}
			if (Input.GetKey(KeyCode.Space))
			{
				movement.y = jumpSpeed; //solo modifica su posición en el eje Y 
			}

		}
		movement.y -= gravity * Time.deltaTime; //en el vector3 se calcula un movimiento en y constante, o sea la gravedad

		characterController.Move(movement * Time.deltaTime);



		if (Input.GetKey(KeyCode.E))
		{
			Interaction();
		}
	}

	private void Interaction()
	{
		RaycastHit hit;
		if (Physics.Raycast(cam_pos.position, cam_pos.forward, out hit, interactDistance, LayerMask.GetMask("Grabable")))
		{
       hit.transform.GetComponent<Grabable>();//manda a llamar el override de los codigos 
          
		}

	}
	private void get_ToHand(GameObject object_ToGrab)
    {
		object_ToGrab.transform.SetParent(cam_pos);
		object_ToGrab.transform.position = Vector3.Lerp(object_ToGrab.transform.position, righ_Hand.position, Time.deltaTime);
		object_ToGrab.transform.rotation = Quaternion.Lerp(object_ToGrab.transform.rotation, righ_Hand.rotation, Time.deltaTime);
    }
}

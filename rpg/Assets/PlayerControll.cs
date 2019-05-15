using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
	CharacterController controller;
	// Use this for initialization
	public float speed = .1f;
	public float jumpSpeed = .1f;
	public float gravity = 10;
	void Start () {
		controller = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDirection=new Vector3();
		if (controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection);
	}
}

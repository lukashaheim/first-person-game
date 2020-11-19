using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController controller;

	public float speed = 12f;
	public float speedBoost = 10f;
	

	public float normalJumpHeight = 2f;
	public float secondJumpHeight = 6f;
	public int stackJumps = 0; 
	public float gravity = -9.81f;
	

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if(isGrounded && velocity.y < 0) {
			velocity.y = -2f;
			stackJumps = 0;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime);

		// if(Input.GetButtonDown("Jump") && isGrounded) {
		// 	velocity.y = Mathf.Sqrt(normalJumpHeight * -2f * gravity);
		// }

		if(Input.GetButtonDown("Jump")) {
			if (stackJumps != 2) {
				if (stackJumps == 1) {
					velocity.y = Mathf.Sqrt(secondJumpHeight * -2f * gravity);
				} else {
					velocity.y = Mathf.Sqrt(normalJumpHeight * -2f * gravity);
				}
				stackJumps++;
			} 
		}

		// if(Input.GetKey(KeyCode.LeftShift)) 
		// 	speed = speedBoost;
		// else {
		// 	speed = 12f;
		// }
		

		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) {
			speed = speedBoost;
		} else {
			speed = 12f;
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}
}

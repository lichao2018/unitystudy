using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	Status status;
	CharacterController controller;
	// Use this for initialization
	Vector3 targetPoint;
	Vector3 movedir=Vector3.zero;
	bool moving = false;
	void Start () {
		controller = this.GetComponent<CharacterController>();
		status = this.GetComponent<Status>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
		{
			targetPoint.y = transform.position.y;
			if (Vector3.Distance(targetPoint, transform.position) < status.moveSpeed)
			{
				moving = false;
			}
			else
			{
				var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 25);

				if (controller.isGrounded)
				{
					movedir = transform.TransformDirection(Vector3.forward * status.moveSpeed);
				}
			}
		}
		if (!moving)
		{
			movedir = Vector3.zero;
		}

		movedir.y -= 20 * Time.deltaTime;
		controller.Move(movedir * Time.deltaTime);
	}

	public void moveTo(Vector3 p)
	{
		moving = true;
		targetPoint = p;
	}
}

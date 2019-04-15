using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	public WheelJoint2D leftWheelJoint;
	public WheelJoint2D rightWheelJoint;
	public float speed = 500;
	public float maxSpeed = 10000;
	public float rotSpeed = 1000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal");
		leftWheelJoint.useMotor = h != 0;
		rightWheelJoint.useMotor = h != 0;
		var mt = leftWheelJoint.motor;
		mt.motorSpeed = -speed * h;
		mt.maxMotorTorque = maxSpeed;
		leftWheelJoint.motor = mt;
		mt = rightWheelJoint.motor;
		mt.motorSpeed = -speed * h;
		mt.maxMotorTorque = maxSpeed;
		rightWheelJoint.motor = mt;
		var v = Input.GetAxis("Vertical")*Mathf.Abs(h);
		GetComponent<Rigidbody2D>().AddTorque(-v * rotSpeed);
	}
}

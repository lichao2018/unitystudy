using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var fp = base.transform.position;
		var tp = target.transform.position;
		fp.x += (tp.x - fp.x) * .9f;
		fp.y += (tp.y - fp.y) * .9f;
		base.transform.position = fp;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	Move move;
	// Use this for initialization
	void Start () {
		move = this.GetComponent<Move>();
		randomPos();
		InvokeRepeating("randomPos", 10, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void randomPos()
	{
		var p = transform.position;
		p.x += Random.Range(-10, 10);
		p.z += Random.Range(-10, 10);
		move.moveTo(p);
	}
}

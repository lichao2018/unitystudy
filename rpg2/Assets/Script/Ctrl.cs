using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour {
	Move move;
	// Use this for initialization
	void Start () {
		move = this.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		var isHit = Physics.Raycast(ray, out hit, 100);
		if (isHit&&Input.GetMouseButton(0))
		{
			move.moveTo(hit.point);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//地图上的道具
public class ItemInMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider aaa)
	{
		Debug.Log("吃道具");
	}
}

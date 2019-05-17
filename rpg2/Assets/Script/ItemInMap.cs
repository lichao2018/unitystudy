using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//地图上的道具
public class ItemInMap : MonoBehaviour {

	// Use this for initialization
	public int item=-1;
	public int status = 0;//0正常状态 1已经吃过
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider aaa)
	{
		Debug.Log("吃道具");
		if (item>=0)
		{
			Mgr.getInstance().users[0].packages.addFree(item);
		}
	}
}

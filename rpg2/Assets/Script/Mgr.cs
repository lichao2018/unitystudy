using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mgr : MonoBehaviour {

	// Use this for initialization
	private static Mgr _ins;
	public GameObject[] icons;
	void Start () {
		_ins = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static Mgr getInstance()
	{
		return _ins;
	}
}

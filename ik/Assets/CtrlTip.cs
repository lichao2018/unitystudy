using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlTip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log((new Vector3(2, 2, 3)).sqrMagnitude);
	}
	
	// Update is called once per frame
	void Update () {
		base.transform.Translate(.01f, 0, 0);
	}
}

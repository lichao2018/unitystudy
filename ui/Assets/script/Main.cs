using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var ui = GameObject.Find("Canvas").transform.Find("wrapper");

		var btn = GameObject.Find("btn1").GetComponent<Button>();//ui.transform.Find("left").Find("btn1").gameObject.GetComponent<Button>();
		Debug.Log(btn);
		btn.onClick.AddListener(
		   delegate ()
		   {
			   Debug.Log("click");
		   }
		  );
	}
}

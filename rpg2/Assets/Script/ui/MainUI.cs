using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		var juesebtn= transform.Find("wrapper").Find("bottom").Find("jueseBtn").gameObject.GetComponent<Button>();
		juesebtn.onClick.AddListener(
			delegate ()
			{
				transform.Find("wrapper").Find("jueseui").gameObject.SetActive(true);
			}	
		);

	}

	// Update is called once per frame
	void Update () {
		
	}
}

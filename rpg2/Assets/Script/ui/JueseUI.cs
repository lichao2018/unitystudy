using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JueseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var closeBtn = transform.Find("closeBtn").gameObject.GetComponent<Button>();
		closeBtn.onClick.AddListener(
			delegate ()
			{
				gameObject.SetActive(false);
				//transform.Find("wrapper").Find("jueseui").gameObject.SetActive(true);
			}
		);

		Instantiate(Mgr.getInstance().icons[0], transform.Find("Button (9)"));

		var dm= transform.Find("Button (1)").gameObject.GetComponent<DropMe>();
		dm.onDropEvent.AddListener(
			delegate (PointerEventData a,DropMe b)
			{
				Instantiate(Mgr.getInstance().icons[0], b.gameObject.transform);
				Debug.Log("ondrop"+a+b);
			}
		);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

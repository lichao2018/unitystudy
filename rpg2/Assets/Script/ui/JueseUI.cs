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
			}
		);
		Mgr.getInstance().newIcon(0,transform.Find("Button (9)"));
		Mgr.getInstance().newIcon(1,transform.Find("Button (10)"));

		var dm= transform.Find("Button (1)").gameObject.GetComponent<DropMe>();
		dm.onDropEvent.AddListener(
			delegate (PointerEventData a,DropMe b)
			{
				
				var iconB = a.pointerDrag.GetComponent<Icon>();
				Mgr.getInstance().newIcon(iconB.id, b.gameObject.transform);
				Debug.Log("ondrop"+iconB.id);
			}
		);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

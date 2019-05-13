using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconWrapper : MonoBehaviour {
	public Icon icon;
	public GameObject display;
	public GameObject icondisplay;
	public int index;
	public int packageTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateIcon()
	{
		if (icondisplay!=null)
		{
			Destroy(icondisplay);
		}
		if (icon!=null)
		{
			icondisplay = Mgr.getInstance().newIcon(icon, display.transform);	
		}
	}
}

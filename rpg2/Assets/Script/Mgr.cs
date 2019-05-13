using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mgr : MonoBehaviour {

	// Use this for initialization
	private static Mgr _ins;
	public GameObject iconPrefab;
	public Sprite[] icons;
	public List<User> users = new List<User>();
	void Start () {
		_ins = this;
		var user = new User();
		user.packages.setIcon(new Icon(),0);
		user.packages.setIcon(new Icon(),1);
		user.packages.setIcon(new Icon(),2);
		Icon icon = new Icon();
		icon.assetid = 1;
		user.packages.setIcon(icon,3);
		user.eqs.setIcon(new Icon(), 0);
		users.Add(user);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static Mgr getInstance()
	{
		return _ins;
	}

	public GameObject newIcon(Icon icon,Transform parent)
	{
		var iconObj = Instantiate(Mgr.getInstance().iconPrefab, parent);
		var iconImg = iconObj.GetComponent<Image>();
		//var icon = iconObj.GetComponent<Icon>();
		//icon.id = id;
		iconImg.sprite = Mgr.getInstance().icons[icon.assetid];
		return iconObj;
	}
}

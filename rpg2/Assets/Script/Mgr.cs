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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static Mgr getInstance()
	{
		return _ins;
	}

	public GameObject newIcon(int id,Transform parent)
	{
		var iconObj = Instantiate(Mgr.getInstance().iconPrefab, parent);
		var iconImg = iconObj.GetComponent<Image>();
		var icon = iconObj.GetComponent<Icon>();
		icon.id = id;
		iconImg.sprite = Mgr.getInstance().icons[id];
		return iconObj;
	}
}

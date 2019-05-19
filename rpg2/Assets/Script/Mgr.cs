using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr : MonoBehaviour {

	// Use this for initialization
	private static Mgr _ins;
	public GameObject iconPrefab;
	public Sprite[] icons;
	public GameObject[] models;
	public GameObject[] monsterList; //monster list to spawn
	public List<User> users = new List<User>();
	public Dictionary<int,Item> items=new Dictionary<int,Item>();

	public AsyncOperation async = null;
	public string posName = null;

    public GameObject player;

	void Start () {
		_ins = this;

		//init items
		var item = new Item();
		item.id = 0;
		item.assetid = 0;
		items.Add(item.id, item);


		item = new Item();
		item.id = 1;
		item.assetid = 1;
		items.Add(item.id, item);


		item = new Item();
		item.id = 2;//钥匙
		item.assetid = 1;
		items.Add(item.id, item);


		var user = new User();
		user.packages.setIcon(new Icon(),0);
		user.packages.setIcon(new Icon(),1);
		user.packages.setIcon(new Icon(),2);
		Icon icon = new Icon();
		icon.item = getItem(1);
		user.packages.setIcon(icon,3);
		user.eqs.setIcon(new Icon(), 0);
		user.eqs.setIcon(new Icon(), 1);
		users.Add(user);

	    player = Instantiate(monsterList[0]);//(GameObject)GameObject.Find("player");
		player.layer = LayerMask.NameToLayer("A");
        player.AddComponent<Ctrl>();
		var status= player.GetComponent<Status>();
		status.model=Instantiate(models[0], player.transform, false);
		status.user = user;
		user.model = player;
		player.tag = "A";

		
		foreach(var o in SceneManager.GetActiveScene().GetRootGameObjects())
		{
			DontDestroyOnLoad(o);
		}
		SceneManager.LoadScene("Scenes/" + "scene1", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		if (async != null&&async.isDone)
		{
			Debug.Log(async.isDone+posName);

			var g= GameObject.Find(posName);
			if (g!=null)
			{
				users[0].model.transform.position = g.transform.position;
				users[0].model.transform.eulerAngles = new Vector3(0,g.transform.eulerAngles.y ,0);
			}

			async = null;
		}
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
		iconImg.sprite = Mgr.getInstance().icons[icon.item.assetid];
		return iconObj;
	}

	public Item getItem(int id)
	{
		return items[id];
	}
}

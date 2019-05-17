using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//门 根据门的名字，传到另外的场景，相同的名字。

public class Door : MonoBehaviour
{
	//传送角色的位置
	public int[] requestItems;
	public string sceneName;
	public string posName;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider aaa)
	{
		if (aaa.gameObject.CompareTag("A"))
		{
			Debug.Log("door");
			LoadScene();

			Debug.Log(SceneManager.GetActiveScene().name);

			//SceneManager.LoadScene("Scenes/" + sceneName, LoadSceneMode.Single);
		}
	}

	void LoadScene()
	{
		Mgr.getInstance().users[0].model.GetComponent<Move>().stopMove();
		Mgr.getInstance().async = SceneManager.LoadSceneAsync("Scenes/" + sceneName);
		Mgr.getInstance().posName = posName;
	}
}

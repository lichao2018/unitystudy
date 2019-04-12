using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadModel : MonoBehaviour {
	string dir = "../AssetBundles/";
	private Object go;
	IEnumerator Start () {
		yield return loadAsset("assets/models/model1.prefab");
		Instantiate(go);
		yield return loadAsset("assets/models/model2.prefab");
		Instantiate(go);
	}

	IEnumerator loadAsset(string url)
	{
		string path= Application.absoluteURL + dir + url;
		path=Path.GetFullPath(path);
		System.UriBuilder uriBuilder = new System.UriBuilder(path);
		uriBuilder.Scheme = "file";
		Debug.Log(uriBuilder.ToString());
		WWW www = new WWW(uriBuilder.ToString());//AssetBundle.LoadFromFileAsync("F:/New Unity Project (2)/Assets/AssetBundles/thirdpc");
		yield return www;
		AssetBundle ab = www.assetBundle;
		if (ab == null)
		{
			Debug.Log("加载失败");
		}
		go = ab.LoadAsset(url);
	}
}

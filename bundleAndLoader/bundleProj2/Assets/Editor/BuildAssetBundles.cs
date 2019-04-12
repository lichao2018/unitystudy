using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAssetBundles  {
	[MenuItem("my/BuildAllBundles")]
	static void BuildAllBundles()
	{
		//找到所有prefab 并设置导出名字
		List<string> paths = new List<string>();
		doFiles(Application.dataPath, paths);
		//Dictionary<string, GameObject> path2gameobject = new Dictionary<string, GameObject>();
		foreach (string path in paths)
		{
			string rpath = path.Replace(Application.dataPath, "Assets");
			AssetImporter asset = AssetImporter.GetAtPath(rpath);
			asset.assetBundleName = rpath;
			//GameObject go = (GameObject)AssetDatabase.LoadAssetAtPath(rpath, typeof(GameObject));
			//path2gameobject.Add(rpath, go);
			Debug.Log(path);
			Debug.Log(rpath);
		}
		string dir = "../AssetBundles";
		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
	}

	private static void doFiles(string path, List<string> arr)
	{
		if (File.Exists(path))
		{
			if (Path.GetExtension(path) == ".prefab")
			{
				arr.Add(path);
			}
		}
		else if (Directory.Exists(path))
		{
			foreach (string str in Directory.GetFileSystemEntries(path))
			{
				doFiles(str, arr);
			}
		}
	}
}

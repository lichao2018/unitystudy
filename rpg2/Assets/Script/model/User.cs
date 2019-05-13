using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {

	// Use this for initialization
	public IconPackage packages = new IconPackage(10);//new Icon[10];//背包
	public IconPackage eqs = new IconPackage(5); //new Icon[5];//装备
	public IconPackage getPackByTag(int i)
	{
		switch (i)
		{
			case 0:
				return eqs;
			case 1:
				return packages;
		}
		return null;
	}
}

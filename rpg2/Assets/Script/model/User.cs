using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {

	// Use this for initialization
	public IconPackage packages = new IconPackage(10);//new Icon[10];//背包
	public IconPackage eqs = new IconPackage(5); //new Icon[5];//装备
	private float _moveSpeed = -1;
	public GameObject model;
	public User()
	{
		eqs.onChangeEvent.AddListener(
			delegate
			{
				updateMoveSpeed();
			}
		);
	}
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

	private void updateMoveSpeed()
	{
		_moveSpeed = 0;
		for(var i = 0; i < eqs.num; i++)
		{
			var icon = eqs.getIcon(i);
			if (icon!=null)
			{
				_moveSpeed += icon.item.moveSpeedAdder;
			}
		}
	}

	public float getMoveSpeed()
	{
		return _moveSpeed;
	}
}

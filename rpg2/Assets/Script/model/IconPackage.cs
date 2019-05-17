using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
public class IndexEvent : UnityEvent<int>
{
}
public class IconPackage  {
	public int num = 0;
	public IndexEvent onChangeEvent = new IndexEvent();
	private Icon[] icons; //= new Icon[10];//背包
	public IconPackage(int num) {
		this.num = num;
		icons = new Icon[num];
	}
	
	public Icon getIcon(int index)
	{
		return icons[index];
	}

	public void setIcon(Icon icon,int index)
	{
		icons[index] = icon;
		onChangeEvent.Invoke(index);
	}
	
	//在空闲格子添加道具
	public bool addFree(int id)
	{
		for (var i = 0; i < icons.Length;i++)
		{
			if (getIcon(i)==null)
			{
				var icon = new Icon();
				icon.item = Mgr.getInstance().getItem(id);
				setIcon(icon, i);
				return true;
			}
		}
		return false;
	}
}

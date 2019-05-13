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
	public IndexEvent onChangeEvent = new IndexEvent();
	private Icon[] icons; //= new Icon[10];//背包
	public IconPackage(int num) {
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
}

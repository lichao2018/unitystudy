using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JueseUI : MonoBehaviour {

	User user;
	// Use this for initialization
	void Start () {
		var closeBtn = transform.Find("closeBtn").gameObject.GetComponent<Button>();
		closeBtn.onClick.AddListener(
			delegate ()
			{
				gameObject.SetActive(false);
			}
		);

		user = Mgr.getInstance().users[0];

		for (int i = 0; i <= 4; i++)
		{
			var t = transform.Find("Button (" + i + ")");
			var go = t.gameObject;
			var iw = go.AddComponent<IconWrapper>();
			var index = i;
			iw.display = go;
			iw.index = index;
			iw.packageTag = 0;
			updateEqIcon(index);
			var dm= go.AddComponent<DropMe>();
			dm.containerImage = t.GetComponent<Image>();
			dm.OnEnable();

			dm.onDropEvent.AddListener(
			delegate (PointerEventData a, DropMe b)
			{
				swapIcon(a, b);
			});
		}

		

		for (int i=5;i<=14;i++)
		{
			var t= transform.Find("Button (" + i + ")");
			var go = t.gameObject;
			var iw= go.AddComponent<IconWrapper>();
			var index = i - 5;
			iw.display = go;
			iw.index = index;
			iw.packageTag = 1;
			updatePackIcon(index);
			var dm= go.AddComponent<DropMe>();
			dm.containerImage = t.GetComponent<Image>();
			dm.OnEnable();
			dm.onDropEvent.AddListener(
				delegate (PointerEventData a, DropMe b)
				{
					swapIcon(a, b);
				}
			);
		}

		user.eqs.onChangeEvent.AddListener(
			delegate (int index)
			{
				updateEqIcon(index);
				updateStats();
			}
		);
		user.packages.onChangeEvent.AddListener(
			delegate (int index)
			{
				updatePackIcon(index);
			}
		);
		updateStats();
	}

	void updateStats()
	{
		var t = transform.Find("moveSpeedLab");
		var txt = t.gameObject.GetComponent<Text>();
		txt.text ="movespeed:"+ user.getMoveSpeed() + "";
	}

	void swapIcon(PointerEventData a, DropMe b)
	{
		var dgm = a.pointerDrag.GetComponent<DragMe>();
		dgm.OnEndDrag(a);

		var iconB = a.pointerDrag.GetComponentInParent<IconWrapper>();
		var iconA = b.gameObject.GetComponent<IconWrapper>();

		var iconBB = user.getPackByTag(iconB.packageTag);
		var iconAB = user.getPackByTag(iconA.packageTag);

		var temp = iconBB.getIcon(iconB.index);
		iconBB.setIcon(iconA.icon, iconB.index);
		iconAB.setIcon(temp, iconA.index);
	}

	void updateEqIcon(int index)
	{
		var t = transform.Find("Button (" + index + ")");
		var go = t.gameObject;
		var iw = go.GetComponent<IconWrapper>();
		var icon = user.eqs.getIcon(index);
		iw.icon = icon;
		iw.updateIcon();
	}

	void updatePackIcon(int index)
	{
		var t = transform.Find("Button (" + (index+5) + ")");
		var go = t.gameObject;
		var iw = go.GetComponent<IconWrapper>();
		var icon = user.packages.getIcon(index);
		iw.icon = icon;
		iw.updateIcon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

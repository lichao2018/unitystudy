using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//主机游戏类型的控制器，点击技能释放攻击，不需要指定怪物
public class Ctrl : MonoBehaviour {
	Move move;
	Status status;
	// Use this for initialization
	void Start () {
		move = this.GetComponent<Move>();
		status = this.GetComponent<Status>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)&& !EventSystem.current.IsPointerOverGameObject())
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			var isHit = Physics.Raycast(ray, out hit, 100);
			if (isHit) {//鼠标按下
				var isGround = hit.transform.gameObject.CompareTag("ground");
				var attackAble = !hit.transform.gameObject.CompareTag(gameObject.tag)&&!isGround;
				var isClick = Input.GetMouseButtonDown(0);
				if (isClick)
				{
					status.canSkill();//如果点击，则取消技能
					if (attackAble)
					{
						var t = hit.transform;
						while (t!=null)
						{
							if (t.gameObject.GetComponent<Status>()!=null)
							{
								break;
							}
							t = t.parent;
						}
						status.attackSkill.target = t.gameObject;
						//followTo(t.gameObject,status.attackSkill);
					}else if (isGround)
					{
						//followTarget = null;
						move.moveTo(hit.point);
					}
				}
				else
				{
					//if (isGround&&followTarget==null)
					//{
					//	move.moveTo(hit.point);
					//}
				}
			}
		}
	}
}

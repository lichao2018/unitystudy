using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		var isHit = Physics.Raycast(ray, out hit, 100);
		if (isHit)
		{
			if (Input.GetMouseButton(0)) {//鼠标按下
				var isGround = hit.transform.gameObject.CompareTag("ground");
				var attackAble = !hit.transform.gameObject.CompareTag(gameObject.tag)&&!isGround;
				var isClick = Input.GetMouseButtonDown(0);
				if (isClick)
				{
					status.canSkill();//如果点击，则取消技能
					if (attackAble)
					{
						
						move.followTo(hit.transform.gameObject,status.attackSkill);
					}else if (isGround)
					{
						move.followTarget = null;
						move.moveTo(hit.point);
					}
				}
				else
				{
					if (move.followTarget==null)
					{
						move.moveTo(hit.point);
					}
				}
			}
		}
	}
}

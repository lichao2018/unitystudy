using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//类似dota的控制器，点击地面，点击怪物攻击。并且自动攻击
public class DotaLikeCtrl : MonoBehaviour
{
	Move move;
	Status status;

	Skill skill;
	public GameObject followTarget;
	// Use this for initialization
	void Start()
	{
		move = this.GetComponent<Move>();
		status = this.GetComponent<Status>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			var isHit = Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("B", "Ground"));
			if (isHit)
			{//鼠标按下
				var isGround = hit.transform.gameObject.CompareTag("ground");
				var attackAble = hit.transform.gameObject.tag=="B" && !isGround;
				var isClick = Input.GetMouseButtonDown(0);
				if (isClick)
				{
					status.canSkill();//如果点击，则取消技能
					if (attackAble)
					{
						var t = hit.transform;
						while (t != null)
						{
							if (move.GetComponent<Status>() != null)
							{
								break;
							}
							t = t.parent;
						}
						var skill = new Skill();
						skill.target = t.gameObject;
						skill.from = gameObject;
						skill.data = (SkillData)status.user.skills.getIcon(Random.Range(0, status.user.skills.num)).item;
						followTo(t.gameObject, skill);
					}
					else if (isGround)
					{
						followTarget = null;
						move.moveTo(hit.point);
					}
				}
				else
				{
					if (isGround && followTarget == null)
					{
						move.moveTo(hit.point);
					}
				}
			}
		}

		if (followTarget != null)
		{
			move.moveTo(followTarget.transform.position);

		}

		if (followTarget != null && skill != null&&status.currentSkill==null)
		{
			if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(followTarget.transform.position.x, followTarget.transform.position.z)) < skill.data.range)
			{
				Debug.Log("攻击");
				status.attack(this.skill, Time.time);
			}
		}
	}

	public void followTo(GameObject t, Skill skill)
	{
		followTarget = t;
		this.skill = skill;
	}
}

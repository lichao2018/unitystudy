using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	public int hp = 3;
	public float moveSpeed = 1;
	public float attackTimeAfter = .5f;//攻击前摇
	public float attackTimeBefore = .5f;//攻击后摇
	public Skill attackSkill = new Skill();

	public Skill currentSkill;//当前正在执行的技能
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hp<=0)
		{
			Debug.Log("小于0 删除");
			var dis = gameObject.transform.GetChild(0);
			dis.SetParent(null);
			Destroy(gameObject);
			var ani= dis.gameObject.GetComponent<Animator>();
			if (ani!=null)
			{
				ani.enabled = false;
			}
		}
	}

	public void attack(Skill skill,float time)
	{
		skill.skillExeover = false;
		currentSkill = skill;
		skill.attackStartTime = time;
	}

	//是否在攻击后摇
	public bool isInBefore(float time)
	{
		return time-currentSkill.attackStartTime<attackTimeBefore;
	}
	//是否在攻击前摇
	public bool isInAfter(float time)
	{
		return time - currentSkill.attackStartTime < attackTimeBefore+attackTimeAfter;
	}

	public void exeSkill()
	{
		Debug.Log("执行技能"+currentSkill.target.name);
		var ts = currentSkill.target.GetComponent<Status>();
		ts.hp--;
		currentSkill.skillExeover = true;
	}


	//取消当前技能攻击
	public void canSkill()
	{
		if (currentSkill!=null)
		{
			Debug.Log("取消技能");
			currentSkill = null;
		}
		
	}
}

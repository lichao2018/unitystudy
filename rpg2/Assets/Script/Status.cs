using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 1;
	public float attackTimeAfter = .5f;//攻击前摇
	public float attackTimeBefore = .5f;//攻击后摇
	public Skill attackSkill = new Skill();

	public Skill currentSkill;//当前正在执行的技能
	public float attackStartTime;//当前技能释放的开始时间
	public bool skillExeover;//是否技能已经执行完毕
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void attack(Skill skill,float time)
	{
		skillExeover = false;
		currentSkill = skill;
		attackStartTime = time;
	}

	//是否在攻击后摇
	public bool isInBefore(float time)
	{
		return time-attackStartTime<attackTimeBefore;
	}
	//是否在攻击前摇
	public bool isInAfter(float time)
	{
		return time - attackStartTime < attackTimeBefore+attackTimeAfter;
	}

	public void exeSkill()
	{
		Debug.Log("执行技能");
		skillExeover = true;
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

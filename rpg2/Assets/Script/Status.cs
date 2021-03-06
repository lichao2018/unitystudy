﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	public Animator animator;
	public int hp = 3;
	public float attackSpeed = 1;
	private float _moveSpeed = 1;
	public float moveSpeed
	{
		get
		{
			if (user!=null)
			{
				return user.getMoveSpeed();
			}
			return _moveSpeed;
		}
		set
		{
			_moveSpeed = value;
		}
	}
	//public Skill attackSkill = new Skill();
	private Skill _currentSkill;//当前正在执行的技能
	public Skill currentSkill//当前正在执行的技能
	{
		get
		{
			return _currentSkill;
		}
		set
		{
			if (value==null&&_currentSkill!=null)
			{
				_currentSkill.stop();
			}
			if (value!=null)
			{
				value.start();
			}
			_currentSkill = value;
			if (animator != null)
			{
				if (_currentSkill == null)
				{
					animator.SetBool("attack", false);
					animator.SetBool("attack2", false);
					animator.SetBool("attack3", false);
				}
				else
				{
					animator.SetBool(_currentSkill.data.animName, true);
				}
				
			}
		}
	}
	public User user;
	public GameObject model;//模型动画
	void Start () {
		foreach(var c in model.GetComponentsInChildren<Collider>())
		{
			c.enabled = false;
		}

		foreach (var c in model.GetComponentsInChildren<Rigidbody>())
		{
			c.isKinematic = true;
		}
		animator = model.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp<=0)
		{
			Debug.Log("小于0 删除");
			var dis = model.transform;
			dis.SetParent(null);
			var ani= dis.gameObject.GetComponent<Animator>();
            DestroyImmediate(ani);
            Invoke("destroy", 1);

			if (ani!=null)
			{
				ani.enabled = false;
			}
			foreach (var c in dis.gameObject.GetComponentsInChildren<Collider>())
			{
				c.enabled = true;
			}
			foreach (var c in dis.gameObject.GetComponentsInChildren<Rigidbody>())
			{
				c.isKinematic = false;
			}
        }else{
            //攻击动画结束会产生位置偏移，需要将model还原到父对象到位置
            if(currentSkill != null){
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    model.transform.position = transform.position;
                }
            }else{
                //跑步动画开始会产生位置偏移
                model.transform.position = transform.position;
            }
        }
	}

    void destroy(){
        Destroy(gameObject);
        Destroy(model);
    }

    public void attack(Skill skill,float time)
	{
        if(currentSkill != null){
            return;
        }
		skill.skillExeover = false;
		currentSkill = skill;
		skill.attackStartTime = time;
		//bind
	}

	//是否在攻击后摇
	public bool isInBefore(float time)
	{
		return time-currentSkill.attackStartTime<currentSkill.data.attackTimeBefore/attackSpeed;
	}
	//是否在攻击前摇
	public bool isInAfter(float time)
	{
		return time - currentSkill.attackStartTime < (currentSkill.data.attackTimeBefore+currentSkill.data.attackTimeAfter)/attackSpeed;
	}

	public void exeSkill()
	{
		if (currentSkill.target!=null) {
			Debug.Log("执行技能" + currentSkill.target.name);
			var ts = currentSkill.target.GetComponent<Status>();
            if(ts != null){
                ts.hp--;
            }
		}
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

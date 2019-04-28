using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	Status status;
	CharacterController controller;
	// Use this for initialization
	Vector3 targetPoint;
	public GameObject followTarget;
	Skill skill;
	public Animator animator;
	Vector3 movedir=Vector3.zero;
	bool moving = false;
	void Start () {
		controller = this.GetComponent<CharacterController>();
		status = this.GetComponent<Status>();
	}
	
	// Update is called once per frame
	void Update () {
		if (status.currentSkill != null )//如果当前正在执行技能，停止移动
		{
			if (!status.currentSkill.skillExeover)//没有执行完成技能执行技能
			{
				if (!status.isInBefore(Time.realtimeSinceStartup))
				{
					status.exeSkill();
				}
			}else//判断后摇
			{
				if (!status.isInAfter(Time.realtimeSinceStartup))
				{
					status.currentSkill = null;
				}
			}
			if (animator != null)
			{
				animator.SetBool("attack", true);
				animator.speed = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length/(status.attackTimeAfter+status.attackTimeBefore);
				
			}
			return;
		}
		if (animator != null)
		{
			animator.speed = 1;
			animator.SetBool("attack", false);
		}

		if (followTarget!=null)
		{
			moveTo(followTarget.transform.position);
		}
		if (moving)
		{
			targetPoint.y = transform.position.y;
			if (Vector3.Distance(targetPoint, transform.position) < (status.moveSpeed * Time.deltaTime))
			{
				moving = false;
			}
			else
			{
				var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 25);

				if (controller.isGrounded)
				{
					movedir = transform.TransformDirection(Vector3.forward * status.moveSpeed);
				}
			}
		}
		if (!moving)
		{
			movedir = Vector3.zero;
		}

		if (animator != null)
		{
			animator.SetBool("walking", moving);
			if (moving)
			{
				animator.speed = status.moveSpeed*1.25f;
			}
			else
			{
				animator.speed = 1;
			}
		}

		movedir.y -= 200 * Time.deltaTime;
		controller.Move(movedir * Time.deltaTime);

		if (followTarget!=null&&skill!=null)
		{
			if (Vector2.Distance(new Vector2(transform.position.x,transform.position.z),new Vector2(followTarget.transform.position.x,followTarget.transform.position.z))<skill.range)
			{
				Debug.Log("攻击");
				status.attack(skill, Time.realtimeSinceStartup);
			}
		}
	}

	public void moveTo(Vector3 p)
	{
		moving = true;
		targetPoint = p;
	}

	public void followTo(GameObject t,Skill skill)
	{
		followTarget = t;
		this.skill = skill;
	}

}

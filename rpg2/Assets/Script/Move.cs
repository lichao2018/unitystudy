using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	Status status;
	CharacterController controller;
	// Use this for initialization
	Vector3 targetPoint;
	public Animator animator;
	Vector3 movedir=Vector3.zero;
	bool moving = false;
	void Start () {
		controller = this.GetComponent<CharacterController>();
		status = this.GetComponent<Status>();
		animator = status.model.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {//移动攻击，需要固定时间更新
		if (status.currentSkill != null )//如果当前正在执行技能，停止移动
		{
            var time = Time.realtimeSinceStartup;

			var t = time - status.currentSkill.attackStartTime;
			t/=(status.currentSkill.data.attackTimeAfter+status.currentSkill.data.attackTimeBefore)/ status.attackSpeed;
			status.currentSkill.update(t);

			if (!status.currentSkill.skillExeover)//没有执行完成技能执行技能
			{
				if (!status.isInBefore(time))
				{
					status.exeSkill();
				}
			}else//判断后摇
			{
				if (!status.isInAfter(time))
				{
					status.currentSkill = null;
				}
			}

			if (status.currentSkill==null)
			{
				animator.speed = 1;
			}
			else
			{
				animator.speed = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length / (status.currentSkill.data.attackTimeAfter + status.currentSkill.data.attackTimeBefore)*status.attackSpeed;
			}
			return;
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
		//controller.SimpleMove(movedir * Time.deltaTime);
	}

	public void moveTo(Vector3 p)
	{
		moving = true;
		targetPoint = p;
	}

    public void move(float rotation, float translation){
        if(status.currentSkill != null){//如果正在执行技能，则不能移动
            return;
        }
        transform.Rotate(new Vector3(0, rotation, 0));
        controller.Move(transform.forward * status.moveSpeed * translation);
        animator.SetBool("walking", true);
        animator.speed = status.moveSpeed * 1.25f;
    }

	public void stopMove()
	{
		moving = false;
	}
}

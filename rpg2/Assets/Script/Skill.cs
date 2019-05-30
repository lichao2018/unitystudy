using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill  {

	// Use this for initialization
	public SkillData data;
	public float attackStartTime;//当前技能释放的开始时间
	public bool skillExeover;//是否技能已经执行完毕
	public GameObject target;
	public GameObject from;
	public Animator animator;
	public SkillAttack[] skillAttacks;
	public void start()
	{
		if (data.skillAttackDatas!=null)
		{
			
			skillAttacks = new SkillAttack[data.skillAttackDatas.Length];
			for (var i=0;i<data.skillAttackDatas.Length;i++)
			{
				var sad = data.skillAttackDatas[i];
			
				var bindBone = from.GetComponent<Status>().animator.GetBoneTransform(sad.bindname);
				if (bindBone==null)
				{
					bindBone = from.transform;
				}
				var sa = new SkillAttack();
				sa.data = sad;
				sa.start(bindBone);
				skillAttacks[i] = sa;
			}
		}
	}

	public void update(float time)
	{
		if (skillAttacks!=null)
		{
			foreach (var sa in skillAttacks)
			{
				sa.update(time);
			}
		}
	}

	public void stop()
	{
		if (skillAttacks != null)
		{
			foreach (var sa in skillAttacks)
			{
				sa.stop();
			}
		}
	}
}

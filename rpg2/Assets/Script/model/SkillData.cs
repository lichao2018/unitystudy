using UnityEngine;
using System.Collections;

//技能数据
public class SkillData : Item
{
	public float attackTimeAfter = .5f;//攻击前摇
	public float attackTimeBefore = .5f;//攻击后摇
	public int type;
	public float range = 5;//攻击距离
	public string animName = "attack";
}

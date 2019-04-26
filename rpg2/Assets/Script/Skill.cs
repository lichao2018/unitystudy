using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill  {

	// Use this for initialization
	public int type;
	public float range=5;//攻击距离

	public float attackStartTime;//当前技能释放的开始时间
	public bool skillExeover;//是否技能已经执行完毕
	public GameObject target;
}

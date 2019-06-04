using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//技能碰撞
public class SkillCol : MonoBehaviour
{
	public SkillAttack skillAttack;
	Dictionary<GameObject,float> gotime=new Dictionary<GameObject, float>();
	void OnTriggerEnter(Collider aaa)
	{
		var s= aaa.gameObject.GetComponent<Status>();
		if (s!=null)
		{
			var t = Time.time;
			var isHit = false;
			if (gotime.ContainsKey(aaa.gameObject))
			{
				var d = t - gotime[aaa.gameObject];
				if (d>skillAttack.data.attgap)
				{
					isHit = true;
				}
			}
			else
			{
				isHit = true;
				
			}
			if (isHit)
			{
				gotime[aaa.gameObject] = t;
				s.hp--;
				Debug.Log("you" + aaa.gameObject.tag);
			}
			//Debug.Log("执行技能伤害"+aaa.gameObject.name);
			

		}
		else
		{
			//Debug.Log("mei" + aaa.gameObject.name);
		}
		
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}

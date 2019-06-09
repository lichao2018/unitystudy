using UnityEngine;
using System.Collections;

public class SkillAttack 
{
	public SkillAttackData data;
	public GameObject col;

	private bool currentActive = false;
	//绑定攻击体
	public void start(Transform target,GameObject player)
	{
		Debug.Log("start");
		//foreach (var c in cols)
		//{
		col = GameObject.Instantiate(data.col, target);//, false);
		col.GetComponent<SkillCol>().skillAttack = this;
		col.layer = LayerMask.NameToLayer("Skill"+player.tag);
		col.SetActive(false);
		//}

	}
	//取消绑定
	public void stop()
	{
		//foreach (var c in cols)
		//	{
		GameObject.Destroy(col);
		//}
	}

	public void update(float t)
	{
		//Debug.Log("updata");
		//更新是否可碰撞
		var a = false;
		for (var i = 0; i < data.times.Length; i += 2)
		{
			var t0 = data.times[i];
			var t1 = data.times[i + 1];
			if (t >= t0 && t <= t1)
			{
				a = true;
				break;
			}
		}

		if (currentActive != a)
		{
			currentActive = a;
			//foreach (var c in cols)
			//{

			col.SetActive(currentActive);
			//}
		}

	}
}

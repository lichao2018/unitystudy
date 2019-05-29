using UnityEngine;
using System.Collections;

//技能碰撞
public class SkillCol : MonoBehaviour
{
	void OnTriggerEnter(Collider aaa)
	{
		Debug.Log("执行技能伤害");
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

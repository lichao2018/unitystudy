using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//主机游戏类型的控制器，点击技能释放攻击，不需要指定怪物
public class Ctrl : MonoBehaviour {
	Move move;
    float rotateSpeed = 30.0f;
    Status status;

    // Use this for initialization
    void Start () {
		move = this.GetComponent<Move>();
        status = this.GetComponent<Status>();
    }
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        if(Mathf.Abs(translation) < 0.01f && Mathf.Abs(rotation) < 0.01f){
            move.stopMove();
        }
        else{
            float angle = transform.localEulerAngles.y + rotation;
            move.move(rotation, translation);
        }

        if(Input.GetKeyDown(KeyCode.J)){
            var skill = new Skill();
            skill.data = (SkillData)status.user.skills.getIcon(Random.Range(0, status.user.skills.num)).item;
            status.attack(skill, Time.realtimeSinceStartup);
        }
    }
}

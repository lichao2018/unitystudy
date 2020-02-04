using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//主机游戏类型的控制器，点击技能释放攻击，不需要指定怪物
public class Ctrl : MonoBehaviour {
	Move move;
    float rotateSpeed = 300.0f;
    Status status;

    // Use this for initialization
    void Start () {
		move = this.GetComponent<Move>();
        status = this.GetComponent<Status>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.S)){
            move.move(180, 0);
        }

        if(Input.GetKey(KeyCode.S)){
            return;
        }

        float translation = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        if(Mathf.Abs(translation) < 0.01f && Mathf.Abs(rotation) < 0.01f){
            move.stopMove();
        }
        else{
            move.move(rotation, translation);
        }

        if(Input.GetKeyDown(KeyCode.J)){
            var skill = new Skill();
            skill.data = (SkillData)status.user.skills.getIcon(Random.Range(0, status.user.skills.num)).item;
            skill.from = gameObject;
            //check enemy
            skill.target = checkTarget();
            status.attack(skill, Time.realtimeSinceStartup);
        }
    }

    //检测前方扇形区域中是否有敌人。半径1，角度60，layer未设置
    private GameObject checkTarget(){
        Collider[] cols = Physics.OverlapSphere(gameObject.transform.position, 1);
        //if(cols!=null && cols.Length>0) Debug.Log(cols[0]);
        if (cols.Length > 0)
        {
            foreach (Collider col in cols)
            {
                Quaternion targetRot = Quaternion.LookRotation(col.transform.position - gameObject.transform.position);
                if (Quaternion.Angle(targetRot, gameObject.transform.rotation) < 60) {
                    if (col.gameObject != null && col.gameObject.tag == "enemy") {
                        Debug.Log("find a enemy");
                        return col.gameObject;
                    }
                }
            }
        }
        return null;
    }
}

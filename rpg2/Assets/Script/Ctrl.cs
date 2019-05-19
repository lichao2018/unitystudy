using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//主机游戏类型的控制器，点击技能释放攻击，不需要指定怪物
public class Ctrl : MonoBehaviour {
	Move move;
	Status status;
    CharacterController controller;
    Animator animator;
    float speed = 10.0f;
    float rotateSpeed = 100.0f;
    // Use this for initialization
    void Start () {
		move = this.GetComponent<Move>();
		status = this.GetComponent<Status>();
        controller = this.GetComponent<Move>().GetComponent<CharacterController>();
        animator = this.GetComponent<Status>().model.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        controller.Move(transform.forward * translation);
        transform.Rotate(0, rotation, 0);

        if(Mathf.Abs(translation) < 0.1f && Mathf.Abs(rotation) < 0.1f){
            animator.SetBool("walking", false);
        }else{
            animator.SetBool("walking", true);
        }
    }
}

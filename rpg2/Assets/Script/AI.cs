using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	Move move;
    public float visibleRange = 3;
    public float attackRange = 1;

    public float actRestTime = 10;
    private float lastActTime;
    private GameObject player;
    private Animator animator;

	// Use this for initialization
	void Start () {
        player = Mgr.getInstance().player;
        animator = this.GetComponent<Status>().model.GetComponent<Animator>();
		move = this.GetComponent<Move>();
		randomPos();
	}
	
	// Update is called once per frame
	void Update () {
        if(player == null){
            Debug.Log("player == null");
            return;
        }
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToPlayer < attackRange){
            move.stopMove();
            animator.SetBool("attack", true);
        }else if(distanceToPlayer < visibleRange){
            moveToPlayer();
        }else{
            if(Time.time - lastActTime > actRestTime){
                randomPos();
            }
        }
	}

	void randomPos()
	{
        lastActTime = Time.time;
        animator.SetBool("attack", false);
        var p = transform.position;
		p.x += Random.Range(-10, 10);
		p.z += Random.Range(-10, 10);
		move.moveTo(p);
	}

    void moveToPlayer(){
        animator.SetBool("attack", false);
        move.moveTo(player.transform.position);
    }
}

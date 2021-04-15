using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    Transform player;//怪物寻找的目标
    NavMeshAgent Nav;//导航组件
    //Animator Anim;
	void Start () {
        //利用tag寻找人物
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //获取NavMeshAgent组件
        Nav = GetComponent<NavMeshAgent>();
        //Anim = GetComponent<Animator>();
	}
	

	void Update () {
        Nav.SetDestination(player.position);
	}
}

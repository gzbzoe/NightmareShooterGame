using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    Animator Anim;
    public int attacking=10;//攻击力
    //攻击时间间隔
    public int attacktime = 1;
    float timer;
    //判断怪物攻击范围
    bool Inrange;
    GameObject player;
    PlayerHealth playerhealth;
	void Start () {
        Anim = GetComponent<Animator>();
        //寻找到人物
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
	}
	
	
	void Update () {
        timer += Time.deltaTime;
        if (timer >= attacktime&&Inrange==true)
        {
            //重置timer
            timer = 0;
            //人物血量>0 减血
            if (playerhealth.CurrentHealth > 0)
            {
                playerhealth.TakeDamage(attacking);
            }
            playerhealth.isdamage = false;
            playerhealth.timer = 0f;
        }
        if (playerhealth.CurrentHealth <= 0)
        {
            
            Anim.SetBool("PlayerDeath", true);
        }
	}
    //正在碰撞
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Inrange = true;
        }
    }
    //离开碰撞
    public void OnTriggerExit(Collider other)
    {
        Inrange = false;
    }
}

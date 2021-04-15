using UnityEngine;
using System.Collections;


public class PlayerShooting : MonoBehaviour {
    PlayerHealth playerhealth;
    AudioSource Audioshoot;
    
    Light lighting;
    LineRenderer line;//LineRenderer组件
    float Starttime = 0.15f;
    float Endtime = 0.1f;
    float timer;
    Ray shootRay;//定义一条射线
    LayerMask shootMask;//可射击的层
    RaycastHit shootHit;//射线检测到的点
    public int Shootinghit=100;//攻击力
    void Start () {
        //获取组件
        line = GetComponent<LineRenderer>();
        shootMask = LayerMask.GetMask("floor");
        lighting = GetComponent<Light>();
        Audioshoot = GetComponent<AudioSource>();
        playerhealth = transform.parent.gameObject.GetComponent<PlayerHealth>();
       // ps =this. GetComponent<ParticleSystem>();
    }
	
	
	void Update () {
       
        //把射线的起始点设置为枪口
        shootRay.origin = transform.position;
        //射线的方向设置为枪口的正前方
        shootRay.direction = transform.forward;
        //把linrender组件的起始点设置为枪口坐标
        line.SetPosition(0,transform.position);
        //计时
        timer += Time.deltaTime;
        //按下鼠标左键 
        if (Input.GetMouseButton(0)&&timer>Endtime
                &&!playerhealth.isdeath 
                    && UIManager.instance.isRunning)
        {
            Audioshoot.Play();
            //发射一条射线  射线名称 检测到的点 长度
            if (Physics.Raycast(shootRay,out shootHit,100,shootMask))
            {
                //获取挂载到物体身上的怪物血量脚本
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                ParticleSystem  ps = shootHit.collider.GetComponentInChildren<ParticleSystem>();
               
                if (enemyHealth != null)
                {
                    ps.Play();
                    enemyHealth.TakeDamage(Shootinghit);
                }
                //设置LineRender组件的终点
                line.SetPosition(1, shootHit.point);
            }
            else
            {
                //没有射到怪物
                line.SetPosition(1, shootRay.origin + shootRay.direction * 100);
            }
            timer = 0f;
            //激活组件
            line.enabled = true;
            lighting.enabled = true;
            //ps.tranform.position = shootHit.point;
            
           


        }
        else
        {
            //禁用
            line.enabled = false;
            lighting.enabled = false;
        }
	}
}

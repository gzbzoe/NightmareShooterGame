using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public AudioClip death;
    public AudioClip hurt;
    public AudioClip bossdeath;
    public AudioClip bosshurt;
    AudioSource audio;
    public int StartEnemyHealth = 100;//初始血量
    public int CurrentHealth;//实时血量
    Animator Anim;//怪物动画
    bool isdeath;//怪物是否死亡
    bool isSinking;//怪物下沉
    void Start() {

        //血量初始化
        CurrentHealth = StartEnemyHealth;
        Anim = GetComponent<Animator>();
        audio = transform.GetComponent<AudioSource>();
    }

        void Update() {
            if (isSinking)
            {
                //怪物下沉
                transform.Translate(Vector3.down * 2.5f * Time.deltaTime);
            }
            if (CurrentHealth > 0)
            {
                Anim.SetBool("EnemyMove", true);
            }
        }
        //怪物减血
        public void TakeDamage(int amount)
        {
            if (isdeath)
            {
               // Debug.Log("222");
                return;
            }
            else
            {
                CurrentHealth -= amount;

                if (CurrentHealth <= 0)
                {
                
                Death();
                }
           
            }
        }
        //怪物死亡
        public void Death()
        {
            if (gameObject.tag == "Boss")
            {
                audio.clip = bossdeath;
                audio.Play();
                UIManager.instance.Score += 10;
            }
            else
            {
                audio.clip = death;
                audio.Play();
                UIManager.instance.Score += 5;
            }
            isdeath = true;
            
            Anim.SetBool("EnemyDeath", true);
        }
        //动画事件 
        public void StartSinking()
        {
            GetComponent<NavMeshAgent>().enabled = false;
            isSinking = true;
            Destroy(gameObject);
        }

 }


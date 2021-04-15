using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float StartHealth = 100;
    public float CurrentHealth;
    public Slider sliderHP;
    public AudioClip death;  
    public AudioClip hurt;
    AudioSource audio1;
    Animator Anim;
    public bool isdamage=false; //被攻击状态
    public bool isdeath = false;//死亡状态
    public bool isemerge = false;//紧急状态
    public float timer;
    void Start () {
        CurrentHealth = StartHealth;
        Anim = GetComponent<Animator>();
        audio1 =transform. GetComponent<AudioSource>();
	}
	
	
	void Update () {
        timer += Time.deltaTime;
        sliderHP.value = CurrentHealth;
        //恢复血量
        if (timer>10&&!isdamage &&CurrentHealth<100)
        {
            //Debug.Log("123");
            CurrentHealth += 0.1f; 
        }
        //警报
        if (CurrentHealth <= 20&&CurrentHealth>0)
        {
            UIManager.instance.EmergePanel.SetActive(true);
        }
        else
        {
            UIManager.instance.EmergePanel.SetActive(false);
        }
	}
  
    public void TakeDamage(int damage)
    {
        isdamage = true;
        //人物减血
        CurrentHealth -= damage;
        audio1.clip = hurt;
        audio1.Play();
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Anim.SetBool("PlayerDeath",true);
        audio1.clip = death;
        audio1.Play();
        isdeath = true;
        
        UIManager.instance.Lose();
    }
}

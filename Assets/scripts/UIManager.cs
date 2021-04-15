using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    //将UIManager类设置为一个单例，方便其他类调用
    public static UIManager instance;
    public GameObject StartPanel;//开始界面
    public GameObject RunningPanel;//运行界面
    public GameObject LosePanel;//失败界面
    public GameObject EmergePanel;//紧急界面
    public GameObject VictoryPanel;//胜利界面
    public Sprite paused;//zanting图片
    public Sprite start; //kaishi图片
    public bool isRunning=true;//运行状态
    public Text Scoretext;//分数显示框
    public int Score = 0;//分数
    

    void Start () {
        instance = this;
        
        Scoretext.text = Score + "";
        isRunning = true;
        

    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().buildIndex==1)
        {
            Scoretext.text = Score + "";
            // 游戏胜利
           if (GameObject.Find("Hellephant 1(Clone)") == null &&
                GameObject.Find("ZomBear 1(Clone)") == null &&
                GameObject.Find("Zombunny 1(Clone)") == null)
            {
                VictoryPanel.SetActive(true);
                isRunning = false;
               

                //Time.timeScale = 0;
            }
        }
       
    }
    //开始游戏
    public void StartOnClick(int num)
    {
        
        SceneManager.LoadScene(num);
        //Score = 0;
        isRunning = true;
        //StartPanel.SetActive(false);
        //RunningPanel.SetActive(true);
        
    }
    //重新开始
    public void RestartOnClick(int num)
    {
        
        SceneManager.LoadScene(num);
        Time.timeScale = 1;
        isRunning = true;
        //Score = 0;
        //LosePanel.SetActive(false);
        //RunningPanel.SetActive(true);
    }
    //游戏失败
    public void Lose()
    {
        LosePanel.SetActive(true);
        
        
        isRunning = false;
        //Time.timeScale = 0;
        //Delay();
        StartCoroutine(Delay());
       

    }
    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(3.2f);

        GameObject.Find("Canvas/LosePanel/Text").GetComponent<Animator>().enabled = false;
        Time.timeScale = 0;


    }
    //游戏暂停
    public void Pause()   
    {
        
        
        if (!isRunning)
        {
            
            //开始
            isRunning = true;
            Time.timeScale = 1;
            transform.GetComponent<AudioSource>().Play();
            transform.Find("RunningPanel/Zanting").GetComponent<Image>().sprite = paused;
            

        }
        else
        {
            
            //暂停
            isRunning = false;
            Time.timeScale = 0;
            transform.GetComponent<AudioSource>().Stop();
            
            transform.Find("RunningPanel/Zanting").GetComponent<Image>().sprite = start;
           
           
        }

        


    }
    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }
}

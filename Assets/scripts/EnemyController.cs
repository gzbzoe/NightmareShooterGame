using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject EnemyPrefab;//怪物预设物
    public Transform EnemyPos;//怪物生成点
    public float EnemyTime=10f;//小怪物生成时间间隔
    public float BossTime=20f;//大怪物生成时间间隔
    public int number=0;//几波怪物
    void Start () {
        //开启协程
        StartCoroutine(enemyCopy());
	}
	
	
	void Update () {
	
	}
    IEnumerator enemyCopy()
    {
        while (number++<5)
        {
            if (EnemyPrefab.tag == "Boss")
            {
                //小怪生成时间间隔
                yield return new WaitForSeconds(BossTime);
                //实例化怪物
                GameObject bossprefab = Instantiate(EnemyPrefab);
                //怪物在一点生成的位置
                bossprefab.transform.position = EnemyPos.position;
               
            }
            else
            {
                //实例化怪物
                GameObject enemyprefab = Instantiate(EnemyPrefab);
                //怪物在一点生成的位置
                enemyprefab.transform.position = EnemyPos.position;
                //小怪生成时间间隔
                yield return new WaitForSeconds(EnemyTime);
            }
            
        }
    }
}

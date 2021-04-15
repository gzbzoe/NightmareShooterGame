using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform Player;//人物坐标
    Vector3 offest;
	void Start () {
        //计算人物到相机的向量
        offest = transform.position - Player.position;
       
    }
	
	
	void Update () {
        //计算相机到人物之间的距离
        Vector3 palyerTocam = Player.position + offest;
        //差值运算，速度缓慢移动从一点到另一点
        transform.position = Vector3.Lerp(transform.position, palyerTocam,5f*Time.deltaTime);
	}
}

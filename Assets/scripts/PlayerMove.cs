using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    private Rigidbody Rigi;//定义人物刚体
    Vector3 movement;//人物坐标
    public float speed=5f;
    Animator Anima;//动画控制器
    LayerMask Floor;//鼠标旋转识别的层
    PlayerHealth playerhealth;
	void Start () {
        Rigi = transform.GetComponent<Rigidbody>();
        Anima = GetComponent<Animator>();
        Floor = LayerMask.GetMask("floor");
        playerhealth = GetComponent<PlayerHealth>();
	}
	
	
	void Update () {
        float h = Input.GetAxis("Horizontal");//获取键盘水平轴
        float v = Input.GetAxis("Vertical");//获取键盘垂直轴
        Move(h, v);
        Turning();

	}
    public void Move(float h,float v)
    {
        if (!playerhealth.isdeath&&UIManager.instance.isRunning)
        {
            //获取人物坐标
            movement.Set(h, 0, v);
            movement = movement.normalized * speed * Time.deltaTime;
            //当前位置+移动位置
            Rigi.MovePosition(movement + transform.position);
            bool ismove = h != 0 || v != 0;
            if (ismove)
            {
                //播放人物移动动画
                Anima.SetBool("PlayerMove", true);
            }
            else
            {
                Anima.SetBool("PlayerMove", false);
            }

        }
  

    }
    //鼠标控制人物旋转
    public void Turning()
    {
        //创建一条从相机发出的射线
        Ray CamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //创建一个存储到的点的变量
        RaycastHit floorHit;
        //进行射线投射 射线的名字 射线投射到的点 射线的长度 所能投射的层
        if (Physics.Raycast(CamRay, out floorHit, 100f, Floor))
        {   
            //创建一个向量 计算人物到射线投射点的向量
            Vector3 playerToray = floorHit.point - transform.position;
            //使向量始终与y轴平行
            playerToray.y = 0f;
            //创建一个四元数，旋转角度为向量
            Quaternion newRotation = Quaternion.LookRotation(playerToray);
            //利用刚体进行旋转
            Rigi.MoveRotation(newRotation);
        }
    }
    
}

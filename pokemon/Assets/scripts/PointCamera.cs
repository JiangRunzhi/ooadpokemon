using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//挂载到Main Camera下，聚焦战斗场景中心的默认视角，用鼠标控制，右键旋转，中键平移，滚轮移动
public class PointCamera : MonoBehaviour
{
    private Vector3 center;//初始视角中心点，此处设为原点
    float sensitivityRX = 10;//旋转x轴灵敏度参数
    float sensitivityRY = 10;//旋转y轴灵敏度参数
    float sensitivityMX = 10;//平移x轴灵敏度参数
    float sensitivityMY = 10;//平移y轴灵敏度参数
    float sensitivityD = 10;//镜头前后移动灵敏度参数
    private float rotationX = 0;//初始镜头角度
    private float rotationY = 0;//初始镜头角度
    
    void Start() 
    {
        center = Vector3.zero;//初始化视角中心点
    }
    
    void Update()
    {
        if (Input.GetMouseButton(1)) //右键旋转
        { 
            rotationX += Input.GetAxis("Mouse X") * sensitivityRX / 5;//获取鼠标x轴偏移量
            rotationY += Input.GetAxis("Mouse Y") * sensitivityRY / 5;//获取鼠标y轴偏移量
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);//转动摄像头到新的角度
        }

        if (Input.GetMouseButton(2)) //中键平移
        {
            float translationX = Input.GetAxisRaw("Mouse X") * Time.timeScale * sensitivityMX / 100;//获取鼠标x轴偏移量
            float translationY = Input.GetAxisRaw("Mouse Y") * Time.timeScale * sensitivityMY / 100;//获取鼠标y轴偏移量
            transform.position = transform.position - transform.right * translationX - transform.up * translationY;//移动摄像头
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0) //滚轮调整视角前后
        {
            int judge = 1;
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                judge = -1;
            }//判断滚轮运动朝向
            float d = Vector3.Distance(center, transform.position);//视角中心点与镜头之间的距离
            var dir = transform.position - center;//视角中心点指向镜头的向量
            if ( (d > 0 && d - judge * sensitivityD * 20 * Time.deltaTime > 0) || (d < 0 && d - judge * sensitivityD * 20 * Time.deltaTime < 0) )//摄像头不能越过中心点
            {
                dir = dir.normalized * (d - judge * sensitivityD * 20 * Time.deltaTime); //方向向量乘以移动后的距离，即最终视角中心点指向镜头的向量
                transform.position = dir + center; //将摄像头移动到最终位置
            }
        }
    }
}
/*
作者名称:YHB

脚本作用:虚拟杆控制运动

建立时间:2016.8.15.8.36
*/

using UnityEngine;
using System.Collections;

public class VirtualBar : MonoBehaviour
{
    #region 字段
    public static float h;
    public static float v;

    private bool isPress = false;
    private Transform VirtualPoint;
    #endregion

    #region Unity内置函数
    void Start()
    {
        VirtualPoint = this.transform.FindChild("VirtualPoint").transform;
    }
    void Update()
    {
        MoveValueCalculate();
    }
    #endregion

    #region NGUI内置方法
    void OnPress(bool isPress)
    {
        this.isPress = isPress;

        if (isPress == false)//表示虚拟杆按键抬起来了
        {
            VirtualPoint.localPosition = Vector3.zero;//按键归零

            h = 0;//横向移动数值归零
            v = 0;//纵向移动数值归零
        }
    }
    #endregion

    #region 移动数值计算方法
    void MoveValueCalculate()
    {
        if (isPress)//虚拟杆被按下才开始计算
        {
            //NGUI中计算拖拽的移动距离..返回的是脚本所挂载物体的boxCollider大小，一般就是这张图片的像素大小
            Vector2 touchPos = UICamera.lastTouchPosition;

            //坐标中心化
            touchPos -= new Vector2(150, 150);

            //计算中心到移动后的距离
            float dir = Vector3.Distance(Vector3.zero, touchPos);

            //限制范围
            if (dir > 100)//超出范围，限制它的最大值为150
            {
                touchPos = touchPos.normalized * 100;//归一化后只取它的方向，再乘以150就是最大移动范围了
                VirtualPoint.localPosition = touchPos;
            }
            else
            {
                VirtualPoint.localPosition = touchPos;
            }

            //VirtualPoint.localPosition = touchPos;//设置那个虚拟杆中心的位置

            //记录移动数值
            h = touchPos.x / 100;
            v = touchPos.y / 100;
        }
    }
    #endregion
}

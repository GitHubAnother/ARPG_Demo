/*
作者名称:YHB

脚本作用:相机插值跟随

建立时间:2016.8.14.13.21
*/

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    #region 字段
    public Vector3 cameraOffset = new Vector3(-1.195778f, 2.156892f, -2.426493f);
    public float lerpSpeed = 10;

    private GameObject player;
    #endregion

    #region Unity内置函数
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ASD");
    }
    void LateUpdate()
    {
        if (player != null)
        {
            LerpFollow();
        }
    }
    #endregion

    #region 插值运算方法
    void LerpFollow()
    {
        //目标位置
        Vector3 targetPos = player.transform.position + cameraOffset;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, lerpSpeed * Time.deltaTime);

        //目标旋转
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - this.transform.position);

        //这里用四元素的插值运算
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, lerpSpeed * Time.deltaTime);
    }
    #endregion
}

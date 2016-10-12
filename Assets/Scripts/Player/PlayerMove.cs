/*
作者名称:YHB

脚本作用:移动玩家

建立时间:2016.8.14.14.10
*/

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    #region 字段
    public float moveSpeed = 10;

    private Animator anim;
    private CharacterController playerCharacterController;
    #endregion

    #region Unity内置函数
    void Start()
    {
        anim = this.GetComponent<Animator>();
        playerCharacterController = this.GetComponent<CharacterController>();
    }
    void Update()
    {
        Move();
    }
    #endregion

    #region 移动方法
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //如果虚拟杆的数值有变化就优先使用虚拟杆的数值
        if (VirtualBar.h != 0 || VirtualBar.v != 0)
        {
            h = VirtualBar.h;
            v = VirtualBar.v;
        }

        if (Mathf.Abs(h) > 0.01f || Mathf.Abs(v) > 0.01f)
        {
            anim.SetBool("walk", true);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))//只有当前是跑的动画才能进行真正的移动
            {
                Vector3 targetDir = new Vector3(h, 0, v);
                this.transform.LookAt(targetDir + this.transform.position);

                playerCharacterController.SimpleMove(targetDir * moveSpeed);
            }
        }
        else
        {
            anim.SetBool("walk", false);
        }

    }
    #endregion
}

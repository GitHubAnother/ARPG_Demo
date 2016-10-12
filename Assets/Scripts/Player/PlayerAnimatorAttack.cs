/*
作者名称:YHB

脚本作用:玩家动画攻击脚本

建立时间:2016.8.15.11.15
*/

using UnityEngine;
using System.Collections;

public class PlayerAnimatorAttack : MonoBehaviour
{
    #region 字段
    public UIButton normalAttack;
    public UIButton rangeAttack;
    public UIButton redAttack;

    private Animator anim;
    private bool isAttackB = false;
    #endregion

    #region Unity内置函数
    void Start()
    {
        anim = this.GetComponent<Animator>();

        EventDelegate normal = new EventDelegate(this, "NormalAttack");
        normalAttack.onClick.Add(normal);

        EventDelegate range = new EventDelegate(this, "RangeAttack");
        rangeAttack.onClick.Add(range);

        EventDelegate red = new EventDelegate(this, "RedAttack");
        redAttack.onClick.Add(red);

        AttackModl_UI._i.SingleAndDual_AttackUI();
    }
    #endregion

    #region 攻击事件方法
    public void NormalAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isAttackB)//这个时候才能进行普通B攻击
        {
            anim.SetTrigger("attackB");
        }
        else
        {
            anim.SetTrigger("attackA");
        }
    }
    public void RangeAttack()
    {
        anim.SetTrigger("attackRange");
    }
    public void RedAttack()
    {
        anim.SetTrigger("attackGun");
    }
    public void AttackB1()//开启B攻击
    {
        isAttackB = true;
    }
    public void AttackB2()//关闭B攻击
    {
        isAttackB = false;
    }
    #endregion
}

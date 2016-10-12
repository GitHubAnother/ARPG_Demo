/*
作者名称:YHB

脚本作用:玩家身上处理道具的方法

建立时间:2016.8.18.9.55
*/

using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    #region 字段
    public GameObject Single;
    public GameObject Gun;
    public GameObject Dual;

    private float persistTime = 60;//持续时间
    private float gunTime = 0;
    private float dualTime = 0;
    #endregion

    #region Unity内置函数
    void Update()
    {
        GunCountZero();
        DualCountZero();
    }
    #endregion

    #region  根据传进来的道具切换武器
    public void GetItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.Gun:
                HandOverToGun();
                break;
            case ItemType.Knife://Knife就是蓝色的刀
                HandOverToDual();
                break;
        }
    }
    #endregion

    #region 3个切换不同武器的方法
    void HandOverToGun()//切换为枪
    {
        Gun.SetActive(true);
        Single.SetActive(false);
        Dual.SetActive(false);

        gunTime = persistTime;
        dualTime = 0;

        AttackModl_UI._i.Gun_AttackUI();
    }
    void HandOverToDual()//切换为蓝色的刀
    {
        Dual.SetActive(true);
        Gun.SetActive(false);
        Single.SetActive(false);

        dualTime = persistTime;
        gunTime = 0;

        AttackModl_UI._i.SingleAndDual_AttackUI();
    }
    void HandOverToSingle()//切换为红色的刀
    {
        Single.SetActive(true);
        Gun.SetActive(false);
        Dual.SetActive(false);

        dualTime = 0;
        gunTime = 0;

        AttackModl_UI._i.SingleAndDual_AttackUI();
    }
    #endregion

    #region 2种武器的持续时间
    void GunCountZero()
    {
        if (gunTime > 0)
        {
            gunTime -= Time.deltaTime;

            if (gunTime <= 0)
            {
                HandOverToSingle();//时间到了切换为普通的那把红色的刀
            }
        }
    }
    void DualCountZero()
    {
        if (dualTime > 0)
        {
            dualTime -= Time.deltaTime;

            if (dualTime <= 0)
            {
                HandOverToSingle();//时间到了切换为普通的那把红色的刀
            }
        }
    }
    #endregion
}

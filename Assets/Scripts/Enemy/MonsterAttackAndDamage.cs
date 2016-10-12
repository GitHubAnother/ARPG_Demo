/*
作者名称:YHB

脚本作用:Monster的攻击脚本

建立时间:2016.8.17.10.05
*/

using UnityEngine;
using System.Collections;

public class MonsterAttackAndDamage : AttackAndDamage
{
    #region 字段
    private Transform player;
    private PlayerAttackAndDamage playerAttackAndDamage;
    #endregion

    #region Unity内置函数
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ASD").transform;
        playerAttackAndDamage = player.GetComponent<PlayerAttackAndDamage>();
    }
    #endregion

    #region 攻击方法
    public void MonsterAttack()
    {
        float distance = Vector3.Distance(this.transform.position, player.position);

        if (distance < base.attackDistance)
        {
            playerAttackAndDamage.Damage(base.normalAttack);
        }
    }
    #endregion
}

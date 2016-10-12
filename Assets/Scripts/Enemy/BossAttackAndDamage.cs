/*
作者名称:YHB

脚本作用:boss攻击脚本

建立时间:2016.8.17.13.27
*/

using UnityEngine;
using System.Collections;

public class BossAttackAndDamage : AttackAndDamage
{
    #region 字段
    public AudioClip attackClip;

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

    #region 攻击方法 1
    public void BossAttack_1()
    {
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.5f);

        float distance = Vector3.Distance(this.transform.position, player.position);

        if (distance < base.attackDistance)
        {
            playerAttackAndDamage.Damage(base.normalAttack);
        }
    }
    #endregion

    #region 攻击方法 2
    public void BossAttack_2()
    {
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.5f);

        float distance = Vector3.Distance(this.transform.position, player.position);

        if (distance < base.attackDistance)
        {
            playerAttackAndDamage.Damage(base.normalAttack);
        }
    }
    #endregion
}

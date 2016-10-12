/*
作者名称:YHB

脚本作用:玩家攻击伤害处理脚本

建立时间:2016.8.17.8.47
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttackAndDamage : AttackAndDamage
{
    #region 字段
    public float gunAttack = 150;
    public float attackB = 50;//B攻击力
    public float attackRange = 90;//范围攻击力
    public Gun gun;
    #endregion

    #region  4个攻击事件方法
    public void AttackA()
    {
        Monomer(base.normalAttack);
    }
    public void AttackB()
    {
        Monomer(attackB);
    }
    public void AttackRange()
    {
        Community();
    }
    public void AttackGun()//TODO
    {
        gun.attack = gunAttack;
        gun.Shot();
    }
    #endregion

    #region  单体群体攻击敌人
    void Monomer(float damage)//单体攻击范围内的敌人
    {
        GameObject enemy = null;

        float distance = base.attackDistance;

        foreach (GameObject go in SpawnEnemy._i.enemyArray)
        {
            float dis = Vector3.Distance(go.transform.position, this.transform.position);

            if (dis < distance)
            {
                enemy = go;//缓存敌人

                distance = dis;//更换最小距离
            }
        }

        if (enemy != null)//缓存下来的敌人不等于空才能调用敌人的受伤方法
        {
            //先朝向敌人
            Vector3 dir = enemy.transform.position;
            dir.y = this.transform.position.y;//保持自身Y轴不变
            this.transform.LookAt(dir);

            //调用敌人受伤方法
            enemy.GetComponent<AttackAndDamage>().Damage(damage);
        }
    }
    void Community()//群体攻击范围内的敌人
    {
        List<GameObject> enemyList = new List<GameObject>();//临时记录符合条件的enemy进行遍历

        //这里遍历的时候其他的地方修改了集合里面的元素的话，再在下面调用集合里元素中的方法是可能会报错
        foreach (GameObject go in SpawnEnemy._i.enemyArray)
        {
            float dis = Vector3.Distance(go.transform.position, this.transform.position);

            if (dis < base.attackDistance)//因为是范围攻击所以敌人到玩家的距离小于玩家的攻击距离就要受到伤害
            {
                enemyList.Add(go);
            }
        }

        foreach (GameObject go in enemyList)//单独遍历复合条件的enemy
        {
            go.GetComponent<AttackAndDamage>().Damage(attackRange);
        }
    }
    #endregion
}

/*
作者名称:YHB

脚本作用:用来处理攻击和伤害的脚本

建立时间:2016.8.17.6.48
*/

using UnityEngine;

public class AttackAndDamage : MonoBehaviour
{
    #region 字段
    public float hp = 100;
    public float normalAttack = 30;//普通攻击力
    public float attackDistance = 3;//攻击范围
    public AudioClip deathClip;

    [HideInInspector]
    public Animator anim;
    #endregion

    #region Unity内置函数
    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }
    #endregion

    #region +Damage处理伤害方法
    public void Damage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }

        if (hp > 0)
        {
            //玩家受到攻击不播放动画，因为动画播放时间太长了，会导致不能使用普通攻击
            if (this.tag == "Boss" || this.tag == "Monster")
            {
                anim.SetTrigger("damage");//播放受到攻击的动画
            }
        }
        else
        {
            //播放死亡的动画
            anim.SetTrigger("death");

            if (this.tag == "Boss" || this.tag == "Monster")
            {
                AudioSource.PlayClipAtPoint(deathClip, this.transform.position, 1f);

                RandomItem();
                SpawnEnemy._i.enemyArray.Remove(this.gameObject);
                this.GetComponent<CharacterController>().enabled = false;
                Destroy(this.gameObject, 1);
            }
        }

        AttackEffect();//实例化特效
    }
    #endregion

    #region -AttackEffect根据当前物体的标签实例化受到攻击的伤害特效
    void AttackEffect()
    {
        if (this.gameObject.tag == "Boss")
        {
            Instantiate(Resources.Load("HitBoss"), this.transform.position + Vector3.up, this.transform.rotation);
        }
        else if (this.gameObject.tag == "Monster")
        {
            Instantiate(Resources.Load("HitMonster"), this.transform.position + Vector3.up, this.transform.rotation);
        }
    }
    #endregion

    #region  怪物死亡后产生道具
    void RandomItem()
    {
        int probability = Random.Range(1, 100);

        if (this.tag == "Monster")
        {
            if (probability < 36)
            {
                int index = Random.Range(1, 100);

                if (index < 36)
                {
                    Instantiate(Resources.Load("Knife"), this.transform.position + Vector3.up, Quaternion.identity);
                }
                else
                {
                    Instantiate(Resources.Load("Gun"), this.transform.position + Vector3.up, Quaternion.identity);
                }
            }
        }

        if (this.tag == "Boss")//Boss百分之66的概率生成道具
        {
            if (probability < 66)
            {
                int index = Random.Range(1, 100);

                if (index < 66)
                {
                    Instantiate(Resources.Load("Knife"), this.transform.position + Vector3.up, Quaternion.identity);
                }
                else
                {
                    Instantiate(Resources.Load("Gun"), this.transform.position + Vector3.up, Quaternion.identity);
                }
            }
        }
    }
    #endregion
}

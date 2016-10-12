/*
作者名称:YHB

脚本作用:敌人跟踪玩家

建立时间:2016.8.16.9.21
*/

using UnityEngine;
using System.Collections;

public class EnemyFollowPlayer : MonoBehaviour
{
    #region 字段
    public float moveSpeed = 0.9f;
    public float attackDistance = 2f;
    public float attackInterval = 3f;//攻击间隔

    private GameObject player;
    private CharacterController enemyCharacterController;
    private PlayerAttackAndDamage playerAttackAndDamage;
    private Animator anim;
    private float attackStartTime;
    private const float zeroTime = 0;
    #endregion

    #region Unity内置函数
    void Start()
    {
        enemyCharacterController = this.GetComponent<CharacterController>();
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("ASD");
        playerAttackAndDamage = player.GetComponent<PlayerAttackAndDamage>();

        attackStartTime = attackInterval;//记录初始的攻击间隔
        attackInterval = zeroTime;//这样在游戏一运行时玩家进入boss的攻击范围后boss直接进行攻击
    }
    void FixedUpdate()
    {
        if (playerAttackAndDamage.hp <= 0)
        {
            anim.SetBool("walk", false);
            return;
        }

        FollowPlayer();
    }
    #endregion

    #region 全图追击玩家
    void FollowPlayer()
    {
        Vector3 targetPos = player.transform.position;
        targetPos.y = this.transform.position.y;//Boss在Y轴上的位置不变

        //始终朝向玩家
        this.transform.LookAt(targetPos);

        //计算玩家与boss的距离
        float distance = Vector3.Distance(targetPos, this.transform.position);

        if (distance <= attackDistance)//进入boss的攻击范围，boss进行攻击
        {
            AttackTiming();
        }
        else//boss的攻击范围之外，boss进行全图追击
        {
            //玩家每次第一次进入boss的攻击范围，boss都要直接攻击，不进行攻击间隔计算
            attackInterval = zeroTime;

            //移动前判断当前正在播放的动画是run动画才能进行实际的移动
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                //移动
                enemyCharacterController.SimpleMove(transform.forward * moveSpeed);
            }

            anim.SetBool("walk", true);//播放run动画
        }
    }
    #endregion

    #region 攻击计时
    void AttackTiming()
    {
        attackInterval -= Time.deltaTime;//开始计时

        if (attackInterval <= zeroTime)//达到计时时间进行攻击
        {
            BossAttackRandom();//播放攻击动画
            attackInterval = attackStartTime;//返回初始攻击间隔
        }
        else//在攻击间隔计时的时候不能播放其他任何的动画---一般都是关闭run动画
        {
            anim.SetBool("walk", false);
        }
    }
    #endregion

    #region boss随机攻击动画
    void BossAttackRandom()
    {
        if (this.gameObject.tag == "Boss")
        {
            int attackIndex = Random.Range(0, 2);

            if (attackIndex == 0)
            {
                anim.SetTrigger("attackA");
            }
            else
            {
                anim.SetTrigger("attackB");
            }
        }
        else
        {
            anim.SetTrigger("attack");
        }
    }
    #endregion
}

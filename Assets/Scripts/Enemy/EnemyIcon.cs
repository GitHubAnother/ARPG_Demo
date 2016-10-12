/*
作者名称:YHB

脚本作用:控制敌人icon在小地图上显示的位置

建立时间:
*/

using UnityEngine;
using System.Collections;

public class EnemyIcon : MonoBehaviour
{
    #region 字段
    private Transform player;
    private Transform enemyIcon;
    #endregion

    #region Unity内置函数
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ASD").transform;

        if (this.tag == "Boss")
        {
            enemyIcon = MinimapIcon._i.BossIconGameObject().transform;
        }
        else
        {
            enemyIcon = MinimapIcon._i.MonsterIconGameObject().transform;
        }
    }
    void Update()
    {
        SynchronizationTransform();
    }
    #endregion

    #region 同步位置
    void SynchronizationTransform()
    {
        //偏移值
        Vector3 offset = this.transform.position - player.position;
        offset *= 10;
        enemyIcon.localPosition = new Vector3(offset.x, offset.z, 0);
    }
    #endregion

    #region 
    void OnDestroy()
    {
        if (enemyIcon != null)
        {
            Destroy(enemyIcon.gameObject);
        }
    }
    #endregion
}

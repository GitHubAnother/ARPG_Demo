/*
作者名称:YHB

脚本作用:敌人生成器

建立时间:2016.8.16.11.22
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour
{
    #region 字段
    public static SpawnEnemy _i;

    public GameObject monster;
    public GameObject boss;
    public CreateBoss[] createBossScriptArray;
    public CreateMonster[] createMonsterScriptArray;

    [HideInInspector]
    public List<GameObject> enemyArray = new List<GameObject>();
    #endregion

    #region Unity内置函数
    void Awake()
    {
        _i = this;
    }
    void Start()
    {
        StartCoroutine(CreateEnemyToThreeWave());
    }
    #endregion

    #region 协程生成3波敌人
    IEnumerator CreateEnemyToThreeWave()
    {
        foreach (CreateMonster m in createMonsterScriptArray)//第一波8个monster
        {
            enemyArray.Add(m.Enemy(monster));

            yield return new WaitForSeconds(0.3f);
        }

        while (enemyArray.Count > 0)//集合部位空表示场上还有敌人
        {
            yield return new WaitForSeconds(1f);//一直延迟生成下一波敌人
        }

        foreach (CreateMonster m in createMonsterScriptArray)//第二波先8个monster
        {
            enemyArray.Add(m.Enemy(monster));
        }

        yield return new WaitForSeconds(3f);

        foreach (CreateMonster m in createMonsterScriptArray)//第二波再8个monster
        {
            enemyArray.Add(m.Enemy(monster));

            yield return new WaitForSeconds(0.6f);
        }

        while (enemyArray.Count > 0)//集合部位空表示场上还有敌人
        {
            yield return new WaitForSeconds(1f);//一直延迟生成下一波敌人
        }

        foreach (CreateBoss b in createBossScriptArray)//第三波3个boss
        {
            enemyArray.Add(b.Enemy(boss));

            yield return new WaitForSeconds(3f);
        }
    }
    #endregion
}

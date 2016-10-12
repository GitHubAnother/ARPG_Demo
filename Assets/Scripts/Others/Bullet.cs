/*
作者名称:YHB

脚本作用:子弹脚本

建立时间:2016.8.17.9.50
*/

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    #region 字段
    [HideInInspector]
    public float attack;

    private float moveSpeed = 10f;
    #endregion

    #region Unity内置函数
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    #endregion

    #region  触发函数
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Boss" || col.tag == "Monster")
        {
            col.GetComponent<AttackAndDamage>().Damage(attack);
        }
    }
    #endregion
}

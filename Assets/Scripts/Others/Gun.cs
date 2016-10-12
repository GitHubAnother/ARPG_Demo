/*
作者名称:YHB

脚本作用:枪

建立时间:2016.8.17.9.49
*/

using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    #region 字段
    [HideInInspector]
    public float attack = 66;

    public GameObject bullet;

    private Transform shotPoint;
    #endregion

    #region Unity内置函数
    void Start()
    {
        shotPoint = this.transform.FindChild("BulletSpawnPosition");
    }
    #endregion

    #region 枪发射子弹的方法
    public void Shot()
    {
        GameObject go = Instantiate(bullet, shotPoint.position, this.transform.root.rotation) as GameObject;
        go.GetComponent<Bullet>().attack = this.attack;
    }
    #endregion
}

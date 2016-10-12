/*
作者名称:YHB

脚本作用:控制小地图中玩家与敌人的icon

建立时间:2016.8.18.14.17
*/

using UnityEngine;
using System.Collections;

public class MinimapIcon : MonoBehaviour
{
    #region 字段
    public static MinimapIcon _i;

    public GameObject iconPrefab;

    private Transform player;
    #endregion

    #region Unity内置函数
    void Awake()
    {
        _i = this;
        player = this.transform.FindChild("PlayerIcon");
    }
    #endregion

    #region   返回PlayerIcon的Transform
    public Transform PlayerTransform()
    {
        return player;
    }
    #endregion

    #region 返回Boss的icon的gameobject
    public GameObject BossIconGameObject()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, iconPrefab);
        go.GetComponent<UISprite>().spriteName = "BossIcon";
        return go;
    }
    #endregion

    #region 返回Monster的icon的gameobject
    public GameObject MonsterIconGameObject()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, iconPrefab);
        go.GetComponent<UISprite>().spriteName = "EnemyIcon";
        return go;
    }
    #endregion
}

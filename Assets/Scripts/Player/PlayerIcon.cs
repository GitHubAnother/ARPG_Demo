/*
作者名称:YHB

脚本作用:用来同步小地图上的图标的旋转方向

建立时间:2016.8.18.14.22
*/

using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour
{
    #region 字段
    private Transform playerTransform;
    #endregion

    #region Unity内置函数
    void Start()
    {
        playerTransform = MinimapIcon._i.PlayerTransform();
    }
    void Update()
    {
        SynchronizationRotation();
    }
    #endregion

    #region 同步Rotation
    void SynchronizationRotation()
    {
        float y = this.transform.localEulerAngles.y;

        playerTransform.eulerAngles = new Vector3(0, 0, -y);
    }
    #endregion
}

/*
作者名称:YHB

脚本作用:道具自旋转

建立时间:2016.8.18.9.31
*/

using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(Vector3.up * 6.6f);
    }
}

/*
作者名称:YHB

脚本作用:特效自动销毁脚本

建立时间:2016.8.17.13.04
*/

using UnityEngine;
using System.Collections;

public class DestroyFX : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }
}

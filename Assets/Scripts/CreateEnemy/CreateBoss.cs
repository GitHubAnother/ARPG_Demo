/*
作者名称:YHB

脚本作用:生成boss

建立时间:2016.8.16.11.22
*/

using UnityEngine;
using System.Collections;

public class CreateBoss : MonoBehaviour
{
    public GameObject Enemy(GameObject prefab)
    {
        GameObject go = Instantiate(prefab, this.transform.position, Quaternion.identity) as GameObject;

        return go;
    }
}

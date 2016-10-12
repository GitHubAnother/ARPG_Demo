/*
作者名称:YHB

脚本作用:根据攻击模式来切换UI的显示

建立时间:
*/

using UnityEngine;
using System.Collections;

public class AttackModl_UI : MonoBehaviour
{
    #region 字段
    public static AttackModl_UI _i;

    private GameObject normalAttack;
    private GameObject rangeAttack;
    private GameObject redAttack;
    #endregion

    #region Unity内置函数
    void Awake()
    {
        _i = this;
    }
    void Start()
    {
        normalAttack = this.transform.FindChild("normalAttack").gameObject;
        rangeAttack = this.transform.FindChild("rangeAttack").gameObject;
        redAttack = this.transform.FindChild("redAttack").gameObject;
    }
    #endregion

    #region 外调
    public void SingleAndDual_AttackUI()
    {
        normalAttack.SetActive(true);
        rangeAttack.SetActive(true);
        redAttack.SetActive(false);
    }
    public void Gun_AttackUI()
    {
        normalAttack.SetActive(false);
        rangeAttack.SetActive(false);
        redAttack.SetActive(true);
    }
    #endregion
}

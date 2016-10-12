/*
作者名称:YHB

脚本作用:读取main场景的换装信息

建立时间:2016.8.18.16.43
*/

using UnityEngine;
using System.Collections;

public class PlayerReadyCos : MonoBehaviour
{
    #region 字段
    private SkinnedMeshRenderer _AHead;
    private SkinnedMeshRenderer _BUpperBody;
    private SkinnedMeshRenderer _CLowerBody;
    private SkinnedMeshRenderer _DHand;
    private SkinnedMeshRenderer _EFoot;
    #endregion

    #region Unity内置函数
    void Start()
    {
        _AHead = this.transform.FindChild("AHead").GetComponent<SkinnedMeshRenderer>();
        _BUpperBody = this.transform.FindChild("BUpperBody").GetComponent<SkinnedMeshRenderer>();
        _CLowerBody = this.transform.FindChild("CLowerBody").GetComponent<SkinnedMeshRenderer>();
        _DHand = this.transform.FindChild("DHand").GetComponent<SkinnedMeshRenderer>();
        _EFoot = this.transform.FindChild("EFoot").GetComponent<SkinnedMeshRenderer>();

        ReadyInit();
    }
    #endregion

    #region  读取换装信息
    void ReadyInit()
    {
        int headIndex = PlayerPrefs.GetInt("HeadIndex");
        int upperBodyIndex = PlayerPrefs.GetInt("UpperBodyIndex");
        int lowerBodyIndex = PlayerPrefs.GetInt("LowerBodyIndex");
        int handIndex = PlayerPrefs.GetInt("HandIndex");
        int footIndex = PlayerPrefs.GetInt("FootIndex");

        int colorIndex = PlayerPrefs.GetInt("ColorIndex");

        _AHead.sharedMesh = Cosplay._i.head[headIndex];
        _BUpperBody.sharedMesh = Cosplay._i.upperBody[upperBodyIndex];
        _CLowerBody.sharedMesh = Cosplay._i.lowerBody[lowerBodyIndex];
        _DHand.sharedMesh = Cosplay._i.hand[handIndex];
        _EFoot.sharedMesh = Cosplay._i.hand[footIndex];

        _AHead.material.color = Cosplay._i.colorArray[colorIndex];
        _BUpperBody.material.color = Cosplay._i.colorArray[colorIndex];
        _CLowerBody.material.color = Cosplay._i.colorArray[colorIndex];
        _DHand.material.color = Cosplay._i.colorArray[colorIndex];
        _EFoot.material.color = Cosplay._i.colorArray[colorIndex];
    }
    #endregion
}

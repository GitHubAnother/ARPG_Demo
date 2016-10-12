/*
作者名称:YHB

脚本作用:换装

建立时间:2016.8.14.10.45
*/

using UnityEngine;

public class Cosplay : MonoBehaviour
{
    #region 字段
    public static Cosplay _i;

    public GameObject player;
    public Color violet;//紫色

    #region  player5个部位的渲染器和5个部位用来换装的mesh和颜色

    #region  SkinnedMeshRenderer
    private SkinnedMeshRenderer _AHead;
    private SkinnedMeshRenderer _BUpperBody;
    private SkinnedMeshRenderer _CLowerBody;
    private SkinnedMeshRenderer _DHand;
    private SkinnedMeshRenderer _EFoot;
    #endregion

    #region 头
    public Mesh[] head;
    private int headIndex = 0;
    #endregion

    #region 身体
    public Mesh[] upperBody;
    private int upperBodyIndex = 0;
    #endregion

    #region 腿部
    public Mesh[] lowerBody;
    private int lowerBodyIndex = 0;
    #endregion

    #region 手部
    public Mesh[] hand;
    private int handIndex = 0;
    #endregion

    #region 脚
    public Mesh[] foot;
    private int footIndex = 0;
    #endregion

    #region 颜色
    [HideInInspector]
    public Color[] colorArray;
    private int colorIndex = -1;
    #endregion

    #endregion

    #endregion

    #region Unity内置函数
    void Awake()
    {
        _i = this;
    }
    void Start()
    {
        _AHead = player.transform.FindChild("AHead").GetComponent<SkinnedMeshRenderer>();
        _BUpperBody = player.transform.FindChild("BUpperBody").GetComponent<SkinnedMeshRenderer>();
        _CLowerBody = player.transform.FindChild("CLowerBody").GetComponent<SkinnedMeshRenderer>();
        _DHand = player.transform.FindChild("DHand").GetComponent<SkinnedMeshRenderer>();
        _EFoot = player.transform.FindChild("EFoot").GetComponent<SkinnedMeshRenderer>();

        DontDestroyOnLoad(this.gameObject);//切换场景不销毁当前游戏物体

        colorArray = new Color[] { Color.blue, Color.cyan, violet, Color.green, Color.red };
    }
    #endregion

    #region 换装方法---公共
    public void CosHead()
    {
        headIndex++;
        headIndex %= head.Length;
        _AHead.sharedMesh = head[headIndex];
    }
    public void CosUpperBody()
    {
        upperBodyIndex++;
        upperBodyIndex %= upperBody.Length;
        _BUpperBody.sharedMesh = upperBody[upperBodyIndex];
    }
    public void CosLowerBody()
    {
        lowerBodyIndex++;
        lowerBodyIndex %= lowerBody.Length;
        _CLowerBody.sharedMesh = lowerBody[lowerBodyIndex];
    }
    public void CosHand()
    {
        handIndex++;
        handIndex %= hand.Length;
        _DHand.sharedMesh = hand[handIndex];
    }
    public void CosFoot()
    {
        footIndex++;
        footIndex %= foot.Length;
        _EFoot.sharedMesh = foot[footIndex];
    }
    #endregion

    #region 换色方法---公共
    public void Bluer()
    {
        colorIndex = 0;
        ChangColor(Color.blue);
    }
    public void Cyan()
    {
        colorIndex = 1;
        ChangColor(Color.cyan);
    }
    public void Violet()
    {
        colorIndex = 2;
        ChangColor(violet);
    }
    public void Green()
    {
        colorIndex = 3;
        ChangColor(Color.green);
    }
    public void Red()
    {
        colorIndex = 4;
        ChangColor(Color.red);
    }
    #endregion

    #region -ChangColor统一换色方法
    void ChangColor(Color color)
    {
        _AHead.material.color = color;
        _BUpperBody.material.color = color;
        _CLowerBody.material.color = color;
        _DHand.material.color = color;
        _EFoot.material.color = color;
    }
    #endregion

    #region -Save开始游戏的一些方法---保存  切换场景
    void Save()
    {
        PlayerPrefs.SetInt("HeadIndex", headIndex);
        PlayerPrefs.SetInt("UpperBodyIndex", upperBodyIndex);
        PlayerPrefs.SetInt("LowerBodyIndex", lowerBodyIndex);
        PlayerPrefs.SetInt("HandIndex", handIndex);
        PlayerPrefs.SetInt("FootIndex", footIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
    }
    #endregion

    #region +Play开始游戏
    public void Play()
    {
        Save();//点击play按钮线保存一下当前的设置,在切换场景
        Application.LoadLevel(1);
    }
    #endregion
}

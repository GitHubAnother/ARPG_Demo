/*
作者名称:YHB

脚本作用:处理道具的掉落触发

建立时间:2016.8.18.9.23
*/

using UnityEngine;
using System.Collections;

//道具枚举
public enum ItemType
{
    Gun,
    Knife
}

public class AwardItem : MonoBehaviour
{
    #region 字段
    public ItemType itemType;
    public float lerpSpeed;

    private GameObject player;
    private Item item;
    private Rigidbody r3d;
    private BoxCollider boxCol;
    private SphereCollider sphereCol;
    private bool isMove = false;//表示玩家吃到道具，道具往玩家色身上移动
    #endregion

    #region Unity内置函数
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ASD");
        item = player.GetComponent<Item>();
        r3d = this.GetComponent<Rigidbody>();
        boxCol = this.GetComponent<BoxCollider>();
        sphereCol = this.GetComponent<SphereCollider>();

        r3d.velocity = new Vector3(Random.Range(-6.6f, 6.6f), 0, Random.Range(-6.6f, 6.6f));
    }
    void Update()
    {
        ItemMove();
    }
    #endregion

    #region  碰撞检测---碰到地面停止运动，关闭box碰撞器打开sphere触发器
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            r3d.useGravity = false;//关闭重力
            r3d.isKinematic = true;//打开动力学

            boxCol.enabled = false;
            sphereCol.enabled = true;
        }
    }
    #endregion

    #region  触发检测
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ASD")
        {
            isMove = true;
        }
    }
    #endregion

    #region 道具移动
    void ItemMove()
    {
        if (isMove)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + Vector3.up, lerpSpeed * Time.deltaTime);

            // iTween.MoveTo(this.gameObject, player.transform.position + Vector3.up, timer);//运动不平滑

            //往玩家身上移动过程中进行距离的判断，小于指定距离调用玩家身上的脚本，并销毁当前道具物体
            if (Vector3.Distance(this.transform.position, player.transform.position + Vector3.up) < 0.36f)
            {
                item.GetItem(itemType);
                Destroy(this.gameObject);
            }
        }
    }
    #endregion
}

/*
作者名称:YHB

脚本作用:构建拖痕

建立时间:2016.8.18.15.57
*/

using UnityEngine;
using System.Collections;

public class myTrail : MonoBehaviour
{
    public WeaponTrail myT;

    private float t = 0.033f;
    private float tempT = 0;
    private float anim = 0.003f;

    void LateUpdate()
    {
        t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);

        if (t > 0)
        {
            while (tempT < t)
            {
                tempT += anim;

                if (myT.time > 0)
                {
                    myT.Itterate(Time.time - t + tempT);
                }
                else
                {
                    myT.ClearTrail();
                }
            }

            tempT -= t;

            if (myT.time > 0)
            {
                myT.UpdateTrail(Time.time, t);
            }

        }
    }
}

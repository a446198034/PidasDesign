using UnityEngine;
using System.Collections;

/// <summary>
/// 这个类管理微波组合用的
/// </summary>
public class MicrowaveGroupManager : MonoBehaviour {

    /// <summary>
    /// 详细信息
    /// </summary>
    public MicrowaveDao MyMicrowaveDao;

    public GameObject Microwave_First;
    public GameObject Microwave_Second;
    public GameObject TeXiaoObj;
    public Transform MiddleTran;

    MicrowaveManager mm_first;
    MicrowaveManager mm_second;
    MoveTextureOffset mmo;
    // Use this for initialization
    void Start() {
      
    }

    public void initMySelf()
    {
        mm_first = Microwave_First.GetComponent<MicrowaveManager>();
        mm_second = Microwave_Second.GetComponent<MicrowaveManager>();
        mmo = TeXiaoObj.GetComponent<MoveTextureOffset>();
    }

    #region 特效

    /// <summary>
    /// 控制特效的外部方法
    /// </summary>
    /// <param name="s"></param>
    public void OnShowTeXiao(bool s)
    {
        mmo.IsRend = s;
    }

    /// <summary>
    /// 获取特效状态
    /// </summary>
    /// <returns></returns>
    public bool getTeXiaoRend()
    {
        return mmo.IsRend;
    }



    #endregion

    #region 关于两个头部的操作

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public GameObject getFirstHead()
    {
        return mm_first.MyHeadObj;
    }
    public void setFirstHeadPostion(Vector3 v)
    {
        mm_first.MyHeadObj.transform.position = v;
    }
    public GameObject getSecondHead()
    {
        return mm_second.MyHeadObj;
    }
    public void setSecondHeadPosition(Vector3 v)
    {
        mm_second.MyHeadObj.transform.position = v;
    }

    #endregion

    #region 操作详细信息

    public void setChangKuan(float f)
    {
        MyMicrowaveDao.ChangKuan = f;
    }

    public void setMachinehigh(float f)
    {
        MyMicrowaveDao.MachineHigh = f;
    }

    #endregion

    /// <summary>
    /// 给设备添加ID
    /// </summary>
    public void setMachineId()
    {
        mm_first.setMachineID();
        mm_second.setMachineID();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    public void OnShowCollider(bool s)
    {
        mm_first.OnShowCollider(s);
        mm_second.OnShowCollider(s);
    }

    #region 判断点击的物体在不在这里面

    /// <summary>
    /// 判断点击的物体是否在First 里面
    /// </summary>
    /// <param name="tt"></param>
    /// <returns></returns>
    public Transform isObjectInFirst(Transform tt)
    {
        Transform res = null;
        mm_first.OnShowHighLight(false);
        if (mm_first.MyHeadObj == tt.gameObject)
        {
            res = mm_first.MyHeadObj.transform;
            mm_first.OnShowHighLight(true);
        }
        else if (mm_first.MyBodyObj == tt.gameObject)
        {
            res = mm_first.MyBodyObj.transform;
            mm_first.OnShowHighLight(true);
        }

        return res;
    }

    /// <summary>
    /// 判断点击的物体是否在Second 里面 
    /// </summary>
    /// <param name="tt"></param>
    /// <returns></returns>
    public Transform isObjInSecond(Transform tt)
    {
        Transform res = null;
        mm_second.OnShowHighLight(false);

        if (mm_second.MyHeadObj == tt.gameObject)
        {
            res = mm_second.MyHeadObj.transform;
            mm_second.OnShowHighLight(true);
        }
        else if (mm_second.MyBodyObj == tt.gameObject)
        {
            res = mm_second.MyBodyObj.transform;
            mm_second.OnShowHighLight(true);
        }

        return res;

    }


    #endregion

    void Update()
    {
        UpdateMiddleTranPosition();
        UpdateTeXiaoPosition();
    }

    /// <summary>
    /// 实时更新特效的位置
    /// </summary>
    void UpdateTeXiaoPosition()
    {
        TeXiaoObj.transform.position = mm_first.ChangPos.position;

        Vector3 offsetPos = Microwave_Second.transform.position - Microwave_First.transform.position;
        float angle = Vector3.Angle(Vector3.right, offsetPos);
        angle = 180 - angle;

        //方向纠正
        angle = Microwave_Second.transform.position.z < Microwave_First.transform.position.z ? angle * -1 : angle;

        //微波特效自行矫正
        angle -= 90;

        Vector3 r = TeXiaoObj.transform.rotation.eulerAngles;
        r.y = angle;
        TeXiaoObj.transform.rotation = Quaternion.Euler(r);

        //Scale  y = n * 1 + 0.4 * (n - 1)
        float distance = Mathf.Abs(Vector3.Distance(mm_second.MyHeadObj.transform.position, mm_first.MyHeadObj.transform.position));

        float Scale_Z = distance * 1 + 0.4f * (distance - 1);
        Vector3 ss = TeXiaoObj.transform.localScale;
        ss.z = Scale_Z;
        TeXiaoObj.transform.localScale = ss;
    }

   
    /// <summary>
    /// 让两个微波一直看着中间点
    /// </summary>
    void UpdateMiddleTranPosition()
    {
        Vector3 MiddlePos = Microwave_Second.transform.position - Microwave_First.transform.position;
        MiddleTran.position = Microwave_First.transform.position + MiddlePos / 2.0f;

        Microwave_First.transform.LookAt(MiddleTran);
        Microwave_Second.transform.LookAt(MiddleTran);

        Vector3 f = Microwave_First.transform.rotation.eulerAngles;
        f.x = 0;

        f.y = 180 - f.y;
        f.y *= -1;
        f.y = f.y < 0 ? f.y + 360 : f.y;

        f.z = 0;
        Microwave_First.transform.rotation = Quaternion.Euler(f);
      
        Vector3 s = Microwave_Second.transform.rotation.eulerAngles;
        s.x = 0;

        s.y = 180 - s.y;
        s.y *= -1;
        s.y = s.y < 0 ? s.y + 360 : s.y;

        s.z = 0;
        Microwave_Second.transform.rotation = Quaternion.Euler(s);
    }

}

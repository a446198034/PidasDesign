using UnityEngine;
using System.Collections;

/// <summary>
/// 这个类是红外对射的组合
/// </summary>
public class InfraredGroupManager : MonoBehaviour {

    /// <summary>
    ///  详细信息
    /// </summary>
    public InfraredDao MyInfraredDao;

    public GameObject Infrared_First;
    public GameObject Infrared_Second;
    public GameObject TexiaoObj;
    public Transform TeXiaoChangPos;
    public Transform MiddelTran;

    MoveTextureOffset mto;

	// Use this for initialization
	void Start () {
	
	}

    public void initMySelf()
    {
        mto = TexiaoObj.GetComponent<MoveTextureOffset>();
    }


    #region 特效

    /// <summary>
    /// 控制特效的外部方法
    /// </summary>
    /// <param name="s"></param>
    public void OnShowTeXiao(bool s)
    {
        mto.IsRend = s;
    }

    /// <summary>
    /// 返回特效的状态
    /// </summary>
    /// <returns></returns>
    public bool getTeXiaoRend()
    {
        return mto.IsRend;
    }

    /// <summary>
    /// 设置Rend的速度 X
    /// </summary>
    /// <param name="f"></param>
    public void setTeXiaoRend_X(float f)
    {
        mto.scrollSpeedX = f;
    }

    #endregion

    #region 详细信息

    /// <summary>
    /// 设置密度 XX
    /// </summary>
    /// <param name="f"></param>
    public void setInfraredDensity_X(float f)
    {
        MyInfraredDao.InfraredDensity_X = f;
    }

    /// <summary>
    /// 设置密度  YY
    /// </summary>
    /// <param name="f"></param>
    public void setInfraredDensity_Y(float f)
    {
        MyInfraredDao.InfraredDensity_Y = f;
    }

    /// <summary>
    /// 设置对射的速度
    /// </summary>
    /// <param name="f"></param>
    public void setInfraredSpeed(float f)
    {
        MyInfraredDao.InfraredSpeed = f;
    }
    #endregion

    #region Public Function


    /// <summary>
    /// 添加设备ID
    /// </summary>
    public void setMachineId()
    {
        EquipmentSelfDetail ess1 = Infrared_First.GetComponent<EquipmentSelfDetail>();
        EquipmentSelfDetail ess2 = Infrared_Second.GetComponent<EquipmentSelfDetail>();

        ess1.MyEquipmentDao.setANewGuid();
        ess2.MyEquipmentDao.setANewGuid();
    }

    /// <summary>
    /// BoxCollider
    /// </summary>
    /// <param name="s"></param>
    public void OnShowCollider(bool s)
    {
        Infrared_First.GetComponent<BoxCollider>().enabled = s;
        Infrared_Second.GetComponent<BoxCollider>().enabled = s;
    }

    /// <summary>
    /// 判断物体在不在这里面
    /// </summary>
    /// <param name="tt"></param>
    /// <returns></returns>
    public Transform isObjectInList(Transform tt)
    {
        Transform res = null;
        OnShowHighLight(false);
        if (Infrared_First.transform == tt)
        {
            res = Infrared_First.transform;
        }
        else if (Infrared_Second.transform == tt)
        {
            res = Infrared_Second.transform;
        }

        if (null != res)
            OnShowHighLight(true);

        return res;

    }

    /// <summary>
    /// 控制物体外圈高亮
    /// </summary>
    /// <param name="s"></param>
    public void OnShowHighLight(bool s)
    {
        MachineHighLightController mcc1 = Infrared_First.GetComponent<MachineHighLightController>();
        MachineHighLightController mcc2 = Infrared_Second.GetComponent<MachineHighLightController>();

        mcc1.OnShowHighLight(s);
        mcc1.MyStateControl(s);

        mcc2.OnShowHighLight(s);
        mcc2.MyStateControl(s);
    }


    #endregion


    void Update()
    {
        UpdateTeXiaoPosition();
        UpdateMiddleTranPosition();
    }

    #region Update


    /// <summary>
    /// 实时更新特效的位置
    /// </summary>
    void UpdateTeXiaoPosition()
    {
        TexiaoObj.transform.position = TeXiaoChangPos.position;

        Vector3 offsetPos = Infrared_Second.transform.position - Infrared_First.transform.position;
        float angle = Vector3.Angle(Vector3.right, offsetPos);
        angle = 180 - angle;

        //方向纠正
        angle = Infrared_Second.transform.position.z < Infrared_First.transform.position.z ? angle * -1 : angle;

        //微波特效自行矫正
        //angle -= 90;

        Vector3 r = TexiaoObj.transform.rotation.eulerAngles;
        r.y = angle;
        TexiaoObj.transform.rotation = Quaternion.Euler(r);

        //Scale y = 0.4 * n + n * 0.006
        float distance = Mathf.Abs(Vector3.Distance(Infrared_Second.transform.position,Infrared_First.transform.position));

        float ScaleX = distance * 0.1f + distance * 0.006f;
        Vector3 ss = TexiaoObj.transform.localScale;
        ss.x = ScaleX;
        TexiaoObj.transform.localScale = ss; 

    }

    /// <summary>
    /// 让两个红外一直看着中间点
    /// </summary>
    void UpdateMiddleTranPosition()
    {
        Vector3 MiddlePos = Infrared_Second.transform.position - Infrared_First.transform.position;
        MiddelTran.position = Infrared_First.transform.position + MiddlePos / 2.0f;

        Infrared_First.transform.LookAt(MiddelTran);
        Infrared_Second.transform.LookAt(MiddelTran);

        Vector3 f = Infrared_First.transform.rotation.eulerAngles;
        f.x = 0;

        f.y = 180 - f.y;
        f.y *= -1;
        f.y = f.y < 0 ? f.y + 360 : f.y;
        f.y -= 90;

        f.z = 0;
        Infrared_First.transform.rotation = Quaternion.Euler(f);

        Vector3 s = Infrared_Second.transform.rotation.eulerAngles;
        s.x = 0;

        s.y = 180 - s.y;
        s.y *= -1;
        s.y = s.y < 0 ? s.y + 360 : s.y;
        s.y -= 90;

        s.z = 0;
        Infrared_Second.transform.rotation = Quaternion.Euler(s);
    }


    #endregion


}

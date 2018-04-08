using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 控制设备旋转的类
/// </summary>
public class MachineTransformController : MonoBehaviour {

    [Header("场的位置点")]
    public List<Transform> ChangPositionList;

    [Header("设备场旋转的点，没有值就旋转自身")]
    public Transform MachineRotatePoint = null;
    Transform RotateTran = null;

    [Header("初始旋转值")]
    public Vector3 InitRotation;

    EquipmentRotationDao HengRotationDao = null;
    EquipmentRotationDao ShuRotationDao = null;

    // Use this for initialization
    void Start () {
        initHengShuRotateDoa();
    }


    #region 公有方法

    /// <summary>
    /// 设置相机场的位置
    /// </summary>
    /// <param name="FirstCamTran"></param>
    /// <param name="SecondCamTran"></param>
    public void SetCamMesgPosition(Transform FirstCamTran, Transform SecondCamTran)
    {
        FirstCamTran.SetParent(ChangPositionList[0]);
        FirstCamTran.localPosition = Vector3.zero;
        FirstCamTran.localRotation = Quaternion.Euler(InitRotation);

        if (ChangPositionList.Count > 1)
        {
            SecondCamTran.SetParent(ChangPositionList[1]);
            SecondCamTran.localPosition = Vector3.zero;
            SecondCamTran.localRotation = Quaternion.Euler(InitRotation);
        }

    }

    /// <summary>
    /// 设置横向旋转值
    /// </summary>
    /// <param name="f"></param>
    public void setRotate_Value_X(float f)
    {
        setRotateAngle(f,false);
    }

    /// <summary>
    /// 设置竖向旋转值
    /// </summary>
    /// <param name="f"></param>
    public void setRotate_Value_Y(float f)
    {
        setRotateAngle(f,true);
    }

    #endregion

    #region 本地方法

    /// <summary>
    /// 设置旋转
    /// </summary>
    /// <param name="f"></param>
    /// <param name="isY"></param>
    void setRotateAngle(float f, bool isY)
    {
        initHengShuRotateDoa();

        if (null == RotateTran && null != MachineRotatePoint)
        {
            RotateTran = MachineRotatePoint;
        }

        Quaternion qua = null == RotateTran ? transform.rotation : MachineRotatePoint.rotation;
        Vector3 v = qua.eulerAngles;
        if (isY)
        {
            switch (HengRotationDao.RotateAxis)
            {
                case ControlAxis.Axis_X: v.x = f; v.x = HengRotationDao.isNeedFuShu ? v.x * -1 : v.x; break;
                case ControlAxis.Axis_Y: v.y = f; v.y = HengRotationDao.isNeedFuShu ? v.y * -1 : v.y; break;
                case ControlAxis.Axis_Z: v.z = f; v.z = HengRotationDao.isNeedFuShu ? v.z * -1 : v.z; break;
            }
            //赋值value的值
            HengRotationDao.RotateValue = f;
        }
        else
        {
            switch (ShuRotationDao.RotateAxis)
            {
                case ControlAxis.Axis_X: v.x = f; v.x = ShuRotationDao.isNeedFuShu ? v.x * -1 : v.x; break;
                case ControlAxis.Axis_Y: v.y = f; v.y = ShuRotationDao.isNeedFuShu ? v.y * -1 : v.y; break;
                case ControlAxis.Axis_Z: v.z = f; v.z = ShuRotationDao.isNeedFuShu ? v.z * -1 : v.z; break;
            }
            //赋值value的值
            ShuRotationDao.RotateValue = f;
        }
        Quaternion qqq = Quaternion.Euler(v);
        if (null == RotateTran)
        {
            transform.rotation = qqq;
        }
        else
        {
            MachineRotatePoint.rotation = qqq;
        }
    }



    /// <summary>
    /// 初始化横竖两个旋转的类
    /// </summary>
    void initHengShuRotateDoa()
    {
        if (null == HengRotationDao)
        {
            HengRotationDao = GetComponent<Equipment_Camera_Qiangji>().MyEquipmentDao.HengRotate;
        }

        if (null == ShuRotationDao)
        {
            ShuRotationDao = GetComponent<Equipment_Camera_Qiangji>().MyEquipmentDao.ShuRotate;
        }
    }

    #endregion

}

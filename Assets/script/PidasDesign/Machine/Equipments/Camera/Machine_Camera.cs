using UnityEngine;
using System.Collections;

/// <summary>
/// 这个是所有相机的父类
/// </summary>
public class Machine_Camera : EquipmentSelfDetail {

    [Header("我的特殊属性")]
    public CameraDao MyCamdao;

    [Header("摄像机类型")]
    public CameraMachineType CamType = CameraMachineType.QiangJi;


    #region Public Function

    /// <summary>
    /// 设置感光元器件类型
    /// </summary>
    /// <param name="f"></param>
    public void setMyPhotoreceptor(float f)
    {
        MyCamdao.MyPhotoreceptorType = GlogalData.getPhotoreceptorType(f);
    }

    /// <summary>
    /// 设置FOV 的值
    /// </summary>
    /// <param name="f"></param>
    public void setFOVValue(float f)
    {
        MyCamdao.FOV_Value = f;
    }

    /// <summary>
    /// 设置焦距
    /// </summary>
    /// <param name="f"></param>
    public void setValidDistance(float f)
    {
        MyCamdao.ValidDistance = f;
    }

    /// <summary>
    /// 获取摄像机的类型
    /// 枪机  球机  半球
    /// </summary>
    /// <returns></returns>
    public string getMyCameraMachineType()
    {
        string res = "";
        switch (CamType)
        {
            case CameraMachineType.BanQiu: res = "半球"; break;
            case CameraMachineType.QiangJi: res = "枪机"; break;
            case CameraMachineType.Qiu: res = "球机";break;
        }
        return res;
    }

    #endregion


}

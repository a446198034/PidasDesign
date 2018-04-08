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

    

}

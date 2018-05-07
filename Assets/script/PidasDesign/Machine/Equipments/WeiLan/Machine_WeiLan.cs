using UnityEngine;
using System.Collections;

/// <summary>
/// 这个类是所有围栏的父对象
/// </summary>

[RequireComponent(typeof(MachineTransformController))]
[RequireComponent(typeof(MachineHighLightController))]
public class Machine_WeiLan : EquipmentSelfDetail {

    [Header("设备类型")]
    public MachineType MyMachinetype = MachineType.WeiLan;


    protected override void SonInit()
    {
        setMachineType(MyMachinetype);
    }
}

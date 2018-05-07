using UnityEngine;
using System.Collections;

/// <summary>
/// 这个类是所有红外的父对象
/// </summary>

[RequireComponent(typeof(MachineTransformController))]
[RequireComponent(typeof(MachineHighLightController))]
public class Machine_Infrared : EquipmentSelfDetail {
    
    [Header("设备类型")]
    public MachineType myMachinetype = MachineType.Infrared;

    [Header("我的父对象")]
    public GameObject MyFatherManagerObj;
    InfraredGroupManager ifm;

    protected override void SonInit()
    {
        ifm = MyFatherManagerObj.GetComponent<InfraredGroupManager>();
        setMachineType(myMachinetype);
    }

}

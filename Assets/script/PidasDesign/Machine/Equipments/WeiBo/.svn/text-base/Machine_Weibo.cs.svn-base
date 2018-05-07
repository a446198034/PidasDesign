using UnityEngine;
using System.Collections;


/// <summary>
/// 这个类是所有微波的父对象
/// </summary>

[RequireComponent(typeof(MachineTransformController))]
[RequireComponent(typeof(MachineHighLightController))]
public class Machine_Weibo : EquipmentSelfDetail {

    [Header("设备类型")]
    public MachineType MyMachinetype = MachineType.Microwave;

    [Header("我的父对象")]
    public GameObject MyFatherManagerObj;
    MicrowaveManager mm;

    protected override void SonInit()
    {
        mm = MyFatherManagerObj.GetComponent<MicrowaveManager>();
        setMachineType(MyMachinetype);
    }

    protected override void HighOn()
    {
        mm.SetMicrowaveHighOnOff(true,gameObject);
    }

    protected override void HighOff()
    {
        mm.SetMicrowaveHighOnOff(false, gameObject);
    }

}

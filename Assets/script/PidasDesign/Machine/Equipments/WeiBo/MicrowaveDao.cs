using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class MicrowaveDao  {

    /// <summary>
    /// 设备类别名称
    /// </summary>
    public string MachineTypeName;

    /// <summary>
    /// 设备名称
    /// </summary>
    public string MyName;

    /// <summary>
    /// 设备型号
    /// </summary>
    public string MachineVersion;

    /// <summary>
    /// 场宽
    /// </summary>
    public float ChangKuan;

    /// <summary>
    /// 设备高度
    /// </summary>
    public float MachineHigh;

    public MicrowaveDao()
    {
        MachineTypeName = "微波对射";
        MyName = "微波一号";
        MachineVersion = "AB-CD";
        ChangKuan = 3.4f;
        MachineHigh = 1.4f;
    }

}

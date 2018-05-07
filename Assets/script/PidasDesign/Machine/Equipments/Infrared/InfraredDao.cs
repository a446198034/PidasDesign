using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class InfraredDao  {

    /// <summary>
    /// 设备类型名称
    /// </summary>
    public string MachineTypeName;

    /// <summary>
    /// 设备名称
    /// </summary>
    public string MyName;

    /// <summary>
    /// 设备型号
    /// </summary>
    public string MaachineVersion;

    /// <summary>
    /// 红外线的密度 X
    /// </summary>
    public float InfraredDensity_X;

    /// <summary>
    /// 红外线的密度 Y
    /// </summary>
    public float InfraredDensity_Y;

    /// <summary>
    /// 对射的速度
    /// </summary>
    public float InfraredSpeed;


    public InfraredDao()
    {
        MachineTypeName = "红外对射";
        MyName = "红外对射一号";
        MaachineVersion = "AA-xx-XX";
        InfraredDensity_X = 4;
        InfraredDensity_Y = 16;
        InfraredSpeed = 2;
    }

}

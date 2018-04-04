using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 设备的通用类
/// </summary>
[Serializable]
public class EquipmentNormalDao  {

    /// <summary>
    /// 横向旋转类
    /// </summary>
    [Header("横向旋转")]
    public EquipmentRotationDao HengRotate;

    /// <summary>
    /// 竖直旋转类
    /// </summary>.
    [Header("竖向旋转")]
    public EquipmentRotationDao ShuRotate;


    public EquipmentNormalDao()
    {
        HengRotate = new EquipmentRotationDao();
        ShuRotate = new EquipmentRotationDao();
    }

    public EquipmentNormalDao getAnewEquipmentNormalDao(EquipmentNormalDao edd)
    {
        EquipmentNormalDao res = new EquipmentNormalDao();
        res.HengRotate = res.HengRotate.getANewEquipmentRotationDao(edd.HengRotate);
        res.ShuRotate = res.ShuRotate.getANewEquipmentRotationDao(edd.ShuRotate);
        return res;
    }
}

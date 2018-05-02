using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class EquipmentRotationDao  {

    /// <summary>
    /// 横向旋转的轴 Y值
    /// </summary>
    public ControlAxis RotateAxis = ControlAxis.Axis_Y;

    /// <summary>
    /// 横向旋转要不要负数
    /// </summary>
    public bool isNeedFuShu = false;

    /// <summary>
    /// 值
    /// </summary>
    public float RotateValue = 0;

    public EquipmentRotationDao() { }

    public EquipmentRotationDao getANewEquipmentRotationDao(EquipmentRotationDao edd)
    {
        EquipmentRotationDao res = new EquipmentRotationDao();
        res.RotateAxis = edd.RotateAxis;
        res.isNeedFuShu = edd.isNeedFuShu;
        res.RotateValue = edd.RotateValue;
        return res;
    }


}

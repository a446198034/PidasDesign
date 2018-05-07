using UnityEngine;
using System.Collections;

/// <summary>
/// 设备总类
/// 所有的设备都继承这个类
/// </summary>
public class EquipmentSelfDetail : MonoBehaviour {

    [Header("通用属性")]
    public EquipmentNormalDao MyEquipmentDao;

    MachineType MyMachineType;

    #region 儿子能用的方法

    /// <summary>
    /// 儿子的初始化
    /// </summary>
    protected virtual void SonInit() { }

    /// <summary>
    /// 高亮显示的时候
    /// </summary>
    protected virtual void HighOn() { }

    /// <summary>
    /// 高亮灭掉
    /// </summary>
    protected virtual void HighOff() { }

    #endregion

    #region 公有方法

    /// <summary>
    ///  设备高亮显示的回调
    /// </summary>
    /// <param name="s"></param>
    public void EquipmentHighOnOff(bool s)
    {
        if (s)
            HighOn();
        else
            HighOff();
    }

    /// <summary>
    /// 获取我的设备类型
    /// </summary>
    /// <returns></returns>
    public MachineType getMyMachineType()
    {
        return MyMachineType;
    }

    public void setMachineType(MachineType mt)
    {
        MyMachineType = mt;
    }
    #endregion



    // Use this for initialization
    void Start () {

        SonInit();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

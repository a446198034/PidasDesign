using UnityEngine;
using System.Collections;

/// <summary>
/// 这个是所有相机的父类
/// </summary>
public class Machine_Camera : MonoBehaviour {

    [Header("通用属性")]
    public EquipmentNormalDao MyEquipmentDao;

    [Header("我的特殊属性")]
    public CameraDao MyCamdao;

    [Header("摄像机类型")]
    public CameraMachineType CamType = CameraMachineType.QiangJi;

    

    #region 儿子能用的方法

    /// <summary>
    /// 儿子的初始化
    /// </summary>
    protected virtual void SonInit() { }


    #endregion

    #region 公有方法




    #endregion

    // Use this for initialization
    void Start () {


        SonInit();
	}

    // Update is called once per frame
    void Update()
    {

    }

}

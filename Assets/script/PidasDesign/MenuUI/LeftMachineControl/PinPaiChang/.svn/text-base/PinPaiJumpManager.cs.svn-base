using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 设备类型跳转页面管理
/// </summary>
public class PinPaiJumpManager : MonoBehaviour {


    [Header("品牌设置页面")]
    public List<GameObject> MachineTypeSettingPanelObjList;

    [Header("摄像机品牌页")]
    public List<GameObject> CameraFactorySettingPanelObjList;

    [Header("围栏品牌页")]
    public List<GameObject> WeiLanFactorySettingPanelObjList;

    [Header("微波品牌页")]
    public List<GameObject> MicrowaveFactorySettingPanelObjList;

    // Use this for initialization
    void Start () {
	
	}

    /// <summary>
    /// 最左边的按钮
    /// </summary>
    /// <param name="SettingPanel"></param>
    public void UIpanelJumpManager(GameObject SettingPanel)
    {

        DisableAll();
        SettingPanel.SetActive(true);
    }

    /// <summary>
    /// 显示设备厂商
    /// </summary>
    /// <param name="go"></param>
    public void UIShowOnMachineFactory(GameObject go)
    {
        DisableAll();
        go.SetActive(true);
    }

    /// <summary>
    /// 海康品牌按钮页面 XX
    /// </summary>
    /// <param name="go"></param>
    public void Camera_HaiKang_Btn(GameObject go)
    {
        DisableAll();
        go.SetActive(true);
    }

    /// <summary>
    /// 围栏厂家一的设置页面XX
    /// </summary>
    /// <param name="go"></param>
    public void WeiLan_ChangJiaYi_Btn(GameObject go)
    {
        DisableAll();
        go.SetActive(true);
    }

    void DisableAll()
    {
        foreach (GameObject gg in MachineTypeSettingPanelObjList)
        {
            gg.SetActive(false);
        }

        foreach (GameObject gg in CameraFactorySettingPanelObjList)
        {
            gg.SetActive(false);
        }

        foreach (GameObject gg in WeiLanFactorySettingPanelObjList)
        {
            gg.SetActive(false);
        }

        foreach (GameObject gg in MicrowaveFactorySettingPanelObjList)
        {
            gg.SetActive(false);
        }

    }

}

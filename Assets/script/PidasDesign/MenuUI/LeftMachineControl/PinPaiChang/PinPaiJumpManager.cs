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
    /// 海康品牌按钮页面
    /// </summary>
    /// <param name="go"></param>
    public void Camera_HaiKang_Btn(GameObject go)
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
    }

}

using UnityEngine;
using System.Collections;

public class SettingPanelManager : MonoBehaviour {

    [Header("相机设置页面")]
    public GameObject CameraSettingPanelObj;

    SettingPanelConnectWithTransform spcwt;
	// Use this for initialization
	void Start () {
        spcwt = GetComponent<SettingPanelConnectWithTransform>();
	}


    #region Camera

    /// <summary>
    /// 显示摄像机的设置 页面
    /// </summary>
    /// <param name="go"></param>
    public void CallOnCameraSetting(GameObject go)
    {
        CameraSettingPanelObj.SetActive(true);
        CameraSettingPanelManager cspm = CameraSettingPanelObj.GetComponent<CameraSettingPanelManager>();
        cspm.CallOnCameraSettingPanel(go);

        spcwt.InitMySelf(go, cspm.Slider_Horizontal, cspm.Slider_Vertical);
    }

    /// <summary>
    /// 隐藏摄像机设置页面 
    /// </summary>
    public void DisableCameraSetting()
    {
        CameraSettingPanelManager cspm = CameraSettingPanelObj.GetComponent<CameraSettingPanelManager>();
        cspm.CloseBtnCallBack();
    }

    /// <summary>
    /// 获取此时面板正在操作的对象
    /// </summary>
    /// <returns></returns>
    public GameObject getCameraSettingPanelObj()
    {
        CameraSettingPanelManager cspm = CameraSettingPanelObj.GetComponent<CameraSettingPanelManager>();
        return cspm.getCurControlObj();
    }


    #endregion

}

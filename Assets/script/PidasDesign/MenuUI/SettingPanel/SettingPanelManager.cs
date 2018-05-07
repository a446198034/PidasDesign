using UnityEngine;
using System.Collections;

public class SettingPanelManager : MonoBehaviour {

    [Header("相机设置页面")]
    public GameObject CameraSettingPanelObj;

    [Header("围栏设置页面")]
    public GameObject WeiLanSettingPanelObj;

    [Header("微波设置页面")]
    public GameObject MicrowaveSettingPanelObj;

    [Header("红外对射设置页面")]
    public GameObject InfraredSettingPanelObj;

    SettingPanelConnectWithTransform spcwt;
    // Use this for initialization
    void Start() {
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

    #region Microwave

    /// <summary>
    /// 显示微波设置页面
    /// </summary>
    /// <param name="go"></param>
    public void CallOnMicrowaveSetting(GameObject go)
    {
        MicrowaveSettingPanelObj.SetActive(true);
        MicrowaveSettingPanelManager mmm = MicrowaveSettingPanelObj.GetComponent<MicrowaveSettingPanelManager>();
        mmm.initMicrowaveSettingPanel(go);
    }

    /// <summary>
    /// 关闭微波设置页面
    /// </summary>
    public void DisableMicrowaveSetting()
    {
        MicrowaveSettingPanelManager mmm = MicrowaveSettingPanelObj.GetComponent<MicrowaveSettingPanelManager>();
        mmm.CloseBtnCallBack();

    }

    /// <summary>
    /// 返回微波面板正在操作的对象
    /// </summary>
    /// <returns></returns>
    public GameObject getMicrowaveCurControlObj()
    {
        MicrowaveSettingPanelManager mmm = MicrowaveSettingPanelObj.GetComponent<MicrowaveSettingPanelManager>();
        return mmm.getMicrowaveControlMicrowaveGroupObj();
    }

    #endregion

    #region Infrared

    /// <summary>
    /// 显示红外对射设置页面
    /// </summary>
    /// <param name="go"></param>
    public void CallOnInfraredSetting(GameObject go)
    {
        InfraredSettingPanelObj.SetActive(true);
        InfraredSettingPanelManager ispm = InfraredSettingPanelObj.GetComponent<InfraredSettingPanelManager>();
        ispm.initInfraredSettingPanel(go);
    }

    /// <summary>
    /// 关闭红外对射设置页面
    /// </summary>
    public void DisabelInfraredSetting()
    {
        InfraredSettingPanelManager ispm = InfraredSettingPanelObj.GetComponent<InfraredSettingPanelManager>();
        ispm.CloseBtnCallBack();
    }

    /// <summary>
    /// 返回红外对射设置页面
    /// </summary>
    /// <returns></returns>
    public GameObject getInfraredCurControlObj()
    {
        InfraredSettingPanelManager ispm = InfraredSettingPanelObj.GetComponent<InfraredSettingPanelManager>();
        return ispm.getInfraredControlGroupObj();
    }

    #endregion


    #region WeiLan
    /// <summary>
    /// 呼出围栏设置页面
    /// </summary>
    /// <param name="go"></param>
    public void CallOnWeiLanSetting( )
    {
        WeiLanSettingPanelObj.SetActive(true);
        WeiLanSettingPanel wsp = WeiLanSettingPanelObj.GetComponent<WeiLanSettingPanel>();

        wsp.InitWeiLanSettingPanel();
    }

    /// <summary>
    /// 关闭围栏设置页面
    /// </summary>
    public void DisableWeiLanSetting()
    {
        WeiLanSettingPanelObj.SetActive(false);
    }

    #endregion


}

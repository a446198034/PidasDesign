using UnityEngine;
using System.Collections;

public class SettingPanelManager : MonoBehaviour {

    [Header("相机设置页面")]
    public GameObject CameraSettingPanelObj;

	// Use this for initialization
	void Start () {
	
	}


    #region Public Function

    /// <summary>
    /// 显示摄像机的设置 页面
    /// </summary>
    /// <param name="go"></param>
    public void CallOnCameraSetting(GameObject go)
    {
        CameraSettingPanelObj.SetActive(true);
        CameraSettingPanelManager cspm = CameraSettingPanelObj.GetComponent<CameraSettingPanelManager>();
        cspm.CallOnCameraSettingPanel(go);
    }

    /// <summary>
    /// 隐藏摄像机设置页面 
    /// </summary>
    public void DisableCameraSetting()
    {
        CameraSettingPanelObj.SetActive(false);
    }

    #endregion

}

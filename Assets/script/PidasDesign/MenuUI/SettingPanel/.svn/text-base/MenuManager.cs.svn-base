using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    [Header("操作的页面")]
    public GameObject MenuObj;

    [Header("显示Transform面板的物体")]
    public GameObject TranformShowControlObj;
    TransformMessageController ttmc;

    [Header("AddMachineParentManager")]
    public GameObject AddGameObjParentObj;
    AddMachineParentManager ampm;

    SettingPanelManager spm;
    GameObject CurControl;
    MachineType CurMachineType;
	// Use this for initialization
	void Start () {
        spm = GetComponent<SettingPanelManager>();
        ttmc = TranformShowControlObj.GetComponent<TransformMessageController>();
        ampm = AddGameObjParentObj.GetComponent<AddMachineParentManager>();
        TranformShowControlObj.SetActive(false);
        MenuObj.SetActive(false);
	}

    #region 右键菜单总控制

    /// <summary>
    /// 显示Menu
    /// </summary>
    /// <param name="go"></param>
    /// <param name="my"></param>
    public void CallOnRightMenu(GameObject go, MachineType my)
    {
        CurMachineType = my;

        CurControl = CurMachineType == MachineType.Microwave? go.GetComponent<Machine_Weibo>().MyFatherManagerObj : go;
        MenuObj.SetActive(true);

        MenuObj.transform.position = Input.mousePosition;

        MenuObj.transform.FindChild("ProperyBtn").gameObject.SetActive(CurMachineType == MachineType.WeiLan? false : true);
        
    }


    /// <summary>
    /// 隐藏Menu
    /// </summary>
    public void CallDisableRightMenu()
    {
        MenuObj.SetActive(false);
    }

    #endregion

    #region TransformController面板控制

    /// <summary>
    /// 显示transform面板
    /// </summary>
    /// <param name="go"></param>
    public void CallOnTransformMessagePanel()
    {
        TranformShowControlObj.SetActive(true);

        ttmc.CallOnTransformControllerPanel(CurControl);
    }

    /// <summary>
    /// 在UI关掉
    /// 关闭transform面板
    /// </summary>
    public void CallDisableTransformControlPanel()
    {
        TranformShowControlObj.SetActive(false);
    }

    #endregion



    #region UI Event

    /// <summary>
    /// 复制   按钮回调事件
    /// </summary>
    public void Btn_CopyCallback()
    {

    }

    /// <summary>
    /// 查看场    按钮回调事件
    /// </summary>
    public void BtnCallback_Replace()
    {

    }

    /// <summary>
    /// 旋转   按钮回调事件
    /// </summary>
    public void BtnCallBack_Rotate()
    { }

    /// <summary>
    /// 删除  按钮回调事件
    /// </summary>
    public void BtnCallBack_Delete()
    {
        switch (CurMachineType)
        {
            case MachineType.Camera:

                if (CurControl == spm.getCameraSettingPanelObj())
                {
                    spm.DisableCameraSetting();
                    CallDisableTransformControlPanel();
                }
                        
                break;
            case MachineType.Infrared:

                if (CurControl.transform.parent.gameObject == spm.getInfraredCurControlObj())
                {
                    spm.DisabelInfraredSetting();
                    CallDisableTransformControlPanel();
                }

                break;
            case MachineType.Radar: break;
            case MachineType.Microwave:

                if (CurControl.transform.parent.gameObject == spm.getMicrowaveCurControlObj())
                {
                    spm.DisableMicrowaveSetting();
                    CallDisableTransformControlPanel();
                }

                break;
        }
        MenuObj.SetActive(false);
        ampm.RemoveObjInScene(CurControl,CurMachineType);

    }

    /// <summary>
    /// 属性  按钮回调事件
    /// </summary>
    public void BtnCallBack_Property()
    {
        switch (CurMachineType)
        {
            case MachineType.Camera:
                spm.CallOnCameraSetting(CurControl);
                break;
            case MachineType.Infrared:
                spm.CallOnInfraredSetting(CurControl.transform.parent.gameObject);
                break;
            case MachineType.Radar:break;
            case MachineType.Microwave:
                spm.CallOnMicrowaveSetting(CurControl.transform.parent.gameObject);
                break;
        }
        MenuObj.SetActive(false);
        CallOnTransformMessagePanel();
    }


    #endregion


}

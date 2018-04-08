using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    [Header("操作的页面")]
    public GameObject MenuObj;

    SettingPanelManager spm;
    GameObject CurControl;
    MachineType CurMachineType;
	// Use this for initialization
	void Start () {
        spm = GetComponent<SettingPanelManager>();

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
        CurControl = go;
        CurMachineType = my;
        MenuObj.SetActive(true);


        MenuObj.transform.position = Input.mousePosition;
    }


    /// <summary>
    /// 隐藏Menu
    /// </summary>
    public void CallDisableRightMenu()
    {
        MenuObj.SetActive(false);
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
    /// 替换    按钮回调事件
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
    { }

    /// <summary>
    /// 属性  按钮回调事件
    /// </summary>
    public void BtnCallBack_Property()
    {
        switch (CurMachineType)
        {
            case MachineType.Camera: spm.CallOnCameraSetting(CurControl);break;
            case MachineType.Infrared: break;
            case MachineType.Radar:break;
            case MachineType.Microwave:break;
        }
        MenuObj.SetActive(false);
    }


    #endregion


}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 微波设置页面
/// </summary>
public class MicrowaveSettingPanelManager : MonoBehaviour
{

    [Multiline]
    public string Introduction = "";

    [Header("微波设备名称")]
    public InputField IF_MachineName;

    [Header("型号")]
    public Text IF_Machine_Version;

    [Header("按钮及其文字")]
    public GameObject ChangClickBtn;
    public Text BtnStateText;

    [Header("场宽的slider")]
    public Slider Slider_ChangKuan;
    public Text Text_ChangKuan;

    [Header("设备高度的slider")]
    public Slider Slider_MachineHigh;
    public Text Text_MachineHigh;

    GameObject CurControlMicrowaveGroupObj;
    MicrowaveGroupManager Curmgm;
    // Use this for initialization
    void Start()
    {

        CurControlMicrowaveGroupObj = null;
        Curmgm = null;
        gameObject.SetActive(false);

    }

    #region Public Function

    public void initMicrowaveSettingPanel(GameObject MicrowaveObj)
    {
        CurControlMicrowaveGroupObj = MicrowaveObj;
        Curmgm = CurControlMicrowaveGroupObj.GetComponent<MicrowaveGroupManager>();

        IF_Machine_Version.text = Curmgm.MyMicrowaveDao.MachineVersion;
        IF_MachineName.text = Curmgm.MyMicrowaveDao.MachineTypeName;

        float sx = Curmgm.TeXiaoObj.transform.localScale.x;
        sx = GlogalData.getNumByFloat(sx, 1);
        Slider_ChangKuan.value = sx;
        Text_ChangKuan.text = sx + " m";

        float h = Curmgm.getFirstHead().transform.position.y;
        h = GlogalData.getNumByFloat(h, 1);
        Slider_MachineHigh.value = h;
        Text_MachineHigh.text = h + " m";

        bool s = Curmgm.getTeXiaoRend();
        SetBtnState(!s);
    }

    public void CloseBtnCallBack()
    {
       // Curmgm.OnShowTeXiao(false);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 返回当前正在操作的对象
    /// </summary>
    /// <returns></returns>
    public GameObject getMicrowaveControlMicrowaveGroupObj()
    {
        return CurControlMicrowaveGroupObj;
    }

    #endregion


    #region Slider

    /// <summary>
    /// 监听 场宽的Slider
    /// </summary>
    public void Slider_ChangKuan_ValueChangedListen()
    {
        float f = GlogalData.getNumByFloat(Slider_ChangKuan.value, 1);

        Vector3 s = Curmgm.TeXiaoObj.transform.localScale;
        s.x = f;
        s.y = f;
        Curmgm.TeXiaoObj.transform.localScale = s;

        Text_ChangKuan.text = f + " m";

        Curmgm.setChangKuan(f);
    }

    /// <summary>
    /// 监听 设备高度的Slider
    /// </summary>
    public void Slider_MachineHigh_ValueChangListen()
    {
        float f = GlogalData.getNumByFloat(Slider_MachineHigh.value, 1);

        Vector3 hf = Curmgm.getFirstHead().transform.position;
        Vector3 hs = Curmgm.getSecondHead().transform.position;

        hf.y = f;
        hs.y = f;
        Text_MachineHigh.text = f + " m";

        Curmgm.setFirstHeadPostion(hf);
        Curmgm.setSecondHeadPosition(hs);
        Curmgm.setMachinehigh(f);

    }

    #endregion

    #region Button

    /// <summary>
    /// 开启关闭特效的按钮监听
    /// </summary>
    public void TeXiaoButtonCallback()
    {
        bool s = Curmgm.getTeXiaoRend();
        Curmgm.OnShowTeXiao(!s);

        SetBtnState(s);
    }


    void SetBtnState(bool s)
    {
        ChangClickBtn.GetComponent<Image>().color = s ? Color.white : Color.green;
        BtnStateText.text = s ? "探测场已关闭" : "探测场已开启";
    }

    #endregion

}

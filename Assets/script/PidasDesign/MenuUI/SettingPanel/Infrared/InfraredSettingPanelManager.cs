using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 红外对射设置页面
/// </summary>
public class InfraredSettingPanelManager : MonoBehaviour {

    [Multiline]
    public string Introduction = "";

    [Header("红外对射设备名称")]
    public InputField IF_MachineName;

    [Header("型号")]
    public Text Text_Machine_Version;

    [Header("按钮及其文字")]
    public GameObject ChangClickBtn;
    public Text BtnStateText;

    [Header("密度XSlider")]
    public Slider Slider_Density_X;
    public Text Text_density_X;

    [Header("密度YSlider")]
    public Slider Slider_Density_Y;
    public Text Text_density_Y;

    [Header("速度Slider")]
    public Slider Slider_Speed;
    public Text Text_Speed;

    GameObject CurControlInfraredGroupObj;
    InfraredGroupManager igm;

    // Use this for initialization
    void Start () {

        CurControlInfraredGroupObj = null;
        igm = null;
        gameObject.SetActive(false);

	}

    #region Public Function


    public void initInfraredSettingPanel(GameObject go)
    {
        CurControlInfraredGroupObj = go;
        igm = CurControlInfraredGroupObj.GetComponent<InfraredGroupManager>();

        IF_MachineName.text = igm.MyInfraredDao.MachineTypeName;
        Text_Machine_Version.text = igm.MyInfraredDao.MachineTypeName;

        Vector2 Midu = get_MainTex();
        Midu.x = GlogalData.getNumByFloat(Midu.x,1);
        Slider_Density_X.value = Midu.x;
        Text_density_X.text = Midu.x + " ";

        Midu.y = GlogalData.getNumByFloat(Midu.y,1);
        Slider_Density_Y.value = Midu.y;
        Text_density_Y.text = Midu.y + " ";

        bool s = igm.getTeXiaoRend();
        SetBtnState(!s);
    }

    public void CloseBtnCallBack()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 返回当前正在操作的对象
    /// </summary>
    /// <returns></returns>
    public GameObject getInfraredControlGroupObj()
    {
        return CurControlInfraredGroupObj;
    }

    #endregion


    #region _MainTex

    public void set_MainTex(Vector2 v)
    {
        igm.TexiaoObj.GetComponent<Renderer>().material.SetTextureScale("_MainTex",v);
    }

    public Vector2 get_MainTex()
    {
        return igm.TexiaoObj.GetComponent<Renderer>().material.GetTextureScale("_MainTex");
    }

    #endregion


    #region Slider

    /// <summary>
    /// 监听关于密度的X的SLider的变化
    /// </summary>
    public void Slider_density_X_ValueListen()
    {
        float f = GlogalData.getNumByFloat(Slider_Density_X.value,1);

        Vector2 vv = get_MainTex();
        vv.x = f;
        set_MainTex(vv);
        igm.setInfraredDensity_X(f);

        Text_density_X.text = f.ToString();
    }

    /// <summary>
    /// 监听关于密度的Y的Slider 的变化
    /// </summary>
    public void Slider_density_Y_ValueListen()
    {
        float f = GlogalData.getNumByFloat(Slider_Density_Y.value,1);

        Vector2 vv = get_MainTex();
        vv.y = f;
        set_MainTex(vv);
        igm.setInfraredDensity_Y(f);

        Text_density_Y.text = f.ToString();
    }

    /// <summary>
    /// 监听关于速度的Slider 的变化
    /// </summary>
    public void Slider_Speed_ValueListen()
    {
        float f = GlogalData.getNumByFloat(Slider_Speed.value, 1);

        igm.setInfraredSpeed(f);
        igm.setTeXiaoRend_X(f);

        Text_Speed.text = f.ToString();
    }

    #endregion


    #region Button

    /// <summary>
    /// 开启关闭特效的按钮监听
    /// </summary>
    public void TeXiaoButtonCallback()
    {
        bool s = igm.getTeXiaoRend();
        igm.OnShowTeXiao(!s);

        SetBtnState(s);
    }


    void SetBtnState(bool s)
    {
        ChangClickBtn.GetComponent<Image>().color = s ? Color.white : Color.green;
        BtnStateText.text = s ? "探测场已关闭" : "探测场已开启";
    }

    #endregion
}

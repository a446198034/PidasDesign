using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraSettingPanelManager : MonoBehaviour {
    [Multiline]
    public string Introduction = "";

    [Header("相机的场一")]
    public GameObject CameraFieldObj;
    TestDrawCam tdc;

    [Header("相机场二")]
    public GameObject CameraSecondFieldObj;
    TestDrawCam tdc_Second;

    [Header("品牌展示图片")]
    public Image BrandShowImg;

    [Header("品牌展示的text")]
    public Text BrandShowText;

    [Header("摄像机类型展示 枪机 球机 半球")]
    public Text CameraTypeShowText;

    [Header("Name")]
    public InputField IF_Name;

    [Header("IP")]
    public InputField IF_IpAddress;

    [Header("Port")]
    public InputField IF_Port;

    [Header("感光元器件")]
    public GameObject PhotoreceptorManagerObj;
    PhotoreceptorManager ppmm;

    [Header("焦距")]
    public Slider Slider_Jiaoju;
    public Text text_Jiaodu;

    [Header("水平视场角")]
    public Slider Slider_Horizontal;
    public Text text_horizontal;

    [Header("上下视场角")]
    public Slider Slider_Vertical;
    public Text text_vertical;

    GameObject CurControlObj;
    Machine_Camera CurMC;
    MachineTransformController CurMttcc;
    float CurSelectPhotoreceptor;
    float curSelectValidDistance;
    CameraBrandManager cbm;
    // Use this for initialization
    void Start () {
        ppmm = PhotoreceptorManagerObj.GetComponent<PhotoreceptorManager>();
        CurSelectPhotoreceptor = 0;
        curSelectValidDistance = 0;
        tdc = CameraFieldObj.GetComponent<TestDrawCam>();
        tdc_Second = CameraSecondFieldObj.GetComponent<TestDrawCam>();
        cbm = GetComponent<CameraBrandManager>();

        gameObject.SetActive(false);
	}


    #region 感光元器件

    public void SetCurPhotoreceptorChiCun(float f)
    {
        CurSelectPhotoreceptor = f;
        CalculateFOV();
    }

    public void SetCurSelectValidDistance(float f)
    {
        curSelectValidDistance = f;
        CalculateFOV();
    }

    void CalculateFOV()
    {
        if (CurSelectPhotoreceptor == 0 || curSelectValidDistance == 0)
        {
            Debug.Log("CurSelectPhotoreceptor || CurSelectValidDistance == 0. Please check!");
            return;
        }
        float Angle = GlogalData.getDistance(CurSelectPhotoreceptor, curSelectValidDistance);
        //  cssm.SetCamDaoValue(CurSelectPhotoreceptor, Angle, curSelectValidDistance);

        CurMC.setMyPhotoreceptor(CurSelectPhotoreceptor);
        CurMC.setFOVValue(Angle);
        CurMC.setValidDistance(curSelectValidDistance);

        tdc.FieldofView = (int)Angle;
        if (CurMC.CamType == CameraMachineType.Qiu)
        {
            tdc_Second.FieldofView = (int)Angle;
        }
    }


    #endregion

    /// <summary>
    /// 呼叫显示相机设置页面
    /// </summary>
    /// <param name="go"></param>
    public void CallOnCameraSettingPanel(GameObject go)
    {
        CurControlObj = go;
        CurMC = CurControlObj.GetComponent<Machine_Camera>();
        CurMttcc = CurControlObj.GetComponent<MachineTransformController>();

        BrandShowImg.sprite = cbm.getBrandByCameraFactoryType(CurMC.MyCamdao.CamFactorytype);
        BrandShowImg.SetNativeSize();
        BrandShowText.text = CurMC.MyCamdao.CameraVersion;
        CameraTypeShowText.text = CurMC.getMyCameraMachineType();

        IF_Name.text = CurMC.MyCamdao.CamName;
        IF_IpAddress.text = CurMC.MyCamdao.IpAddressStr;
        IF_Port.text = CurMC.MyCamdao.Port;
        
        CurSelectPhotoreceptor = GlogalData.getChiCunByPhotoreceptor(CurMC.MyCamdao.MyPhotoreceptorType);
        curSelectValidDistance = CurMC.MyCamdao.ValidDistance;
        SetCurPhotoreceptorChiCun(CurSelectPhotoreceptor);
        ppmm.ShowOnPhotorecetporByType(CurMC.MyCamdao.MyPhotoreceptorType);

        Slider_Jiaoju.value = CurMC.MyCamdao.ValidDistance;
        text_Jiaodu.text = Slider_Jiaoju.value.ToString();
        Slider_Horizontal.value = CurMC.MyEquipmentDao.HengRotate.RotateValue;
        text_horizontal.text = Slider_Horizontal.value.ToString();
        Slider_Vertical.value = CurMC.MyEquipmentDao.ShuRotate.RotateValue;
        text_vertical.text = Slider_Vertical.value.ToString();


        CallonCameraDrawView();

    }

    /// <summary>
    /// 关闭按钮回调事件
    /// </summary>
    public void CloseBtnCallBack()
    {
        CameraFieldObj.SetActive(false);
        CameraSecondFieldObj.SetActive(false);
        gameObject.SetActive(false);
    }

    #region Local Function

    /// <summary>
    /// 显示相机的场
    /// </summary>
    void CallonCameraDrawView()
    {

        Machine_Camera mc = CurControlObj.GetComponent<Machine_Camera>();

        CameraFieldObj.SetActive(true);
        tdc.InitMyDrawField();

        if (mc.CamType == CameraMachineType.Qiu)
        {

            CameraSecondFieldObj.SetActive(true);
            tdc_Second.InitMyDrawField();
        }


        MachineTransformController mtfc = CurControlObj.GetComponent<MachineTransformController>();
        mtfc.SetCamMesgPosition(CameraFieldObj.transform, CameraSecondFieldObj.transform);


    }


    #endregion

    #region Slider Control

    /// <summary>
    /// 焦距的Slider 滑动的事件
    /// </summary>
    public void Slider_Jiaoju_ValueChangedCallBack()
    {
        float f = GlogalData.getNumByFloat(Slider_Jiaoju.value,2);
        SetCurSelectValidDistance(f);
        text_Jiaodu.text = f.ToString();
    }

    /// <summary>
    /// 水平视场角的Slider 的滑动事件
    /// </summary>
    public void Slider_Horizontal_valueChangCallback()
    {
        CurMttcc.setRotate_Value_Y(Slider_Horizontal.value);
        text_horizontal.text = Slider_Horizontal.value.ToString();
    }

    /// <summary>
    /// 上下视场角的Slider 的滑动事件
    /// </summary>
    public void Slider_Vertical_ValueChangeCallBack()
    {
        CurMttcc.setRotate_Value_X(Slider_Vertical.value);
        text_vertical.text = Slider_Vertical.value.ToString();
    }


    #endregion




}

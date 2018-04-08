using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraSettingPanelManager : MonoBehaviour {
    [Header("相机的场一")]
    public GameObject CameraFieldObj;
    TestDrawCam tdc;

    [Header("相机场二")]
    public GameObject CameraSecondFieldObj;
    TestDrawCam tdc_Second;

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
    float CurSelectPhotoreceptor;
    float curSelectValidDistance;

	// Use this for initialization
	void Start () {
        ppmm = PhotoreceptorManagerObj.GetComponent<PhotoreceptorManager>();
        CurSelectPhotoreceptor = 0;
        curSelectValidDistance = 0;


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

        IF_Name.text = CurMC.MyCamdao.CamName;
        IF_IpAddress.text = CurMC.MyCamdao.IpAddressStr;
        IF_Port.text = CurMC.MyCamdao.Port;
        
        CurSelectPhotoreceptor = ppmm.getChiCunByPhotoreceptor(CurMC.MyCamdao.MyPhotoreceptorType);
        curSelectValidDistance = CurMC.MyCamdao.ValidDistance;
        ppmm.setCurPhotoreceptorByChiCun(CurMC.MyCamdao.MyPhotoreceptorType);

        Slider_Jiaoju.value = CurMC.MyCamdao.ValidDistance;
        text_Jiaodu.text = Slider_Jiaoju.value.ToString();
        Slider_Horizontal.value = CurMC.MyEquipmentDao.HengRotate.RotateValue;
        text_horizontal.text = Slider_Horizontal.value.ToString();
        Slider_Vertical.value = CurMC.MyEquipmentDao.ShuRotate.RotateValue;
        text_vertical.text = Slider_Vertical.value.ToString();

        CallonCameraDrawView();

    }



    // Update is called once per frame
    void Update () {
	
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

    #region 相机调节

    void SetCameraDaoValue(float photoreceptor, float angle, float ValidDistance)
    {

    }

    #endregion
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraSettingPanelManager : MonoBehaviour {

    [Header("Name")]
    public InputField IF_Name;

    [Header("IP")]
    public InputField IF_IpAddress;

    [Header("Port")]
    public InputField IF_Port;

    public GameObject PhotoreceptorManagerObj;
    PhotoreceptorManager ppmm;

    [Header("焦距")]
    public Slider Slider_Jiaoju;

    [Header("水平视场角")]
    public Slider Slider_Horizontal;

    [Header("上下视场角")]
    public Slider Slider_Vertical;

    GameObject CurControlObj;
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


    // Update is called once per frame
    void Update () {
	
	}
}

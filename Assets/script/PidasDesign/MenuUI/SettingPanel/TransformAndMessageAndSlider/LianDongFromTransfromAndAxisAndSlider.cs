using UnityEngine;
using System.Collections;

public class LianDongFromTransfromAndAxisAndSlider : MonoBehaviour {

    public GameObject TransformObjMessageObj;
    TransformMessageController tmc;

    public GameObject CoorDinateAxisObj;
    CoordinateSystem cs;

    public GameObject CanvasObj;
    SettingPanelConnectWithTransform spwt;

	// Use this for initialization
	void Start () {

        tmc = TransformObjMessageObj.GetComponent<TransformMessageController>();
        cs = CoorDinateAxisObj.GetComponent<CoordinateSystem>();
        spwt = CanvasObj.GetComponent<SettingPanelConnectWithTransform>();
	}


    /// <summary>
    /// 当坐标轴变化后呼出的联动请求
    /// </summary>
    /// <param name="isRotate"></param>
    /// <param name="f"></param>
    public void LianDongCallWithCoordinateSystem(bool isRotate)
    {
        if (TransformObjMessageObj.activeSelf)
        {
            tmc.UpdateTransformPanel();
            spwt.UpdateSliderValue();
        }
    }

    /// <summary>
    /// Transform 面板呼出的同步坐标轴的请求
    /// </summary>
    public void LianDongCallWithTransformMessageDrag()
    {
        cs.UpdateZuoBiaoZhouPosAndQua();
        spwt.UpdateSliderValue();
    }

    /// <summary>
    /// 当Slider 值变化的时候呼出的同步联动请求
    /// </summary>
    public void LianDongCallWithPanelSlider()
    {
        cs.UpdateZuoBiaoZhouPosAndQua();
        tmc.UpdateTransformPanel();
    }

    public void CallHideZuoBiaoZhou()
    {
        cs.CallDisableZuoBiaoZhou();
    }

}

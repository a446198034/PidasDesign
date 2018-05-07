using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingPanelConnectWithTransform : MonoBehaviour {

    public GameObject LianDongObj;
    LianDongFromTransfromAndAxisAndSlider liandongff;

    
    GameObject CurControlObj;

    Slider CurHorzonialSlider;
    EquipmentRotationDao HorizontalDao;
    Slider CUrVerticalSlider;
    EquipmentRotationDao VerticalDao;
    // Use this for initialization
    void Start () {
        liandongff = LianDongObj.GetComponent<LianDongFromTransfromAndAxisAndSlider>();
	}

    public void InitMySelf(GameObject go,  Slider h, Slider v)
    {
        CurControlObj = go;
        CurHorzonialSlider = h;
        CUrVerticalSlider = v;

        HorizontalDao = new EquipmentRotationDao();
        EquipmentRotationDao hh = go.GetComponent<EquipmentSelfDetail>().MyEquipmentDao.HengRotate;
        HorizontalDao = HorizontalDao.getANewEquipmentRotationDao(hh);

        VerticalDao = new EquipmentRotationDao();
        EquipmentRotationDao vv = go.GetComponent<EquipmentSelfDetail>().MyEquipmentDao.ShuRotate;
        VerticalDao = VerticalDao.getANewEquipmentRotationDao(vv);
    }


    /// <summary>
    /// 改变旋转轴是否需要通过Slider来弄
    /// </summary>
    /// <returns></returns>
    public bool IsChangeRotationAxisValueBySlider(ControlAxis ca,float f)
    {
        bool res = false;

        if (ca == HorizontalDao.RotateAxis)
        {
            CurHorzonialSlider.value = f;
            res = true;
        }

        if (ca == VerticalDao.RotateAxis)
        {
            CUrVerticalSlider.value = f;
            res = true;
        }

        return res;
    }

    /// <summary>
    /// 更新Slider 的值
    /// </summary>
    public void UpdateSliderValue()
    {
        if (null == CurControlObj) return;

        if (!CurControlObj.activeSelf) return;

        Vector3 v = CurControlObj.transform.rotation.eulerAngles;

        setRotationDao(HorizontalDao,v);
        setRotationDao(VerticalDao,v);

        CurHorzonialSlider.value = HorizontalDao.RotateValue;
        CUrVerticalSlider.value = VerticalDao.RotateValue;
        
    }

    void setRotationDao(EquipmentRotationDao erd,Vector3 v)
    {
        switch (erd.RotateAxis)
        {
            case ControlAxis.Axis_X: erd.RotateValue = erd.isNeedFuShu ? v.x * -1 : v.x; break;
            case ControlAxis.Axis_Y: erd.RotateValue = erd.isNeedFuShu ? v.y * -1 : v.y; break;
            case ControlAxis.Axis_Z: erd.RotateValue = erd.isNeedFuShu ? v.z * -1 : v.z; break;
        }
    }

    /// <summary>
    /// 设置面板里面Slider 值变化的时候同步面板
    /// </summary>
    public void SettingPanelSliderValueChanged()
    {
        liandongff.LianDongCallWithPanelSlider();
    }

}

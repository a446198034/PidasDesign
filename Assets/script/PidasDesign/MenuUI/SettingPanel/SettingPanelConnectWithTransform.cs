using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingPanelConnectWithTransform : MonoBehaviour {

    GameObject CurControlObj;

    Slider CurHorzonialSlider;
    EquipmentRotationDao HorizontalDao;
    Slider CUrVerticalSlider;
    EquipmentRotationDao VerticalDao;
    // Use this for initialization
    void Start () {
	
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


}

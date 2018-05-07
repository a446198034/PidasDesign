using UnityEngine;
using System.Collections;

public class MicrowaveManager : MonoBehaviour {

    public GameObject MyHeadObj;
    public GameObject MyBodyObj;
    public Transform ChangPos;

	// Use this for initialization
	void Start () {
	
	}
    /// <summary>
    /// 给设备添加一个Id
    /// </summary>
    public void setMachineID()
    {
        EquipmentSelfDetail es = MyHeadObj.GetComponent<EquipmentSelfDetail>();
        EquipmentSelfDetail ess = MyBodyObj.GetComponent<EquipmentSelfDetail>();

        es.MyEquipmentDao.setANewGuid();
        ess.MyEquipmentDao.setANewGuid();
    }

    /// <summary>
    /// 高亮回调函数
    /// </summary>
    /// <param name="s"></param>
    /// <param name="go"></param>
    public void SetMicrowaveHighOnOff(bool s,GameObject go)
    {
        HighLighMaterial hh1 = MyHeadObj.GetComponent<HighLighMaterial>();
        HighLighMaterial hh2 = MyBodyObj.GetComponent<HighLighMaterial>();

        if (MyHeadObj == go)
        {
            hh2.onShowHighLight(s);
        }
        else if (MyBodyObj == go)
        {
            hh1.onShowHighLight(s);
        }
    }

    /// <summary>
    /// 控制选中状态和高亮显示
    /// 用于呈现鼠标选中状态
    /// </summary>
    /// <param name="s"></param>
    public void OnShowHighLight(bool s)
    {
        MachineHighLightController mhlc1 = MyHeadObj.GetComponent<MachineHighLightController>();
        MachineHighLightController mhlc2 = MyBodyObj.GetComponent<MachineHighLightController>();

        mhlc1.OnShowHighLight(false);
        mhlc1.MyStateControl(false);

        mhlc2.OnShowHighLight(false);
        mhlc2.MyStateControl(false);

    }

    /// <summary>
    /// BoxCollider
    /// </summary>
    /// <param name="s"></param>
    public void OnShowCollider(bool s)
    {
        MyBodyObj.GetComponent<BoxCollider>().enabled = s;
        MyHeadObj.GetComponent<BoxCollider>().enabled = s;
    }

    /// <summary>
    /// isKinematic
    /// </summary>
    /// <param name="s"></param>
    public void OnControlKinematic(bool s)
    {
        MyBodyObj.GetComponent<Rigidbody>().isKinematic = s;
    }
}

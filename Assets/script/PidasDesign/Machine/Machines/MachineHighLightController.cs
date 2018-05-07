using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HighLighMaterial))]
public class MachineHighLightController : MonoBehaviour {

    HighLighMaterial hh;
    EquipmentSelfDetail ess;

    bool isSlected = false;
    bool isDoingMeSelf = false; //用来检测我是否正在被操作
	// Use this for initialization
	void Start () {
        
	}

    #region 外部调用高亮方法

    /// <summary>
    /// 外部调用  是否高亮显示
    /// </summary>
    /// <param name="s"></param>
    public void OnShowHighLight(bool s)
    {
        CheckMaterialValue();
        hh.onShowHighLight(s);
        ess.EquipmentHighOnOff(s);
    }

    public void MyStateControl(bool s)
    {
        isSlected = s;
    }

    #endregion



    #region 鼠标事件 OnMouse

    void OnMouseEnter()
    {
        OnShowHighLight(true);
    }

    void OnMouseOver()
    {
        
    }

    void OnMouseExit()
    {
        if (!isSlected)
        {
            OnShowHighLight(false);
        }
    }

    void OnMouseDown() {}

  //  void OnMouseDrag(){}

    void OnMouseUp(){}

    #endregion




    #region LocalFunction

    /// <summary>
    /// 检测 hh的值
    /// </summary>
    void CheckMaterialValue()
    {
        if (null == hh || null == ess)
        {
            hh = GetComponent<HighLighMaterial>();
            ess = GetComponent<EquipmentSelfDetail>();
        }
    }

    #endregion

}

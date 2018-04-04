using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HighLighMaterial))]
public class MachineHighLightController : MonoBehaviour {

    HighLighMaterial hh;

	// Use this for initialization
	void Start () {
        hh = GetComponent<HighLighMaterial>();
	}

    #region 鼠标事件 OnMouse

    void OnMouseEnter()
    {
        hh.onShowHighLight(true);
    }

    void OnMouseOver()
    {
    }

    void OnMouseExit()
    {
        hh.onShowHighLight(false);
    }

    void OnMouseDown()
    {
    }

  //  void OnMouseDrag(){}

  //  void OnMouseUp(){}

    #endregion

    // Update is called once per frame
    void Update () {
	
	}
}

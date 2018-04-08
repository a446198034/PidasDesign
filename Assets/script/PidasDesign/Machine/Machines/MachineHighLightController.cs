using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HighLighMaterial))]
public class MachineHighLightController : MonoBehaviour {

    HighLighMaterial hh;

    bool isSlected = false;
    bool isDoingMeSelf = false; //用来检测我是否正在被操作
	// Use this for initialization
	void Start () {
        hh = GetComponent<HighLighMaterial>();
	}

    #region 外部调用高亮方法

    /// <summary>
    /// 外部调用  是否高亮显示
    /// </summary>
    /// <param name="s"></param>
    public void OnShowHighLight(bool s)
    {
        hh.onShowHighLight(s);
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

    void OnMouseDown()
    {
        //isDoingMeSelf = true;
        //isSlected = !isSlected;
        //hh.onShowHighLight(isSlected);


        //ClickCallBack();
    }

  //  void OnMouseDrag(){}

    void OnMouseUp(){
        isDoingMeSelf = false;
    }

    #endregion

    // Update is called once per frame
    void Update () {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (isDoingMeSelf) return;

        //    //isSlected = false;
        //    //hh.onShowHighLight(isSlected);

        //    //GameObject.Find("Canvas").GetComponent<MenuManager>().CallDisableRightMenu();
        //}

	}


    #region LocalFunction

    /// <summary>
    /// 点击回调
    /// </summary>
    void ClickCallBack()
    {
        MenuManager mm = GameObject.Find("Canvas").GetComponent<MenuManager>();
        if (isSlected)
        {
            mm.CallOnRightMenu(gameObject, MachineType.Camera);
        }
        else
        {
            mm.CallDisableRightMenu();
        }
    }

    #endregion

}

using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    [Header("操作的页面")]
    public GameObject MenuObj;


    GameObject CurControl;
    MachineType CurMachineType;
	// Use this for initialization
	void Start () {
        MenuObj.SetActive(false);
	}

    /// <summary>
    /// 显示Menu
    /// </summary>
    /// <param name="go"></param>
    /// <param name="my"></param>
    public void CallOnRightMenu(GameObject go,MachineType my)
    {
        CurControl = go;
        CurMachineType = my;
        MenuObj.SetActive(true);


        MenuObj.transform.position = Input.mousePosition;
    }


    /// <summary>
    /// 隐藏Menu
    /// </summary>
    public void CallDisableRightMenu()
    {
        MenuObj.SetActive(false);
    }

}

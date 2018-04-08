using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 管理添加设备的父对象的管理
/// </summary>
public class AddMachineParentManager : MonoBehaviour {

    [Header("存放右键菜单的物体")]
    public GameObject MenuManagerObj;
    MenuManager mm;

    [Header("存放相机的List")]
    public List<GameObject> CameraObjList;


    /// <summary>
    /// 当前控制的设备类型
    /// </summary>
    MachineType CurMachineType = MachineType.Camera;
	// Use this for initialization
	void Start () {
        CameraObjList = new List<GameObject>();

        mm = MenuManagerObj.GetComponent<MenuManager>();

	}

    #region 公有方法


    /// <summary>
    /// 添加相机到List里去
    /// </summary>
    /// <param name="go"></param>
    public void AddCameraObj(GameObject go)
    {
        CameraObjList.Add(go);
    }


    #endregion



    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;

            if (Physics.Raycast(ray, out rayhit))
            {
                bool s = checkIfInList(rayhit.transform);

                if (s)
                    mm.CallOnRightMenu(rayhit.transform.gameObject,CurMachineType);
                else
                    mm.CallDisableRightMenu();
            }
        }
    }

    /// <summary>
    /// 检测射线射到的物体是否在List里面
    /// </summary>
    /// <param name="tt"></param>
    /// <returns></returns>
    bool checkIfInList(Transform tt)
    {
        bool res = false;

        for (int i = 0; i < CameraObjList.Count; i++)
        {
            MachineHighLightController mhlc = CameraObjList[i].GetComponent<MachineHighLightController>();
            mhlc.OnShowHighLight(false);
            mhlc.MyStateControl(false);
            if (CameraObjList[i].transform == tt)
            {
                mhlc.OnShowHighLight(true);
                mhlc.MyStateControl(true);
                
                res = true;
                CurMachineType = MachineType.Camera;
                return res;
            }
        }

        return res;
    }

}

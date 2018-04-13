using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

/// <summary>
/// 管理添加设备的父对象的管理
/// </summary>
public class AddMachineParentManager : MonoBehaviour {

    [Header("坐标系")]
    public GameObject ZhouBiaoXiObj;
    CoordinateSystem ccss;

    [Header("存放右键菜单的物体")]
    public GameObject MenuManagerObj;
    MenuManager mm;

    [Header("下面的不用赋值存放相机的List")]
    public List<GameObject> CameraObjList;

    GameObject CurLeftControlObj;
    GameObject CurRightControlObj;
    /// <summary>
    /// 当前控制的设备类型
    /// </summary>
    MachineType CurMachineType = MachineType.Camera;
	// Use this for initialization
	void Start () {
        CameraObjList = new List<GameObject>();
        ccss = ZhouBiaoXiObj.GetComponent<CoordinateSystem>();
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

    /// <summary>
    /// 从场景中删除物体
    /// </summary>
    /// <param name="go"></param>
    /// <param name="mt"></param>
    public void RemoveObjInScene(GameObject go, MachineType mt)
    {
        switch (mt)
        {
            case MachineType.Camera:
                CameraObjList.Remove(go);
                Destroy(go);
                break;
            case MachineType.Infrared: break;
            case MachineType.Microwave: break;
            case MachineType.Radar: break;
        }
    }


    public GameObject getCurControlObj()
    {
        GameObject go = CurLeftControlObj;
        if (null != ccss.getCurControlTran())
        {
            go = ccss.getCurControlTran().gameObject;
        }
        return go;
    }

    #endregion



    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.LeftAlt)) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //UI
            }
            else
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayhit;

                if (Physics.Raycast(ray, out rayhit))
                {
                    bool s = checkIfInList(rayhit.transform);

                    if (s)
                    {
                        CurLeftControlObj = rayhit.transform.gameObject;
                        //关掉东西
                        mm.CallDisableRightMenu();
                    }
                    else
                    {
                        ccss.CheckisHitTranIsControlAxis(rayhit.transform);
                        CurLeftControlObj = null;
                        //关掉东西
                        mm.CallDisableRightMenu();
                    }
                }

            }
        }


        if (Input.GetMouseButtonUp(1))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //UI
            }
            else
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayhit;

                if (Physics.Raycast(ray, out rayhit))
                {
                    bool s = checkIfInList(rayhit.transform);

                    if (s)
                    {
                        CurRightControlObj = rayhit.transform.gameObject;
                        mm.CallOnRightMenu(rayhit.transform.gameObject, CurMachineType);
                    }
                    else
                    {
                        ccss.CheckisHitTranIsControlAxis(rayhit.transform);
                        CurRightControlObj = null;
                        mm.CallDisableRightMenu();
                    
                    }
                }

            }
        }


    }


    #region 本地方法

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
                ccss.CallOnZhouBiaoZhou(CameraObjList[i].transform);
                res = true;
                CurMachineType = MachineType.Camera;
            }
        }

        return res;
    }

    #endregion


}

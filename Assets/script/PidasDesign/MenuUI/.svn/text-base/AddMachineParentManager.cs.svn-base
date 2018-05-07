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

    [Header("不用赋值的存放围栏的List")]
    public List<GameObject> WeiLanObjList;

    [Header("不用赋值的存放微波组合的List")]
    public List<GameObject> MicrowaveGroupList;

    [Header("不用赋值的存放红外对射的List")]
    public List<GameObject> InfraredGroupList;

    GameObject CurLeftControlObj;
    GameObject CurRightControlObj;
    /// <summary>
    /// 当前控制的设备类型
    /// </summary>
    MachineType CurMachineType = MachineType.Camera;
	// Use this for initialization
	void Start () {
        CameraObjList = new List<GameObject>();
        WeiLanObjList = new List<GameObject>();
        MicrowaveGroupList = new List<GameObject>();
        InfraredGroupList = new List<GameObject>();
        ccss = ZhouBiaoXiObj.GetComponent<CoordinateSystem>();
        mm = MenuManagerObj.GetComponent<MenuManager>();

	}


    #region Camera


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
            case MachineType.Infrared:
                GameObject InfraredgroupObj = go.transform.parent.gameObject;
                InfraredGroupList.Remove(InfraredgroupObj);
                Destroy(InfraredgroupObj);
                break;
            case MachineType.Microwave:
                GameObject groupObj = go.transform.parent.gameObject;
                MicrowaveGroupList.Remove(groupObj);
                Destroy(groupObj);
                break;
            case MachineType.Radar: break;
            case MachineType.WeiLan:
                WeiLanObjList.Remove(go);
                Destroy(go);
                break;

        }
        ccss.CallDisableZuoBiaoZhou();
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

    #region WeiLan

    /// <summary>
    /// 添加围栏
    /// </summary>
    /// <param name="go"></param>
    public void AddWeiLanToList(GameObject go)
    {
        WeiLanObjList.Add(go);
    }

    #endregion

    #region Microwave

    /// <summary>
    /// 添加微波
    /// </summary>
    /// <param name="go"></param>
    public void AddMicrowaveIntoList(GameObject go)
    {
        MicrowaveGroupList.Add(go);
        
    }

    #endregion

    #region Infrared

    /// <summary>
    /// 添加红外
    /// </summary>
    /// <param name="go"></param>
    public void AddInfraredIntoList(GameObject go)
    {
        InfraredGroupList.Add(go);
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

        //camera
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

        //WeiLan
        for (int i = 0; i < WeiLanObjList.Count; i++)
        {
            MachineHighLightController mhlc = WeiLanObjList[i].GetComponent<MachineHighLightController>();
            mhlc.OnShowHighLight(false);
            mhlc.MyStateControl(false);
            if (WeiLanObjList[i].transform == tt)
            {
                mhlc.OnShowHighLight(true);
                mhlc.MyStateControl(true);
               // ccss.CallOnZhouBiaoZhou(WeiLanObjList[i].transform);
                res = true;
                CurMachineType = MachineType.WeiLan;
            }
        }

        //Infrared
        for (int i = 0; i < InfraredGroupList.Count; i++)
        {
            InfraredGroupManager igm = InfraredGroupList[i].GetComponent<InfraredGroupManager>();
            Transform tf = igm.isObjectInList(tt);

            if (null != tf)
            {
                ccss.CallOnZhouBiaoZhou(tf);
                res = true;
                CurMachineType = MachineType.Infrared;
            }

        }



        //Microwave
        for (int i = 0; i < MicrowaveGroupList.Count; i++)
        {
            MicrowaveGroupManager mgm = MicrowaveGroupList[i].GetComponent<MicrowaveGroupManager>();
            Transform FirstTT = mgm.isObjectInFirst(tt);
            Transform SecondTT = mgm.isObjInSecond(tt);

            if (null != FirstTT)
            {
                ccss.CallOnZhouBiaoZhou(FirstTT);
                res = true;
                CurMachineType = MachineType.Microwave;
            }

            if (null != SecondTT)
            {
                ccss.CallOnZhouBiaoZhou(SecondTT);
                res = true;
                CurMachineType = MachineType.Microwave;
            }

            if (null != FirstTT && null != SecondTT)
                Debug.Log(" First 和 Second 两个都有值啊!!");
        }

        return res;
    }

    #endregion


}

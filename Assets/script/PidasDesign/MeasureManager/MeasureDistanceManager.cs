﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MeasureDistanceManager : MonoBehaviour {

    [Header("管理Prefab的物体")]
    public GameObject PrefabManagerObj;
    MachinesManager mm;

    public Transform FirstPointTran;
    LineRenderer FirstLR;

    public Transform SecondPointTran;
    public TextMesh TextDistanceShow;

    bool IsStartMeasureDistance = false;


    bool IsCheckFirst = false;
    bool IsCheckSecond = false;
    bool IsEverythingShow = false;
    // Use this for initialization
    void Start () {
        FirstLR = FirstPointTran.gameObject.GetComponent<LineRenderer>();
        FirstPointTran.gameObject.SetActive(false);
        SecondPointTran.gameObject.SetActive(false);
        TextDistanceShow.gameObject.SetActive(false);
        mm = PrefabManagerObj.GetComponent<MachinesManager>();
	}
	
    public void StartMeasureDistanceCheck()
    {
        IsEverythingShow = false;
        FirstPointTran.position = getMouseRayFloorPos(Input.mousePosition);
        FirstPointTran.gameObject.SetActive(true);
        IsCheckFirst = true;
        IsStartMeasureDistance = true;
    }

    public bool getIfNowisDistanceing()
    {
        return IsStartMeasureDistance;
    }

	// Update is called once per frame
	void Update () {

        if (!IsStartMeasureDistance) return;

        if (IsCheckFirst)
        {
            FirstPointTran.position = getMouseRayFloorPos(Input.mousePosition);
        }

        if (IsCheckSecond)
        {
            SecondPointTran.position = getMouseRayFloorPos(Input.mousePosition);
            MeasureDistacneControl();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //碰到UI

            }
            else
            {
                CannelCheckDistance();
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //碰到UI

            }
            else
            {
                if (IsEverythingShow)
                {
                    
                    mm.WeiLanCreateBtnCallback(FirstPointTran,SecondPointTran);
                    CannelCheckDistance();
                }

                if (IsCheckSecond)
                {
                    IsCheckSecond = false;
                    IsEverythingShow = true;
                }

                if (IsCheckFirst)
                {
                    IsCheckFirst = false;
                    SecondPointTran.position = FirstPointTran.position;
                    FirstLR.SetPosition(0, FirstPointTran.position);
                    SecondPointTran.gameObject.SetActive(true);
                    TextDistanceShow.gameObject.SetActive(true);
                    FirstPointTran.gameObject.GetComponent<LineRenderer>().enabled = true;
                    IsCheckSecond = true;
                    
                }

                

            }
        }

    }

    void MeasureDistacneControl()
    {
        float dis = Vector3.Distance(FirstPointTran.position, SecondPointTran.position);
        dis = GlogalData.getNumByFloat(dis,2);


        Vector3 temp = SecondPointTran.position - FirstPointTran.position;
        Vector3 TextPos = temp / 2 + FirstPointTran.position;

        TextDistanceShow.transform.position = TextPos;
        TextDistanceShow.text = dis.ToString() + "m";


        FirstLR.SetPosition(1,SecondPointTran.position);
    }

    void CannelCheckDistance()
    {

        IsEverythingShow = false;
        IsStartMeasureDistance = false;
        FirstLR.enabled = false;
        IsCheckFirst = false;
        IsCheckSecond = false;
        TextDistanceShow.gameObject.SetActive(false);
        FirstPointTran.gameObject.SetActive(false);
        SecondPointTran.gameObject.SetActive(false);
    }

    Vector3 getTranPosInCam(Transform tran)
    {
        // return Camera.main.WorldToScreenPoint(SecondPointTran.position);
        return tran.position;
    }

    Vector3 getMouseRayFloorPos(Vector3 RayPOs)
    {
        Vector3 res = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(RayPOs);
        RaycastHit hit;

        // Mask = ~Mask;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            res = hit.point;
            //res.y += 0.5f;

        }
        else
        {
            res = Vector3.zero;
            Debug.Log(" HIt Error");
        }

        return res;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 坐标系里面移动轴 
/// </summary>
public class ControlAxisMoveXYZ : MonoBehaviour {

    [Header("")]
    public ControlAxis MyAxis = ControlAxis.Axis_X;
    
    [Header("轴的部分，头和身")]
    public List<GameObject> ZhouObjList;
    List<Color> initColorList;

    [Header("操作颜色")]
    public Color ControlColor = Color.yellow;

    public GameObject MyFatherControlObj;
    CoordinateSystem cs;
	// Use this for initialization
	void Start () {
        cs = MyFatherControlObj.GetComponent<CoordinateSystem>();
        initColorList = new List<Color>();
        foreach (GameObject go in ZhouObjList)
        {
            Color c = go.GetComponent<Renderer>().material.color;
            initColorList.Add(c);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftAlt)) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (isTransformInList(hit.transform))
                {
                    StartCoroutine(cs.OnMouseDownToMove());
                }
            }
        }
	}


    





    /// <summary>
    /// 判断物体是否在List 里面s
    /// </summary>
    /// <param name="tran"></param>
    /// <returns></returns>
    bool isTransformInList(Transform tran)
    {
        bool res = false;
        foreach (GameObject go in ZhouObjList)
        {
            if (tran == go.transform)
            {
                res = true;
                break;
            }
        }
        return res;
    }


}

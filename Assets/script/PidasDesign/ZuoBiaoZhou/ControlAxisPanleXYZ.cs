using UnityEngine;
using System.Collections;

/// <summary>
/// 坐标系里面的面板移动
/// </summary>
public class ControlAxisPanleXYZ : MonoBehaviour {

    [Header("哪两个面")]
    public ControlAxis MyAxisOne = ControlAxis.Axis_X;
    public ControlAxis MyAxisTwo = ControlAxis.Axis_Y;

    [Header("操作的颜色")]
    public Color ControlColor = Color.yellow;
    Color initColor;

    public GameObject MyFatherControlObj;
    CoordinateSystem cs;
    Transform CurControlTran;

	// Use this for initialization
	void Start () {

        cs = MyFatherControlObj.GetComponent<CoordinateSystem>();
        initColor = gameObject.GetComponent<Renderer>().material.color;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftAlt)) return;

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            SetMyPosByCamera();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    CurControlTran = cs.getCurControlTran();
                    CurControlTran.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    StartCoroutine(OnMouseDownToMovePlane());
                }
            }
        }   
	}


    #region XYZ三个平面移动


    //XYZ三平面移动
    IEnumerator OnMouseDownToMovePlane()
    {
        setObjColor(true);
        //将物体由世界坐标系转化为屏幕坐标系， 有vector3 结构体变量ScreenSpace 存储，以用来明确屏幕坐标系Z轴的位置
        Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(CurControlTran.position);
        // Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);

        //完成了两个步骤  1是鼠标的坐标是二维的 需要转化为三维的世界坐标系   
        //                2是只有三维的情况才能计算鼠标位置和物体的距离  offset是两者的距离
        Vector3 offset = CurControlTran.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));


        while (Input.GetMouseButton(0))
        {
            //得到现在鼠标的二维坐标系位置
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z);
            //将当前鼠标的二维位置转化成三维的位置  再加上鼠标的移动量
            Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            //CurPosition就是这个物体应该的移动向量赋给 transform 的position属性
            //CurControlTran.position = MovePlaneByTransform(CurPosition);
            //MyGrandFatherObj.position = CurPosition;
            Vector3 taregtPos = MovePlaneByTransform(CurPosition);
            cs.setControlObjPosition(taregtPos);

            //这个很重要
            yield return new WaitForFixedUpdate();
        }

        setObjColor(false);
    }

    //根据点击的XYZ三条轴控制物体的方向
    Vector3 MovePlaneByTransform(Vector3 CurPosition)
    {
        string name = CheckCurControlAxis();
        Vector3 pos = new Vector3(name == "X_Plane" ? CurControlTran.position.x : CurPosition.x, 
                                  name == "Y_Plane" ? CurControlTran.position.y : CurPosition.y,
                                  name == "Z_Plane" ? CurControlTran.position.z : CurPosition.z  );

        // Debug.Log("  x " + pos.x + " y " + pos.y + " z " + pos.z);

        return pos;
    }

    string CheckCurControlAxis()
    {
        string res = "";
        if (MyAxisOne == ControlAxis.Axis_X && MyAxisTwo == ControlAxis.Axis_Y)
        {
            res = "Z_Plane";
        }
        else if (MyAxisOne == ControlAxis.Axis_X && MyAxisTwo == ControlAxis.Axis_Z)
        {
            res = "Y_Plane";
        }
        else if (MyAxisOne == ControlAxis.Axis_Z && MyAxisTwo == ControlAxis.Axis_Y)
        {
            res = "X_Plane";
        }
        else
        {
            Debug.Log("Unkonew Plane AAAA");
        }
        return res;
    }

    #endregion

    #region SetPosition

    /// <summary>
    /// 根据与相机的距离重新计算位置
    /// </summary>
    void SetMyPosByCamera()
    {
        if (!cs.PanelAxisObj.activeSelf)
            return;

        Vector3 v = Camera.main.transform.position - MyFatherControlObj.transform.position;
        Vector3 myV = transform.localPosition;

        Vector3 targetPos = new Vector3( Mathf.Abs(myV.x), Mathf.Abs(myV.y), Mathf.Abs(myV.z));

        targetPos.x = v.x > 0 ? targetPos.x : targetPos.x * -1;
        targetPos.y = v.y > 0 ? targetPos.y : targetPos.y * -1;
        targetPos.z = v.z > 0 ? targetPos.z : targetPos.z * -1;

        transform.localPosition = targetPos;

    }

    #endregion

    /// <summary>
    /// 设置选中颜色
    /// </summary>
    /// <param name="isSeleted"></param>
    void setObjColor(bool isSeleted)
    {
        GetComponent<Renderer>().material.color = isSeleted ? ControlColor : initColor;
    }


}


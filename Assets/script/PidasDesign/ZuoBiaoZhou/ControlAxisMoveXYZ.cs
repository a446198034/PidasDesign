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
    Transform CurControlTran;
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
                    CurControlTran = cs.getCurControlTran();
                    CurControlTran.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    StartCoroutine(OnMouseDownToMove());
                }
            }
        }
	}


    #region XYZ 三轴移动

    //XYZ 三轴移动
    //下面函数是当鼠标触碰到碰转体或者刚体的时候被调用  
    //现在可以用  如果添加物理的话会自动掉落
    public IEnumerator OnMouseDownToMove()
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

            Vector3 taregtPos = MovePathByTransform(CurPosition);
            cs.setControlObjPosition(taregtPos);
            //CurPosition就是这个物体应该的移动向量赋给 transform 的position属性
            //CurControlTran.position = MovePathByTransform(CurPosition);
            ////MyGrandFatherObj.position = CurPosition;
            //transform.position = CurControlTran.position;
            //这个很重要
            yield return new WaitForFixedUpdate();
        }

        setObjColor(false);
    }

    //根据点击的XYZ三条轴控制物体的方向
    Vector3 MovePathByTransform(Vector3 CurPosition)
    {
        string name = transform.name;
        Vector3 pos = new Vector3(MyAxis == ControlAxis.Axis_X ? CurPosition.x : CurControlTran.position.x,
                                  MyAxis == ControlAxis.Axis_Y ? CurPosition.y : CurControlTran.position.y,
                                  MyAxis == ControlAxis.Axis_Z ? CurPosition.z : CurControlTran.position.z);

        // Debug.Log("  x " + pos.x + " y " + pos.y + " z " + pos.z);

        return pos;
    }

    #endregion

    /// <summary>
    /// 设置选中颜色
    /// </summary>
    /// <param name="isSeleted"></param>
    void setObjColor(bool isSeleted)
    {
        for ( int i = 0;i < ZhouObjList.Count; i++)
        {
            ZhouObjList[i].GetComponent<Renderer>().material.color = isSeleted ? ControlColor : initColorList[i];
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

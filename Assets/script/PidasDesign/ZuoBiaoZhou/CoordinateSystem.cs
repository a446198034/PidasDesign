using UnityEngine;
using System.Collections;

/// <summary>
/// 坐标轴系统
/// </summary>
public class CoordinateSystem : MonoBehaviour {

    [Header("移动")]
    public GameObject MoveAxisObj;
    [Header("平面")]
    public GameObject PanelAxisObj;
    [Header("旋转")]
    public GameObject RotateAxisObj;

    Transform CurControlTran;

	// Use this for initialization
	void Start () {
	
	}


    #region 公有方法

    /// <summary>
    /// 呼出坐标系
    /// </summary>
    /// <param name="tf"></param>
    public void CallOnZhouBiaoZhou(Transform tf)
    {
        CurControlTran = tf;
           
    }

    public void CallDisableZuoBiaoZhou()
    {
        MoveAxisObj.SetActive(false);
        PanelAxisObj.SetActive(false);
        RotateAxisObj.SetActive(false);
    }

    #endregion


    #region XYZ 三轴移动

    //XYZ 三轴移动
    //下面函数是当鼠标触碰到碰转体或者刚体的时候被调用  
    //现在可以用  如果添加物理的话会自动掉落
    public IEnumerator OnMouseDownToMove()
    {

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
            CurControlTran.position = MovePathByTransform(CurPosition);
            //MyGrandFatherObj.position = CurPosition;

            //这个很重要
            yield return new WaitForFixedUpdate();
        }
    }

    //根据点击的XYZ三条轴控制物体的方向
    Vector3 MovePathByTransform(Vector3 CurPosition)
    {
        string name = transform.name;
        Vector3 pos = new Vector3(name == "X_Axis" ? CurPosition.x : CurControlTran.position.x,
                                  name == "Y_Axis" ? CurPosition.y : CurControlTran.position.y,
                                  name == "Z_Axis" ? CurPosition.z : CurControlTran.position.z);

        // Debug.Log("  x " + pos.x + " y " + pos.y + " z " + pos.z);

        return pos;
    }

    #endregion


    #region XYZ三个平面移动


    //XYZ三平面移动
    IEnumerator OnMouseDownToMovePlane()
    {

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
            CurControlTran.position = MovePlaneByTransform(CurPosition);
            //MyGrandFatherObj.position = CurPosition;

            //这个很重要
            yield return new WaitForFixedUpdate();
        }
    }

    //根据点击的XYZ三条轴控制物体的方向
    Vector3 MovePlaneByTransform(Vector3 CurPosition)
    {
        string name = transform.name;
        Vector3 pos = new Vector3(name == "X_Plane" ? CurControlTran.position.x : CurPosition.x,
                                  name == "Y_Plane" ? CurControlTran.position.y : CurPosition.y,
                                  name == "Z_Plane" ? CurControlTran.position.z : CurPosition.z);

        // Debug.Log("  x " + pos.x + " y " + pos.y + " z " + pos.z);

        return pos;
    }

    #endregion


    #region XYZ 三轴旋转

    //XYZ 三轴旋转
    IEnumerator OnMouseDownToRotate()
    {

        while (Input.GetMouseButton(0))
        {
            CurControlTran.GetChild(CurControlTran.childCount - 1).Rotate(RotatePathByTransform());

            //这个很重要
            yield return new WaitForFixedUpdate();
        }
    }

    //XYZ 三轴旋转
    Vector3 RotatePathByTransform()
    {
        string name = transform.name;
        Vector3 pos = new Vector3(name == "XRotate" ? -Input.GetAxis("Mouse Y") * Time.deltaTime * 10 : 0,
                                  name == "YRotate" ? -Input.GetAxis("Mouse X") * Time.deltaTime * 10 : 0,
                                  name == "ZRotate" ? -Input.GetAxis("Mouse Y") * Time.deltaTime * 10 : 0);

        // Debug.Log("  x " + pos.x + " y " + pos.y + " z " + pos.z);

        return pos;
    }

    #endregion

}

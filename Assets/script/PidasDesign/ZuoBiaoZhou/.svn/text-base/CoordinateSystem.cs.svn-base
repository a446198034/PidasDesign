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

    public GameObject MessageLiandongObj;
    LianDongFromTransfromAndAxisAndSlider liandongff;

    float DistanceTemp = 3;

    Transform CurControlTran;
    ControlAxis CurControlAxis = ControlAxis.Axis_X;
	// Use this for initialization
	void Start () {
        liandongff = MessageLiandongObj.GetComponent<LianDongFromTransfromAndAxisAndSlider>();
	}


    #region 公有方法

    /// <summary>
    /// 呼出坐标系
    /// </summary>
    /// <param name="tf"></param>
    public void CallOnZhouBiaoZhou(Transform tf)
    {
        transform.position = tf.position;
        CurControlTran = tf;
        MoveAxisObj.SetActive(true);
        PanelAxisObj.SetActive(true);
        RotateAxisObj.SetActive(false);
        CurControlTran.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    /// <summary>
    /// 隐藏所有的轴
    /// </summary>
    public void CallDisableZuoBiaoZhou()
    {
        if (null != CurControlTran)
        {
            CurControlTran.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        MoveAxisObj.SetActive(false);
        PanelAxisObj.SetActive(false);
        RotateAxisObj.SetActive(false);
    }

    /// <summary>
    /// 判断点到的物体的Tag是不是轴的tag  ControlAxis
    /// </summary>
    /// <param name="tt"></param>
    /// <returns></returns>
    public void CheckisHitTranIsControlAxis(Transform tt)
    {
        if (!tt.tag.Contains("ControlAxis"))
        {
            CallDisableZuoBiaoZhou();
        }
    }

    /// <summary>
    /// 平行轴控制物体移动
    /// </summary>
    /// <param name="v"></param>
    public void setControlObjPosition(Vector3 v)
    {
        CurControlTran.position = v;
        transform.position = v;
        liandongff.LianDongCallWithCoordinateSystem(false);
    }


    /// <summary>
    /// 旋转物体
    /// </summary>
    /// <param name="v"></param>
    public void setControlObjRotation(Vector3 v)
    {
        CurControlTran.Rotate(v);
        transform.Rotate(v);
        liandongff.LianDongCallWithCoordinateSystem(true);
    }

    /// <summary>
    /// 更新坐标轴与物体的位置关系
    /// </summary>
    public void UpdateZuoBiaoZhouPosAndQua()
    {
        transform.position = CurControlTran.position;
        transform.rotation = CurControlTran.rotation;
    }

    public Transform getCurControlTran()
    {
        return CurControlTran;
    }

    /// <summary>
    /// 获取现在坐标轴的显示状态
    /// </summary>
    /// <returns>true 坐标轴显示</returns>
    public bool getIfZuoBiaoZhouActive()
    {
        return MoveAxisObj.activeSelf || RotateAxisObj.activeSelf;
    }

    #endregion


    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0 || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.LeftAlt))
        {
            float f = Vector3.Distance(Camera.main.transform.position,transform.position);
            float temp = f / DistanceTemp;

            Vector3 v = Vector3.one;
            if (temp > 1)
            {
                v *= temp / 2.0f;
            }

            transform.localScale = v;
        }


        if (!getIfZuoBiaoZhouActive()) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            RotateAxisObj.SetActive(false);
            MoveAxisObj.SetActive(true);
            PanelAxisObj.SetActive(true);
        }

        if (Input.GetMouseButton(1)) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateAxisObj.SetActive(true);
            MoveAxisObj.SetActive(false);
            PanelAxisObj.SetActive(false);
        }

    }


    


    

}

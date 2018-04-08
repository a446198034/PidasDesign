using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 这个类是当设备创建的时候需要准备的事情
/// 所有的类都有 
/// </summary>
public class MachineCreateInit : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    #region 公有方法

    /// <summary>
    /// 创建物体后的移动操作
    /// </summary>
    public void CreateObjForFirst()
    {
        OnShowCollider(false);
        StartCoroutine(OnMouseOverToMove());
    }



    #endregion

    #region 鼠标拖拽模块

    /// <summary>
    /// 鼠标拖拽
    /// </summary>
    /// <returns></returns>
    IEnumerator OnMouseOverToMove()
    {
        while (Input.GetMouseButton(0))
        {
            Vector3 v = Vector3.zero;

            v = getPositionByRay();


            transform.position = v;
            yield return new WaitForFixedUpdate();
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UIUI: I Should Do Delete");
        }
        else
        {
            Debug.Log("none");
        }

        OnShowCollider(true);
    }


    /// <summary>
    /// 根据射线获取位置
    /// </summary>
    /// <returns></returns>
    Vector3 getPositionByRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 res = Vector3.zero;
        if (Physics.Raycast(ray, out hit))
        {
            res = hit.point;
        }
        return res;
    }

    void OnShowCollider(bool s)
    {
        GetComponent<BoxCollider>().enabled = s;
    }


    #endregion


    #region Local Function




    #endregion




}

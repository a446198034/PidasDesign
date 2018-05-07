using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 这个类是当设备创建的时候需要准备的事情
/// 所有的类都有 
/// </summary>
public class MachineCreateInit : MonoBehaviour {

    bool isControlGroup = false;

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
        isControlGroup = false;
        GetComponent<EquipmentSelfDetail>().MyEquipmentDao.setANewGuid();
        OnShowCollider(false);
        StartCoroutine(OnMouseOverToMove());

    }

    /// <summary>
    /// 创建物体后的移动操作  给组合设备用的
    /// </summary>
    public void CreateObjForInitWithMircowaveGroupMachine()
    {
        isControlGroup = true;
        GetComponent<MicrowaveGroupManager>().setMachineId();
        GetComponent<MicrowaveGroupManager>().OnShowCollider(false);
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

        if (isControlGroup)
        {
            GetComponent<MicrowaveGroupManager>().OnShowCollider(true);
        }
        else
        {
            OnShowCollider(true);
        }
        
    }


    /// <summary>
    /// 根据射线获取位置
    /// </summary>
    /// <returns></returns>
    Vector3 getPositionByRay()
    {
        Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 res = Vector3.zero;
        if (Physics.Raycast(ray, out hit))
        {
            res = hit.point;
        }
        else
        {
            Vector3 CurScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenSpace.z);
            Vector3 Curposition = Camera.main.ScreenToWorldPoint(CurScreenSpace) + offset;
            res = Curposition;
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

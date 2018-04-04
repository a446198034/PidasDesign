using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 这个类是当设备创建的时候需要准备的事情
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
    /// 鼠标拖拽
    /// </summary>
    /// <returns></returns>
    IEnumerator OnMouseOverToMove()
    {
        while (Input.GetMouseButton(0))
        {

            if (EventSystem.current.IsPointerOverGameObject())
            {
                //碰到UI了
            }
            else
            {

            }


            yield return new WaitForFixedUpdate();
        }
    }


    #endregion


}

using UnityEngine;
using System.Collections;

/// <summary>
/// 这个类是所有预制体的管理
/// </summary>
public class MachinesManager : MonoBehaviour {

    [Header("海康 DS-2CD3T25-I3 ")]
    public GameObject HK_DS2CD3T25I3_PreObj;

    [Header("海康 DS-2CE16D1T-IT3F ")]
    public GameObject HK_DS2CE16D1TIT3F_PreObj;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// 创建来自相机的预制体
    /// </summary>
    /// <param name="go"></param>
    public void CameraCreateBtncallback(GameObject go)
    {
        UICameraMachineDetail ucm = go.GetComponent<UICameraMachineDetail>();
        GameObject CamGo = getCameraPrefabsByCheckMessage(ucm);


    }

    #region LocalFunction

    /// <summary>
    /// 根据相机的类型返回对应预制体
    /// </summary>
    /// <param name="uccm"></param>
    /// <returns></returns>
    GameObject getCameraPrefabsByCheckMessage(UICameraMachineDetail uccm)
    {
        GameObject go = null;
        if (uccm.MyFactoryType == CameraFactoryType.HaiKang)
        {
            //海康
            switch (uccm.HKVersion)
            {
                case HaiKangCameraVersion.DS2CD3T25I3: go = HK_DS2CD3T25I3_PreObj;break;
                case HaiKangCameraVersion.DS2CE16D1TIT3F: go = HK_DS2CE16D1TIT3F_PreObj; break;
            }
        }
        else if (uccm.MyFactoryType == CameraFactoryType.Dahua)
        {
            //大华
        }

        return go;
    }

    #endregion
}

using UnityEngine;
using System.Collections;

public class UICameraMachineDetail : MonoBehaviour {


    [Header("厂商类型")]
    public CameraFactoryType MyFactoryType = CameraFactoryType.HaiKang;

    [Header("产品型号")]
    public HaiKangCameraVersion HKVersion = HaiKangCameraVersion.DS2CD3T25I3;
    
	// Use this for initialization
	void Start () {
	
	}
	
}

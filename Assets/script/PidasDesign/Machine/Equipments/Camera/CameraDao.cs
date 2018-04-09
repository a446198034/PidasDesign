using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class CameraDao  {

    /// <summary>
    /// pos
    /// </summary>
    public Vector3 CamPos = Vector3.zero;

    /// <summary>
    /// Camera name
    /// </summary>
    public string CamName = "Camera";

    /// <summary>
    /// Photoreceptor Type
    /// </summary>
    public Photoreceptor MyPhotoreceptorType = Photoreceptor.TwoOfOne;

    /// <summary>
    /// 
    /// </summary>
    public float ValidDistance = 0;

    /// <summary>
    /// 标记我是否是球机相机
    /// </summary>
    public bool isIamQiuJiCam = false;

    /// <summary>
    /// fov
    /// </summary>
    public float FOV_Value = 60;

    /// <summary>
    /// ip
    /// </summary>
    public string IpAddressStr = "192.168.1.1";

    /// <summary>
    /// port
    /// </summary>
    public string Port = "8080";

    /// <summary>
    /// 摄像机厂商
    /// </summary>
    public CameraFactoryType CamFactorytype = CameraFactoryType.HaiKang;

    /// <summary>
    /// 摄像机型号
    /// </summary>
    public string CameraVersion = "ABCD";

    public CameraDao(){
        
    }

    public CameraDao getCameraDao(CameraDao cd)
    {
        CameraDao res = new CameraDao();

        res.CamPos = cd.CamPos;
        res.CamName = cd.CamName;
        res.MyPhotoreceptorType = cd.MyPhotoreceptorType;
        res.ValidDistance = cd.ValidDistance;
        res.isIamQiuJiCam = cd.isIamQiuJiCam;
        res.FOV_Value = cd.FOV_Value;    
        res.IpAddressStr = cd.IpAddressStr;
        res.Port = cd.Port;
        res.CamFactorytype = cd.CamFactorytype;
        res.CameraVersion = cd.CameraVersion;

        return res;
    }


}

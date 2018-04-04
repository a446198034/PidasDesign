
using UnityEngine;
/// <summary>
/// 公有类
/// </summary>
public class GlogalData {

    /// <summary>
    /// 感光元器件值
    /// </summary>
    public static float Photoreceptor_Two_One = 6.4f;
    public static float Photoreceptor_Three_One = 4.8f;
    public static float Photoreceptor_Four_One = 7.2f;
    static float QingXiest = 30;
    static float hhh;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="CurPhotoreceptor"></param>
    /// <param name="ValidDistance"></param>
    /// <returns></returns>
    public static float getDistance(float CurPhotoreceptor, float ValidDistance)
    {
        CurPhotoreceptor *= 0.001f;
        ValidDistance *= 0.001f;
        float res = 0;

        float h = QingXiest * ValidDistance / CurPhotoreceptor * 1.0f;

        hhh = h;

        float Dui_Ling = (QingXiest / 2.0f) / h * 1.0f;
        float Tan_Jiao = Mathf.Tan(Dui_Ling);
        float Hu_AJIao = Mathf.Atan(Tan_Jiao);
        res = Hu_AJIao * 180 / Mathf.PI;

        res *= 2;
        return res;
    }


}

/// <summary>
/// 控制的轴
/// </summary>
public enum ControlAxis
{
    Axis_X,
    Axis_Y,
    Axis_Z
}

/// <summary>
/// 设备类型
/// </summary>
public enum MachineType
{
    Camera,
    Microwave,
    Infrared,
    Radar
}


#region Camera

/// <summary>
/// 摄像机厂商类型
/// </summary>
public enum CameraFactoryType
{
    HaiKang,
    Dahua
}

/// <summary>
/// 海康摄像机的产品类型
/// </summary>
public enum HaiKangCameraVersion
{
    DS2CD3T25I3,
    DS2CE16D1TIT3F
}


/// <summary>
/// 摄像机的感光元器件类型
/// </summary>
public enum Photoreceptor
{
    TwoOfOne,
    ThreeOfOne,
    FourOfOne
}

/// <summary>
/// 摄像机的设备类型
/// 枪机  半球  球机
/// </summary>
public enum CameraMachineType
{
    QiangJi,
    BanQiu,
    Qiu
}

#endregion
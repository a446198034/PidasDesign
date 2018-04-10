using UnityEngine;
using System.Collections;

/// <summary>
/// 物体的Transform信息控制
/// </summary>
public class TransformMessageController : MonoBehaviour {

    [Header("Position")]
    public TransformDetail TD_Position;
    [Header("Rotation")]
    public TransformDetail TD_Rotation;
    [Header("Scale")]
    public TransformDetail TD_Scale;

    GameObject CurControlObj;
    // Use this for initialization
    void Start() {

    }

    /// <summary>
    /// 呼出设置面板
    /// </summary>
    /// <param name="go"></param>
    public void CallOnTransformControllerPanel(GameObject go)
    {
        CurControlObj = go;

        Vector3 v = CurControlObj.transform.position;
        TD_Position.InitInputValue(ControlAxis.Axis_X,v.x);
        TD_Position.InitInputValue(ControlAxis.Axis_Y,v.y);
        TD_Position.InitInputValue(ControlAxis.Axis_Z,v.z);

        Vector3 q = CurControlObj.transform.rotation.eulerAngles;
        TD_Rotation.InitInputValue(ControlAxis.Axis_X,q.x);
        TD_Rotation.InitInputValue(ControlAxis.Axis_Y,q.y);
        TD_Rotation.InitInputValue(ControlAxis.Axis_Z,q.z);

        Vector3 s = CurControlObj.transform.localScale;
        TD_Scale.InitInputValue(ControlAxis.Axis_X, s.x);
        TD_Scale.InitInputValue(ControlAxis.Axis_Y, s.y);
        TD_Scale.InitInputValue(ControlAxis.Axis_Z, s.z);

    }

    /// <summary>
    /// 处理值
    /// </summary>
    /// <param name="tt"></param>
    /// <param name="cc"></param>
    /// <param name="f"></param>
    public void DealWithInputValue(TransformType tt, ControlAxis cc, float f)
    {
        switch (tt)
        {
            case TransformType.T_position: getValueFrom_Position(cc,f);break;
            case TransformType.T_rotation: getValueFrom_Rotation(cc,f);break;
            case TransformType.T_scale: getValueFrom_Scale(cc,f);break;
        }
    }


    /// <summary>
    /// Position
    /// </summary>
    /// <param name="ca"></param>
    /// <param name="f"></param>
    void getValueFrom_Position(ControlAxis ca,float f)
    {
        Vector3 v = CurControlObj.transform.position;

        switch (ca)
        {
            case ControlAxis.Axis_X: v.x = f; break;
            case ControlAxis.Axis_Y: v.y = f; break;
            case ControlAxis.Axis_Z: v.z = f; break;
        }

        CurControlObj.transform.position = v;
    }

    /// <summary>
    /// Rotation
    /// </summary>
    /// <param name="ca"></param>
    /// <param name="f"></param>
    void getValueFrom_Rotation(ControlAxis ca, float f)
    {

        f = f < 0 ? f + 360 : f;

        Vector3 q = CurControlObj.transform.rotation.eulerAngles;

        switch (ca)
        {
            case ControlAxis.Axis_X: q.x = f; break;
            case ControlAxis.Axis_Y: q.y = f; break;
            case ControlAxis.Axis_Z: q.z = f; break;
        }

        CurControlObj.transform.rotation = Quaternion.Euler(q);

    }

    /// <summary>
    /// Scale
    /// </summary>
    /// <param name="ca"></param>
    /// <param name="f"></param>
    void getValueFrom_Scale(ControlAxis ca, float f)
    {

        Vector3 s = CurControlObj.transform.localScale;

        switch (ca)
        {
            case ControlAxis.Axis_X: s.x = f; break;
            case ControlAxis.Axis_Y: s.y = f; break;
            case ControlAxis.Axis_Z: s.z = f; break;
        }

        CurControlObj.transform.localScale = s;
    }

}

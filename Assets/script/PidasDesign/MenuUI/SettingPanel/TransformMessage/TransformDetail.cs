using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Transform 的类型  InputField
/// </summary>
public class TransformDetail : MonoBehaviour {

    [Header("类型")]
    public TransformType MyDetail = TransformType.T_position;

    [Header("X")]
    public InputField IF_X;
    bool isInputX = false;
    public GameObject Tag_X;

    [Header("Y")]
    public InputField IF_Y;
    bool isInputY = false;
    public GameObject Tag_Y;

    [Header("Z")]
    public InputField IF_Z;
    bool isInputZ = false;
    public GameObject Tag_Z;

    [Header("拖拽的图片")]
    public GameObject DragImgObj;

    [Header("TransformMessageController")]
    public GameObject MyfatherControlObj;
    TransformMessageController ttmc;

    // Use this for initialization
    void Start() {

        #region InputField

        isInputX = false;
        IF_X.onEndEdit.AddListener(delegate { X_InputFiled_EndEdit(IF_X); });
        IF_X.onValueChanged.AddListener(delegate { X_input_Changed(); });

        isInputY = false;
        IF_Y.onEndEdit.AddListener(delegate { Y_InputFiled_EndEdit(IF_Y); });
        IF_Y.onValueChanged.AddListener(delegate { Y_input_Changed(); });

        isInputZ = false;
        IF_Z.onEndEdit.AddListener(delegate { Z_InputFiled_EndEdit(IF_Z); });
        IF_Z.onValueChanged.AddListener(delegate { Z_input_Changed(); });

        #endregion

        InitDargModel();

        ttmc = MyfatherControlObj.GetComponent<TransformMessageController>();
        DragImgObj.SetActive(false);
    }

    void InitDargModel()
    {
        Tag_X.AddComponent<TransformDragController>();
        TransformDragController tdx = Tag_X.GetComponent<TransformDragController>();
        tdx.initMySelf(ControlAxis.Axis_X,gameObject,DragImgObj);

        Tag_Y.AddComponent<TransformDragController>();
        TransformDragController tdy = Tag_Y.GetComponent<TransformDragController>();
        tdy.initMySelf(ControlAxis.Axis_Y, gameObject, DragImgObj);

        Tag_Z.AddComponent<TransformDragController>();
        TransformDragController tdz = Tag_Z.GetComponent<TransformDragController>();
        tdz.initMySelf(ControlAxis.Axis_Z, gameObject, DragImgObj);
    }

    /// <summary>
    /// 设置输入框的值
    /// </summary>
    /// <param name="ca"></param>
    /// <param name="f"></param>
    public void InitInputValue(ControlAxis ca, float f)
    {
        f = GlogalData.getNumByFloat(f,3);
        switch (ca)
        {
            case ControlAxis.Axis_X: IF_X.text = f.ToString(); break;
            case ControlAxis.Axis_Y: IF_Y.text = f.ToString(); break;
            case ControlAxis.Axis_Z: IF_Z.text = f.ToString(); break;
        }
    }

    /// <summary>
    /// 设置输入框的值
    /// </summary>
    /// <param name="ca"></param>
    /// <param name="f"></param>
    public void setInputValue(ControlAxis ca, float f)
    {
        ttmc.DealWithInputValue(MyDetail, ca, f);
    }


    #region X

    void X_InputFiled_EndEdit(InputField iiiii)
    {
        float temp;
        if (!float.TryParse(iiiii.text, out temp))
        {
            Debug.Log("AAAAAAAAAAA Valid Fomat. Please Check!");
            return;
        }

        float res = float.Parse(iiiii.text);
        if (iiiii.text.Length > 0 && isInputX)
        {
            res = float.Parse(iiiii.text);
        }
        else if (iiiii.text.Length == 0 && isInputX)
        {
            Debug.Log("Your Input Empty");            
        }
        isInputX = false;

        res = GlogalData.getNumByFloat(res,3);

        setInputValue(ControlAxis.Axis_X,res);

    }
    void X_input_Changed()
    {
        isInputX = true;
    }

    #endregion

    #region Y

    void Y_InputFiled_EndEdit(InputField iiiii)
    {
        float temp;
        if (!float.TryParse(iiiii.text, out temp))
        {
            Debug.Log("AAAAAAAAAAA Valid Fomat. Please Check!");
            return;
        }

        float res = float.Parse(iiiii.text);
        if (iiiii.text.Length > 0 && isInputY)
        {
            res = float.Parse(iiiii.text);
        }
        else if (iiiii.text.Length == 0 && isInputY)
        {
            Debug.Log("Your Input Empty");
         
        }
        isInputY = false;
        res = GlogalData.getNumByFloat(res, 3);

        setInputValue(ControlAxis.Axis_Y,res);
    }
    void Y_input_Changed()
    {
        isInputY = true;
    }

    #endregion

    #region Z

    void Z_InputFiled_EndEdit(InputField iiiii)
    {
        float temp;
        if (!float.TryParse(iiiii.text, out temp))
        {
            Debug.Log("AAAAAAAAAAA Valid Fomat. Please Check!");
            return;
        }

        float res = float.Parse(iiiii.text);

        if (iiiii.text.Length > 0 && isInputZ)
        {
            res = float.Parse(iiiii.text);
        }
        else if (iiiii.text.Length == 0 && isInputZ)
        {
            Debug.Log("Your Input Empty");
        }
        isInputZ = false;
        res = GlogalData.getNumByFloat(res, 3);

        setInputValue(ControlAxis.Axis_Z,res);
    }
    void Z_input_Changed()
    {
        isInputZ = true;
    }

    #endregion


}

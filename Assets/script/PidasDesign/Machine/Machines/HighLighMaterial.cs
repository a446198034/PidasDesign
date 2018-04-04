using UnityEngine;
using System.Collections;

public class HighLighMaterial : HighlighterInteractive
{
    [Header("选中状态")]
    public bool isShow = false;

    [Header("选中的颜色")]
    public Color ShowColor = Color.red;

    #region Public Function

    public void onShowHighLight(bool s)
    {
        isShow = s;
    }

    #endregion


    #region MonoBehaviour
    // 
    protected override void Awake()
    {
        base.Awake();


    }

    // 
    protected override void Update()
    {

        if (isShow)
        {
            //  h.ConstantOnImmediate(showcc);
            h.ConstantOn(ShowColor);
        }
        else
        {
            h.ConstantOff();
        }

    }
    #endregion

}

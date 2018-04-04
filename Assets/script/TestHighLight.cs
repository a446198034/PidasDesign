using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class TestHighLight : HighlighterInteractive
{


    public bool isShow = false;

    public Color showcc = Color.red;

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
            h.ConstantOn(showcc);
        }
        else
        {
            h.ConstantOff();
        }

    }
    #endregion


}

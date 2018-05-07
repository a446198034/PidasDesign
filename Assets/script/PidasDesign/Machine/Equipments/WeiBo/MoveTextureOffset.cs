using UnityEngine;
using System.Collections;

public class MoveTextureOffset : MonoBehaviour
{
    public float scrollSpeedX = 0.5F;
    public float scrollSpeedY = 0.5F;
    public bool IsRend = false;
    private bool IsOpenAll = false;
    private Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
       

    }
    void Update()
    {


        //显示特效
        ShowTeXiao();

        //鼠标点击
        //ShowMouseClick();

        //按键控制全部
        //ShowAllTeXiao();

		//showSameType  
		//ShowSameType ();



    }

    

    //开全部
    void ShowAllTeXiao()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            IsOpenAll = IsOpenAll ? false : true;
            IsRend = IsOpenAll ? true : false;
        }
    }

    //显示特效
    void ShowTeXiao()
    {
        if (IsRend)
        {
            rend.enabled = true;
            rend.material.SetTextureOffset("_MainTex", new Vector2(Time.time * scrollSpeedX, Time.time * scrollSpeedY));
        }
        else
        {
            rend.enabled = false;
        }
    }

    //按键显示特效
    void ShowSameType()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && getSubString(transform.name) == "Micr")
        { 
            // 1  微波  weibo
			IsRend = IsRend? false : true;

        }
		if (Input.GetKeyDown(KeyCode.Alpha2) && getSubString(transform.name) == "redl")
        {
			// 2 --> hongwai
			IsRend = IsRend? false : true;
        }
		if (Input.GetKeyDown(KeyCode.Alpha3) && getSubString(transform.name) == "zhen" )
        {
            // 3  tiesiwang
			IsRend = IsRend? false : true;
        }
    }

    //显示单个特效
    void ShowMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (getSubString(hit.transform.name) == "HLig")
                {
                  
                        //IsRend = IsRend ? false : true;
                    
                }

            }
        }
    }



    //切割名字
    string getSubString(string str)
    {
        string s = str.Substring(0, 4);
        return s;
    }
}
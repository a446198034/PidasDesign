using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GanGuangYuanQiJianControl : MonoBehaviour {

    public List<GameObject> GanGuangYuanQiJianList;
    List<bool> isSelectList;

    public Color SelectColor = Color.green;

    Color initColor = Color.white;
   

	// Use this for initialization
	void Start () {

        isSelectList = new List<bool>();
        isSelectList.Add(false);
        isSelectList.Add(false);
        isSelectList.Add(false);


    }

    public void DisableAllPhotorecreptorSelected()
    {
        
    }


    public void OnClick_GanGuangYuanQiJian(int index)
    {
        
    }


}

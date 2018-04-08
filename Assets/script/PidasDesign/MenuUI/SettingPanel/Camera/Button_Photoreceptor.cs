using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 相机设置面板上面的感光元器件的按钮
/// </summary>
public class Button_Photoreceptor : MonoBehaviour {

    
    public Photoreceptor myPhotoreceptorType = Photoreceptor.TwoOfOne;

    public GameObject MyPhotoreceptorManagerObj;
    PhotoreceptorManager pm;

    public Color MyShowColor = Color.green;
    Color initColor = Color.white;
    bool isIamBeSelect = false;


	// Use this for initialization
	void Start () {

        pm = MyPhotoreceptorManagerObj.GetComponent<PhotoreceptorManager>();

	}

    public void PhotoreceptorBtn_Click()
    {
        pm.DisableAllPhotoreceptorSelected();

        OnShowHighLineManager(true);

        pm.setCurPhotoreceptorByChiCun(myPhotoreceptorType);
    }

    public void OnShowHighLineManager(bool s)
    {
        isIamBeSelect = s;
        GetComponent<Image>().color = s ? MyShowColor : initColor;
    }

   
}

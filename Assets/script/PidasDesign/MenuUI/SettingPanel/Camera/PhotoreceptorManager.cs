using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 感光元器件管理
/// </summary>
public class PhotoreceptorManager : MonoBehaviour {

    public List<Button_Photoreceptor> PhotoreceptorBtnList;

    public GameObject MyCameraSettingPanelObj;

	// Use this for initialization
	void Start () {
	    
	}

    /// <summary>
    /// 关闭所有感光元器件的高亮
    /// </summary>
    public void DisableAllPhotoreceptorSelected()
    {
        foreach (Button_Photoreceptor bp in PhotoreceptorBtnList)
        {
            bp.OnShowHighLineManager(false);
        }
    }

    /// <summary>
    /// 控制显示某个感光元器件
    /// </summary>
    /// <param name="pp"></param>
    public void ShowOnPhotorecetporByType(Photoreceptor pp)
    {
        DisableAllPhotoreceptorSelected();

        foreach (Button_Photoreceptor b in PhotoreceptorBtnList)
        {
            if (b.myPhotoreceptorType == pp)
            {
                b.OnShowHighLineManager(true);
            }
        }
    }

    /// <summary>
    /// 通知面板设置感光元器件的尺寸
    /// </summary>
    /// <param name="p"></param>
    public void setCurPhotoreceptorByChiCun(Photoreceptor p)
    {
        float f = getChiCunByPhotoreceptor(p);
        MyCameraSettingPanelObj.GetComponent<CameraSettingPanelManager>().SetCurPhotoreceptorChiCun(f);
    }

    float getChiCunByPhotoreceptor(Photoreceptor pp)
    {
        float res = 0;
        switch (pp)
        {
            case Photoreceptor.TwoOfOne: res = GlogalData.Photoreceptor_Two_One;break;
            case Photoreceptor.ThreeOfOne: res = GlogalData.Photoreceptor_Three_One;break;
            case Photoreceptor.FourOfOne: res = GlogalData.Photoreceptor_Four_One;break;
        }
        return res;
    }
}

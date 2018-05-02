using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBrandManager : MonoBehaviour {

    [Multiline,Header("脚本介绍")]
    public string Introduction = "摄像机品牌的图片管理";

    [Header("摄像机品牌 0-HK 1-DaHua")]
    public List<Sprite> BrandSpriteList;

    // Use this for initialization
    void Start () {
	
	}

    /// <summary>
    /// 根据摄像机厂商获取对应图片
    /// </summary>
    /// <param name="ctt"></param>
    /// <returns></returns>
    public Sprite getBrandByCameraFactoryType(CameraFactoryType ctt)
    {
        Sprite sp = null;

        switch (ctt)
        {
            case CameraFactoryType.HaiKang: sp = BrandSpriteList[0];break;
            case CameraFactoryType.Dahua: sp = BrandSpriteList[1];break;
        }


        return sp;
    }
}

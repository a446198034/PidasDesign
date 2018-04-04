using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LeftMenuJianTouControl : MonoBehaviour {

    public List<GameObject> ControlObjList;


    public GameObject Buttonobj;

    float HeBing_PosX = -920;
    float ZhanKai_PosX = -398;

	// Use this for initialization
	void Start () {

	}

    public void OnShowMenu()
    {
        bool s = ControlObjList[0].activeSelf;
        foreach (GameObject go in ControlObjList)
        {
            go.SetActive(!s);
        }

        Vector3 v = Buttonobj.transform.localPosition;
        v.x = s? HeBing_PosX : ZhanKai_PosX;
        Buttonobj.transform.localPosition = v;

        Vector3 q = Buttonobj.transform.localRotation.eulerAngles;
        q.z = s ? 0 : 180;
        Buttonobj.transform.localRotation = Quaternion.Euler(q);
    }
}

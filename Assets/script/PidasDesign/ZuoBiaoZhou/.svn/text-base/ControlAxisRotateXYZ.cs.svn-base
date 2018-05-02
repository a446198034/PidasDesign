using UnityEngine;
using System.Collections;

public class ControlAxisRotateXYZ : MonoBehaviour {

    public ControlAxis MyAxis = ControlAxis.Axis_X;

    [Header("操作的颜色")]
    public Color ControlColor = Color.yellow;

    public GameObject MyFatherControlObj;
    CoordinateSystem cs;
    Transform CurControlTran;
    Color initColor;
    // Use this for initialization
    void Start () {

        cs = MyFatherControlObj.GetComponent<CoordinateSystem>();
        initColor = GetComponent<Renderer>().material.color;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftAlt)) return;


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform == transform)
                {
                    CurControlTran = cs.getCurControlTran();
                    CurControlTran.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    StartCoroutine(OnMouseDownToRotate());
                }
            }
        }

	}


    #region XYZ 三轴旋转

    //XYZ 三轴旋转
    IEnumerator OnMouseDownToRotate()
    {
        setObjColor(true);

        while (Input.GetMouseButton(0))
        {
            cs.setControlObjRotation(RotatePathByTransform());
            
            //这个很重要
            yield return new WaitForFixedUpdate();
        }

        setObjColor(false);

    }

    //XYZ 三轴旋转
    Vector3 RotatePathByTransform()
    {
        
        Vector3 pos = new Vector3(MyAxis == ControlAxis.Axis_X ? -Input.GetAxis("Mouse Y") * Time.deltaTime * 50 : 0,
                          MyAxis == ControlAxis.Axis_Y ? -Input.GetAxis("Mouse X") * Time.deltaTime * 50 : 0,
                          MyAxis == ControlAxis.Axis_Z ? Input.GetAxis("Mouse Y") * Time.deltaTime * 50 : 0);

        // Debug.Log("  x " + pos.x + " y " + pos.y + " z " + pos.z);


        return pos;
    }

    #endregion

    /// <summary>
    /// 设置选中颜色
    /// </summary>
    /// <param name="isSeleted"></param>
    void setObjColor(bool isSeleted)
    {

           GetComponent<Renderer>().material.color = isSeleted ? ControlColor : initColor;
  
    }

}

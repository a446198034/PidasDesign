using UnityEngine;
using System.Collections;

public class MouseXunYouController : MonoBehaviour {

    [Multiline]
    public string JieShao = "鼠标点击事件";

    public GameObject AddMachineParentObj;
    AddMachineParentManager adpm;

    public GameObject ZuoBiaoZhou;
    CoordinateSystem cs;

    #region F Fly
    public float FlySpeed = 5;
    bool isFly = false;
    Transform CamFlyTargetTran;
    #endregion

    float initY = 0;
    float TempY = 30;
    float initX = 0;
    float TempX = 0;
    // Use this for initialization
    void Start () {
        adpm = AddMachineParentObj.GetComponent<AddMachineParentManager>();
        cs = ZuoBiaoZhou.GetComponent<CoordinateSystem>();
	}

    // Update is called once per frame
    void Update() {

        //滚轮进行缩放
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float z = -Input.GetAxis("Mouse ScrollWheel") * 10;
            transform.Translate(0, 0, -z);
        }

        if (!cs.getIfZuoBiaoZhouActive() || Input.GetMouseButton(1))
        {
            float mx = Input.GetAxis("Horizontal");
            float my = Input.GetAxis("Vertical");
            float s = Input.GetKey(KeyCode.LeftShift) ? 20 : 5;
            transform.Translate(new Vector3(mx * Time.deltaTime * s, 0, my * Time.deltaTime * s));

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(Vector3.down * Time.deltaTime * s);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(Vector3.up * Time.deltaTime * s);
            }
        }//if (!adpm.ZhouBiaoXiObj.activeSelf)

        //滚轮键拖动相机
        if (Input.GetMouseButton(2))
        {
            transform.Translate(Vector3.left * Input.GetAxis("Mouse X"));
            transform.Translate(Vector3.down * Input.GetAxis("Mouse Y"));
        }

        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X") * 2;
            float y = Input.GetAxis("Mouse Y") * 2;
            transform.Rotate(-y , x , 0);

            Vector3 vv = transform.rotation.eulerAngles;
            vv.z = 0;
            transform.rotation = Quaternion.Euler(vv);
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetMouseButtonDown(0))
            {
                initX = Input.mousePosition.x;
                initY = Input.mousePosition.y;
            }

            if (Input.GetMouseButton(0))
            {
                bool isAllowToRotateX = Mathf.Abs(Input.mousePosition.x - initX) >= TempX ? true : false;
                bool isAllowToRotateY = Mathf.Abs(Input.mousePosition.y - initY) >= TempY ? true : false;

                float x = Input.GetAxis("Mouse X") * 1;
                float y = Input.GetAxis("Mouse Y") * 1;

                x = isAllowToRotateX ? x : 0;
                y = isAllowToRotateY ? y : 0;
                if (null == CamFlyTargetTran)
                {
                    transform.Rotate(-y, x, 0);
                }
                else
                {
                    transform.LookAt(CamFlyTargetTran);
                    transform.RotateAround(CamFlyTargetTran.position,Vector3.up, x * 5);
                    transform.RotateAround(CamFlyTargetTran.position,transform.right, -y * 5);

                    //强制卡住
                    Vector3 quaV = transform.rotation.eulerAngles;

                    if (quaV.x >= 270)
                        quaV.x = Mathf.Clamp(quaV.x, 280, 359);
                    else
                        quaV.x = Mathf.Clamp(quaV.x, 1, 70);

                    //if (quaV.y > 180)
                    //    quaV.y = Mathf.Clamp(quaV.y, 180, 359);
                    //else
                    //    quaV.y = Mathf.Clamp(quaV.y, 0, 179);

                    quaV.z = 0;
                    transform.rotation = Quaternion.Euler(quaV);
                }
            }

            
            
        }

        UpdateCameraFlyControl();
    }

    /// <summary>
    /// 场景相机的飞翔控制  F
    /// </summary>
    void UpdateCameraFlyControl()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (null != adpm.getCurControlObj())
            {
                CamFlyTargetTran = adpm.getCurControlObj().transform;
                isFly = true;
            }
            
        }

        if (isFly)
        {
            transform.LookAt(CamFlyTargetTran);
            transform.position = Vector3.Lerp(transform.position, CamFlyTargetTran.position, Time.deltaTime * FlySpeed);

            if (Vector3.Distance(transform.position, CamFlyTargetTran.position) < 5)
            {
                isFly = false;
            }

        }

    }

}

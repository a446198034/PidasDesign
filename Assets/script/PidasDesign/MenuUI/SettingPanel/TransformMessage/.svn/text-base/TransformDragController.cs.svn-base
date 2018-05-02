using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// 这个类是Transform 的拖拽类
/// 由TransformDetail添加
/// </summary>
public class TransformDragController : MonoBehaviour {

    ControlAxis MyAxis;
    TransformDetail tdd;
    GameObject DragImgObj;
    float CurValue = 0;
    float ChangTemp = 1;
    bool isDraging = false;
	// Use this for initialization
	void Start () {
	
	}

    public void initMySelf(ControlAxis ca,GameObject go,GameObject DragImg)
    {
        MyAxis = ca;
        tdd = go.GetComponent<TransformDetail>();
        DragImgObj = DragImg;
        InitEventTrigger();
    }


    void InitEventTrigger()
    {
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { MouseEnterCallBack((PointerEventData)data); });
        trigger.triggers.Add(entry);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.Drag;
        entry2.callback.AddListener((data) => { MouseDragCallBack((PointerEventData)data); });
        trigger.triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.EndDrag;
        entry3.callback.AddListener((data) => { MouseEndDragCallBack((PointerEventData)data); });
        trigger.triggers.Add(entry3);

        EventTrigger.Entry entry4 = new EventTrigger.Entry();
        entry4.eventID = EventTriggerType.PointerExit;
        entry4.callback.AddListener((data) => { MouseExit((PointerEventData)data); });
        trigger.triggers.Add(entry4);
    }



    void MouseEnterCallBack(PointerEventData data)
    {
        DragImgObj.SetActive(true);
        DragImgObj.transform.position = transform.position;

        switch (MyAxis)
        {
            case ControlAxis.Axis_X: CurValue = float.Parse(tdd.IF_X.text);break;
            case ControlAxis.Axis_Y: CurValue = float.Parse(tdd.IF_Y.text);break;
            case ControlAxis.Axis_Z: CurValue = float.Parse(tdd.IF_Z.text);break;
        }
        isDraging = false;
    }

    void MouseDragCallBack(PointerEventData data)
    {
        isDraging = true;
        DragImgObj.transform.position = Input.mousePosition;

        float x = Input.GetAxis("Mouse X") * 2;
        CurValue += x;

        tdd.DealWithInputValue(MyAxis,CurValue);
        tdd.setInputValue(MyAxis,CurValue);
    }

    void MouseEndDragCallBack(PointerEventData data)
    {
        DragImgObj.SetActive(false);
    }

    void MouseExit(PointerEventData data)
    {
        if (!isDraging)
            DragImgObj.SetActive(false);
    }
}

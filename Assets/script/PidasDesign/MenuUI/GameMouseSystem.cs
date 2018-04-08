using UnityEngine;
using System.Collections;

/// <summary>
/// 全局的鼠标管理
/// </summary>
public class GameMouseSystem : MonoBehaviour {

    AddMachineParentManager ampm;

	// Use this for initialization
	void Start () {
        ampm = GetComponent<AddMachineParentManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;

            if (Physics.Raycast(ray, out rayhit))
            {

            }
        }

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;
    public GameObject cam;
    public int moveAmount;
    
    // Use this for initialization
    void Start () {
        // 形变组件transform,与该脚本直接关联上的组件就是transform
        
    }

    // Update is called once per frame
    void Update () {
        // Vector3 cameraposition = cam.transform.position;
        //  if (Input.mousePosition.y > Screen.height)
        // {
        //     cameraposition.y += moveAmount * Time.deltaTime;
        // }
        // if (Input.mousePosition.y < 0)
        // {
        //     cameraposition.y -= moveAmount * Time.deltaTime;
        // }

        // if (Input.mousePosition.x > Screen.width)//如果鼠标位置在右侧
        // {
        //     cameraposition.x += moveAmount * Time.deltaTime;//就向右移动
        // }
        // if (Input.mousePosition.x < 0)
        // {
        //     cameraposition.x -= moveAmount * Time.deltaTime;
        // }

        // // cameraposition.y = Mathf.Clamp(cameraposition.y, m_minCamYPos, m_maxCamYPos);
        // // cameraposition.x = Mathf.Clamp(cameraposition.x, m_minCamXPos, m_maxCamXPos);
        // GetComponent<Camera>().transform.position = cameraposition;//刷新摄像机位置
    }
}

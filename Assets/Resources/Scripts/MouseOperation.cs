using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 以物体target为中心
 * 右键上下左右旋转
 * 滚轮视野拉近拉远
 * 中键平移场景
 */
public class MouseOperation : MonoBehaviour
{   
    public Transform target;//相机跟随的目标物体，一般是一个空物体；没有需要为中心的物体时，为摄像机即可，target=gameObject.transform;


    private float x = 0.0f; //存储相机的euler角
    private float y = 0.0f; //存储相机的euler角

    private float Distance = 0; //相机和target之间的距离
    private Vector3 targetOnScreenPosition; //目标的屏幕坐标，第三个值为z轴距离
    private Quaternion storeRotation; //存储相机的姿态四元数
    private Vector3 CameraTargetPosition; //target的位置
    private Vector3 initPosition; //平移时用于存储平移的起点位置
    private Vector3 cameraX; //相机的x轴方向向量
    private Vector3 cameraY; //相机的y轴方向向量
    private Vector3 cameraZ; //相机的z轴方向向量

    private Vector3 initScreenPos; //中键刚按下时鼠标的屏幕坐标（第三个值其实没什么用）
    private Vector3 curScreenPos; //当前鼠标的屏幕坐标（第三个值其实没什么用）
    void Start()
    {
        //这里就是设置一下初始的相机视角以及一些其他变量，这里的x和y。。。是和下面getAxis的mouse x与mouse y对应
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        CameraTargetPosition = target.position;
        storeRotation = Quaternion.Euler(y, x, 0);
        transform.rotation = storeRotation; //设置相机姿态

        Distance = (transform.position - target.position).magnitude;
        //四元数表示一个旋转，四元数乘以向量相当于把向量旋转对应角度，然后加上目标物体的位置就是相机位置了
        transform.position = storeRotation * new Vector3(0, 0, -Distance) + CameraTargetPosition; //设置相机位置
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }


        //鼠标中键平移
        if (Input.GetMouseButtonDown(2))
        {
            cameraX = transform.right;
            cameraY = transform.up;
            cameraZ = transform.forward;

            initScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetOnScreenPosition.z);
            
            //targetOnScreenPosition.z为目标物体到相机xmidbuttonDownPositiony平面的法线距离
            targetOnScreenPosition = Camera.main.WorldToScreenPoint(CameraTargetPosition);
            initPosition = CameraTargetPosition;
        }

        if (Input.GetMouseButton(2))
        {
            curScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetOnScreenPosition.z);
            //0.01这个系数是控制平移的速度，要根据相机和目标物体的distance来灵活选择
            target.position = initPosition - Camera.main.orthographicSize/4f*0.01f * ((curScreenPos.x - initScreenPos.x) * cameraX + (curScreenPos.y - initScreenPos.y) * cameraY);

            //重新计算位置
            Vector3 mPosition = storeRotation * new Vector3(0.0F, 0.0F, -Distance) + target.position;
            transform.position = mPosition;

            //用这个会让相机的平移变得更平滑，但是可能在你buttonup时未使相机移动到应到的位置，导致再进行旋转与缩放操作时出现短暂抖动
            //transform.position=Vector3.Lerp(transform.position,mPosition,Time.deltaTime*moveSpeed);

        }
        if (Input.GetMouseButtonUp(2))
        {
            //平移结束把cameraTargetPosition的位置更新一下，不然会影响缩放与旋转功能
            CameraTargetPosition = target.position;
        }

    }

    //将angle限制在min~max之间
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
    
}

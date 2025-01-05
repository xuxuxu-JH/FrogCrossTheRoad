using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform forg;
    //相机距离Player的Y轴距离 差值
    public float offsetY;
    public float zoomBase;
    private float ratio;

    private void Start()
    {
        //获得屏幕的宽高比
        ratio = (float)Screen.height / (float)Screen.width;
        //根据屏幕的宽高比例来调整摄像机的视野 防止出现黑边
        Camera.main.orthographicSize = zoomBase * ratio * 0.5f;
    }

    //相机跟随Player
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, forg.position.y + offsetY * ratio, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.WCamera
{

    [CreateAssetMenu(menuName = "创建相机位数据/相机", fileName = "CameraViewInfo")]
    public class CameraViewInfo : ScriptableObject
    {

        public Vector3 position;
        public Vector3 rotation;

        public float fov;
    }

}
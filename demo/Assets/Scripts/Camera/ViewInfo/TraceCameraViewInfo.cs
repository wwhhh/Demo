using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.WCamera
{

    [CreateAssetMenu(menuName = "创建相机位数据/跟随相机", fileName = "TraceCameraViewInfo")]
    public class TraceCameraViewInfo : ScriptableObject
    {
        public Vector3 rotation;

        public float fov;

        public float pitch;
        public float minPitch = -40;
        public float maxPitch = 70;
        private float pitchVelocity;

        public float yaw;
        private float yawVelocity;

        public float distance;
        public float minDistance = 1;
        public float maxDistance = 50;
        private float distanceVelocity;
    }

}
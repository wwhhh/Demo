using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.WCamera
{
    public class CameraTrace : CameraBase
    {
        private const float A2R = Mathf.PI / 180;

        public bool bLookAt = true;

        TraceCameraViewInfo _info;

        Vector3 _rotation;

        // 相机俯仰角
        float _pitch;
        float _pitchDelta;
        float _pitchVelocity;

        float _yaw;
        float _yawDelta;
        float _yawVelocity;

        float _distance;
        float _fov;

        Transform _aim;

        public CameraTrace(Camera cam, string name)
        {
            Init(name);

            _cam = cam;
            _rotation = _info.rotation;
            _pitch = _info.pitch;
            _yaw = _info.yaw;
            _distance = _info.distance;
            _fov = _info.fov;

            // 特殊的属性，先设置一下
            _cam.fieldOfView = _fov;
        }

        protected override void InitViewInfo(string viewinfo)
        {
            AssetLoader<TraceCameraViewInfo> asset = AssetLoaderManager.instance.LoadAsset<TraceCameraViewInfo>(GetPath(viewinfo));
            _info = asset.asset;
            asset.UnLoadAsset();

            if (_info == null)
                Debug.LogError("Init CameraViewInfo Failure;");
        }

        public void LookAt(Transform aim)
        {
            // 设置目标
            _aim = aim;
        }

        public override void Update()
        {
            TickInput();
        }

        public override void LateUpdate()
        {
            TickTranslation();
            TickTransform();
        }

        private void TickInput()
        {
            _pitchDelta = KInput.instance.Pitch;
            _yawDelta = KInput.instance.Yaw;
        }

        private void TickTranslation()
        {
            _yaw = Mathf.SmoothDamp(_yaw, _yaw + _yawDelta, ref _yawVelocity, 0.2f);
            _pitch = Mathf.SmoothDamp(_pitch, _pitch + _pitchDelta, ref _pitchVelocity, 0.2f);
        }

        private void TickTransform()
        {
            Vector3 aimPosition = _aim.position + Vector3.up;//角色模型的问题，暂时先这么加上
            Vector3 dir = aimPosition - _cam.transform.position;
            Quaternion dest = Quaternion.LookRotation(dir, Vector3.up);
            _cam.transform.rotation = dest;

            float angle = A2R * _yaw;
            float cosYaw = Mathf.Cos(angle);
            float sinYaw = Mathf.Sin(angle);
            angle = A2R * _pitch;
            float cosPitch = Mathf.Cos(angle);
            float sinPitch = Mathf.Sin(angle);
            _cam.transform.position = aimPosition + new Vector3(_distance * cosYaw * sinPitch, _distance * sinYaw, -_distance * cosYaw * cosPitch);
        }

    }

}
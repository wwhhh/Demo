using UnityEngine;
using Framework;

namespace Game
{
    class KInput : Singleton<KInput>
    {
        #region 按键输入
        public static float ANGLE_NONE = 999f;

        public float ASDWAngle = ANGLE_NONE;
        public bool JoystickUse { get { return ASDWAngle != ANGLE_NONE; } }

        private Vector3 delta = new Vector3();
        public Vector3 GetMoveForward()
        {
            float angle = 0f;//Camera.main.transform.eulerAngles.y;
            if (ASDWAngle != ANGLE_NONE) angle += ASDWAngle;
            else return Vector3.zero;

            angle *= Mathf.Deg2Rad;
            float x = Mathf.Sin(angle);
            float z = Mathf.Cos(angle);

            delta.x = x;
            delta.z = z;
            return delta;
        }

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        public void Update()
        {
            bool A = Input.GetKey(KeyCode.A);
            bool S = Input.GetKey(KeyCode.S);
            bool D = Input.GetKey(KeyCode.D);
            bool W = Input.GetKey(KeyCode.W);

            if (A || S || D || W)
            {
                int x = -(A ? 1 : 0) + (D ? 1 : 0);
                int y = -(S ? 1 : 0) + (W ? 1 : 0);
                ASDWAngle = Mathf.Atan2(x, y) * 180f / Mathf.PI;
            }
            else
            {
                ASDWAngle = ANGLE_NONE;
            }

            if (Input.GetMouseButtonDown(1))
            {
                _enableInputCapture = true;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                Cursor.visible = false;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                _enableInputCapture = false;
            }

            if (_enableInputCapture)
            {
                Pitch = Input.GetAxis("Mouse X");
                Yaw = Input.GetAxis("Mouse Y");
                Debug.Log(Pitch + " " + Yaw);
            }
        }
#endif

        public void LateUpdate()
        {
            Pitch = 0;
            Yaw = 0;
        }

        #endregion

        #region 屏幕操作

        public float Pitch;
        public float Yaw;

        private bool _enableInputCapture = false;

        #endregion

    }
}

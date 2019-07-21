using UnityEngine;
using Game.WCamera;
using Framework;

public class CameraController : MonoBehaviour
{
    
    private Camera _cam;
    private CameraBase _cur;

    [SerializeField]
    public CameraTrace _trace;

    private void Awake()
    {
        _cam = gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (_cur == null) return;

        _cur.Update();
    }

    public void Trace(string viewinfo, Transform aim)
    {
        _trace = new CameraTrace(_cam, viewinfo);
        _trace.LookAt(aim);

        _cur = _trace;
    }

    private void LateUpdate()
    {
        if (_cur == null) return;

        _cur.LateUpdate();
    }

}

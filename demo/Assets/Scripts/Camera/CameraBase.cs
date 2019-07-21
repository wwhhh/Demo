using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.WCamera
{

    public class CameraBase
    {

        public Camera _cam;

        public CameraBase() {}

        public virtual void Update() {}

        public virtual void LateUpdate() {}

        public void Init(string viewinfo) { InitViewInfo(viewinfo); }

        protected virtual void InitViewInfo(string viewinfo) {}

        protected string GetPath(string name) { return "common/" + name; }

    }

}
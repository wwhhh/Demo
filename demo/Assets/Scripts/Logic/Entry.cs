using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using Game;

public class Entry : MonoBehaviour
{

    private ActorAuthority _actor;
    private CameraController _cc;

    private void Awake()
    {
        DataCenter.instance.InitConfigs();
    }

    void Start()
    {
        // 加载角色
        _actor = ActorManager.instance.AddActorAuthority();

        // 加载相机
        AssetLoader<GameObject> assetLoader = AssetLoaderManager.instance.LoadAsset<GameObject>("prefabs/camera");
        GameObject go = Instantiate(assetLoader.asset);
        assetLoader.UnLoadAsset();

        // 相机追踪角色
        _cc = go.GetComponent<CameraController>();
        _cc.Trace("tracecameraviewinfo", _actor.transform);
    }

    void Update()
    {
        KInput.instance.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _actor.cachedJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _actor.cachedJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            _actor.cachedSlotIdx = 1;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            _actor.stateController.ChangeStateIdle();
        }
    }

    private void LateUpdate()
    {
        KInput.instance.LateUpdate();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Actor : Entity
{

    public RotationController rotationController;
    public StateController stateController;
    public AnimationController animController;
    public PhysicsController physicsController;

    public Transform playerTransform;

    public float speedBase { get; set; }

    public int cachedSlotIdx { get; set; }

    public bool cachedJump { get; set; }

    public void ClearSkillFlag()
    {
        cachedSlotIdx = 0;
    }

    protected override bool isActor() { return true; }

    #region 模块初始化

    public void Init()
    {
        InitRotation();
        InitAvatar();
        InitPhysical();
        InitAnimation();
        InitState();
        InitAnimatorMove();
        PostInit();
    }

    protected virtual void InitAnimatorMove()
    {
    }

    protected virtual void InitPhysical()
    {
        physicsController = gameObject.AddComponent<PhysicsController>();
    }

    protected virtual void PostInit()
    {
    }

    protected virtual void InitRotation()
    {
        rotationController = gameObject.AddComponent<RotationController>();
    }
    
    protected virtual void InitAvatar() {}
    
    protected virtual void InitState()
    {
        stateController = gameObject.AddComponent<StateController>();
    }

    protected virtual void InitAnimation()
    {
        animController = gameObject.AddComponent<AnimationController>();
    }
    
    #endregion

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class ActorState
    {

        public Actor actor { get; set; }
        public ActorAuthority actorAuthority { get { return actor as ActorAuthority; } private set { } }

        public int ID = 0;

        protected Vector3 _delta;

        protected float _prevAngularVelocity;               // 朝向角速度

        public virtual void OnEnter(int preState) { }

        public virtual void OnExist(int nextState) { }

        public virtual void Tick() { }

        protected bool HasMoveInput()
        {

            bool b = KInput.instance.JoystickUse;
            if (!b) return false;

            return b;
        }

        protected bool TryRun()
        {
            if (HasMoveInput())
            {
                actor.stateController.ChangeStateMove(); 
                return true;
            }
            return false;
        }

        protected bool TryJump()
        {
            if (ID == EActorState.Skill || ID == EActorState.Jump)
                return false;

            if (actor.cachedJump)
            {
                actor.stateController.ChangeStateJump();
                return true;
            }

            return false;
        }

        protected void TickRotation()
        {
            Vector3 forward = KInput.instance.GetMoveForward();
            actor.rotationController.To(forward);
        }

        protected void TickPosition()
        {
            Vector3 forward = KInput.instance.GetMoveForward();
            if (HasMoveInput())
            {
                actor.physicsController.Move(forward);
            }
            else if (actor.physicsController.isMoving && !HasMoveInput())
            {
                actor.physicsController.Stop();
            }
            else if (!HasMoveInput())
            {

            }
        }

    }

}
using UnityEngine;

namespace Game
{
    class ActorStateJump : ActorState
    {

        public ActorStateJump()
        {
            ID = EActorState.Jump;
        }

    }

    class ActorStateJumpAuthority : ActorStateJump
    {
        float _startTime;

        public override void OnEnter(int preState)
        {
            actor.animController.Play("unarmed-jump-flip", false);
            actor.physicsController.Jump();
        }

        public override void OnExist(int nextState)
        {
            
        }


        public override void Tick()
        {
            if (actor.physicsController.isLanding)
            {
                actor.animController.Play("unarmed-land", false);
                actor.physicsController.Stop();
                _startTime = Time.time;
            }
            else if (_startTime > 0 && Time.time - _startTime > 0.3f)
            {
                _startTime = 0f;
                actor.stateController.ChangeStateIdle();
            }
            else
            {
                //TickRotation();
            }
        }
    }
}
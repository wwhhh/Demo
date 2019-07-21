using UnityEngine;

namespace Game
{

    class ActorStateMove : ActorState
    {
        public ActorStateMove()
        {
            ID = EActorState.MoveLand;
        }
    }

    class ActorStateMoveAuthority : ActorStateMove
    {

        public override void OnEnter(int preState)
        {

            actor.animController.Play("unarmed-run-forward", false);

            actorAuthority.speedBase = 5f;
        }

        public override void OnExist(int nextState)
        {
        }

        public override void Tick()
        {
            TickPosition();
            TickRotation();

            if (TryJump()) return;
            if (TryIdle()) return;
        }

        bool TryIdle()
        {
            if (!actor.physicsController.isMoving)
            {
                actor.stateController.ChangeStateIdle();
            }

            return false;
        }

    }
}
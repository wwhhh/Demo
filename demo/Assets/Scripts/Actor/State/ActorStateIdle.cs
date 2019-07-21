using UnityEngine;

namespace Game
{

    class ActorStateIdle : ActorState
    {
        public ActorStateIdle()
        {
            ID = EActorState.IdleLand;
        }
    }

    class ActorStateIdleAuthority : ActorStateIdle
    {

        float _startTime;

        public override void OnEnter(int preState)
        {
            _startTime = Time.time;
            actor.animController.Play("Unarmed-Idle", false);
        }

        public override void OnExist(int nextState)
        {
            _startTime = float.MaxValue;
        }

        public override void Tick()
        {
            if (TryJump()) return;
            if (TryRun()) return;
        }

    }
}

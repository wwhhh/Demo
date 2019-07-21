using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    
    public class StateController : MonoBehaviour
    {

        protected Actor _actor;

        private ActorState _curState = null;

        private Dictionary<int, ActorState> _dicStates = new Dictionary<int, ActorState>();

        private void Awake()
        {
            _actor = GetComponent<Actor>();
            InitStates();
        }

        protected virtual void InitStates() {}

        public void ChangeState(int id)
        {
            ActorState nextState;
            _dicStates.TryGetValue(id, out nextState);
            if (nextState == null)
            {
                 Debug.LogError(id + " state not found");
            }

            int preId = EActorState.None;
            if (_curState != null)
            {
                preId = _curState.ID;
                _curState.OnExist(id);
            }

            Debug.Log("State Changed From id=" + EActorState.ToString(preId) + " To id=" + EActorState.ToString(nextState.ID) + " time:" + Time.time);

            _curState = nextState;
            _curState.OnEnter(preId);
        }

        public int GetCurStateId()
        {
            return _curState.ID;
        }

        protected void AddState(ActorState state)
        {
            state.actor = _actor;
            _dicStates.Add(state.ID, state);
        }

        private void Update()
        {
            if (_curState != null)
                _curState.Tick();
        }

        #region 状态切换

        public void ChangeStateIdle()
        {
            ChangeState(EActorState.IdleLand);
        }

        public void ChangeStateSkill()
        {
            ChangeState(EActorState.Skill);
        }

        public void ChangeStateMove()
        {
            ChangeState(EActorState.MoveLand);
        }

        public void ChangeStateJump()
        {
            ChangeState(EActorState.Jump);
        }

        #endregion

    }

    public class StateControllerAuthority : StateController
    {

        protected override void InitStates()
        {
            AddState(new ActorStateIdleAuthority());
            AddState(new ActorStateSkillAuthority());
            AddState(new ActorStateMoveAuthority());
            AddState(new ActorStateJumpAuthority());
        }

    }

}
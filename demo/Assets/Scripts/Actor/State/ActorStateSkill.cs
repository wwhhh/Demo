
namespace Game
{
    class ActorStateSkill : ActorState
    {
        public ActorStateSkill()
        {
            ID = EActorState.Skill;
        }
    }

    class ActorStateSkillAuthority : ActorStateSkill
    {

        public override void OnEnter(int preState)
        {
        }

        public override void OnExist(int nextState)
        {

        }

        public override void Tick()
        {
        }

    }

}
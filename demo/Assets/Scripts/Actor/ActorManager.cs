using Framework;
using UnityEngine;

namespace Game
{
    
    public class ActorManager : Singleton<ActorManager>
    {
    
        public ActorAuthority AddActorAuthority()
        {
            GameObject go = new GameObject();
#if UNITY_EDITOR
            go.name = "ActorAuthority";
#endif
            ActorAuthority actor = go.AddComponent<ActorAuthority>();
            actor.Init();
            return actor;
        }
    
    }
    
}
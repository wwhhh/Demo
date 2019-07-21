
namespace Game
{
    
    public static class EActorState
    {
        public const int None = 0;
        public const int IdleLand = 1;
        public const int MoveLand = 2;
        public const int Skill = 3;
        public const int Jump = 4;

        public static string ToString(int state)
        {
            switch (state)
            {
                case 0:
                    return "None";
                case 1:
                    return "IdleLand";
                case 2:
                    return "MoveLand";
                case 3:
                    return "Skill";
                case 4:
                    return "Jump";
                default:
                    return "None";
            }
        }
    }

}

using Framework;
using Game;

namespace Assets
{
    class DataCenter : Singleton<DataCenter>
    {

        public void InitConfigs()
        {
            InitSkillConfig();
        }

        #region 技能配置

        void InitSkillConfig()
        {
            //_skillConfig = SkillConfig.Load("assets/game/common/skillconfig.asset");
        }

        #endregion
    }
}

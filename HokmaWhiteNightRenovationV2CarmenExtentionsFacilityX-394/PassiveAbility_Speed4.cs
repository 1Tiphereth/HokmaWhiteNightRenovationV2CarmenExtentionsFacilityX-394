using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_Speed4 : PassiveAbilityBase
    {
        public override void OnCreated()
        {
            name = Singleton<PassiveDescXmlList>.Instance.GetName(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 20));
            desc = Singleton<PassiveDescXmlList>.Instance.GetDesc(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 20));
        }

        public override int SpeedDiceNumAdder()
        {
            BattleUnitModel battleUnitModel = owner;
            if (battleUnitModel != null && battleUnitModel.emotionDetail?.EmotionLevel >= 3)
            {
                return 3;
            }
            return 2;
        }
    }
}

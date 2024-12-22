using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_hm_3 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            base.OnSucceedAttack(behavior);
            HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.UpdateSP(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(behavior.TargetDice?.owner), -2);
            owner.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.DmgUp, 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_hm_1 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            base.OnSucceedAttack(behavior);
            behavior.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Bleeding, HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner)) / 9);
        }
    }
}

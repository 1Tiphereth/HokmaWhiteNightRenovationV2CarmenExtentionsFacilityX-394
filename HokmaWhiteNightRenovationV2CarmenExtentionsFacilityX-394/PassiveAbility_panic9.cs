using HyperCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_panic9 : PassiveAbilityBase
    {
        public override void OnRoundEnd_before()
        {
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            if (sp <= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.minSp)
            {
                foreach (BattleUnitModel ally in BattleObjectManager.instance.GetAliveList(owner.faction))
                {
                    ally.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Protection, 2);
                    ally.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Disarm, 2);
                }
            }
        }
    }
}

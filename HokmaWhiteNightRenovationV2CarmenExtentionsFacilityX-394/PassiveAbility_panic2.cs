using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_panic2 : PassiveAbilityBase
    {
        public override void OnRoundEnd_before()
        {
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            if (sp <= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.minSp)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.DmgUp, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Vulnerable, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Binding, 6);
            }
        }
    }
}

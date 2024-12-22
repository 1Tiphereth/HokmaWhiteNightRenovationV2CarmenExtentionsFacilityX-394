using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_panic1 : PassiveAbilityBase
    {
        public override void OnRoundEnd_before()
        {
            if (owner.id == 102)
            {
                owner.view.ChangeEgoSkin("EGO_Butterfly");
            }

            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            if (sp <= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.minSp)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Weak, 1);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Disarm, 2);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Binding, 3);
            }
        }
    }
}

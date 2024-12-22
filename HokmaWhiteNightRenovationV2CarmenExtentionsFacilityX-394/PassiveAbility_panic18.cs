using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.UI.GridLayoutGroup;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_panic18 : PassiveAbilityBase
    {
        public override void OnRoundEnd_before()
        {
            base.OnRoundEnd_before();
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            if (sp <= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.minSp)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.DmgUp, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 3);
                HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.SetSP(ids, HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.maxSp);
                HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.updateSPDisplay(owner);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_panic8 : PassiveAbilityBase
    {
        public override void OnRoundEnd_before()
        {
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            if (sp <= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.minSp)
            {
                int a = UnityEngine.Random.Range(0,3);
                if (a == 0)
                {
                    owner.RecoverHP(5);
                }

                if (a == 1)
                {
                    owner.breakDetail.RecoverBreak(10);
                }

                if (a == 2)
                {
                    owner.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.DmgUp, 2);
                }

                if (a == 3)
                {
                    owner.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Vulnerable, 1);
                }
            }
        }
    }
}

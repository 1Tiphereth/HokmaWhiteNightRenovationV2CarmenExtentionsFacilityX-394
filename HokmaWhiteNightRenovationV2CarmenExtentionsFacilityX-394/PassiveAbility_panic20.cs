using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_panic20 : PassiveAbilityBase
    {
        internal bool a = false;

        public override void OnRoundEnd_before()
        {
            base.OnRoundEnd_before();
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            Debug.Log("binah: " + sp);
            if (sp >= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.maxSp)
            {
                //if (!a)
                //{
                //    Debug.Log("binah: 3" + sp);
                //    owner.bufListDetail.AddBuf(new DiceCardSelfAbility_allyBaral.BattleUnitBuf_zenaSpawner());
                //    owner.bufListDetail.AddBuf(new DiceCardSelfAbility_allyZena.BattleUnitBuf_zenaSpawner());
                //    a = true;
                //}
                //Debug.Log("binah 2: " + sp);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 3);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardAbility_hokma_burnBoth21 : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[1] { "Burn_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 2, base.owner);
            target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 1, base.owner);
        }
    }
}

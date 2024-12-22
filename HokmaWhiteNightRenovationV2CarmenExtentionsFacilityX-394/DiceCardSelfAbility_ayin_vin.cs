using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_vin : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -30);
            if (Init.IsCorroded(ids))
            {
                card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_binding2atk());
            }
            else
            {
                card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_burn2AreaEachDice());
            }
        }
    }
}

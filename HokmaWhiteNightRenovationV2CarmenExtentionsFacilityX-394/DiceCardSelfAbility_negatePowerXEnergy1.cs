using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_negatePowerXEnergy1 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            card.ignorePower = true;
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }

        public override void OnStartParrying()
        {
            BattleUnitModel target = card.target;
            if (target != null && target.currentDiceAction != null)
            {
                target.currentDiceAction.ignorePower = true;
            }
        }
    }
}

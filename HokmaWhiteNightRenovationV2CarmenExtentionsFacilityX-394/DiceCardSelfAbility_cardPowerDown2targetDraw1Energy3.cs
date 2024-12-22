using HyperCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_cardPowerDown2targetDraw1Energy3 : DiceCardSelfAbilityBase
    {

        public override void OnUseCard()
        {
            base.owner.cardSlotDetail.RecoverPlayPointByCard(3);
            base.owner.allyCardDetail.DrawCards(1);
        }

    public override void OnStartParrying()
    {
        card.target?.currentDiceAction?.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
        {
            power = -2
        });
    }
}
}

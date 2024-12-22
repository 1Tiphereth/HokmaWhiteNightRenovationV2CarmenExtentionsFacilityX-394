using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_yanSwordbutactuallygoodthistime : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[1] { "Energy_Keyword" };
        int _cost = 0;

        public override int GetCostLast(BattleUnitModel unit, BattleDiceCardModel self, int oldCost)
        {
            _cost = unit.cardSlotDetail.GetMaxPlayPoint();
            return unit.cardSlotDetail.GetMaxPlayPoint();
        }

        public override void OnUseCard()
        {
            //int emotionLevel = base.owner.emotionDetail.EmotionLevel;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = _cost,
            });
            base.owner.cardSlotDetail.RecoverPlayPointByCard(base.owner.cardSlotDetail.GetMaxPlayPoint());
        }
    }
}

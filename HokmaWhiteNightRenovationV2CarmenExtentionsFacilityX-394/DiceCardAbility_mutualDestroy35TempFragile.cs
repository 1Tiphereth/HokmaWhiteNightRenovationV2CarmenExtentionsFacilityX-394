using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardAbility_mutualDestroy35TempFragile : DiceCardAbilityBase
    {
        public override void OnWinParrying()
        {
            base.card?.target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice);
            card?.target?.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 2);
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                dmg = 2,
            });
        }

        public override void OnDrawParrying()
        {
            base.owner.currentDiceAction?.DestroyDice(DiceMatch.AllDice, DiceUITiming.AttackAfter);
        }

        public override void OnLoseParrying()
        {
            base.owner.currentDiceAction?.DestroyDice(DiceMatch.AllDice, DiceUITiming.AttackAfter);
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 3);
        }
    }
}

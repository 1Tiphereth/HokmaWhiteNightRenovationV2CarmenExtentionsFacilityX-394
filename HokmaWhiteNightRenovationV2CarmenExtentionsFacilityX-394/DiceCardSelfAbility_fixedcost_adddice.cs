using HyperCard;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    internal class DiceCardSelfAbility_fixedcost_adddice : DiceCardSelfAbilityBase
    {
        bool _used = false;

        public override bool IsFixedCost()
        {
            return true;
        }

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            base.OnRollDice(behavior);
            if (behavior.DiceVanillaValue == behavior.GetDiceMax() && !_used)
            {
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = new DiceBehaviour { Detail = BehaviourDetail.Slash, Min = 3, Dice = 7, MotionDetail = MotionDetail.H, EffectRes = "BlackSilence_H" };
                battleDiceBehavior.SetIndex(3);
                card.AddDice(battleDiceBehavior);
                _used = true;
            }
        }
    }
}

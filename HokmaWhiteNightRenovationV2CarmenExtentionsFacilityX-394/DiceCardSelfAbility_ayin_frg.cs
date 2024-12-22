using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_frg : DiceCardSelfAbilityBase
    {
        public class DiceCardAbility_ayin_frg_dice : DiceCardAbilityBase
        {
            public override void BeforeRollDice()
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmg = -9999,
                    breakDmg = behavior.GetDiceMin()
                });
            }
        }

        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -25);

            if (Init.IsCorroded(ids))
            {
                card.RemoveAllDice();
                DiceCardXmlInfo cardItem = new DiceCardXmlInfo { DiceBehaviourList = new List<DiceBehaviour> { new DiceBehaviour { Min = -15, Dice = 25, Type = BehaviourType.Atk, Detail = BehaviourDetail.Hit, MotionDetail = MotionDetail.S1, Script = "teddyEgo", ActionScript = "teddyEgo" } } };
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                battleDiceBehavior.SetIndex(0);
                card.AddDice(battleDiceBehavior);
            } else
            {
                card.ApplyDiceAbility(DiceMatch.DiceByIdx(0), new DiceCardAbility_ayin_frg_dice());
            }
        }
    }
}
 
using HyperCard;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_hm_5 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            base.OnUseCard(curCard);
            if (curCard.card._script is DiceCardSelfAbility_uniteAttack)
            {
                DiceCardXmlInfo cardItem = new DiceCardXmlInfo { DiceBehaviourList = new List<DiceBehaviour> { new DiceBehaviour { Min = 3, Dice = 6, Type = BehaviourType.Atk, Detail = BehaviourDetail.Hit, MotionDetail = MotionDetail.S2, Script = "paralysis1atk" } } };
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                curCard.AddDice(battleDiceBehavior);
            }
            else if (curCard.card._script is DiceCardSelfAbility_unitePower)
            {
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 1,
                });
            } else if (curCard.card._script is DiceCardSelfAbility_uniteDefense)
            {
                DiceCardXmlInfo cardItem = new DiceCardXmlInfo { DiceBehaviourList = new List<DiceBehaviour> { new DiceBehaviour { Min = 3, Dice = 6, Type = BehaviourType.Atk, Detail = BehaviourDetail.Penetrate, MotionDetail = MotionDetail.S3, Script = "bleeding2atk" } } };
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                curCard.AddDice(battleDiceBehavior);
            }
        }
    }
}

using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_hor : DiceCardSelfAbilityBase
    {
        public class DiceCardAbility_ayin_hor_dice : DiceCardAbilityBase
        {
            public override void OnSucceedAttack(BattleUnitModel target)
            {
                base.OnSucceedAttack(target);
                target?.bufListDetail?.AddKeywordBufThisRoundByCard(KeywordBuf.Vulnerable, 7);
                owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vulnerable, 7);
            }
        }

        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -35);
            if (Init.IsCorroded(ids))
            {
                card.DestroyDice(DiceMatch.AllDice);
                DiceCardXmlInfo cardItem = new DiceCardXmlInfo { DiceBehaviourList = new List<DiceBehaviour> { new DiceBehaviour { Min = 20, Dice = 32, Type = BehaviourType.Atk, Detail = BehaviourDetail.Penetrate, MotionDetail = MotionDetail.S1, Script = "paralysis3atk", ActionScript = "angela_super_queenbee" } } };
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                battleDiceBehavior.SetIndex(0);
                card.AddDice(battleDiceBehavior);

            }
            else
            {
                card.ApplyDiceAbility(DiceMatch.DiceByIdx(0), new DiceCardAbility_paralysis3atk());
            }
        }
    }
}

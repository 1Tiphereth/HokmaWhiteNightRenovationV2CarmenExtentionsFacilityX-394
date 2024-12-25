using HyperCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_x394_disposal : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[1] { "WarpCharge" };

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            BattleUnitBuf activatedBuf = owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge);
            if (activatedBuf != null && activatedBuf.stack >= 20)
            {
                return true;
            }
            return false;
        }

        public override void OnUseCard()
        {
            card.card.exhaust = true;
        }

        public override void OnEndBattle()
        {
            if (card.target != null && card.target.IsDead())
            {
                base.owner.allyCardDetail.AddNewCard(608004).AddCost(-2);
                base.owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, 7);
                base.owner.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Strength, 3);
                base.owner.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Protection, 3);

                if (base.owner.UnitData.historyInStage.stageInfo.chapter == 6)
                {
                    base.owner.UnitData.historyInUnit.killByCheoboon++;
                }
            }
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitBuf_warpCharge activatedBuf = owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) as BattleUnitBuf_warpCharge;
            
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = 3 * activatedBuf.stack
            });
            activatedBuf.UseStack(activatedBuf.stack, true);


            if (card.target != null && card.target.hp <= (float)card.target.MaxHp * 0.5f)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = 100
                });
            }
        }
    }
}

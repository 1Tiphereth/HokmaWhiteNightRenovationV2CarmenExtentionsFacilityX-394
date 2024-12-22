using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ammo_discard2draw1 : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[2] { "bullet_keyword", "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            BattleDiceCardModel battleDiceCardModel = base.owner.allyCardDetail.DiscardACardLowest();
            BattleDiceCardModel battleDiceCardModel2 = base.owner.allyCardDetail.DiscardACardLowest();
            base.owner.allyCardDetail.DrawCards(1);
            if (battleDiceCardModel != null)
            {
                if (ThumbBulletClass.IsBulletId(battleDiceCardModel.GetID()))
                {
                    card.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus
                    {
                        power = 1
                    });
                }
                if (base.owner.UnitData.historyInStage.stageInfo.chapter == 6)
                {
                    base.owner.UnitData.historyInUnit.ch6discardByThumb++;
                }
            }
            else if (battleDiceCardModel2 != null && ThumbBulletClass.IsBulletId(battleDiceCardModel2.GetID()))
            {
                card.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus
                {
                    power = 1
                });
            }
        }
        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            base.OnRollDice(behavior);
            BattleUnitBuf buf = base.owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_Ammo);
            if (buf != null && buf.stack >= 0)
            {
                buf.stack = buf.stack - 1;
            }
        }
    }
}

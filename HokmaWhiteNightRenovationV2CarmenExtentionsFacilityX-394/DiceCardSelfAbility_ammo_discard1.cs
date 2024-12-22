using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ammo_discard1 : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[1] { "bullet_keyword" };

        public override void OnUseCard()
        {
            BattleDiceCardModel battleDiceCardModel = base.owner.allyCardDetail.DiscardACardLowest();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ammo_discard4bullet : DiceCardSelfAbilityBase
    {
        private int _max = 4;

        public override string[] Keywords => new string[1] { "bullet_keyword" };

        public override void OnUseCard()
        {
            List<BattleDiceCardModel> list = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetCost() == 0);
            List<BattleDiceCardModel> list2 = new List<BattleDiceCardModel>();
            for (int i = 0; i < _max; i++)
            {
                if (list.Count > 0)
                {
                    BattleDiceCardModel item = RandomUtil.SelectOne(list);
                    list2.Add(item);
                    list.Remove(item);
                }
            }
            base.owner.allyCardDetail.DiscardACardByAbility(list2);
            List<BattleDiceCardModel> list3 = list2.FindAll((BattleDiceCardModel x) => ThumbBulletClass.IsBulletId(x.GetID()));
            if (list3.Count > 0 && base.owner.UnitData.historyInStage.stageInfo.chapter == 6)
            {
                base.owner.UnitData.historyInUnit.ch6discardByThumb++;
            }
            card.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus
            {
                power = list3.Count
            });

            BattleUnitBuf buf = base.owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_Ammo);
            if (buf != null && buf.stack >= 0)
            {
                card.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus
                {
                    power = buf.stack
                });
                buf.stack = 0;
            }

        }
    }
}

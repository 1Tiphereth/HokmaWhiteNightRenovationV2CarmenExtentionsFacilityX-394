using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_cardPowerDown2targetDraw1Energy3GloriaSingletonCostBuf : DiceCardSelfAbilityBase
    {
        public class BattleDiceCardBuf_costDown1round : BattleDiceCardBuf
        {
            public override int GetCost(int oldCost)
            {
                return oldCost - 1;
            }
        }

        public override string[] Keywords => new string[2] { "Energy_Keyword", "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            foreach (BattleDiceCardModel item in owner.allyCardDetail.GetAllDeck())
            {
                foreach (BattleDiceCardBuf item2 in item.GetBufList().FindAll((BattleDiceCardBuf x) => x is BattleDiceCardBuf_costDown1round))
                {
                    item.RemoveBuf(item2);
                }
            }
            List<BattleDiceCardModel> list = owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.CurCost > 0);
            if (list.Count > 0)
            {
                RandomUtil.SelectOne(list).AddBuf(new BattleDiceCardBuf_costDown1round());
            }
            card.card.AddBuf(new BattleDiceCardBuf_costDown1round());

            base.owner.cardSlotDetail.RecoverPlayPointByCard(3);
            base.owner.allyCardDetail.DrawCards(1);
        }

        public override void OnStartParrying()
        {
            card.target?.currentDiceAction?.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = -2
            });
        }
    }
}

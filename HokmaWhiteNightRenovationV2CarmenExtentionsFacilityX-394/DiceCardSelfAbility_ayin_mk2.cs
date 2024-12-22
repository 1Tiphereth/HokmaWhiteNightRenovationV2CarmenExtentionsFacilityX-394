using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_mk2 : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[2] { "ego_Keyword", "WarpCharge" };
        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -25);
            if (Init.IsCorroded(ids))
            {

                List<BattlePlayingCardDataInUnitModel.SubTarget> list = new List<BattlePlayingCardDataInUnitModel.SubTarget>();
                var list1 = BattleObjectManager.instance.GetAliveList();
                list1.Remove(owner);
                foreach (BattleUnitModel battleUnitModel in list1)
                {
                    list.Add(new BattlePlayingCardDataInUnitModel.SubTarget
                    {
                        target = battleUnitModel,
                        targetSlotOrder = UnityEngine.Random.Range(0, battleUnitModel.speedDiceResult.Count)
                    });
                }
                card.subTargets = list;

                BattleUnitBuf_warpCharge battleUnitBuf_warpCharge = base.owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) as BattleUnitBuf_warpCharge;
                if (battleUnitBuf_warpCharge != null && battleUnitBuf_warpCharge.stack >= 3)
                {
                    int stack = battleUnitBuf_warpCharge.stack;
                    battleUnitBuf_warpCharge.UseStack(stack, isCard: true);
                    card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                    {
                        dmg = stack/3
                    });
                }
            }
            else
            {
                BattleUnitBuf_warpCharge battleUnitBuf_warpCharge = base.owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) as BattleUnitBuf_warpCharge;
                if (battleUnitBuf_warpCharge != null && battleUnitBuf_warpCharge.stack >= 4)
                {
                    int stack = battleUnitBuf_warpCharge.stack;
                    battleUnitBuf_warpCharge.UseStack(stack, isCard: true);
                    card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                    {
                        power = stack / 4
                    });
                }
            }
        }
    }
}

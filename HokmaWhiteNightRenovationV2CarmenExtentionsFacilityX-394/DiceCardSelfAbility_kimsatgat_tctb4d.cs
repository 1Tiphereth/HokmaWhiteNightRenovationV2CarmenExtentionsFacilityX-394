using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.PassiveAbility_kimsatgat_resent;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_kimsatgat_tctb4d : DiceCardSelfAbilityBase
    {
        public int _clWon = 0;

        public override void OnWinParryingAtk()
        {
            _clWon++;
        }

        public override void OnLoseParrying()
        {
            if (_clWon == 3)
            {
                owner.breakDetail.TakeBreakDamage(owner.breakDetail.GetDefaultBreakGauge());
            }
            _clWon = 0;
            card.DestroyDice(DiceMatch.AllDice);
            //card.RemoveAllDice();
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (_clWon == 2)
            {
                behavior.card.DestroyDice(DiceMatch.NextDice);
                BattleUnitModel target = base.card.target;
                BattleDiceCardModel card = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId(Init.packageName, 201), false));
                List<BattlePlayingCardDataInUnitModel.SubTarget> list = new List<BattlePlayingCardDataInUnitModel.SubTarget>();
                foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy))
                {
                    list.Add(new BattlePlayingCardDataInUnitModel.SubTarget
                    {
                        target = battleUnitModel,
                        targetSlotOrder = UnityEngine.Random.Range(0, battleUnitModel.speedDiceResult.Count)
                    });
                }
                BattlePlayingCardDataInUnitModel card2 = new BattlePlayingCardDataInUnitModel
                {
                    card = card,
                    owner = base.owner,
                    subTargets = list
                };
                int s = 5;
                if (owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_kimsatgat_resent) != null)
                {
                    s = owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_kimsatgat_resent).stack;
                }
                card2.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus
                {
                    dmg = s/3,
                    breakDmg = s,
                });
                if (base.card.target != null && !base.card.target.IsDead())
                {
                    Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target, -1);
                    return;
                }
                List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction != Faction.Player) ? Faction.Player : Faction.Enemy);
                if (aliveList.Count > 0)
                {
                    BattleUnitModel target2 = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                    Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target2, -1);
                }
            } else
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    breakRate = -9999
                });
            }
            base.BeforeRollDice(behavior);
        }

        public override void OnUseCard()
        {
            _clWon = 0;
            //card.ApplyDiceAbility(DiceMatch.LastDice, new DiceCardAbility_kimsatgat_tctb4d_ma());
            base.OnUseCard();
        }
    }
}

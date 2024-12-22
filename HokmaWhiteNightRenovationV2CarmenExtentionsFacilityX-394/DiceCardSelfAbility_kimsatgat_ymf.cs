using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceCardSelfAbility_elenaMinionStrong;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_kimsatgat_ymf : DiceCardSelfAbilityBase
    {
        public class BattleUnitBuf_elenaStrongOnce : BattleUnitBuf
        {
            public override void OnRoundEnd()
            {
                Destroy();
            }
        }

        private bool _successAttack;
        private int _stack = 0;

        public override void OnUseCard()
        {
            _successAttack = false;
        }

        public override void OnSucceedAttack()
        {
            _successAttack = true;
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = _stack * 2,
            });
            _stack++;
            base.BeforeRollDice(behavior);
        }

        public override void OnEndBattle()
        {
            if (_successAttack)
            {
                List<BattleUnitModel> aliveList_opponent = BattleObjectManager.instance.GetAliveList_opponent(base.owner.faction);
                card?.target.bufListDetail.AddBuf(new BattleUnitBuf_elenaStrongOnce());
                aliveList_opponent.RemoveAll((BattleUnitModel x) => x.bufListDetail.HasBuf<BattleUnitBuf_elenaStrongOnce>());
                if (aliveList_opponent.Count > 0)
                {
                    BattleUnitModel target = RandomUtil.SelectOne(aliveList_opponent);
                    Singleton<StageController>.Instance.AddAllCardListInBattle(card, target);
                }
            }
        }
    }
}

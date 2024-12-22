using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_fanatic_angel : PassiveAbilityBase
    {
        public class BattleUnitBuf_Fanatic : BattleUnitBuf
        {
            public override string keywordId => "WhiteLoss";

            public override BufPositiveType positiveType => BufPositiveType.Positive;

            public override void BeforeRollDice(BattleDiceBehavior behavior)
            {
                base.BeforeRollDice(behavior);
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 2
                });
            }
        }
        public override void OnRoundEnd()
        {
            if (!BattleObjectManager.instance.GetAliveList(owner.faction).Exists((BattleUnitModel x) => x != owner))
            {
                owner.battleCardResultLog?.SetPassiveAbility(this);
                if (!owner.bufListDetail.GetActivatedBufList().Exists(m => m is BattleUnitBuf_Fanatic))
                {
                    owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_Fanatic());
                }
            }
        }
    }
}

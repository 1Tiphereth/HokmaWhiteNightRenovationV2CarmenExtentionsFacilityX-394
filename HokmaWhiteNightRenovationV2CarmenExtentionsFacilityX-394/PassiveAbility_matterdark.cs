using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_matterdark : PassiveAbilityBase
    {

        private BattleUnitModel _lastTarget;

        public class BattleUnitBuf_BlackMark1 : BattleUnitBuf
        {
            public override string keywordId => "BlackMark";

            public override BufPositiveType positiveType => BufPositiveType.Negative;

            public override void Init(BattleUnitModel owner)
            {
                base.Init(owner);
                stack = 2;
            }

            public override void OnRoundStart()
            {
                base.OnRoundStart();
            }

            public override void OnRoundEnd()
            {
                base.OnRoundEnd();
                stack--;
                if (stack <= 0)
                {
                    Destroy();
                }
            }

            public override void BeforeRollDice(BattleDiceBehavior behavior)
            {
                base.BeforeRollDice(behavior);
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = -1
                });
            }
        }



        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (!owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x is BattleUnitBuf_SpiritLink))
            {
                return;
            }
            EnemyTeamStageManager enemyStageManager = Singleton<StageController>.Instance.EnemyStageManager;
                BattleUnitModel battleUnitModel = behavior?.card?.target;
                if (battleUnitModel != null)
                {
                    _lastTarget = battleUnitModel;
                }
            
        }

        public override void OnRoundEnd()
        {
            base.OnRoundEnd();
            if (_lastTarget != null)
            {
                _lastTarget.bufListDetail.AddReadyBuf(new BattleUnitBuf_BlackMark1());
                _lastTarget = null;
            }
        }
    }
}

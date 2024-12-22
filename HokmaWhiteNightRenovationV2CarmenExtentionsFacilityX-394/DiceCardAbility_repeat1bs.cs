using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardAbility_repeat1bs : DiceCardAbilityBase
    {
        private int _repeatCount;

        public override void AfterAction()
        {
            PassiveAbility_10012 passiveAbility_ = owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_10012) as PassiveAbility_10012;
            if (passiveAbility_ != null)
            {
                if (passiveAbility_.IsActivatedSpecialCard())
                {
                    if (!base.owner.IsBreakLifeZero() && _repeatCount < 1)
                    {
                        _repeatCount++;
                        ActivateBonusAttackDice();
                    }
                }
            }
        }
    }
}

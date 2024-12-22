using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_rerollper20sp : DiceCardSelfAbilityBase
    {
        public class DiceCardAbility_rerollper20sp : DiceCardAbilityBase
        {
            private int _repeatCount;
            public int max = -1;

            public override void AfterAction()
            {
                if (max != -1)
                {
                    if (!base.owner.IsBreakLifeZero() && _repeatCount < max)
                    {
                        _repeatCount++;
                        ActivateBonusAttackDice();
                    }
                }
            }
        }

        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            int c = 0;

            if (sp > 20 )
            {
                c = sp / 20;
                card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_rerollper20sp { max = c });
            }
        }
    }
}

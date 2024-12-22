using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardAbility_atksp5 : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.UpdateSP(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(target), 5);
            Init.updateSPDisplay(target);
        }
    }
}

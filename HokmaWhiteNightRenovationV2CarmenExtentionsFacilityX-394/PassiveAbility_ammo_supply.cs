using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_ammo_supply : PassiveAbilityBase
    {
        private int _count;

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged == CardRange.Near)
            {
                _count++;
                if (_count >= 3)
                {
                    owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId());
                    _count = 0;
                }
            }
        }

        public override void OnWaveStart()
        {
            base.OnWaveStart();
            owner.bufListDetail.AddReadyReadyBuf(new BattleUnitBuf_Ammo { stack = 5});
        }
    }
}

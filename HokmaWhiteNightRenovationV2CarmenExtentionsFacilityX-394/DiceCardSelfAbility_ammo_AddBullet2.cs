using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ammo_AddBullet2 : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[1] { "bullet_keyword" };

        public override void OnUseCard()
        {
            base.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId());
            base.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId());
            base.owner.bufListDetail.AddReadyReadyBuf(new BattleUnitBuf_Ammo { stack = 2 });

        }
    }
}

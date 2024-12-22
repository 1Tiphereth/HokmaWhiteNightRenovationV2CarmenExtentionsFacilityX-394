using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ammo_AddBullet1AndDraw : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[2] { "bullet_keyword", "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            base.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId());
            base.owner.allyCardDetail.DrawCards(1);
            base.owner.bufListDetail.AddReadyReadyBuf(new BattleUnitBuf_Ammo { stack = 1 });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardAbility_yujin4 : DiceCardAbilityBase
    {
        public override void OnRollDice()
        {
            if (behavior.DiceVanillaValue >= 4 && behavior.DiceVanillaValue == behavior.GetDiceMax())
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 45
                });
                owner.allyCardDetail.DrawCards(2);
                owner.cardSlotDetail.RecoverPlayPoint(4);
                if (base.owner.faction == Faction.Player)
                {
                    Singleton<StageController>.Instance.ReserveAchievement(AchievementEnum.ONCE_FOUR_BORDER);
                }
            }
        }
    }
}

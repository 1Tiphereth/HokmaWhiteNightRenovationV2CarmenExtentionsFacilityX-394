using HyperCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_theClaw : PassiveAbilityBase
    {
        bool _hasCounter = false;
        int lc = -1;
        public override void OnRoundStart()
        {
            if (lc == -1)
            {
                lc = owner.cardSlotDetail.GetMaxPlayPoint();
            } else if (lc == 0)
            {
                int defaultBreakGauge = owner.breakDetail.GetDefaultBreakGauge();
                owner.breakDetail.TakeBreakDamage(defaultBreakGauge, DamageType.Card_Ability, base.owner, AtkResist.None);
                owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vulnerable, 3);
            }

            int count = owner.allyCardDetail.GetHand().Count;
            int num = 6 - count;
            if (num > 0)
            {
                owner.allyCardDetail.DrawCards(num);
            }

            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, BattleObjectManager.instance.GetAliveList_opponent(owner.faction).Count);

            owner.cardSlotDetail.RecoverPlayPointByCard(lc);
            lc = lc - 1;
            
            if (!_hasCounter)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_clawCounter());
                _hasCounter = true;
            }
        }
    }
}

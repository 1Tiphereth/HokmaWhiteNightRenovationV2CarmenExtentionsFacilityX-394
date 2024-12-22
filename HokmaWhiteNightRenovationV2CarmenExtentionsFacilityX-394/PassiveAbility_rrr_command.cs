using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.UI.GridLayoutGroup;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_rrr_command : PassiveAbilityBase
    {
        internal bool _c;

        public class BattleUnitBuf_Disposal : BattleUnitBuf
        {
            bool _d;
            public override string keywordId => "Disposal";

            public override void OnRoundStart()
            {
                base.OnRoundStart();
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 2);
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 2);
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 2);
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.BreakProtection, 2);
                _owner.cardSlotDetail.RecoverPlayPoint(2);
                _owner.allyCardDetail.DrawCards(2);
            }

            public override void Init(BattleUnitModel owner)
            {
                base.Init(owner);
                if (!_d)
                {
                    owner.allyCardDetail.AddNewCard(608004, true);
                    owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, 11);
                    owner.cardSlotDetail.RecoverPlayPoint(owner.cardSlotDetail.GetMaxPlayPoint());
                    _d = true;
                }
            }

            public override int SpeedDiceNumAdder()
            {
                return 2;
            }
        }

        public override void OnRoundStart()
        {
            BattleUnitBuf activatedBuf = owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge);
            if (activatedBuf == null || activatedBuf.stack < 11)
            {
                return;
            }
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                alive.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1, owner);
                alive.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 1, owner);
                alive.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1, owner);
            }
        }
        public override void OnRoundEnd()
        {
            if (!_c && !BattleObjectManager.instance.GetAliveList(owner.faction).Exists((BattleUnitModel x) => x != owner))
            {
                owner.battleCardResultLog?.SetPassiveAbility(this);
                owner.bufListDetail.AddReadyReadyBuf(new BattleUnitBuf_Disposal());
                _c = true;
            }
        }

        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            base.BeforeGiveDamage(behavior);
            int c = 0;
            BattleUnitBuf activatedBuf = owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge);
            if (activatedBuf != null && activatedBuf.stack > 0)
            {
                c = activatedBuf.stack;
            }


            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = 2 * c,
                breakRate = 2 * c,
            });
        }
    }
}

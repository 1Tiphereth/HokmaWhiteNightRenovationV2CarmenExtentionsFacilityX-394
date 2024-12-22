using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init;
using static HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.PassiveAbility_rrr_command;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_hm_4 : PassiveAbilityBase
    {
        public List<int> hana = new List<int> { 160003, 260003, 160002, 260002, 160004, 260004, 160001, 260001, 160101 };
        public bool _c = false;

        public override void OnRoundStart()
        {
            base.OnRoundStart();
            owner.bufListDetail.AddReadyReadyBuf(new SpGainBuf { stack = 3 });
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            if (sp <= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.maxSp)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 1);
            }

            if (!BattleObjectManager.instance.GetAliveList(owner.faction).Exists((BattleUnitModel x) => x != owner))
            {
                _c = true;
            } else
            {
                _c = false;
            }
        }

        public override int SpeedDiceNumAdder()
        {
            if (_c)
            {
                return 2;
            }
            return 0;
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            int x = 1;
            foreach (BattleUnitModel c in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                if (!c.Book.IsWorkshop)
                {
                    if (hana.Contains(c.Book.BookId.id))
                    {
                        x += 1;
                    }
                }
            }
            if (_c)
            {
                int min = 2;
                int max = 0;
                if (owner.emotionDetail.EmotionLevel >= 3)
                {
                    max = 1;
                }
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    min = min,
                    max = max,
                    dmgRate = x * 5
                });

            }
            else
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = x * 5
                });
            }
        }

        public override void OnRoundEnd_before()
        {
            string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(owner);
            int sp = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetSP(ids);
            if (sp <= HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.minSp)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 3);
            }
        }
    }
}

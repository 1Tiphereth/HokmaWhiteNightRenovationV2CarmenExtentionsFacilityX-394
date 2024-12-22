using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_Orlando : PassiveAbilityBase
    {
        public class BattleUnitBuf_blackSilenceCardCount : BattleUnitBuf
        {
            public override string keywordId => "BlackSilenceCardCount";

            public override string keywordIconId => "BlackSilenceCardCount";
        }

        private int _count;

        public override void OnWaveStart()
        {
            owner.allyCardDetail.DrawCards(2);
        }

        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (_count == 2)
            {
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 2
                });
                _count = 0;
            }
            else
            {
                _count++;
            }
            owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_blackSilenceCardCount));
            if (_count > 0)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_blackSilenceCardCount
                {
                    stack = _count
                });
            }

            if (_count == 9)
            {
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 1
                });
            }
        }
    }
}

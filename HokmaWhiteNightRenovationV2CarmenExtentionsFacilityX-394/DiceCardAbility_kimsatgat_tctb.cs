using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using static HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.PassiveAbility_kimsatgat_resent;
using static UnityEngine.UI.GridLayoutGroup;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardAbility_kimsatgat_tctb : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[1] { "Paralysis_Keyword" };

            public override void BeforeRollDice()
            {
                int s = 5;
                if (card.target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_kimsatgat_revenge) != null)
                {
                    s = card.target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_kimsatgat_revenge).stack;
                }
                behavior.ApplyDiceStatBonus(
                new DiceStatBonus
                {
                    power = s,
                });
                base.BeforeRollDice();
            }


        public override void OnSucceedAttack()
        {
            base.card.target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 5, base.owner);
            base.card.target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 3, base.owner);
        }
    }
}
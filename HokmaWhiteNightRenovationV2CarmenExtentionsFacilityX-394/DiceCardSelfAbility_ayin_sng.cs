using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_sng : DiceCardSelfAbilityBase
    {
        private const int _BREAK_DMG = 3;

        private const int _STRENGTH = 1;

        private bool _awek = false;

        public override string[] Keywords => new string[3] { "ego_Keyword", "Strength_Keyword", "Paralysis_Keyword" };

        public override void OnSucceedAttack()
        {
            if (_awek)
            {
                List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(base.owner.faction);
                if (aliveList.Count > 0)
                {
                    BattleUnitModel battleUnitModel = RandomUtil.SelectOne(aliveList);
                    battleUnitModel.TakeBreakDamage(3, DamageType.Card_Ability, base.owner, AtkResist.None);
                    battleUnitModel.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 1, base.owner);
                }
            }
        }

        public override void OnEndBattle()
        {
            if (card.target == null || !card.target.IsDead())
            {
                return;
            }
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(base.owner.faction))
            {
                alive.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 3, base.owner);
            }
        }
        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -30);
            if (Init.IsCorroded(ids))
            {
                card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_paralysis2atk());

            }

                _awek = true;
        }
    }
}

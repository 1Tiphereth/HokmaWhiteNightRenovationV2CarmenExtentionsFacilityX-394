using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardAbility_ayin_fmf_dice : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[3] { "ego_Keyword", "AreaDiceAll_Keyword", "Burn_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 7 + base.owner.emotionDetail.EmotionLevel, base.owner);
            target?.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_burnBreak());
            GameObject gameObject = Util.LoadPrefab("Battle/DiceAttackEffects/New/FX/IllusionCard/1_M/FX_IllusionCard_1_M_FireTrail_UnATK");
            if (gameObject != null)
            {
                gameObject.transform.position = target.view.atkEffectRoot.position;
                gameObject.AddComponent<AutoDestruct>().time = 3f;
            }
        }
    }
}

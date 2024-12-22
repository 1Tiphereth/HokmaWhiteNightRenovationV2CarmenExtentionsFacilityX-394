using Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceCardSelfAbility_recoverNextRound;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_theClaw_recoverNextRound : DiceCardSelfAbilityBase
    {
        public class BattleUnitBuf_green : BattleUnitBuf
        {
            public override void OnRoundStart()
        {
                _owner.RecoverHP(50);
                _owner.RecoverBreakLife(50);
                _owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 3);
                _owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 3);
            }

            public override void OnDrawCard()
        {
            if (!_owner.IsBreakLifeZero())
            {
                GameObject gameObject = Util.LoadPrefab("Battle/DiceAttackEffects/New/FX/Mon/Claw/FX_Mon_Claw_Recovery");
                if (gameObject != null)
                {
                    gameObject.transform.position = _owner.view.charAppearance.GetSpecialMotionPivot(ActionDetail.S6).position;
                    gameObject.AddComponent<AutoDestruct>().time = 3f;
                }
                _owner.view.charAppearance.ChangeMotion(ActionDetail.S6);
            }
            Destroy();
        }

        public override void OnRoundEnd()
        {
            Destroy();
        }
    }

    public override void OnApplyCard()
    {
        if (!base.owner.IsBreakLifeZero())
        {
            GameObject gameObject = Util.LoadPrefab("Battle/DiceAttackEffects/New/FX/Mon/Claw/FX_Mon_Claw_MistGreen");
            if (gameObject != null)
            {
                gameObject.transform.position = base.owner.view.charAppearance.GetSpecialMotionPivot(ActionDetail.S10).position;
                gameObject.AddComponent<AutoDestruct>().time = 3f;
            }
            base.owner.view.charAppearance.ChangeMotion(ActionDetail.S10);
            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Claw_Injection");
        }
    }

    public override void OnStartBattle()
    {
        base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_green());
    }
}
}

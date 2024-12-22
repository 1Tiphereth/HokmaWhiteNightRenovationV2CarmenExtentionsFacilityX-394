using Sound;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_clawUltimate : DiceCardSelfAbilityBase
    {
        private GameObject _hologramEffect;

        public override void OnApplyCard()
        {
            if (base.owner.IsBreakLifeZero())
            {
                return;
            }
            GameObject gameObject = Util.LoadPrefab("Battle/DiceAttackEffects/New/FX/Mon/Claw/FX_Mon_Claw_MistBlue");
            if (gameObject != null)
            {
                gameObject.transform.position = base.owner.view.charAppearance.GetSpecialMotionPivot(ActionDetail.S11).position;
                gameObject.AddComponent<AutoDestruct>().time = 3f;
                SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Claw_Injection");
            }
            base.owner.view.charAppearance.ChangeMotion(ActionDetail.S11);
            _hologramEffect = Util.LoadPrefab("Battle/DiceAttackEffects/New/FX/Mon/Claw/FX_Mon_Claw_SpecialHolo");
            if (_hologramEffect != null)
            {
                _hologramEffect.transform.SetParent(base.owner.view.transform);
                _hologramEffect.transform.position = base.owner.view.charAppearance.GetSpecialMotionPivot(ActionDetail.S15).position;
                if (base.owner.direction == Direction.RIGHT)
                {
                    _hologramEffect.transform.localRotation = Quaternion.Euler(0f, 80f, 0f);
                }
                SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Claw_Hologram");
            }
        }

        public override void OnStartBattleAfterCreateBehaviour()
        {
            base.OnStartBattleAfterCreateBehaviour();
            if (_hologramEffect != null)
            {
                UnityEngine.Object.Destroy(_hologramEffect);
            }
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            int count = owner.allyCardDetail.GetHand().Count;
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                power = 30 + count * 10,
                breakRate = 2,
            });
            owner.allyCardDetail.DiscardACardByAbility(owner.allyCardDetail.GetHand());
            base.BeforeRollDice(behavior);
        }
    }
}

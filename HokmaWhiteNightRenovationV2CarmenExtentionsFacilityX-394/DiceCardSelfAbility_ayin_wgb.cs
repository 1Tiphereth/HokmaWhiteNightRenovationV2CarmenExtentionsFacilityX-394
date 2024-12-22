using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_wgb : DiceCardSelfAbilityBase
    {
        public class DiceCardAbility_ayin_wgb_dice : DiceCardAbilityBase
        {
            private int count;

            public override string[] Keywords => new string[2] { "ego_Keyword", "Recover_Keyword" };

            public override void OnSucceedAttack()
            {
                string ids = Init.GetOwnId(owner);
                if (behavior.DiceVanillaValue == behavior.GetDiceMax())
                {
                    base.owner.RecoverHP(3);
                } else
                {
                    card.target?.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Bleeding, 1);
                }

                if (count >= 5)
                {
                    return;
                }
                if (Init.GetSP(ids) > Init.baseSp)
                {
                    Init.UpdateSP(ids, -15);
                    ActivateBonusAttackDice();
                    count++;
                }
                base.owner.battleCardResultLog.SetSucceedAtkEvent(delegate
                {
                    CameraFilterPack_FX_EarthQuake cameraFilterPack_FX_EarthQuake = SingletonBehavior<BattleCamManager>.Instance?.EffectCam.gameObject.AddComponent<CameraFilterPack_FX_EarthQuake>() ?? null;
                    if (cameraFilterPack_FX_EarthQuake != null)
                    {
                        cameraFilterPack_FX_EarthQuake.StartCoroutine(EarthQuakeRoutine(cameraFilterPack_FX_EarthQuake));
                        AutoScriptDestruct autoScriptDestruct = SingletonBehavior<BattleCamManager>.Instance?.EffectCam.gameObject.AddComponent<AutoScriptDestruct>() ?? null;
                        if (autoScriptDestruct != null)
                        {
                            autoScriptDestruct.targetScript = cameraFilterPack_FX_EarthQuake;
                            autoScriptDestruct.time = 1f;
                        }
                    }
                });
            }

            private IEnumerator EarthQuakeRoutine(CameraFilterPack_FX_EarthQuake r)
            {
                float e = 0f;
                while (e < 1f)
                {
                    e += Time.deltaTime;
                    r.Speed = 30f * (1f - e);
                    r.X = 0.02f * (1f - e);
                    r.Y = 0.02f * (1f - e);
                    yield return null;
                }
            }
        }

        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -15);
            if (Init.IsCorroded(ids))
            {
                BattleUnitModel lwHP = card.target;
                var list = BattleObjectManager.instance.GetAliveList();
                list.Remove(owner);
                foreach (BattleUnitModel battleUnitModel in list)
                {
                    if (battleUnitModel.hp < lwHP.hp)
                    {
                        lwHP = battleUnitModel;
                    }
                }
                card.target = lwHP;
            } else
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 3);
            }
        }
    }
}

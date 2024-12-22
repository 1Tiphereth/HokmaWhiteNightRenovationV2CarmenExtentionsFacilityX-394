using LOR_DiceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_mur : DiceCardSelfAbilityBase
    {
        private int _actionStack;

        private CameraFilterPack_TV_BrokenGlass _brokenFilter;

        private CameraFilterPack_FX_EarthQuake _earthQuakeFilter;

        private Coroutine _zoomRoutine;

        public override string[] Keywords => new string[1] { "ego_Keyword" };

        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -20);
            if (Init.IsCorroded(ids))
            {
                card.DestroyDice(DiceMatch.AllDice);
                DiceCardXmlInfo cardItem = new DiceCardXmlInfo { DiceBehaviourList = new List<DiceBehaviour> { new DiceBehaviour { Min = -7, Dice = 15, Type = BehaviourType.Atk, Detail = BehaviourDetail.Hit, MotionDetail = MotionDetail.S1, Script = "breakdmgbyselfbreak", ActionScript = "" } } };
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                battleDiceBehavior.SetIndex(0);
                card.AddDice(battleDiceBehavior);

            }
            else
            {
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 2
                });
            }

            _actionStack = 0;
        }

        public override void OnUseCardEvent()
        {
            _brokenFilter = SingletonBehavior<BattleCamManager>.Instance?.EffectCam.gameObject.AddComponent<CameraFilterPack_TV_BrokenGlass>() ?? null;
            _brokenFilter.Broken_Medium = 0f;
            _brokenFilter.Broken_High = 0f;
            _brokenFilter.Broken_Big = 0f;
        }

        public override void OnSucceedAtkEvent()
        {
            base.OnSucceedAtkEvent();
            SetFilter();
        }

        public override void OnEndBattle()
        {
            base.owner?.battleCardResultLog?.SetEndCardActionEvent(delegate
            {
                if (_brokenFilter != null)
                {
                    UnityEngine.Object.Destroy(_brokenFilter);
                    _brokenFilter = null;
                }
            });
        }

        private void SetFilter()
        {
            _actionStack++;
            if (_earthQuakeFilter == null)
            {
                _earthQuakeFilter = SingletonBehavior<BattleCamManager>.Instance?.EffectCam.gameObject.AddComponent<CameraFilterPack_FX_EarthQuake>() ?? null;
            }
            if (_earthQuakeFilter != null)
            {
                _earthQuakeFilter.X = 0.05f * (float)_actionStack;
                _earthQuakeFilter.Y = 0.01f * (float)_actionStack;
                _earthQuakeFilter.Speed = 50f;
            }
            AutoScriptDestruct autoScriptDestruct = SingletonBehavior<BattleCamManager>.Instance?.EffectCam.gameObject.AddComponent<AutoScriptDestruct>() ?? null;
            if (autoScriptDestruct != null)
            {
                autoScriptDestruct.targetScript = _earthQuakeFilter;
                autoScriptDestruct.time = 0.4f;
            }
            if (_actionStack == 3 && _brokenFilter != null)
            {
                _brokenFilter.Broken_Big = 128f;
            }
            if (_zoomRoutine != null)
            {
                SingletonBehavior<BattleCamManager>.Instance?.StopCoroutine(_zoomRoutine);
                _zoomRoutine = null;
                SingletonBehavior<BattleCamManager>.Instance?.ZoomAction(zoomIn: false, directly: true);
            }
            _zoomRoutine = SingletonBehavior<BattleCamManager>.Instance?.StartCoroutine(ZoomRoutine());
        }

        private IEnumerator ZoomRoutine()
        {
            SingletonBehavior<BattleCamManager>.Instance.ZoomAction(zoomIn: true, directly: false);
            yield return YieldCache.WaitForSeconds(0.2f);
            SingletonBehavior<BattleCamManager>.Instance.ZoomAction(zoomIn: false, directly: false);
        }
    }
}

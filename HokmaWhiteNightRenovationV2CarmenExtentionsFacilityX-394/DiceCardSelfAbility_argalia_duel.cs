using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_argalia_duel : DiceCardSelfAbilityBase
    {
        public class PassiveAbility_argalia_duel : PassiveAbilityBase
        {
            public bool _bImmortal = true;
            public bool _player = false;
            public BattleUnitModel _enemy;
            public BattleUnitModel _librarian;

            public bool _bStraighten = true;

            public override bool isHide => true;

            public override bool IsImmune(KeywordBuf buf)
            {
                if (buf == KeywordBuf.Seal || buf == KeywordBuf.Stun)
                {
                    return true;
                }

                return base.IsImmune(buf);
            }
            public override void OnCreated()
            {
                Debug.Log("Duel called |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
                if (!_player)
                {
                    Debug.Log("argy");
                    //BattleUnitModel target = _librarian;
                    //BattleDiceCardModel card = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId(707099), false));
                    //BattlePlayingCardDataInUnitModel card2 = new BattlePlayingCardDataInUnitModel
                    //{
                    //    card = card,
                    //    target = target,
                    //    owner = base.owner,
                    //};
                    //    Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target, -1);
                    //    return;



                    BattleUnitModel target = _librarian;
                    BattleDiceCardModel card = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId(705012), false));
                    List<BattlePlayingCardDataInUnitModel.SubTarget> list = new List<BattlePlayingCardDataInUnitModel.SubTarget>();
                    foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy))
                    {
                        list.Add(new BattlePlayingCardDataInUnitModel.SubTarget
                        {
                            target = battleUnitModel,
                            targetSlotOrder = UnityEngine.Random.Range(0, battleUnitModel.speedDiceResult.Count)
                        });
                    }
                    BattlePlayingCardDataInUnitModel card2 = new BattlePlayingCardDataInUnitModel
                    {
                        card = card,
                        owner = base.owner,
                        subTargets = list
                    };
                    if (target != null && !target.IsDead())
                    {
                        Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target, -1);
                        return;
                    }
                    List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction != Faction.Player) ? Faction.Player : Faction.Enemy);
                    if (aliveList.Count > 0)
                    {
                        BattleUnitModel target2 = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                        Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target2, -1);
                    }
                    //owner.allyCardDetail.ExhaustAllCards();
                    //BattleDiceCardModel battleDiceCardModel = owner.allyCardDetail.AddNewCard(707099);
                    //battleDiceCardModel.SetPriorityAdder(100);
                    //battleDiceCardModel.temporary = true;
                } else
                {
                    Debug.Log("rolan");
                    BattleUnitModel target = _enemy;
                    BattleDiceCardModel card = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId(705012), false));
                    List<BattlePlayingCardDataInUnitModel.SubTarget> list = new List<BattlePlayingCardDataInUnitModel.SubTarget>();
                    foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy))
                    {
                        list.Add(new BattlePlayingCardDataInUnitModel.SubTarget
                        {
                            target = battleUnitModel,
                            targetSlotOrder = UnityEngine.Random.Range(0, battleUnitModel.speedDiceResult.Count)
                        });
                    }
                    BattlePlayingCardDataInUnitModel card2 = new BattlePlayingCardDataInUnitModel
                    {
                        card = card,
                        owner = base.owner,
                        subTargets = list
                    };
                    if (target != null && !target.IsDead())
                    {
                        Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target, -1);
                        return;
                    }
                    List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction != Faction.Player) ? Faction.Player : Faction.Enemy);
                    if (aliveList.Count > 0)
                    {
                        BattleUnitModel target2 = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                        Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target2, -1);
                    }
                    //BattleUnitModel target = _enemy;
                    //BattleDiceCardModel card = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId(707098), false));
                    //BattlePlayingCardDataInUnitModel card2 = new BattlePlayingCardDataInUnitModel
                    //{
                    //    card = card,
                    //    target = target,
                    //    owner = base.owner,
                    //};
                    //    Singleton<StageController>.Instance.AddAllCardListInBattle(card2, target, -1);
                    //    return;

                    //BattleDiceCardModel battleDiceCardModel2 = owner.allyCardDetail.AddNewCard(707098);
                    //battleDiceCardModel2.SetPriorityAdder(80);
                    //battleDiceCardModel2.temporary = true;
                }
            }

            public bool IsRoland()
            {
                return _player;
            }
        }

        public bool specialBattleEnding;
        public override void OnUseCard()
        {
            //BattleUnitModel battleUnitModel = BattleObjectManager.instance.GetAliveList(Faction.Enemy).Find((BattleUnitModel x) => x.UnitData.unitData.EnemyUnitId == 1410011);
            //BattleUnitModel battleUnitModel2 = Singleton<StageController>.Instance.AddNewUnit(Faction.Enemy, 1410012, 1);
            BattleUnitModel battleUnitModel = card.target;
            specialBattleEnding = true;
            battleUnitModel.passiveDetail.AddPassive(new PassiveAbility_argalia_duel { _enemy = card.target, _librarian = owner, _player = false});
            BattleUnitModel battleUnitModel2 = owner;
            battleUnitModel2.passiveDetail.AddPassive(new PassiveAbility_argalia_duel { _enemy = card.target, _librarian = owner, _player = true });
            //if (SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject is ReverberationBand_Map3)
            //{
            //    ReverberationBand_Map3 reverberationBand_Map = SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject as ReverberationBand_Map3;
            //    if (reverberationBand_Map != null)
            //    {
            //        reverberationBand_Map.SetFinalEffect(battleUnitModel, battleUnitModel2, 0f);
            //    }
            //}
            //else
            //{
            //    SetMapForcely();
            //    SingletonBehavior<BattleSceneRoot>.Instance.ChangeToSpecialMap(Singleton<StageController>.Instance.GetStageModel().GetCurrentMapInfo(), playEffect: false);
            //    ReverberationBand_Map3 reverberationBand_Map2 = SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject as ReverberationBand_Map3;
            //    if (reverberationBand_Map2 != null)
            //    {
            //        reverberationBand_Map2.SetFinalEffect(battleUnitModel, battleUnitModel2, 2f);
            //    }
            //}
            //int currentMapInfo = 3;
            //Singleton<StageController>.Instance.GetStageModel().SetCurrentMapInfo(currentMapInfo);
            //ResetUI();
            //DisableGlobalUI();
        }


        private void ResetUI()
        {
            int num = 0;
            foreach (BattleUnitModel item in BattleObjectManager.instance.GetList())
            {
                SingletonBehavior<UICharacterRenderer>.Instance.SetCharacter(item.UnitData.unitData, num++, forcelyReload: true);
            }
            BattleObjectManager.instance.InitUI();
        }

        private void DisableGlobalUI()
        {
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.EnableCanvas(b: false);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitInformation.EnableCanvas(b: false);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitInformationPlayer.EnableCanvas(b: false);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitCardsInHand.EnableCanvas(b: false);
        }

        public void EnableGlobalUI()
        {
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.EnableCanvas(b: true);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitInformation.EnableCanvas(b: true);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitInformationPlayer.EnableCanvas(b: true);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitCardsInHand.EnableCanvas(b: true);
        }

        private void SetMapForcely()
        {
            int num = -1;
            switch (Singleton<StageController>.Instance.CurrentWave)
            {
                case 1:
                    num = 0;
                    break;
                case 2:
                    num = 1;
                    break;
                case 3:
                    num = 2;
                    break;
            }
            int emotionTotalCoinNumber = Singleton<StageController>.Instance.GetCurrentStageFloorModel().team.emotionTotalCoinNumber;
            if (num != -1)
            {
                Singleton<StageController>.Instance.GetCurrentWaveModel().team.emotionTotalCoinNumber = emotionTotalCoinNumber + 1;
                Singleton<StageController>.Instance.GetStageModel().SetCurrentMapInfo(num);
            }
            else
            {
                Singleton<StageController>.Instance.GetCurrentWaveModel().team.emotionTotalCoinNumber = emotionTotalCoinNumber - 1;
            }
        }
    }
}

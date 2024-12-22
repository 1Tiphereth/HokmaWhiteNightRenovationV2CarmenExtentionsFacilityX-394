using HarmonyLib;
using Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI;
using static DiceCardAbility_forbidCardAtk;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.CanvasScaler;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_allyZena : DiceCardSelfAbilityBase
    {
        public class BattleUnitBuf_zenaSpawner : BattleUnitBuf
        {
            public override void OnRoundEndTheLast()
            {
                List<BattleUnitModel> list = BattleObjectManager.instance.GetList(base._owner.faction);
                BattleUnitModel bUM = list.Find((BattleUnitModel x) => x.IsDead());
                int num = -1;
                bool flag = bUM != null;
                if (flag)
                {
                    num = bUM.index;
                }
                else
                {
                    bool flag2 = list.Count < 5;
                    if (flag2)
                    {
                        num = list.Count;
                    }
                }
                bool flag3 = num > -1;
                if (flag3)
                {
                    UnitBattleDataModel zena = CreateFriendUnitData(Singleton<StageController>.Instance.GetStageModel(), Singleton<StageController>.Instance.GetCurrentStageFloorModel()._floorModel);
                    MethodInfo methodInfo = Singleton<StageController>.Instance.GetType().GetMethods(AccessTools.all).FirstOrDefault((MethodInfo c) => c.Name == "CreateLibrarianUnit" && c.GetParameters().Length == 3);
                    BattleUnitModel battleUnitModel = (BattleUnitModel)methodInfo.Invoke(Singleton<StageController>.Instance, new object[]
                        {
                            Singleton<StageController>.Instance.CurrentFloor,
                            zena,
                            num
                        });


                    int num2 = 0;
                    foreach (BattleUnitModel item2 in BattleObjectManager.instance.GetList())
                    {
                        SingletonBehavior<UICharacterRenderer>.Instance.SetCharacter(item2.UnitData.unitData, num2++, forcelyReload: true);
                    }
                    BattleObjectManager.instance.InitUI();
                    SingletonBehavior<BattleSoundManager>.Instance.ChangeToFinalFinalBinahTheme(1);

                    battleUnitModel.SetKnockoutInsteadOfDeath(alter: true);
                    battleUnitModel.emotionDetail.SetEmotionLevel(3);
                    battleUnitModel.allyCardDetail.DrawCards(4);
                    battleUnitModel.cardSlotDetail.RecoverPlayPoint(battleUnitModel.cardSlotDetail.GetMaxPlayPoint());
                    battleUnitModel.view.ChangeSkin("TheHead");
                    battleUnitModel.view.StartEgoSkinChangeEffect("Character");
                    //battleUnitModel.view.ChangeHeight(184);
                }
                Destroy();
            }
        }

        public override void OnUseCard()
        {
            //card.card.exhaust = true;
            //owner.allyCardDetail.ExhaustACardAnywhere(card.card);
            owner.bufListDetail.AddBuf(new BattleUnitBuf_zenaSpawner());
        }

        // Token: 0x0600009A RID: 154 RVA: 0x00006030 File Offset: 0x00004230
        private static UnitBattleDataModel CreateFriendUnitData(StageModel stage, LibraryFloorModel floor)
        {
            UnitDataModel unitDataModel = new UnitDataModel(new LorId(Init.packageName, 3), floor.Sephirah, false);
            unitDataModel.SetTempName("Zena");
            unitDataModel.forceItemChangeLock = true;
            UnitBattleDataModel unitBattleDataModel = new UnitBattleDataModel(stage, unitDataModel);
            unitBattleDataModel.Init();
            return unitBattleDataModel;
        }
    }
}
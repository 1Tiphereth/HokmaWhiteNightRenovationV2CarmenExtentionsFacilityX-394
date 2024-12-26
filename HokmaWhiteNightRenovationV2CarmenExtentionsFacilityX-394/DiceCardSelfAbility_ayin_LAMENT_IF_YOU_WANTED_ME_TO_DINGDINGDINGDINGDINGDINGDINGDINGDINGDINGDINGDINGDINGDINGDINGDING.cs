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
    public class DiceCardAbility_ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING_dice : DiceCardAbilityBase
    {
        private string _PREFAB_BLACK_PATH = "Battle/DiceAttackEffects/CreatureBattle/ButterflyEgoEffect_Black";

        private string _PREFAB_WHITE_PATH = "Battle/DiceAttackEffects/CreatureBattle/ButterflyEgoEffect_White";

        //private const int _REPEAT = 7;

        private int count;

        private int max;

        private int _type;

        public override string[] Keywords => new string[1] { "ego_Keyword" };

        public override void AfterAction()
        {
            base.owner.battleCardResultLog?.SetParam(_type);
            if (count < max)
            {
                ActivateBonusAttackDice();
                count++;
            }
        }

        public override void BeforeRollDice()
        {
            if (max == 0)
            {
                max = 6 + owner.emotionDetail.EmotionLevel;
            }
            _type = RandomUtil.Range(0, 1);

            if (owner.emotionDetail.EmotionLevel >= 5)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 2
                });
            }

            if (count > 9)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = (count - 9) * 50
                });
            }
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = count * 5
            });
        }

        public override void OnSucceedAttack()
        {
            BattleUnitModel battleUnitModel = base.card?.target;
            if (battleUnitModel == null)
            {
                return;
            }

            if (_type == 0)
            {
                battleUnitModel.TakeDamage(3, DamageType.Card_Ability, base.owner);
                battleUnitModel.battleCardResultLog.SetCreatureAbilityEffect("2/ButterflyEffect_Black", 1f);
                base.owner.battleCardResultLog.SetSucceedAtkEvent(delegate
                {
                    GameObject gameObject2 = Util.LoadPrefab(_PREFAB_BLACK_PATH);
                    if (!(gameObject2 == null))
                    {
                        FarAreaeffect_EGO_Butterfly_Black component2 = gameObject2.GetComponent<FarAreaeffect_EGO_Butterfly_Black>();
                        component2?.animator.Play("Butterfly_Ego_White", 0, 0.333f);
                        if (gameObject2 != null)
                        {
                            gameObject2.AddComponent<AutoDestruct>().time = 1f;
                        }
                    }
                });
                return;
            }
            battleUnitModel.TakeBreakDamage(3, DamageType.Card_Ability, base.owner, AtkResist.None);
            battleUnitModel.battleCardResultLog.SetCreatureAbilityEffect("2/ButterflyEffect_White", 1f);
            base.owner.battleCardResultLog.SetSucceedAtkEvent(delegate
            {
                GameObject gameObject = Util.LoadPrefab(_PREFAB_WHITE_PATH);
                if (!(gameObject == null))
                {
                    FarAreaeffect_EGO_Butterfly_White component = gameObject.GetComponent<FarAreaeffect_EGO_Butterfly_White>();
                    component?.animator.Play("Butterfly_Ego_White", 0, 0.333f);
                    if (gameObject != null)
                    {
                        gameObject.AddComponent<AutoDestruct>().time = 1f;
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

    public class DiceCardSelfAbility_ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[1] { "ego_Keyword" };

        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            //card.ApplyDiceAbility(DiceMatch.DiceByIdx(0), new DiceCardAbility_ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING_dice());
            if ((bool)Init.PersistentGet(ids))
            {
                Init.PersistentAdd(ids, false);
                return;
            }
            Init.UpdateSP(ids, -35);
            if (Init.IsCorroded(ids))
            {
                Init.PersistentAdd(ids, true);
                card.DestroyPlayingCard();
                BattleUnitModel target = base.card.target;
                BattleDiceCardModel card1 = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem((card.card.GetID()), false));
                card1.XmlData.Spec.affection = CardAffection.All;
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
                    card = card1,
                    owner = base.owner,
                    subTargets = list
                };
                if (base.card.target != null && !base.card.target.IsDead())
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
            }
        }
    }
}

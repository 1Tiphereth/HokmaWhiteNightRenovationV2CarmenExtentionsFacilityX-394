using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using LOR_DiceSystem;
using UnityEngine;
using LOR_XML;
using static EmotionCardAbility_freischutz2;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;
using Text = UnityEngine.UI.Text;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    [HarmonyPatch]
    public class Init : ModInitializer
    {
        bool _patched = false;
        public static string packageName = "HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394";

        public List<LorId> cards = new List<LorId>
        {
            new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 50),
            new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 51),
            new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 52),
            new LorId(607201),
            new LorId(607202),
            new LorId(607203),
            new LorId(607204),
            new LorId(607205),
            //new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 53),
            //new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 54),
            //new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 55),
            //new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 56),
            //new LorId("HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX-394", 57),
        };

        public static List<LorId> spList = new List<LorId>
        {
            new LorId(packageName, 1001),
            new LorId(packageName, 1001),
            new LorId(packageName, 1002),
            new LorId(packageName, 1003),
            new LorId(packageName, 1004),
            new LorId(packageName, 1005),
            new LorId(packageName, 1006),
            new LorId(packageName, 1007),
            new LorId(packageName, 1008),
            new LorId(packageName, 1009),
            new LorId(packageName, 1010),
            new LorId(packageName, 1011),
            new LorId(packageName, 1012),
            new LorId(packageName, 1013),
            new LorId(packageName, 1014),
            new LorId(packageName, 1015),
            new LorId(packageName, 1016),
            new LorId(packageName, 1017),
            new LorId(packageName, 1018),
            new LorId(packageName, 1019),
            new LorId(packageName, 1020),
            new LorId(packageName, 1021),
        };

        internal static void ReplaceCardInfo(LorId oldId, LorId newId)
        {
            DiceCardXmlInfo diceCardXmlInfo =
                ItemXmlDataList.instance.GetCardList().Find((DiceCardXmlInfo x) => x.id == newId);
            if (ItemXmlDataList.instance.GetCardList().Exists((DiceCardXmlInfo x) => x.id == oldId) &&
                diceCardXmlInfo != null)
            {
                ItemXmlDataList.instance.GetCardItem(oldId, true).workshopName = diceCardXmlInfo.workshopName;
                ItemXmlDataList.instance.GetCardItem(oldId, true)._textId = diceCardXmlInfo._textId;
                ItemXmlDataList.instance.GetCardItem(oldId, true).Artwork = diceCardXmlInfo.Artwork;
                ItemXmlDataList.instance.GetCardItem(oldId, true).Rarity = diceCardXmlInfo.Rarity;
                ItemXmlDataList.instance.GetCardItem(oldId, true).optionList = diceCardXmlInfo.optionList;
                ItemXmlDataList.instance.GetCardItem(oldId, true).Keywords = diceCardXmlInfo.Keywords;
                ItemXmlDataList.instance.GetCardItem(oldId, true).Spec = diceCardXmlInfo.Spec;
                ItemXmlDataList.instance.GetCardItem(oldId, true).Script = diceCardXmlInfo.Script;
                ItemXmlDataList.instance.GetCardItem(oldId, true).ScriptDesc = diceCardXmlInfo.Script;
                ItemXmlDataList.instance.GetCardItem(oldId, true).DiceBehaviourList = diceCardXmlInfo.DiceBehaviourList;
                ItemXmlDataList.instance.GetCardItem(oldId, true).Chapter = diceCardXmlInfo.Chapter;
                ItemXmlDataList.instance.GetCardItem(oldId, true).SpecialEffect = diceCardXmlInfo.SpecialEffect;
                ItemXmlDataList.instance.GetCardItem(oldId, true).SkinChange = diceCardXmlInfo.SkinChange;
                ItemXmlDataList.instance.GetCardItem(oldId, true).SkinChangeType = diceCardXmlInfo.SkinChangeType;
                ItemXmlDataList.instance.GetCardItem(oldId, true).SkinHeight = diceCardXmlInfo.SkinHeight;
                ItemXmlDataList.instance.GetCardItem(oldId, true).MapChange = diceCardXmlInfo.MapChange;
                ItemXmlDataList.instance.GetCardItem(oldId, true).Priority = diceCardXmlInfo.Priority;
                ItemXmlDataList.instance.GetCardItem(oldId, true).PriorityScript = diceCardXmlInfo.PriorityScript;
                ItemXmlDataList.instance.GetCardItem(oldId, true).category = diceCardXmlInfo.category;
                ItemXmlDataList.instance.GetCardItem(oldId, true).EgoMaxCooltimeValue =
                    diceCardXmlInfo.EgoMaxCooltimeValue;
                ItemXmlDataList.instance.GetCardItem(oldId, true).MaxNum = diceCardXmlInfo.MaxNum;
                ItemXmlDataList.instance.GetCardList().RemoveAll((DiceCardXmlInfo x) => x.id == newId);
            }
        }

        internal static void ExclusiveAdder(LorId keypage, LorId card)
        {
            ItemXmlDataList.instance.GetCardItem(card, false).optionList.Add(CardOption.OnlyPage);
            Singleton<BookXmlList>.Instance.GetData(keypage, true).EquipEffect.OnlyCard.Add(card.id);
        }

        public override void OnInitializeMod()
        {
            var harmony = new Harmony("no.comment");
            harmony.PatchAll();

            Singleton<AbnormalityCardDescXmlList>.Instance.GetAbnormalityCard("HappyTeddyBear_Lonely").abilityDesc =
                "[Single Ally]\r\nAll dice gain 3 Power in a clash.\nAll dice lose 2 Power in a one-sided attack.";
            Singleton<AbnormalityCardDescXmlList>.Instance.GetAbnormalityCard("ForsakenMurderer_Tie").abilityDesc =
                "[Single Ally]\r\nBlunt dice gain 1-3 Power.\r\nDeal +25% Blunt Stagger%.";
            Singleton<AbnormalityCardDescXmlList>.Instance.GetAbnormalityCard("SingingMachine_Music").abilityDesc =
                "[All Characters]\r\nAll characters deal +4-8 damage with attacks this reception. They also suffer +8 Stagger damage upon taking a hit.\r\nWhenever an ally defeats an enemy, they recover 15 HP and 30 Stagger Resist.";
            Singleton<AbnormalityCardDescXmlList>.Instance.GetAbnormalityCard("SingingMachine_Atk").abilityDesc =
                "[Single Ally]\r\nOffensive dice gain 2 Power.\r\nDefensive dice roll 1.";
            Singleton<AbnormalityCardDescXmlList>.Instance.GetAbnormalityCard("Matan_Seven").abilityDesc =
                "[Single Ally]\r\nDeal +1-7 damage with Offensive dice.\r\nWhen an Offensive die draws or loses in a clash, deal damage equal to the dice value times 2 to the opponent.\r\nEvery 7th Melee or Ranged page deals +7 Damage and targets random characters, including allies.";

            // localization
            {
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("negatePowerXEnergy1",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Use] Restore 1 Light\r\nDice on this page and the page clashing with it are unaffected by Power gain or loss"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("negatePowerXEnergy2",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Use] Restore 2 Light\r\nDice on this page and the page clashing with it are unaffected by Power gain or loss"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("negatePowerXEnergy3",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Use] Restore 3 Light\r\nDice on this page and the page clashing with it are unaffected by Power gain or loss"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("zenaStagger",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Hit] Dice on this page do not deal damage, instead they deal more stagger damage equal to the damage value"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("theClaw_recoverNextRound",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[Combat Start] Gain 2 Protection, Stagger Protection and Recover 50 HP and Stagger at the start of next Scene"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("clawUltimate",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "Discard All pages in hand to gain power equal to the amount of pages in hand *10 + 30 Power to all dice on this page, and deal 2x stagger damage"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("allyZena",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Use] Spawn Zena next Scene." } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("allyBaral",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Use] Spawn Baral next Scene." } });

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("repeat1bs",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                            { "If all 9 Combat Pages of the Black Silence have been used, re-roll this die once" }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("fixedcost_adddice",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "The Cost of this page cannot be changed.\r\nIf the natural roll of any die is Max, add a Slash die (Roll: 3-7) to the dice queue once"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add(
                    "cardPowerDown2targetDraw1Energy3GloriaSingletonCostBuf",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Use] Restore 3 Light; draw 1 page and reduce the Cost of a random card in hand whose cost is bigger then 0 and self for the next scene\r\n[Start of Clash] Reduce Power of all target's dice by 2"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("cardPowerDown2targetDraw1Energy3",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Use] Restore 3 Light; draw 1 page\r\n[Start of Clash] Reduce Power of all target's dice by 2"
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("mutualDestroy35TempFragile",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Clash Win] Destroy all of opponent's dice and deal +2 more Damage with attacks on this page\r\n[On Clash Lose] Destroy all dice on this page and gain 3 Fragile"
                        }
                    });

                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Sanity",
                    new BattleEffectText { Name = "Sanity", Desc = "The amount of this unit's SP", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("SpGainBuf",
                    new BattleEffectText
                        { Name = "SP Gain", Desc = "Gain +{0} more Sanity upon Winning a Clash", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("SpLoseBuf",
                    new BattleEffectText
                        { Name = "SP Lose", Desc = "Lose +{0} more Sanity upon Losing a Clash", ID = "" });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("atksp2",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Hit] Deal 2 SP Damage" } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("atksp3",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Hit] Deal 3 SP Damage" } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("atksp5",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Hit] Deal 5 SP Damage" } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("atksp7",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Hit] Deal 7 SP Damage" } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("atksp10",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Hit] Deal 10 SP Damage" } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("atkspAll",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Hit] Panic target" } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("1pwper10sp",
                    new BattleCardAbilityDesc { desc = new List<string> { "Gain +1 Power for every 10 SP on Self" } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("rerollper20sp",
                    new BattleCardAbilityDesc
                        { desc = new List<string> { "Reroll all dice on this page for every 20 SP on Self" } });

                // ego
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("argalia_duel",
                    new BattleCardAbilityDesc { desc = new List<string> { "[On Use] Begin the duel..." } });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("GazeAndAwe",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string> { "{Sanity Cost} - 45\r\n{On Awakening}\n\r\r\n{On Corrosion}\r\nABC" }
                    });

                // custom
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Disposal",
                    new BattleEffectText
                    {
                        Name = "Disposal Mode",
                        Desc =
                            "Upon acquiring this status effect gain 11 Charge, Recover all Light, and add a Copy of \"Disposal\" to hand and Gain 2 Extra Speed Dice\r\nAt the start of each scene gain 2 Strength, Haste, Protection and Break Protection, additionally Recover 2 extra Light and Draw 2 more Pages",
                        ID = ""
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("x394_disposal",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "Only usable at 20+ Charge. Spend all Charge to deal additional (3 * Charge)% Damage\n\rUpon defeating an enemy with this page, add a copy of 'Disposal' to hand and lower its Cost by 2 and gain 3 Strength, Protection and 7 Charge next Scene.\r\nIf target's HP is at 50% or lower, deal twice as much damage"
                        }
                    });
            }

            // card patches
            {
                ItemXmlDataList.instance.GetCardItem(new LorId(607201), false).optionList
                    .Remove(CardOption.NoInventory);
                ItemXmlDataList.instance.GetCardItem(new LorId(607202), false).optionList
                    .Remove(CardOption.NoInventory);
                ItemXmlDataList.instance.GetCardItem(new LorId(607203), false).optionList
                    .Remove(CardOption.NoInventory);
                ItemXmlDataList.instance.GetCardItem(new LorId(607204), false).optionList
                    .Remove(CardOption.NoInventory);
                ItemXmlDataList.instance.GetCardItem(new LorId(607205), false).optionList
                    .Remove(CardOption.NoInventory);
                ItemXmlDataList.instance.GetCardItem(new LorId(706203), false).optionList.Add(CardOption.EgoPersonal);

                ItemXmlDataList.instance.GetCardItem(new LorId(408009), false).DiceBehaviourList[0].Script = "atksp7";
                ItemXmlDataList.instance.GetCardItem(new LorId(408008), false).DiceBehaviourList[0].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(408008), false).DiceBehaviourList[1].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(408007), false).DiceBehaviourList[0].Script = "atkspAll";
                ItemXmlDataList.instance.GetCardItem(new LorId(408006), false).DiceBehaviourList[1].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(408006), false).DiceBehaviourList[2].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(102001), false).DiceBehaviourList[2].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(104004), false).DiceBehaviourList[2].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(100004), false).DiceBehaviourList[0].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(303008), false).DiceBehaviourList[1].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(303001), false).DiceBehaviourList[0].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(303001), false).DiceBehaviourList[1].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(303001), false).DiceBehaviourList[2].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(303002), false).DiceBehaviourList[1].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(303002), false).DiceBehaviourList[2].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(303002), false).DiceBehaviourList[3].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(303005), false).DiceBehaviourList[0].Script = "atksp5";
                ItemXmlDataList.instance.GetCardItem(new LorId(302004), false).DiceBehaviourList[0].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(302004), false).DiceBehaviourList[2].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(302003), false).DiceBehaviourList[1].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(603004), false).DiceBehaviourList[0].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(603004), false).DiceBehaviourList[1].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(603004), false).DiceBehaviourList[2].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(501003), false).DiceBehaviourList[0].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(501003), false).DiceBehaviourList[1].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(501002), false).DiceBehaviourList[0].Script = "atksp7";
                ItemXmlDataList.instance.GetCardItem(new LorId(408013), false).Script = "1pwper10sp";
                ItemXmlDataList.instance.GetCardItem(new LorId(408012), false).Script = "1pwper10sp";
                ItemXmlDataList.instance.GetCardItem(new LorId(508011), false).Script = "rerollper20sp";
                ItemXmlDataList.instance.GetCardItem(new LorId(608007), false).DiceBehaviourList[0].Script = "atksp3";
                ItemXmlDataList.instance.GetCardItem(new LorId(608007), false).DiceBehaviourList[1].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(607003), false).DiceBehaviourList[0].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(607003), false).DiceBehaviourList[1].Script = "atksp2";
                ItemXmlDataList.instance.GetCardItem(new LorId(701004), false).Script = "uniteAttack";
                ItemXmlDataList.instance.GetCardItem(new LorId(701008), false).Script = "unitePower";
                ItemXmlDataList.instance.GetCardItem(new LorId(505003), false).DiceBehaviourList[0].Min = -4;
                ItemXmlDataList.instance.GetCardItem(new LorId(505003), false).DiceBehaviourList[1].Min = -2;
                ItemXmlDataList.instance.GetCardItem(new LorId(605005), false).DiceBehaviourList[0].Min = -5;
                ItemXmlDataList.instance.GetCardItem(new LorId(605005), false).DiceBehaviourList[1].Min = -5;
                ItemXmlDataList.instance.GetCardItem(new LorId(605004), false).DiceBehaviourList[1].Min = -3;
                ItemXmlDataList.instance.GetCardItem(new LorId(605004), false).DiceBehaviourList[2].Min = -2;
                ItemXmlDataList.instance.GetCardItem(new LorId(605006), false).DiceBehaviourList[0].Min = -2;
                ItemXmlDataList.instance.GetCardItem(new LorId(605006), false).DiceBehaviourList[1].Min = -2;
                ItemXmlDataList.instance.GetCardItem(new LorId(605002), false).DiceBehaviourList[0].Min = -5;
                ItemXmlDataList.instance.GetCardItem(new LorId(605002), false).DiceBehaviourList[1].Min = 10;
                ItemXmlDataList.instance.GetCardItem(new LorId(501005), false).DiceBehaviourList[0].Min = -2;
                ItemXmlDataList.instance.GetCardItem(new LorId(501005), false).DiceBehaviourList[1].Min = -3;
                ItemXmlDataList.instance.GetCardItem(new LorId(501005), false).DiceBehaviourList[2].Min = -2;
                ItemXmlDataList.instance.GetCardItem(new LorId(501007), false).DiceBehaviourList[0].Min = -3;
                //ItemXmlDataList.instance.GetCardItem(new LorId(501001), false).DiceBehaviourList[0].Min = -4;
                ItemXmlDataList.instance.GetCardItem(new LorId(608004), false).Script = "x394_disposal";
                ItemXmlDataList.instance.GetCardItem(new LorId(502006), false).Script = "drawCard";
                ItemXmlDataList.instance.GetCardItem(new LorId(403006), false).Script = "energy1";
                ItemXmlDataList.instance.GetCardItem(new LorId(706204), false).Spec.Cost = 2;
                ItemXmlDataList.instance.GetCardItem(new LorId(706205), false).Spec.Cost = 1;
                //ItemXmlDataList.instance.GetCardItem(new LorId(706202), false).DiceBehaviourList[] = 2;
            }

            Singleton<BookXmlList>.Instance.GetData(new LorId(packageName, 3)).EquipEffect.PassiveList
                .Add(new LorId(packageName, 20));
            Singleton<BookXmlList>.Instance.GetData(new LorId(packageName, 3)).EquipEffect.PassiveList
                .Add(new LorId(180005));
            Singleton<BookXmlList>.Instance.GetData(new LorId(packageName, 4)).EquipEffect.PassiveList
                .Add(new LorId(packageName, 20));
            Singleton<BookXmlList>.Instance.GetData(new LorId(packageName, 4)).EquipEffect.PassiveList
                .Add(new LorId(packageName, 24));

            // keypage patches
            {
                // aux
                Singleton<BookXmlList>.Instance.GetData(240010).canNotEquip = false;

                // zena
                //Singleton<DeckXmlList>.Instance.GetData(new LorId(packageName, 3)).cardIdList = new List<LorId>
                //{
                //    new LorId(packageName, 11),
                //    new LorId(packageName, 11),
                //    new LorId(packageName, 11),

                //    new LorId(packageName, 12),
                //    new LorId(packageName, 12),

                //    new LorId(packageName, 13),
                //    new LorId(packageName, 13),

                //    new LorId(packageName, 14),
                //    new LorId(packageName, 15),
                //};

                // Yujin Full Potentional
                Singleton<BookXmlList>.Instance.GetData(240001).EquipEffect.PassiveList = new List<LorId>
                {
                    new LorId(10004),

                    new LorId(packageName, 22),
                    new LorId(packageName, 21),
                    new LorId(packageName, 23),
                    new LorId(packageName, 301),
                    new LorId(packageName, 302),
                    new LorId(packageName, 303),
                    new LorId(241001),
                };
                Singleton<StageClassInfoList>.Instance.GetData(40001).waveList[1].enemyUnitIdList
                    .Remove(new LorId(40001));
                Singleton<BookXmlList>.Instance.GetData(140001).EquipEffect.PassiveList.Remove(new LorId(241001));
                Singleton<BookXmlList>.Instance.GetData(140001).EquipEffect.Break = 69;
                Singleton<StageClassInfoList>.Instance.GetData(40001).waveList.Add(new StageWaveInfo
                    { formationId = 1, enemyUnitIdList = new List<LorId> { new LorId(40001) }, availableNumber = 1 });

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("yujin4",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string> { "If the natural roll is Max, and is 4 or higher, add [+45 power]" }
                    });
                ItemXmlDataList.instance.GetCardItem(501001).DiceBehaviourList[0].Script = "yujin4";

                // Yan - 250051
                ItemXmlDataList.instance.GetCardItem(new LorId(611001), false).DiceBehaviourList[0].Min = 22;
                ReplaceCardInfo(new LorId(611002), new LorId(packageName, 300));
                ItemXmlDataList.instance.GetCardItem(new LorId(611006), false).DiceBehaviourList[0].Min = 7;
                ItemXmlDataList.instance.GetCardItem(new LorId(611006), false).DiceBehaviourList[1].Min = 8;
                ItemXmlDataList.instance.GetCardItem(new LorId(611006), false).DiceBehaviourList[2].Min = 8;
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("yanSwordbutactuallygoodthistime",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "The Cost of this page equals the user's Max Light.\r\n[On Use] All dice on this page gain Power equal to the Cost of this page; restore all Light"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(611005), false).Script =
                    "yanSwordbutactuallygoodthistime";
                Singleton<BookXmlList>.Instance.GetData(250051).EquipEffect.PassiveList.Remove(new LorId(250151));
                Singleton<BookXmlList>.Instance.GetData(250051).EquipEffect.PassiveList.Add(new LorId(packageName, 26));
                Singleton<BookXmlList>.Instance.GetData(250051).EquipEffect.PassiveList.Add(new LorId(250115));
                Singleton<BookXmlList>.Instance.GetData(250051).EquipEffect.PassiveList.Add(new LorId(240018));

                // The Black Silence - 102
                ItemXmlDataList.instance.GetCardItem(new LorId(702001), false).Script =
                    "cardPowerDown2targetDraw1Energy3";
                ItemXmlDataList.instance.GetCardItem(new LorId(702001), false).DiceBehaviourList[0].Script =
                    "binding1pw";
                ItemXmlDataList.instance.GetCardItem(new LorId(702002), false).DiceBehaviourList[0].Min = 16;
                ItemXmlDataList.instance.GetCardItem(new LorId(702003), false).DiceBehaviourList[0].Script =
                    "binding1pw";
                ItemXmlDataList.instance.GetCardItem(new LorId(702004), false).DiceBehaviourList.Add(new DiceBehaviour
                {
                    Detail = BehaviourDetail.Slash, Min = 3, Dice = 7, MotionDetail = MotionDetail.H,
                    EffectRes = "BlackSilence_H"
                });
                ItemXmlDataList.instance.GetCardItem(new LorId(702005), false).DiceBehaviourList[0].Script =
                    "repeat1bs";
                ItemXmlDataList.instance.GetCardItem(new LorId(702006), false).Script = "fixedcost_adddice";
                ItemXmlDataList.instance.GetCardItem(new LorId(702007), false).DiceBehaviourList[0].Script =
                    "bleeding2pw";
                ItemXmlDataList.instance.GetCardItem(new LorId(702008), false).DiceBehaviourList[0].Script =
                    "powerUpNext2pl";
                ItemXmlDataList.instance.GetCardItem(new LorId(702008), false).DiceBehaviourList[1].Script =
                    "powerUpNext2pl";
                //ItemXmlDataList.instance.GetCardItem(new LorId(702008), false).DiceBehaviourList[2].Script = "buterflyDice";
                ItemXmlDataList.instance.GetCardItem(new LorId(702009), false).Script = "strength1";

                // Shi.
                Singleton<BookXmlList>.Instance.GetData(140002).EquipEffect.PassiveList
                    .Insert(2, new LorId(packageName, 3001));
                Singleton<BookXmlList>.Instance.GetData(240002).EquipEffect.PassiveList
                    .Insert(2, new LorId(packageName, 3001));
                Singleton<BookXmlList>.Instance.GetData(140003).EquipEffect.PassiveList
                    .Insert(2, new LorId(packageName, 3001));
                Singleton<BookXmlList>.Instance.GetData(240003).EquipEffect.PassiveList
                    .Insert(2, new LorId(packageName, 3001));
                Singleton<BookXmlList>.Instance.GetData(140001).EquipEffect.PassiveList
                    .Insert(2, new LorId(packageName, 3001));
                Singleton<BookXmlList>.Instance.GetData(240001).EquipEffect.PassiveList
                    .Insert(2, new LorId(packageName, 3001));

                // Boris
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.PassiveList.Add(new LorId(3009));
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.PassiveList.Add(new LorId(240003));
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.PassiveList.Add(new LorId(240005));
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.PassiveList.Add(new LorId(220009));
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.PassiveList.Add(new LorId(220010));
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.PassiveList.Add(new LorId(230012));
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.PassiveList.Add(new LorId(220006));
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.MaxPlayPoint = 4;
                Singleton<BookXmlList>.Instance.GetData(250007).EquipEffect.StartPlayPoint = 4;


                foreach (var d in ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).DiceBehaviourList)
                {
                    if (d.Detail != BehaviourDetail.Guard)
                    {
                        d.Min += 1;
                        d.Dice += 2;
                        d.Detail = BehaviourDetail.Hit;
                        //d.MotionDetail = MotionDetail.H;
                        //d.EffectRes = "Thumb_H";
                    }
                }

                //ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).Script = "kali";
                ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).DiceBehaviourList[2].Script = "repeat3";
                ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).DiceBehaviourList.Insert(2,
                    ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).DiceBehaviourList[2]);
                //ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).DiceBehaviourList[3].MotionDetail = MotionDetail.Z;
                //ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).DiceBehaviourList[3].EffectRes = "Thumb_Z";
                //ItemXmlDataList.instance.GetCardItem(new LorId(602010), false).DiceBehaviourList[3].Detail = BehaviourDetail.Penetrate;

                Singleton<BookXmlList>.Instance.GetData(150023).EquipEffect.PassiveList.Remove(new LorId(250023));
                Singleton<BookXmlList>.Instance.GetData(150023).EquipEffect.PassiveList
                    .Add(new LorId(packageName, 4001));
                Singleton<BookXmlList>.Instance.GetData(150031).EquipEffect.PassiveList.Remove(new LorId(250023));
                Singleton<BookXmlList>.Instance.GetData(150031).EquipEffect.PassiveList
                    .Add(new LorId(packageName, 4001));
                Singleton<BookXmlList>.Instance.GetData(250023).EquipEffect.PassiveList.Remove(new LorId(250023));
                Singleton<BookXmlList>.Instance.GetData(250023).EquipEffect.PassiveList
                    .Add(new LorId(packageName, 4001));
            }

            // ego changes
            {
                // malkuth
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_fmf",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 15\r\n{On Awakening}\n\rInflict Burn Break to enemies [On Hit]\r\n{On Corrosion}\n\r{Indiscriminate}\r\nAdd a second die of [(15-30)] to this page which Inflicts (7 + Personal Emotional Level) Burn [On Hit]"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910001), false).Script = "ayin_fmf";

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_frg",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 25\r\n{On Awakening}\n\rDice on this page do not deal damage, instead they deal more stagger damage equal to the damage value\r\n{On Corrosion}\r\nTransform all Dice on this page to Negative Roll Dice"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910002), false).Script = "ayin_frg";

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_wgb",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 15\r\n{On Awakening}\r\nGain 3 Protection [On Use]\r\n{On Corrosion}\r\n{Indiscriminate}\r\nTargets the unit with least HP."
                        }
                    });
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_wgb_dice",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "[On Hit] Consume 15 SP; If the natural roll of this die is Max Heal 3 HP, else Inflict 1 Bleed to Target; Recycle this die until the user has ran out of Positive SP (max. 5)"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910003), false).Script = "ayin_wgb";
                ItemXmlDataList.instance.GetCardItem(new LorId(910003), false).DiceBehaviourList[0].Script =
                    "ayin_wgb_dice";
                ItemXmlDataList.instance.GetCardItem(new LorId(910003), false).DiceBehaviourList[0].Dice = 8;
                ItemXmlDataList.instance.GetCardItem(new LorId(910003), false).DiceBehaviourList[0].Min = -3;

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_hor",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 35\r\n{On Awakening}\n\rInflict 3 Paralysis next Scene [On Hit]\r\n{On Corrosion}\r\nInflict 7 Fragile and Gain 7 Fragile instead"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910004), false).Script = "ayin_hor";

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_vin",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 30\r\n{On Awakening}\n\rInflict 2 Bind next Scene [On Hit]\r\n{On Corrosion}\r\nInflict 2 Burn Instead"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910005), false).Script = "ayin_vin";

                // yesod
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_mur",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 20\r\n{On Awakening}\n\rDice on this page gain 2 Power\r\n{On Corrosion}\r\nBreak all dice on this page and add a new Blunt Dice [(-7~15)] which Spends all of the user's Stagger Resist to deal Stagger Damage damage equal to what's spend"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910011), false).Script = "ayin_mur";

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_mk2",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 25\r\n{On Awakening}\n\rSpend all charge to gain Power equal to (Charge Spent/4)\r\n{On Corrosion}\r\n{Indiscriminate}\r\nSpend all charge to deal extra Damage equal to (Charge Spent/3)"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910012), false).Script = "ayin_mk2";

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_sng",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 30\r\nUpon each successful hit, a random ally takes 3 Stagger damage and gains 1 Strength next Scene\r\nUpon defeating an enemy, all allies gain 2 Strength\r\n{On Corrosion}\r\nInflict 2 Paralysis [On Hit]"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910013), false).Script = "ayin_sng";

                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add(
                    "ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING",
                    new BattleCardAbilityDesc
                    {
                        desc = new List<string>
                        {
                            "{Sanity Cost} - 35\r\nEach die on this page is rolled (7 + Personal Emotional Level) times\r\nIncrease damage of each subsequent die by the (Dice# * 5)%\r\nIf the Personal Emotional Level is at 5 or Higher, Gain +2 Power\r\nDice# of 10 or more gain +50% Dmg Rate for each Dice# over 10 (max 2)\r\n{On Corrosion}\r\n{Indiscriminate}\r\nConvert this card into a Mass Attack"
                        }
                    });
                ItemXmlDataList.instance.GetCardItem(new LorId(910014), false).Script =
                    "ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING";
                ItemXmlDataList.instance.GetCardItem(new LorId(910014), false).DiceBehaviourList[0].Script =
                    "ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING_dice";
                Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add(
                    "ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING_dice",
                    new BattleCardAbilityDesc
                        { desc = new List<string> { "[On Hit] Deal either 3 damage or 3 Stagger damage to target" } });

                //ItemXmlDataList.instance.GetCardItem(new LorId(1), false).Script = "ayin_IN_HELL_WE_LIVE_LAMENT";
                //ItemXmlDataList.instance.GetCardItem(new LorId(2), false).Script = "ayin_LAMENT_IF_YOU_WANTED_ME_TO_DINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDINGDING";
                //ItemXmlDataList.instance.GetCardItem(new LorId(2), false).Script = "argalia_duel";

                // hod
                //Singleton<BattleCardAbilityDescXmlList>.Instance._dictionary.Add("ayin_sde", new BattleCardAbilityDesc { desc = new List<string> { "{Sanity Cost} - 25\r\n[Combat Start] Enemies do not lose Bleed stacks after rolling Offensive dice for this Scene\r\n{On Corrosion}\r\n" } });
                //ItemXmlDataList.instance.GetCardItem(new LorId(910013), false).Script = "ayin_sng";
            }

            // floor specific buffs
            {
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Malkuth",
                    new BattleEffectText
                    {
                        Name = "Floor of History",
                        Desc = "Inflict (3 * Personal Emotional Level) Burn to all enemies upon death", ID = ""
                    });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Yesod",
                    new BattleEffectText
                        { Name = "Floor of Technological Sciences", Desc = "Gain +2 SP Gain Efficiency", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Hod",
                    new BattleEffectText
                        { Name = "Floor of Literature", Desc = "[On Clash Win] Inflict 1 Bleed next Scene", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Netzach",
                    new BattleEffectText { Name = "Floor of Art", Desc = "[On Hit] Recover 2 HP", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Tiph",
                    new BattleEffectText
                    {
                        Name = "Floor of Natural Sciences",
                        Desc =
                            "When inflicting Negative Effects using Combat Pages this Scene, inflict 1 additional stack",
                        ID = ""
                    });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Gebruh",
                    new BattleEffectText
                        { Name = "Floor of Language", Desc = "Deal +1% more Damager per This Unit's SP", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Binah",
                    new BattleEffectText
                    {
                        Name = "Floor of Philosophy",
                        Desc =
                            "At the start of the scene, gain 1 stack of Protection for every 15 positive SP this unit has. Upon winning a clash, recover 2 HP. At the end of the scene, gain 1 Strength for every 3 clashes won (rounded up). Upon losing a clash, recover 3 Break.",
                        ID = ""
                    });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Chesed",
                    new BattleEffectText { Name = "Floor of Social Sciences", Desc = "Gain 3 Haste", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Hokma",
                    new BattleEffectText
                        { Name = "Floor of Religion", Desc = " [On Hit] Deal 2 Fixed SP Damage", ID = "" });
                Singleton<BattleEffectTextsXmlList>.Instance._dictionary.Add("Keter",
                    new BattleEffectText
                    {
                        Name = "Floor of General Works", Desc = "Increase Max HP by 10% and Stagger by 25%", ID = ""
                    });
            }

            // panic types
            {
                // revenge
                List<int> panic2ls = new List<int>
                {
                    100006, 100010, 120008, 130007, 130024, 200006, 200010, 220008, 230007, 230024, 143003, 243003,
                    150006, 250006, 150015, 250015, 150016, 250016, 150017, 250017, 156001, 256001
                };

                //slowdown
                List<int> panic3ls = new List<int>
                {
                    100004, 100007, 100008, 100009, 110001, 110006, 130004, 130005, 130006, 130021, 130022, 130023,
                    200004, 200007, 200008, 200009, 210001, 210006, 230004, 230005, 230006, 230021, 230022, 230023,
                    150009, 250009, 152001, 252001, 152002, 252002
                };

                // bloodthirst
                List<int> panic4ls = new List<int>
                    { 110002, 140002, 240010, 210002, 240002, 143004, 243004, 150007, 250007 };

                // anger
                List<int> panic5ls = new List<int>
                {
                    110003, 110005, 120009, 120010, 120001, 130001, 130002, 130003, 130016, 140003, 140004, 210003,
                    210005, 220009, 220010, 220001, 230001, 230002, 230003, 230016, 240003, 240004, 150002, 250002,
                    150003, 250003, 150004, 250004
                };

                // standoff
                List<int> panic6ls = new List<int>
                {
                    121004, 121002, 121001, 121003, 120002, 130025, 130026, 221004, 221002, 221001, 221003, 220002,
                    230025, 230026, 143002, 243002, 150019, 250019, 154001, 254001
                };

                // decisive break
                List<int> panic7ls = new List<int> { 120004, 120003, 140008, 220004, 220003, 240008 };

                // Gamble
                List<int> panic8ls = new List<int>
                {
                    120005, 120006, 120007, 220005, 220006, 220007, 143001, 243001, 134002, 234002, 134001, 234001,
                    155001, 255001, 155002, 255002
                };

                // Protector
                List<int> panic9ls = new List<int>
                    { 130008, 140005, 230008, 240005, 150008, 250008, 153001, 253001, 160001, 260001, 160101 };

                // Burning Passion
                List<int> panic10ls = new List<int>
                {
                    130009, 130027, 130028, 240027, 230009, 230027, 230028, 150001, 250001, 150021, 250021, 150018,
                    250018, 150037, 250037, 150020, 150036, 150038, 250036
                };

                // Unstable Charge
                List<int> panic11ls = new List<int>
                {
                    130010, 130011, 130012, 140022, 140019, 140020, 140021, 140022, 230010, 230011, 230012, 240022,
                    240019, 240020, 240021, 240022, 150010, 250010, 150011, 250011, 150012, 250012, 150026, 250026,
                    150103, 250103, 150025, 250025, 150102, 250102, 150023, 250023, 150024, 250024, 150101, 250101,
                    150030, 150029, 150028, 150031, 150032, 150033, 150034
                };

                // Bleeding Heart
                List<int> panic12ls = new List<int>
                {
                    131001, 130018, 130019, 130020, 231001, 230018, 230019, 230020, 133001, 233001, 132002, 232002,
                    132001, 232001, 143005, 243005
                };

                // Corpse Liquidification
                List<int> panic13ls = new List<int>
                    { 141002, 140015, 140016, 140017, 241002, 240015, 240016, 240017, 154002, 254002 };

                // Exhaustion
                List<int> panic14ls = new List<int> { 141001, 241001, 151001, 251001, 150035, 250035, 156002, 256002 };

                // Chronic Lung Cancer
                List<int> panic15ls = new List<int>
                    { 140026, 140023, 140024, 140025, 240026, 240023, 240024, 240025, 150014, 250014 };

                // Fate of the Prescript
                List<int> panic16ls = new List<int> { 150051, 250051, 150039, 150040 };

                // Ensemble partiellement ordonné
                List<int> panic17ls = new List<int>
                {
                    150013, 1310011, 260005, 1301011, 1302011, 1303011, 1304011, 1305011, 1306011, 1307011, 1308011,
                    1308021, 1309011, 260006, 260007, 260008, 260009, 260010, 260011, 260012, 260013, 260014
                };

                // The Red Mist
                List<int> panic18ls = new List<int> { 150022, 250022, 180004 };

                // Reverse Panic
                List<int> panic19ls = new List<int> { 140001, 240001 };

                // Forceful Arbitration
                List<int> panic20ls = new List<int> { 8, 3, 4, 180001, 180002 };

                // Sorrow and despair
                List<int> panic21ls = new List<int> { 102, 170001, 180003, 1410012 };

                List<int> nopanic = new List<int>
                {
                    /*180001, 180002*/8
                };

                // Hana: Unity
                // +3 SP Gain Efficiency, if at max SP gain 1 Protection and 1 Strength.
                // Deal +5% more damage per each Hana Assosiation ally alive, if all 5 Hana Assosiation allies are alive gain 1 Strength and 1 Break Protection.
                // If no other allies are present at the end of the Scene, gain +2 Speed Dice, Boost the *minimum* roll value of all dice by +2, At Emotion Level 3 or higher, also boost the *maximum* roll value of all dice by +1.
                // Upon reaching -45 SP, gain 3 Protection
                List<int> hm_4 = new List<int> { 160003, 260003, 160002, 260002, 160004, 260004 };

                // For A Greater Cause
                // When using "Unity" combat cards activate a secondary effect as well.
                List<int> hm_5 = new List<int> { 160003, 260003, 160002, 260002, 160004, 260004 };


                // rm - 150022, 250022, 180004
                // pt - 150035, 250035
                // xiao - 150020, 150036, 150038, 250036


                // Shattered Blade
                List<int> hm_1 = new List<int> { 130018, 130019, 130020, 230018, 230019, 230020 };

                // Extreme Edge
                List<int> hm_2 = new List<int> { 140001, 140002, 140003, 240001, 240002, 240003 };

                // Will of The City
                List<int> hm_3 = new List<int> { 150051, 250051 };

                foreach (BookXmlInfo book in Singleton<BookXmlList>.Instance.GetList())
                {
                    int id = book.id.id;
                    if (nopanic.Contains(id))
                    {
                    }
                    else if (panic2ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[2]);
                    }
                    else if (panic3ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[3]);
                    }
                    else if (panic4ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[4]);
                    }
                    else if (panic5ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[5]);
                    }
                    else if (panic6ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[6]);
                    }
                    else if (panic7ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[7]);
                    }
                    else if (panic8ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[8]);
                    }
                    else if (panic9ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[9]);
                    }
                    else if (panic10ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[10]);
                    }
                    else if (panic11ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[11]);
                    }
                    else if (panic12ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[12]);
                    }
                    else if (panic13ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[13]);
                    }
                    else if (panic14ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[14]);
                    }
                    else if (panic15ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[15]);
                    }
                    else if (panic16ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[16]);
                    }
                    else if (panic17ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[17]);
                    }
                    else if (panic18ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[18]);
                    }
                    else if (panic19ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[19]);
                    }
                    else if (panic20ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[20]);
                    }
                    else if (panic21ls.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[21]);
                    }
                    else if (hm_4.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 1, new LorId(packageName, 2004));
                    }
                    else
                    {
                        sfInsert(book.EquipEffect.PassiveList, 0, spList[0]);
                    }

                    if (hm_1.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 1, new LorId(packageName, 2001));
                    }

                    if (hm_2.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 1, new LorId(packageName, 2002));
                    }

                    if (hm_3.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 1, new LorId(packageName, 2003));
                    }

                    if (hm_5.Contains(id))
                    {
                        sfInsert(book.EquipEffect.PassiveList, 2, new LorId(packageName, 2005));
                    }
                }
            }

            //Singleton<BookXmlList>.Instance.GetData(250023).EquipEffect.PassiveList.Insert(4, new LorId(packageName, 4002));
            Singleton<BookXmlList>.Instance.GetData(8).EquipEffect.PassiveList.Remove(new LorId(10011));
            Singleton<BookXmlList>.Instance.GetData(8).EquipEffect.PassiveList.Add(new LorId(packageName, 1));
            Singleton<DeckXmlList>.Instance._list.RemoveAll(x => x.id == 8);
            Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
            {
                _id = 8,
                cardIdList = new List<LorId>
                {
                    new LorId(706202),
                    new LorId(706202),
                    new LorId(706202),

                    new LorId(706205),
                    new LorId(706205),

                    new LorId(706204),
                    new LorId(706204),
                    new LorId(706201),
                    new LorId(706201),
                }
            });
            foreach (BookXmlInfo bookXmlInfo in Singleton<BookXmlList>.Instance.GetList())
            {
                bookXmlInfo.SuccessionPossibleNumber = 12;
            }
            //Singleton<ModContentManager>.Instance.InitModInfos();
        }

        [HarmonyPatch(typeof(VersionViewer), "Start")]
        [HarmonyPrefix]
        public static bool VersionViewer_Start(VersionViewer __instance)
        {
            Text component = __instance.GetComponent<Text>();
            component.text = string.Concat(new string[]
            {
                GlobalGameManager.Instance.ver,
                Environment.NewLine,
                "YumYum Enterprises v1.0",
                Environment.NewLine,
                "by Yui"
            });
            component.fontSize = 30;
            __instance.gameObject.transform.localPosition = new Vector3(-830f, -460f);
            return false;
        }

        public static void sfInsert<T>(List<T> a, int inx, T b)
        {
            if (a.Count >= inx)
            {
                a.Insert(inx, b);
            }
            else
            {
                a.Add(b);
            }
        }

        public void patch()
        {
            if (!_patched)
            {
                foreach (BookModel x in BookInventoryModel.Instance.GetBookListAll())
                {
                    if (x.BookId == 8)
                    {
                        x._classInfo.EquipEffect.Hp = 30 + (LibraryModel.Instance.GetChapter() * 43);
                        x._classInfo.EquipEffect.Break = 15 + (LibraryModel.Instance.GetChapter() * 32);
                        x._classInfo.speedDiceNumber = 1 + (LibraryModel.Instance.GetChapter() / 2);
                        x._classInfo.EquipEffect.StartPlayPoint = 4 + (LibraryModel.Instance.GetChapter() / 2);
                        x._classInfo.EquipEffect.MaxPlayPoint = 4 + (LibraryModel.Instance.GetChapter() / 2);
                        x.SetOriginalStat();
                        x.SetOriginalPlayPoint();
                        x.SetOriginalSpeedNum();
                    }
                }

                // enemy
                foreach (BookXmlInfo x in Singleton<BookXmlList>.Instance.GetList())
                {
                    //x.EquipEffect.Hp = (int)(x.EquipEffect.Hp * (1 + x.Chapter * 0.07));
                    //x.EquipEffect.Break = (int)(x.EquipEffect.Break * (1 + x.Chapter * 0.03));

                    int ll = 3;
                    if (x.EquipEffect.MaxPlayPoint != 3 && x.Rarity != Rarity.Unique)
                    {
                        ll = x.EquipEffect.MaxPlayPoint;
                    }

                    if (x.Rarity == Rarity.Unique)
                    {
                        if (ll < 4)
                        {
                            ll = 4;
                        }
                    }

                    ll += x.Chapter / 2;
                    x.EquipEffect.MaxPlayPoint = ll;
                    x.EquipEffect.StartPlayPoint = ll;
                    x.speedDiceNumber += x.Chapter / 4;
                }

                // librarian
                Hashtable books = new Hashtable();
                foreach (BookModel x in BookInventoryModel.Instance.GetBookListAll())
                {
                    if (books.Contains(x.BookId))
                    {
                        (int, int, int) stats = ((int, int, int))books[x.BookId];
                        x.equipeffect.Hp = stats.Item1;
                        x.equipeffect.Break = stats.Item2;
                        x.equipeffect.SpeedDiceNum = stats.Item3;
                        x.SetOriginalStat();
                    }
                    else
                    {
                        int chapter = Singleton<BookXmlList>.Instance.GetData(x.BookId).Chapter;
                        Rarity rarity = Singleton<BookXmlList>.Instance.GetData(x.BookId).Rarity;

                        int hp, br;
                        if (x.BookId == 8)
                        {
                            hp = x.equipeffect.Hp;
                            br = x.equipeffect.Break;
                        }
                        else
                        {
                            hp = x.equipeffect.Hp;
                            br = x.equipeffect.Break;
                            //hp = (int)(x.equipeffect.Hp * (1 + chapter * 0.04));
                            //br = (int)(x.equipeffect.Break * (1 + chapter * 0.02));
                        }

                        int sp = (int)(chapter / 4);

                        int ll = 3;
                        if (x.equipeffect.MaxPlayPoint != 3 && rarity != Rarity.Unique)
                        {
                            ll = x.equipeffect.MaxPlayPoint;
                        }
                        else
                        {
                            if (rarity == Rarity.Unique)
                            {
                                if (ll < 4)
                                {
                                    ll = 4;
                                }
                            }
                        }

                        ll += chapter / 2;
                        x.equipeffect.Hp = hp;
                        x.equipeffect.Break = br;
                        x.equipeffect.SpeedDiceNum += sp;
                        x.equipeffect.MaxPlayPoint = ll;
                        x.equipeffect.StartPlayPoint = ll;
                        x.SetOriginalStat();
                        books.Add(x.BookId, (hp, br, sp));
                    }
                }

                // custom decks
                {
                    List<int> nuhuhdeck = new List<int>
                    {
                        150051, 100003, 100001, 110006, 120008, 120006, 130007, 130024, 141001, 140001, 140009, 140010,
                        140005, 140027, 140003, 150010, 156001, 150002, 150018, 150037, 150036, 150022, 150051, 150023,
                        150007
                    };
                    foreach (DeckXmlInfo x in Singleton<DeckXmlList>.Instance._list.ToList())
                    {
                        if (x.id.id > 100000 & x.id.id < 200000)
                        {
                            if (!nuhuhdeck.Contains(x.id.id))
                            {
                                Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                                    { _id = x.id.id + 100000, cardIdList = x.cardIdList });
                            }

                            Singleton<BookXmlList>.Instance.GetData(new LorId(x.id.id + 100000), false).categoryList
                                .Add(BookCategory.DeckFixed);
                        }
                    }

                    // Rats
                    {
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 200003,
                            cardIdList = new List<LorId>
                            {
                                new LorId(101004),
                                new LorId(101004),
                                new LorId(101002),

                                new LorId(101006),
                                new LorId(101005),
                                new LorId(101005),

                                new LorId(101003),
                                new LorId(101003),
                                new LorId(101001),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 200002,
                            cardIdList = new List<LorId>
                            {
                                new LorId(101004),
                                new LorId(101004),
                                new LorId(101002),

                                new LorId(101006),
                                new LorId(101005),
                                new LorId(101005),

                                new LorId(101003),
                                new LorId(101003),
                                new LorId(101001),

                                new LorId(10),
                                new LorId(11),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 200001,
                            cardIdList = new List<LorId>
                            {
                                new LorId(101004),
                                new LorId(101004),
                                new LorId(101002),

                                new LorId(101006),
                                new LorId(101005),
                                new LorId(101005),

                                new LorId(101003),
                                new LorId(101003),
                                new LorId(101001),
                            }
                        });
                    }

                    // Urban Legend
                    {
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 210006,
                            cardIdList = new List<LorId>
                            {
                                new LorId(202009),
                                new LorId(202009),
                                new LorId(202010),

                                new LorId(202010),
                                new LorId(202012),
                                new LorId(202011),

                                new LorId(202011),
                                new LorId(202011),
                                new LorId(202012),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 220006,
                            cardIdList = new List<LorId>
                            {
                                new LorId(302002),
                                new LorId(302002),

                                new LorId(302007),
                                new LorId(302007),

                                new LorId(302005),
                                new LorId(302005),
                                new LorId(302005),

                                new LorId(302004),
                                new LorId(302004),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 220008,
                            cardIdList = new List<LorId>
                            {
                                new LorId(303009),
                                new LorId(303009),

                                new LorId(303005),
                                new LorId(303003),
                                new LorId(303003),

                                new LorId(303002),
                                new LorId(303002),
                                new LorId(303002),
                                new LorId(303001),
                            }
                        });
                    }

                    // Urban Plague
                    {
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 230007,
                            cardIdList = new List<LorId>
                            {
                                new LorId(403006),
                                new LorId(403006),
                                new LorId(403006),

                                new LorId(403002),
                                new LorId(403002),

                                new LorId(403005),
                                new LorId(403005),
                                new LorId(403005),


                                new LorId(403001),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 230024,
                            cardIdList = new List<LorId>
                            {
                                new LorId(408005),
                                new LorId(408005),
                                new LorId(408005),

                                new LorId(408002),
                                new LorId(408002),
                                //new LorId(408002),

                                new LorId(408001),
                                new LorId(408001),
                                new LorId(408003),
                            }
                        });
                    }

                    // Urban Nightmare
                    {
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 241001,
                            cardIdList = new List<LorId>
                            {
                                new LorId(501007),
                                new LorId(501007),
                                new LorId(501006),
                                new LorId(501006),

                                new LorId(501005),
                                new LorId(501005),
                                new LorId(501005),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 240001,
                            cardIdList = new List<LorId>
                            {
                                new LorId(501007),
                                new LorId(501007),
                                new LorId(501006),

                                new LorId(501004),
                                new LorId(501004),

                                new LorId(501005),
                                new LorId(501003),
                                new LorId(501003),

                                new LorId(501001),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 240009,
                            cardIdList = new List<LorId>
                            {
                                new LorId(503003),
                                new LorId(503003),
                                new LorId(503003),

                                new LorId(503010),
                                new LorId(503010),
                                new LorId(503010),

                                new LorId(503002),
                                new LorId(503001),
                                new LorId(503001),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 240010,
                            cardIdList = new List<LorId>
                            {
                                new LorId(503003),
                                new LorId(503003),
                                new LorId(503003),

                                new LorId(503003),
                                new LorId(503003),
                                new LorId(503003),

                                new LorId(503010),
                                new LorId(503010),
                                new LorId(503010),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 240005,
                            cardIdList = new List<LorId>
                            {
                                new LorId(502007),
                                new LorId(502007),
                                new LorId(101002),

                                new LorId(502006),
                                new LorId(502006),
                                new LorId(502006),

                                new LorId(502004),
                                new LorId(502003),
                                new LorId(502001),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 240027,
                            cardIdList = new List<LorId>
                            {
                                new LorId(403006),
                                new LorId(403006),
                                new LorId(403006),

                                new LorId(408013),
                                new LorId(408013),

                                new LorId(408012),
                                new LorId(408012),
                                new LorId(508011),

                                new LorId(508010),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 243003,
                            cardIdList = new List<LorId>
                            {
                                new LorId(512001),
                                new LorId(512001),
                                new LorId(512001),

                                new LorId(512002),

                                new LorId(512005),
                                new LorId(512005),

                                new LorId(512003),
                                new LorId(512004),
                                new LorId(512006),
                            }
                        });
                    }

                    // Sotc
                    {
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250010,
                            cardIdList = new List<LorId>
                            {
                                new LorId(603007),
                                new LorId(603007),

                                new LorId(603006),
                                new LorId(603006),

                                new LorId(603005),
                                new LorId(603005),
                                new LorId(603003),

                                new LorId(603001),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 256001,
                            cardIdList = new List<LorId>
                            {
                                new LorId(616001),
                                new LorId(616001),
                                new LorId(616002),
                                new LorId(616003),
                                new LorId(616003),

                                new LorId(616004),
                                new LorId(616005),
                                new LorId(616005),

                                new LorId(616006),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250002,
                            cardIdList = new List<LorId>
                            {
                                new LorId(601007),
                                new LorId(601007),
                                new LorId(601013),

                                new LorId(601011),
                                new LorId(601003),
                                new LorId(601003),

                                new LorId(601002),
                                new LorId(601001),
                                new LorId(601008),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250018,
                            cardIdList = new List<LorId>
                            {
                                new LorId(601007),
                                new LorId(601011),
                                new LorId(606005),

                                new LorId(601006),
                                new LorId(601003),
                                new LorId(601003),

                                new LorId(606004),
                                new LorId(601001),
                                new LorId(606002),
                            }
                        });

                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250037,
                            cardIdList = new List<LorId>
                            {
                                new LorId(601007),
                                new LorId(601007),
                                new LorId(601011),

                                new LorId(610002),
                                new LorId(610002),
                                new LorId(610002),

                                new LorId(606003),
                                new LorId(606002),
                                new LorId(610011),
                            }
                        });

                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250036,
                            cardIdList = new List<LorId>
                            {
                                new LorId(601007),
                                new LorId(601007),
                                new LorId(601011),

                                new LorId(610010),
                                new LorId(610010),
                                new LorId(610004),

                                new LorId(610008),
                                new LorId(610006),
                                new LorId(606001),

                                new LorId(610003),
                                new LorId(610002),
                                new LorId(610011),

                                new LorId(601011),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250022,
                            cardIdList = new List<LorId>
                            {
                                new LorId(607004),
                                new LorId(607004),
                                new LorId(607004),

                                new LorId(607003),
                                new LorId(607003),

                                new LorId(607005),
                                new LorId(607005),

                                new LorId(607006),
                                new LorId(607006),

                                new LorId(607003),
                                new LorId(607005),
                            }
                        });

                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250051,
                            cardIdList = new List<LorId>
                            {
                                new LorId(605007),
                                new LorId(611004),
                                new LorId(611005),
                                new LorId(611007),
                                new LorId(605006),
                                new LorId(605004),
                                new LorId(611006),
                                new LorId(611003),
                                new LorId(611002),
                                new LorId(611001),
                                new LorId(packageName, 302),
                            }
                        });
                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250007,
                            cardIdList = new List<LorId>
                            {
                                new LorId(602012),
                                new LorId(602012),
                                new LorId(602007),
                                new LorId(602007),

                                new LorId(602008),
                                new LorId(602008),
                                new LorId(602008),

                                new LorId(602010),
                                new LorId(602010),
                            }
                        });

                        Singleton<DeckXmlList>.Instance._list.Add(new DeckXmlInfo
                        {
                            _id = 250023,
                            cardIdList = new List<LorId>
                            {
                                new LorId(608014),
                                new LorId(608014),
                                new LorId(608014),

                                new LorId(608013),
                                new LorId(608013),
                                new LorId(608013),

                                new LorId(608015),
                                new LorId(608009),
                                new LorId(608004),
                            }
                        });
                    }
                }

                Singleton<DropBookXmlList>.Instance.GetData(new LorId(250037)).DropItemList.Add(new BookDropItemInfo
                    { id = new LorId(packageName, 301), itemType = DropItemType.Card });
                Singleton<DropBookXmlList>.Instance.GetData(new LorId(250037)).DropItemList.Add(new BookDropItemInfo
                    { id = new LorId(packageName, 302), itemType = DropItemType.Card });
                Singleton<DropBookXmlList>.Instance.GetData(new LorId(250037)).DropItemList.Add(new BookDropItemInfo
                    { id = new LorId(packageName, 303), itemType = DropItemType.Card });
                _patched = true;
            }
        }

        static public int pWin = 5;
        static public int pLose = -3;
        static public int allyDeath = -15;
        static public int enemyDeath = 10;
        static public int baseSp = 0;

        static public int minSp = -45;
        static public int maxSp = 45;

        public class SpGainBuf : BattleUnitBuf
        {
            public override void OnRoundEnd()
            {
                base.OnRoundEnd();
                this.Destroy();
            }
        }

        public class SpLoseBuf : BattleUnitBuf
        {
            public override void OnRoundEnd()
            {
                base.OnRoundEnd();
                this.Destroy();
            }
        }


        public class MalkuthBuf : BattleUnitBuf
        {
            public override string keywordId => "Malkuth";

            public override void OnDie()
            {
                base.OnDie();
                foreach (BattleUnitModel x in BattleObjectManager.instance.GetAliveList())
                {
                    if (x.faction != _owner.faction)
                    {
                        x.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Burn,
                            3 * _owner.emotionDetail.EmotionLevel);
                    }
                }
            }
        }

        public class YesodBuf : BattleUnitBuf
        {
            public override string keywordId => "Yesod";

            public override void OnRoundStart()
            {
                base.OnRoundStart();
                base._owner.bufListDetail.AddReadyReadyBuf(new SpGainBuf { stack = 2 });
            }
        }

        public class HodBuf : BattleUnitBuf
        {
            public override string keywordId => "Hod";

            public override void OnWinParrying(BattleDiceBehavior behavior)
            {
                base.OnWinParrying(behavior);
                behavior.card.target?.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Bleeding, 1);
            }
        }

        public class NetzachBuf : BattleUnitBuf
        {
            public override string keywordId => "Netzach";

            public override void OnSuccessAttack(BattleDiceBehavior behavior)
            {
                base.OnSuccessAttack(behavior);
                base._owner.RecoverHP(2);
            }
        }

        public class TiphBuf : BattleUnitBuf
        {
            public override string keywordId => "Tiph";

            public override int OnGiveKeywordBufByCard(BattleUnitBuf cardBuf, int stack, BattleUnitModel target)
            {
                if (cardBuf.positiveType == BufPositiveType.Negative)
                {
                    return 1;
                }

                return 0;
            }
        }

        public class GebruhBuf : BattleUnitBuf
        {
            public override string keywordId => "Gebruh";

            public override void BeforeGiveDamage(BattleDiceBehavior behavior)
            {
                base.BeforeGiveDamage(behavior);
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = GetSP(GetOwnId(_owner))
                });
            }
        }

        public class BinahBuf : BattleUnitBuf
        {
            public override string keywordId => "Binah";
            internal static int _clashesWon = 0;

            public override void OnRoundStart()
            {
                base.OnRoundStart();
                //base._owner.bufListDetail.AddReadyReadyBuf(new SpLoseBuf { stack = 5 });
                int sp = GetSP(GetOwnId(_owner));
                if (sp >= 0)
                {
                    base._owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, (int)Mathf.Round(sp / 15));
                }

                _clashesWon = 0;
            }

            public override void OnRoundEnd()
            {
                base.OnRoundEnd();
                if (_clashesWon >= 3)
                {
                    base._owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength,
                        (int)Mathf.Ceil((float)_clashesWon / 3));
                }
            }

            public override void OnWinParrying(BattleDiceBehavior behavior)
            {
                base.OnWinParrying(behavior);
                base._owner.RecoverHP(2);
                _clashesWon++;
            }

            public override void OnLoseParrying(BattleDiceBehavior behavior)
            {
                base.OnLoseParrying(behavior);
                base._owner.breakDetail.RecoverBreak(3);
            }
        }

        public class ChesedBuf : BattleUnitBuf
        {
            public override string keywordId => "Chesed";

            public override void OnRoundStart()
            {
                base.OnRoundStart();
                base._owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 3);
            }
        }

        public class HokmaBuf : BattleUnitBuf
        {
            public override string keywordId => "Hokma";

            public override void OnSuccessAttack(BattleDiceBehavior behavior)
            {
                base.OnSuccessAttack(behavior);
                UpdateSP(GetOwnId(behavior.card?.target), -2, behavior.card?.target);
            }
        }

        public class KeterBuf : BattleUnitBuf
        {
            public override string keywordId => "Keter";

            public override StatBonus GetStatBonus()
            {
                return new StatBonus
                {
                    hpRate = 10,
                    breakRate = 25,
                };
            }
        }

        public static List<BattleUnitBuf> floorPassives = new List<BattleUnitBuf>
        {
            new MalkuthBuf(),
            new YesodBuf(),
            new HodBuf(),
            new NetzachBuf(),
            new TiphBuf(),
            new GebruhBuf(),
            new ChesedBuf(),
            new BinahBuf(),
            new HokmaBuf(),
            new KeterBuf(),
        };

        [HarmonyPatch(typeof(BattleUnitModel), "OnWaveStart")]
        [HarmonyPostfix]
        public static void BattleUnitModel_OnWaveStart_Post(BattleUnitModel __instance)
        {
            var seph = Singleton<StageController>.Instance.GetCurrentStageFloorModel().Sephirah;
            if ((seph != SephirahType.None || seph != SephirahType.ETC) && __instance.faction != Faction.Enemy)
            {
                if (seph == SephirahType.Malkuth)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new MalkuthBuf());
                }
                else if (seph == SephirahType.Yesod)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new YesodBuf());
                }
                else if (seph == SephirahType.Hod)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new HodBuf());
                }
                else if (seph == SephirahType.Netzach)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new NetzachBuf());
                }
                else if (seph == SephirahType.Tiphereth)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new TiphBuf());
                }
                else if (seph == SephirahType.Gebura)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new GebruhBuf());
                }
                else if (seph == SephirahType.Chesed)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new ChesedBuf());
                }
                else if (seph == SephirahType.Binah)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new BinahBuf());
                }
                else if (seph == SephirahType.Hokma)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new HokmaBuf());
                }
                else if (seph == SephirahType.Keter)
                {
                    __instance.bufListDetail.AddBufWithoutDuplication(new KeterBuf());
                }
                //__instance.personalEgoDetail.AddCard(new LorId(packageName, 501));
            }
        }

        public static void PersistentAdd(string a, object b)
        {
            Singleton<StageController>.Instance.GetStageModel().SetStageStorgeData(a, b);
        }

        public static object PersistentGet(string a)
        {
            return Singleton<StageController>.Instance.GetStageModel()._stageDataStorage[a];
        }

        public static string GetOwnId(BattleUnitModel owner)
        {
            return String.Concat(owner.Book.BookId.packageId, owner.Book.BookId.id, owner.index);
        }

        public static void UpdateSP(String ids, int value, BattleUnitModel unit = null)
        {
            object _sp;
            int sp = baseSp;
            if (Singleton<StageController>.Instance.GetStageModel()._stageDataStorage.TryGetValue(ids, out _sp))
            {
                sp = (int)_sp;
                Singleton<StageController>.Instance.GetStageModel()
                    .SetStageStorgeData(ids, Mathf.Clamp(sp + value, minSp, maxSp));
            }
            else
            {
                Singleton<StageController>.Instance.GetStageModel()
                    .SetStageStorgeData(ids, Mathf.Clamp(sp + value, minSp, maxSp));

                //Singleton<StageController>.Instance.GetStageModel()._stageDataStorage.Add(ids, Mathf.Clamp(sp + value, minSp, maxSp));
            }

            if (unit != null)
            {
                updateSPDisplay(unit);
            }
        }

        public static void SetSP(String ids, int value)
        {
            object _sp;
            if (Singleton<StageController>.Instance.GetStageModel()._stageDataStorage.TryGetValue(ids, out _sp))
            {
                Singleton<StageController>.Instance.GetStageModel()._stageDataStorage[ids] =
                    Mathf.Clamp(value, minSp, maxSp);
            }
            else
            {
                Singleton<StageController>.Instance.GetStageModel()._stageDataStorage
                    .Add(ids, Mathf.Clamp(value, minSp, maxSp));
            }
        }

        public static void InitSP(String ids)
        {
            object _sp;
            int sp = baseSp;
            if (!Singleton<StageController>.Instance.GetStageModel()._stageDataStorage.TryGetValue(ids, out _sp))
            {
                Singleton<StageController>.Instance.GetStageModel()._stageDataStorage.Add(ids, sp);
            }
        }

        public static int GetSP(String ids)
        {
            object _sp;
            int sp = baseSp;
            if (Singleton<StageController>.Instance.GetStageModel()._stageDataStorage.TryGetValue(ids, out _sp))
            {
                sp = (int)_sp;
            }
            else
            {
                InitSP(ids);
            }

            return sp;
        }

        public static bool IsCorroded(String ids)
        {
            double p = 0.5 + GetSP(ids) / 100;
            return Random.value < p;
        }

        public static bool MinusRollCalc(int sp)
        {
            double p = 0.5 + sp / 100;
            return Random.value < p;
        }

        public static void updateSPDisplay(BattleUnitModel owner)
        {
            string ids = GetOwnId(owner);
            InitSP(ids);
            int sp = GetSP(ids);

            if (owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x is BattleUnitBuf_Sanity))
            {
                owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Sanity).stack =
                    sp;
            }
            else
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Sanity());
            }
        }


        [HarmonyPatch(typeof(BattleUnitModel), "OnWinParrying")]
        [HarmonyPostfix]
        public static void BattleUnitModel_OnWinParrying_Post(BattleUnitModel __instance, BattleDiceBehavior behavior)
        {
            string ids = GetOwnId(__instance);

            int s = 0;
            if (__instance.bufListDetail.GetActivatedBufList().Find(x => x is SpGainBuf) != null)
            {
                s = __instance.bufListDetail.GetActivatedBufList().Find(x => x is SpGainBuf).stack;
            }

            if (__instance.passiveDetail.HasPassive<PassiveAbility_shiSP>())
            {
                UpdateSP(ids, -pWin);
            }
            else
            {
                UpdateSP(ids, (s + pWin + behavior.DiceResultValue / 2 + behavior.Index));
            }

            updateSPDisplay(__instance);
        }


        [HarmonyPatch(typeof(BattleUnitModel), "OnLoseParrying")]
        [HarmonyPostfix]
        public static void BattleUnitModel_OnLoseParrying_Post(BattleUnitModel __instance, BattleDiceBehavior behavior)
        {
            string ids = GetOwnId(__instance);

            int s = 0;
            if (__instance.bufListDetail.GetActivatedBufList().Find(x => x is SpLoseBuf) != null)
            {
                s = __instance.bufListDetail.GetActivatedBufList().Find(x => x is SpLoseBuf).stack;
            }


            if (__instance.passiveDetail.HasPassive<PassiveAbility_shiSP>())
            {
                UpdateSP(ids, pLose * -1);
            }
            else
            {
                UpdateSP(ids, -s + pLose + -(behavior.DiceResultValue / 2 + Math.Abs(behavior.Index - 3)));
            }

            updateSPDisplay(__instance);
        }

        [HarmonyPatch(typeof(BattleUnitModel), "OnRoundEndTheLast")]
        [HarmonyPostfix]
        public static void BattleUnitModel_OnRoundEndTheLast_Post(BattleUnitModel __instance)
        {
            string ids = GetOwnId(__instance);
            if (GetSP(ids) <= minSp)
            {
                SetSP(ids, baseSp);
            }

            updateSPDisplay(__instance);
        }

        [HarmonyPatch(typeof(BattleUnitModel), "BeforeGiveDamage")]
        [HarmonyPostfix]
        public static void BattleUnitModel_BeforeGiveDamage_Post(BattleUnitModel __instance,
            BattleDiceBehavior behavior)
        {
            int x = __instance.emotionDetail.EmotionLevel;
            if (x >= 3)
            {
                x *= 2;
            }

            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = x * 5,
                breakRate = x * 3,
            });
        }

        [HarmonyPatch(typeof(BattleUnitModel), "OnUseCard")]
        [HarmonyPostfix]
        public static void BattleUnitModel_OnUseCard_Post(BattleUnitModel __instance,
            BattlePlayingCardDataInUnitModel card)
        {
            string ids = GetOwnId(__instance);
            UpdateSP(ids, -card.card.CurCost);
            updateSPDisplay(__instance);
            //int sp = (int)[ids];
        }

        [HarmonyPatch(typeof(BattleDiceBehavior), "UpdateDiceFinalValue")]
        [HarmonyPrefix]
        public static bool nrollPatch3(BattleDiceBehavior __instance)
        {
            if (__instance.abilityList.Exists((DiceCardAbilityBase x) => x.Invalidity))
            {
                __instance._diceFinalResultValue = 91;
                return false;
            }

            int num = __instance._diceResultValue;
            if (__instance._statBonus.ignorePower)
            {
                return false;
            }

            if (__instance.card != null)
            {
                if (__instance.card.ignorePower)
                {
                    __instance._diceFinalResultValue = num;
                    return false;
                }

                if (__instance.owner != null && __instance.owner.IsNullifyPower())
                {
                    __instance._diceFinalResultValue = num;
                    return false;
                }
            }

            int num2 = __instance._statBonus.power;
            if (__instance.abilityList.Find((DiceCardAbilityBase x) => x.IsDoublePower()) != null)
            {
                num2 += __instance._statBonus.power;
            }

            if (__instance.owner != null && __instance.owner.IsHalfPower())
            {
                num2 /= 2;
            }

            num += num2;
            __instance._diceFinalResultValue = num;

            return false;
        }

        [HarmonyPatch(typeof(BattleDiceBehavior), "RollDice")]
        [HarmonyPrefix]
        public static bool nrollPatch5(BattleDiceBehavior __instance)
        {
            int min = __instance.behaviourInCard.Min;
            min += __instance._statBonus.min;

            int max = __instance.behaviourInCard.Dice;
            max += __instance._statBonus.face * 3;
            max += __instance._statBonus.max;

            int diceMin = min;
            int diceMax = max;
            int num = Mathf.Min(diceMin, diceMax);
            //Debug.Log("rolldice: min: " + min + " max: " + max);
            if (diceMin <= 0)
            {
                if (__instance.owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) != null)
                {
                    __instance._diceResultValue = max;
                }
                else
                {
                    if (MinusRollCalc(GetSP(GetOwnId(__instance.owner))))
                    {
                        __instance._diceResultValue = max;
                    }
                    else
                    {
                        __instance._diceResultValue = max + min;
                    }
                }
            }
            else
            {
                __instance._diceResultValue = DiceStatCalculator.MakeDiceResult(diceMin, diceMax, 0);
            }

            __instance.owner.passiveDetail.ChangeDiceResult(__instance, ref __instance._diceResultValue);
            __instance.owner.emotionDetail.ChangeDiceResult(__instance, ref __instance._diceResultValue);
            __instance.owner.bufListDetail.ChangeDiceResult(__instance, ref __instance._diceResultValue);
            if (__instance._diceResultValue < num)
            {
                __instance._diceResultValue = num;
            }

            int num2 = 0;
            int num3 = 0;
            if (num != diceMax)
            {
                if (__instance._diceResultValue >= diceMax)
                {
                    num2++;
                }
                else if (__instance._diceResultValue <= num)
                {
                    num3++;
                }
            }

            if (__instance._diceResultValue < 1)
            {
                __instance._diceResultValue = 1;
            }

            if (num2 > 0)
            {
                int count = __instance.owner.emotionDetail.CreateEmotionCoin(EmotionCoinType.Positive, num2);
                BattleCardTotalResult battleCardResultLog = __instance.owner.battleCardResultLog;
                battleCardResultLog?.AddEmotionCoin(EmotionCoinType.Positive, count);
            }
            else if (num3 > 0)
            {
                int count2 = __instance.owner.emotionDetail.CreateEmotionCoin(EmotionCoinType.Negative, num3);
                BattleCardTotalResult battleCardResultLog2 = __instance.owner.battleCardResultLog;
                battleCardResultLog2?.AddEmotionCoin(EmotionCoinType.Negative, count2);
            }

            __instance.card.OnRollDice(__instance);
            __instance.OnEventDiceAbility(DiceCardAbilityBase.DiceCardPassiveType.RollDice, null);
            __instance.isUsed = true;
            return false;
        }


        [HarmonyPatch(typeof(BattleUnitModel), "OnDieOtherUnit")]
        [HarmonyPostfix]
        public static void BattleUnitModel_OnDieOtherUnit_Post(BattleUnitModel __instance, BattleUnitModel unit)
        {
            string ids = GetOwnId(__instance);
            if (unit.faction == __instance.faction)
            {
                UpdateSP(ids, allyDeath);
            }
            else
            {
                UpdateSP(ids, enemyDeath);
            }

            updateSPDisplay(__instance);
        }


        [HarmonyPatch(typeof(BattleUnitModel), "OnRoundStart_before")]
        [HarmonyPostfix]
        public static void BattleUnitModel_OnRoundStart_before_Post(BattleUnitModel __instance)
        {
            updateSPDisplay(__instance);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(BookModel), "SetXmlInfo")]
        public static void BookModel_SetXmlInfo(BookModel __instance, BookXmlInfo ____classInfo,
            ref List<DiceCardXmlInfo> ____onlyCards)
        {
            if (__instance.BookId.packageId == packageName)
            {
                foreach (int id in ____classInfo.EquipEffect.OnlyCard)
                {
                    DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(new LorId(packageName, id), false);
                    ____onlyCards.Add(cardItem);
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(LibraryModel), "LoadFromSaveData")]
        public static void LibraryModel_LoadFromSaveData()
        {
            //foreach (LorId card in Singleton<Init>.Instance.cards)
            //{
            //    if (Singleton<InventoryModel>.Instance.GetCardList().Find((DiceCardItemModel x) => x.GetID() == card) == null)
            //    {
            //        if (ItemXmlDataList.instance.GetCardItem(card, false).Rarity == Rarity.Unique)
            //        {
            //            Singleton<InventoryModel>.Instance.AddCard(card, 1);
            //        }
            //        else
            //        {
            //            Singleton<InventoryModel>.Instance.AddCard(card, 3);
            //        }
            //    }

            //    //Singleton<InventoryModel>.Instance.AddCard(card, 3);
            //}
        }

        //[HarmonyPatch(typeof(GameSceneManager), "ActivateUIController")]
        //[HarmonyPostfix]
        //public static void GameSceneManager_ActivateUIController_Post()
        //{
        //BookInventoryModel.Instance.CreateBook(new LorId(packageName, 3));
        //BookInventoryModel.Instance.CreateBook(new LorId(packageName, 4));
        //BookInventoryModel.Instance.CreateBook(new LorId(packageName, 5));

        //if (!BookInventoryModel.Instance.GetBookListAll().Exists(x => x.BookId == new LorId(packageName, 3)))
        //{
        //    BookInventoryModel.Instance.CreateBook(new LorId(packageName, 3));
        //}

        //if (!BookInventoryModel.Instance.GetBookListAll().Exists(x => x.BookId == new LorId(packageName, 5)))
        //{
        //    BookInventoryModel.Instance.CreateBook(new LorId(packageName, 5));
        //}
        //}

        [HarmonyPrefix]
        [HarmonyPatch(typeof(UnitDataModel), "IsLockUnit")]
        public static bool CharLocker(ref bool __result, ref UnitDataModel __instance)
        {
            __result = false;
            if (__instance._ownerSephirah == SephirahType.Binah && !__instance.isSephirah)
            {
                __result = true;
            }

            return false;
        }

        //[HarmonyPrefix]
        //[HarmonyPatch(typeof(StageController), "SetCurrentSephirah")]
        //public static bool BinahONLY(SephirahType sephirah, ref StageController __instance)
        //{
        //    if (sephirah != SephirahType.Binah)
        //    {
        //        __instance._currentFloor = SephirahType.Binah;
        //    }
        //    else
        //    {
        //        __instance._currentFloor = sephirah;
        //    }
        //    return false;
        //}

        public static void Automata(int stage)
        {
            //UIAlarmPopup.instance.SetAlarmText("automata!!!");
            int lv = 5;
            //int stage = 610000;
            SephirahType sep = SephirahType.Keter;

            Singleton<StageController>.Instance.SetCurrentSephirah(sep);
            StageClassInfo data = Singleton<StageClassInfoList>.Instance.GetData(stage);
            if (data != null)
            {
                LibraryModel.Instance.GetFloor(sep).SetTemporaryLevel(lv);
                Singleton<StageController>.Instance.InitStageByInvitation(data);

                foreach (UnitBattleDataModel unitBattleDataModel in Singleton<StageController>.Instance
                             .GetCurrentStageFloorModel().GetUnitBattleDataList())
                {
                    if (sep == SephirahType.Binah && LibraryModel.Instance.IsBinahLockedInStage(data) &&
                        unitBattleDataModel.unitData.isSephirah)
                    {
                        unitBattleDataModel.IsAddedBattle = false;
                    }
                    else
                    {
                        unitBattleDataModel.IsAddedBattle = true;
                    }
                }

                GlobalGameManager.Instance.LoadBattleScene();
            }
        }

        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(BattleObjectLayer), "AddUnit")]
        //static void NetzIsAll(BattleUnitModel model)
        //{
        //    //if (isSephirahChar || 1 == 1)
        //    //{
        //    //    // ozma - 147
        //    //    __instance.appearanceType.
        //    //    __instance.bookItem._characterSkin = "[Prefab]EGO_Ozma";
        //    //    __instance.customizeData.specialCustomID = new LorId(147);
        //    //    __instance.giftInventory.AddGift(173);
        //    //    __instance.giftInventory.Equip(__instance.giftInventory.GetGifts().Find(x => x.GetGiftClassInfoId() == 173));

        //    //}

        //    //model.view.ChangeEgoSkin("EGO_Ozma");
        //    //model.UnitData.unitData.giftInventory.AddGift(173);
        //    //model.UnitData.unitData.giftInventory.Equip(model.UnitData.unitData.giftInventory.GetGifts().Find(x => x.GetGiftClassInfoId() == 173));
        //    if (1 == 1)
        //    {
        //        //model._unitData.unitData.name = "Deadly Ego quiFu";
        //        model._unitData.unitData.customizeData.frontHairID = 26;
        //        model._unitData.unitData.customizeData.backHairID = 25;
        //        model._unitData.unitData.customizeData.hairColor = new Color(234, 15, 100);

        //        model._unitData.unitData.customizeData.eyeID = 4;
        //        model._unitData.unitData.customizeData.browID = 8;
        //        model._unitData.unitData.customizeData.mouthID = 9;

        //        model._unitData.unitData.customizeData.skinColor = new Color(53f, 4f, 78f);

        //        model._unitData.unitData.customizeData.specialCustomID = new LorId(524);

        //        model._unitData.unitData.giftInventory.AddGift(173);
        //        model._unitData.unitData.giftInventory.Equip(model._unitData.unitData.giftInventory.GetGifts().Find(x => x.GetGiftClassInfoId() == 173));
        //    }

        //}


        // Librarian only
        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(UnitDataModel), "Init")]
        //static void NetzIsAll(UnitDataModel __instance, bool isSephirahChar)
        //{
        //    if (isSephirahChar || __instance.name == "Yesod")
        //    {
        //        __instance.customizeData.frontHairID = 26;
        //        __instance.customizeData.backHairID = 25;
        //        __instance.customizeData.hairColor = new Color(234, 15, 100);

        //        __instance.customizeData.eyeID = 4;
        //        __instance.customizeData.browID = 8;
        //        __instance.customizeData.mouthID = 9;

        //        __instance.customizeData.skinColor = new Color(53f, 4f, 78f);

        //        __instance.customizeData.specialCustomID = new LorId(524);

        //        __instance.giftInventory.AddGift(173);
        //        __instance.giftInventory.Equip(__instance.giftInventory.GetGifts().Find(x => x.GetGiftClassInfoId() == 173));
        //    }
        //}

        [HarmonyPostfix]
        //[HarmonyPatch(typeof(LibraryModel), "LoadFromSaveData")]
        [HarmonyPatch(typeof(GameSceneManager), "ActivateUIController")]
        static void LastPatch()
        {
            Singleton<Init>.Instance.patch();
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(LibraryModel), "CanPassiveSuccession")]
        public static bool LibraryModel_CanPassiveSuccession_Pre(ref bool __result)
        {
            __result = true;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(BookModel), "GetMaxPassiveCost")]
        static bool GetMaxPassiveCost(ref int __result)
        {
            int chapter = LibraryModel.Instance.GetChapter();
            if (chapter <= 3)
            {
                __result = 6;
                return false;
            }

            if (chapter <= 4)
            {
                __result = 8;
                return false;
            }

            if (chapter <= 5)
            {
                __result = 12;
                return false;
            }

            if (chapter <= 6)
            {
                __result = 16;
            }
            else
            {
                __result = 20;
            }

            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(DiceCardAbility_burnAll), "OnSucceedAttack")]
        static bool DiceCardAbility_burnAll_OnSucceedAttack_Pre(ref DiceCardAbility_burnAll __instance)
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(
                         (__instance.owner.faction != Faction.Player) ? Faction.Player : Faction.Enemy))
            {
                alive.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 5, __instance.owner);
            }

            __instance.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 5, __instance.owner);
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(DiceCardAbility_forbidCardAtk.BattleUnitBuf_costUp4), "GetCardCostAdder")]
        static bool DiceCardAbility_BattleUnitBuf_costUp4_forbidCardAtk_GetCardCostAdder_Pre(BattleDiceCardModel card,
            ref int __result)
        {
            if (card.GetOriginCost() >= 4)
            {
                __result = 3;
            }
            else if (card.GetOriginCost() < 4)
            {
                __result = 2;
            }

            return false;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(TextUtil), "TransformConditionKeyword")]
        static string TextUtil_TransformConditionKeyword_Pre(string text, ref string __result)
        {
            if (text == null || text == string.Empty)
            {
                __result = string.Empty;
            }

            __result = text.Replace("[", "<color=#ebeb0f>[").Replace("]", "]</color>")
                .Replace("Max HP", "<color=#96fa64>Max HP</color>").Replace("%HP", "<color=#96fa64>%HP</color>")
                .Replace("HP%", "<color=#96fa64>HP%</color>").Replace("HP", "<color=#96fa64>HP</color>")
                .Replace("Max SR", "<color=#6496fa>Max SR</color>").Replace("%SR", "<color=#6496fa>%SR</color>")
                .Replace("SR%", "<color=#6496fa>SR%</color>").Replace("SR", "<color=#6496fa>SR</color>")
                .Replace("Light", "<color=#fafaaf>Light</color>").Replace("Strength", "<color=#fa7d7d>Strength</color>")
                .Replace("Feeble", "<color=#c75050>Feeble</color>")
                .Replace("Slash Power Up", "<color=#fa7d7d>Slash Power Up</color>")
                .Replace("Pierce Power Up", "<color=#fa7d7d>Pierce Power Up</color>")
                .Replace("Blunt Power Up", "<color=#fa7d7d>Blunt Power Up</color>")
                .Replace("Endurance", "<color=#7d7dfa>Endurance</color>")
                .Replace("Disarm", "<color=#4e4ec4>Disarm</color>").Replace("Haste", "<color=#ffaf64>Haste</color>")
                .Replace("Bind", "<color=#e69646>Bind</color>").Replace("Paralysis", "<color=#efc333>Paralysis</color>")
                .Replace("Slash Damage Up", "<color=#fa3264>Slash Damage Up</color>")
                .Replace("Pierce Damage Up", "<color=#fa3264>Pierce Damage Up</color>")
                .Replace("Blunt Damage Up", "<color=#fa3264>Blunt Damage Up</color>")
                .Replace("Damage Up", "<color=#fa3264>Damage Up</color>")
                .Replace(" Stagger Damage", " <color=#e1c8af>Stagger</color> <color=#e1c8af>Damage</color>")
                .Replace(" Damage", " <color=#faafaf>Damage</color>").Replace("Tremor", "<color=#f4bb74>Tremor</color>")
                .Replace("Rupture", "<color=#16eec0>Rupture</color>").Replace("Bleed", "<color=#ce3232>Bleed</color>")
                .Replace("Burn", "<color=#ec6929>Burn</color>")
                .Replace("Ammunition", "<color=#ffbf33>Ammunition</color>")
                .Replace("Decay", "<color=#3b4b3b>Decay</color>")
                .Replace("Unlock Shards", "<color=#aebede>Unlock Shards</color>")
                .Replace("Poise", "<color=#cbd4d4>Poise</color>").Replace("Shield", "<color=#80ecec>Shield</color>")
                .Replace("Stagger Shield", "<color=#fefe5e>Stagger Shield</color>")
                .Replace("Protection", "<color=#1cf2f2>Protection</color>")
                .Replace("Stagger Protection", "<color=#f2f21a>Stagger Protection</color>")
                .Replace("Fragile", "<color=#B50050>Fragile</color>")
                .Replace("Suspectible", "<color=#bfbf00>Suspectible</color>")
                .Replace("Charge", "<color=#28F2F2>Charge</color>").Replace("Fairy", "<color=#DFFF00>Fairy</color>")
                .Replace("Target's current die cannot be recycled",
                    "<color=#C70039>Target's current die cannot be recycled</color>")
                .Replace("SP", "<color=#1ca9c9>SP</color>").Replace("Sanity", "<color=#1ca9c9>Sanity</color>")
                .Replace("Panic", "<color=#FF0000>Panic</color>")
                .Replace("{<color=#1ca9c9>Sanity</color> Cost}", "<color=#1ca9c9>[Sanity Cost]</color>")
                .Replace("{On Awakening}", "<color=#00ff00>[On Awakening]</color>")
                .Replace("{Indiscriminate}", "<color=#ff0000>[Indiscriminate]</color>")
                .Replace("{On Corrosion}", "<color=#ff00ff>[On Corrosion]</color>");
            return __result;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(KeywordUI), "Init")]
        public static bool KeywordUI_Init_Pre(string name, string desc, ref KeywordUI __instance)
        {
            __instance._desc = desc;
            if (Singleton<BattleEffectTextsXmlList>.Instance.GetEffectTextName(name) != "")
            {
                __instance._name = "<color=#6a5acd>" + name + "</color>";
            }
            else
            {
                __instance._name = "<color=#FF3333>" + name + "</color>";
            }

            __instance.KeywordNameText.text = __instance._name;
            __instance.KeywordDescText.text = __instance._desc;
            __instance.gameObject.SetActive(true);
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(KeywordListUI), "Init")]
        public static bool KeywordListUI_Init_Pre(DiceCardXmlInfo cardInfo, List<DiceBehaviour> behaviourList,
            ref KeywordListUI __instance)
        {
            string script = cardInfo.Script;
            KeywordUI[] array = __instance.keywordList;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].gameObject.SetActive(false);
            }

            int num = 0;
            __instance.keywordDict = new Dictionary<string, int>();
            foreach (string text in cardInfo.Keywords)
            {
                string effectTextName = Singleton<BattleEffectTextsXmlList>.Instance.GetEffectTextName(text);
                if (effectTextName != "")
                {
                    __instance.keywordDict.Add(text, 1);
                    __instance.keywordList[num].Init("<color=#6a5acd>" + effectTextName + "</color>",
                        Singleton<BattleEffectTextsXmlList>.Instance.GetEffectTextDesc(text));
                    num++;
                }
            }

            List<string> abilityKeywords =
                Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords(cardInfo);
            for (int j = 0; j < abilityKeywords.Count; j++)
            {
                if (j >= __instance.keywordList.Length)
                {
                    UnityEngine.Debug.LogError("Keywordcount over" + j);
                }
                else if (Singleton<BattleEffectTextsXmlList>.Instance.GetEffectTextName(abilityKeywords[j]) != "" &&
                         !__instance.keywordDict.ContainsKey(abilityKeywords[j]))
                {
                    __instance.keywordDict.Add(abilityKeywords[j], 1);
                    __instance.keywordList[num].Init(string.Concat(new string[]
                    {
                        "<color=#FF3333><color=#FF3333>",
                        Singleton<BattleEffectTextsXmlList>.Instance.GetEffectTextName(abilityKeywords[j]),
                        "</color>"
                    }), Singleton<BattleEffectTextsXmlList>.Instance.GetEffectTextDesc(abilityKeywords[j]));
                    num++;
                }
            }

            foreach (DiceBehaviour diceBehaviour in behaviourList)
            {
                List<string> abilityKeywords_byScript =
                    Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords_byScript(diceBehaviour.Script);
                for (int k = 0; k < abilityKeywords_byScript.Count; k++)
                {
                    if (k >= __instance.keywordList.Length)
                    {
                        UnityEngine.Debug.LogError("Keywordcount over" + k);
                    }
                    else
                    {
                        if (num >= __instance.keywordList.Length ||
                            Singleton<BattleEffectTextsXmlList>.Instance
                                .GetEffectTextDesc(abilityKeywords_byScript[k]) == "")
                        {
                            break;
                        }

                        if (!__instance.keywordDict.ContainsKey(abilityKeywords_byScript[k]) &&
                            Singleton<BattleEffectTextsXmlList>.Instance
                                .GetEffectTextName(abilityKeywords_byScript[k]) != "")
                        {
                            __instance.keywordDict.Add(abilityKeywords_byScript[k], 1);
                            __instance.keywordList[num].Init(string.Concat(new string[]
                                {
                                    "<color=#FF3333>",
                                    Singleton<BattleEffectTextsXmlList>.Instance.GetEffectTextName(
                                        abilityKeywords_byScript[k]),
                                    "</color>"
                                }),
                                Singleton<BattleEffectTextsXmlList>.Instance
                                    .GetEffectTextDesc(abilityKeywords_byScript[k]));
                            num++;
                        }
                    }
                }
            }

            if (__instance.isBattleHandUI)
            {
                Vector3 localPosition = __instance.transform.localPosition;
                if ((float)num >= __instance.ChangeNumber)
                {
                    if (localPosition.y != __instance.CHANGE_Height)
                    {
                        localPosition.y = __instance.CHANGE_Height;
                        __instance.transform.localPosition = localPosition;
                        return false;
                    }
                }
                else if (localPosition.y != 0f)
                {
                    localPosition.y = 0f;
                    __instance.transform.localPosition = localPosition;
                }
            }

            return false;
        }
    }
}
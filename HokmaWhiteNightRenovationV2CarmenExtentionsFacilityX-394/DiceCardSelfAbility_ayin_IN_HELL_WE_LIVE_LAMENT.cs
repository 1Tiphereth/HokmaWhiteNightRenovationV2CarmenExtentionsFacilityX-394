using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_IN_HELL_WE_LIVE_LAMENT : DiceCardSelfAbilityBase
    {
        public class BattleUnitBuf_Lament_Sync : BattleUnitBuf
        {
            private bool _init;

            private bool _mapRemoved;

            private string _mapName = "Butterfly";

            public override bool isAssimilation => true;

            public override void OnRoundStart()
            {
                _owner.allyCardDetail.DrawCards(3);
                _owner.cardSlotDetail.RecoverPlayPoint(6);
                if (!_init)
                {
                    _init = true;
                    _owner.passiveDetail.AddPassive(new PassiveAbility_Lament_SP());
                    string ids = HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.GetOwnId(_owner);
                    HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.UpdateSP(ids, -45);
                    List<LorId> list = new List<LorId>();
                    list.Add(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 902201));
                    list.Add(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 902202));
                    list.Add(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 902203));
                    list.Add(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 902204));
                    list.Add(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 902211));
                    list.Add(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 902212));
                    list.Add(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 902201));
                    _owner.personalEgoDetail.AddCard(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 910014));
                    _owner.ChangeTemporaryDeck(list, 7);
                    //_owner.allyCardDetail.AddNewCard(920001);
                    _owner.view.ChangeEgoSkin("EGO_Butterfly", bookNameChange: false);
                    _owner.view.StartEgoSkinChangeEffect("Character");
                    Singleton<StageController>.Instance.AddEgoMapByAssimilation(_mapName);
                    _owner.cardSlotDetail.SetDefaultRecoverPoint(2);
                }
            }

            public void EndSynchronize()
            {
                _owner.view.ResetSkin();
                _owner.ReturnToOriginalDeck();
                _owner.view.StartEgoSkinChangeEffect("Character");
                RemoveMap();
                Destroy();
            }

            private void RemoveMap()
            {
                if (!_mapRemoved)
                {
                    Singleton<StageController>.Instance.RemoveEgoMapByAssimilation(_mapName);
                    _mapRemoved = true;
                }
            }

            public override void OnDie()
            {
                base.OnDie();
                RemoveMap();
            }
        }

        public override string[] Keywords => new string[1] { "ego_Keyword" };

        public override void OnUseCard()
        {
            if (!base.owner.bufListDetail.HasAssimilation())
            {
                base.owner.bufListDetail.AddBuf(new BattleUnitBuf_Lament_Sync());
            }
        }

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            if (owner.bufListDetail.HasAssimilation())
            {
                return false;
            }
            return base.OnChooseCard(owner);
        }
    }
}

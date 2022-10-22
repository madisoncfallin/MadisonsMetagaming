using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using MadisonsMetagaming.Components;
using System.Collections.Generic;
using System.Linq;

namespace MadisonsMetagaming.Feats
{
    public class FatesFavored
    {
        private static readonly string FeatName = "FavoredOfTheGods";
        private static readonly string FeatGuid = "ed2f5650-9212-48c4-8b50-3d338e4e510d";

        private static readonly string DisplayName = "FavoredOfTheGods.Name";
        private static readonly string Description = "FavoredOfTheGods.Description";

        private static readonly LogWrapper Logger = LogWrapper.Get("MadisonsMetagaming");

        public static void Configure()
        {
            Logger.Info($"Configuring {FeatName}");

            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Trait)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddBackgroundClassSkill(StatType.SkillUseMagicDevice)
                .AddComponent<IncreaseTypedBonusToAC>()
                .Configure();
        }
    }
}

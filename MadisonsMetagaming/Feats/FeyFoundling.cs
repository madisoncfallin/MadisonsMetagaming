using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using MadisonsMetagaming.Components;

namespace MadisonsMetagaming.Feats
{
    public class FeyFoundling
    {
        private static readonly string FeatName = "FeyFoundling";
        private static readonly string FeatGuid = "856bcd33-3745-4453-967a-4cffa2d4eb49";

        private static readonly string DisplayName = "FeyFoundlingFeat.Name";
        private static readonly string Description = "FeyFoundlingFeat.Description";

        private static readonly LogWrapper Logger = LogWrapper.Get("MadisonsMetagaming");

        public static void Configure()
        {
            Logger.Info($"Configuring {FeatName}");

            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
              .SetDisplayName(DisplayName)
              .SetDescription(Description)
              .AddPrerequisiteCharacterLevel(1)
              .AddComponent<BonusHealingPerDie>()
              .AddSavingThrowBonusAgainstDescriptor(bonus: 2, spellDescriptor: SpellDescriptor.Death)
              .AddComponent<IncreaseWeaponDamageTakenFromColdIron>()
              .Configure();
        }
    }
}

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Linq;

namespace MadisonsMetagaming.Components
{
    [AllowMultipleComponents]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("29f8c7801a6b4ff8b057decf99a5c52d")]
    public class IncreaseWeaponDamageTakenFromColdIron :
        UnitBuffComponentDelegate, 
        ITargetRulebookHandler<RuleCalculateDamage>, 
        IRulebookHandler<RuleCalculateDamage>, 
        ISubscriber, 
        ITargetRulebookSubscriber
    {
        private static readonly LogWrapper Logger = LogWrapper.Get("MadisonsMetagaming");

        public void OnEventAboutToTrigger(RuleCalculateDamage evt)
        {
            try
            {
                if (evt.GetRuleTarget().Equals(base.Owner))
                {
                    BaseDamage first = evt.DamageBundle.First;
                    if (first == null)
                    {
                        return;
                    }

                    if (evt.DamageBundle.Weapon != null)
                    {
                        foreach (BaseDamage baseDamage in evt.DamageBundle)
                        {
                            if (baseDamage is PhysicalDamage && (baseDamage as PhysicalDamage).Materials.Contains(PhysicalDamageMaterial.ColdIron))
                            {
                                baseDamage.AddModifierTargetRelated(1, base.Fact);
                            }
                        }
                    }
                }
                else
                {
                }

            }
            catch (Exception ex)
            {
                Logger.Error($"Caught exception in OnEventAboutToTrigger", ex);
            }
        }

        public void OnEventDidTrigger(RuleCalculateDamage evt)
        {
        }

        public ContextValue Value;
    }
}

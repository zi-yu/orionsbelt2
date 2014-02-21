using System;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using DesignPatterns;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.Alliances;
using Loki.DataRepresentation;

namespace OrionsBelt.Engine.Common {

    /// <summary>
    /// Represents a player wanting to join an alliance
    /// </summary>
    public class AllianceSubscription : InteractionType {

        #region IInteractionType Members

        public override InteractionContext Context {
            get { return InteractionContext.Alliance; }
        }

        public override void Prepare(Interaction interaction, IEntity source, IEntity target)
        {
            base.Prepare(interaction, source, target);
            interaction.SourceAditionalData = ((PlayerStorage)source).Name;
            interaction.TargetAditionalData = ((AllianceStorage)target).Name;
        }

        public override void Process(Interaction interaction, IEntity state)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance())
            {
                interaction.Resolved = true;
                if (interaction.Response) {
                    AllianceStorage storage = state as AllianceStorage;
                    if (storage == null) {
                        throw new EngineException("Expecting alliance state");
                    }
                    IAlliance alliance = AllianceManager.PrepareAlliance(storage);
                    IPlayer player = PlayerUtils.GetPlayerById(interaction.Source);
                    AllianceManager.AddPlayerToAlliance(alliance, player);
                }
                persistance.Update(interaction);
            }
        }

        public override string TranslateForSource(Interaction interaction)
        {
            string token = LanguageManager.Instance.Get("AllianceSubscriptionForSource");
            return string.Format(token, interaction.Source, interaction.SourceAditionalData, interaction.Target, interaction.TargetAditionalData);
        }

        public override string TranslateForTarget(Interaction interaction)
        {
            string token = LanguageManager.Instance.Get("AllianceSubscriptionForTarget");
            return string.Format(token, interaction.Source, interaction.SourceAditionalData, interaction.Target, interaction.TargetAditionalData);
        }

        #endregion

    };

}

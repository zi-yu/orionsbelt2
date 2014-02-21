using System;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using DesignPatterns;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.Alliances;
using Loki.DataRepresentation;
using OrionsBelt.Engine.Exceptions;

namespace OrionsBelt.Engine.Common {

    /// <summary>
    /// Represents a player wanting to join an alliance
    /// </summary>
    public class TeamInvitation : InteractionType
    {

        #region IInteractionType Members



        public override InteractionContext Context {
            get { return InteractionContext.Team; }
        }

        public override void Prepare(Interaction interaction, IEntity source, IEntity target)
        {
            base.Prepare(interaction, source, target);
            interaction.SourceAditionalData = ((Principal)source).Name;
            interaction.TargetAditionalData = ((Principal)target).Name;
        }

        public override void Process(Interaction interaction, IEntity state)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance())
            {
                interaction.Resolved = true;
                if (interaction.Response) {
                    using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                    {
                        Principal pSource = persistance2.SelectById(interaction.Source)[0];

                        if (pSource.Team == null)
                        {
                            persistance.Update(interaction);
                            throw new TeamException("NoTeam");
                        }

                        if(pSource.Team.IsComplete)
                        {
                            persistance.Update(interaction);
                            throw new TeamException("TeamCompleted");
                        }

                        Principal pTarget = persistance2.SelectById(interaction.Target)[0];

                        if (pTarget.Team != null)
                        {
                            persistance.Update(interaction);
                            throw new TeamException("AlreadyHaveTeam");
                        }

                        pTarget.Team = pSource.Team;
                        persistance2.Update(pTarget);
                        using (ITeamStoragePersistance persistance3 = Persistance.Instance.GetTeamStoragePersistance(persistance2))
                        {
                            pSource.Team.IsComplete = true;
                            persistance3.Update(pSource.Team);
                        }
                    }
                }
                persistance.Update(interaction);
            }
        }

        public override string TranslateForSource(Interaction interaction)
        {
            return string.Empty;
            //string token = LanguageManager.Instance.Get("TeamInvitationForSource");
            //return string.Format(token, interaction.Source, interaction.SourceAditionalData, interaction.Target, interaction.TargetAditionalData);
        }

        public override string TranslateForTarget(Interaction interaction)
        {
            string token = LanguageManager.Instance.Get("TeamInvitationForTarget");
            return string.Format(token, interaction.Source, interaction.SourceAditionalData);
        }

        #endregion

    };

}

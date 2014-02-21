using System;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using DesignPatterns;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.Engine.Common {

    /// <summary>
    /// Represents a tyoe of interaction between two entities
    /// </summary>
    public abstract class InteractionType : IInteractionType, IFactory {

        #region IInteractionType Members

        public string Name {
            get { return GetType().Name; }
        }

        public abstract InteractionContext Context { get; }

        public abstract void Process(Interaction interaction, IEntity state);

        public abstract string TranslateForSource(Interaction interaction);

        public abstract string TranslateForTarget(Interaction interaction);

        public virtual void Prepare(Interaction interaction, IEntity source, IEntity target)
        {
            interaction.InteractionContext = Context.ToString();
            interaction.Type = Name;

            if (source is IEntity) {
                IEntity entity = (IEntity)source;
                interaction.Source = entity.Id;
                interaction.SourceType = entity.TypeName;
            }
            if (target is IEntity) {
                IEntity entity = (IEntity)target;
                interaction.Target = entity.Id;
                interaction.TargetType = entity.TypeName;
            }
        }

        public bool IsTarget(Interaction interaction, IEntity entity)
        {
            if (entity == null) {
                return false;
            }
            return entity.Id == interaction.Target && entity.TypeName == interaction.TargetType;
        }

        public static void ResolveSuccess(Interaction interaction, IEntity state)
        {
            interaction.Response = true;
            Resolve(interaction, state);
        }

        public static void ResolveFail(Interaction interaction, IEntity state)
        {
            interaction.Response = false;
            Resolve(interaction, state);
        }

        public static void Resolve(Interaction interaction, IEntity state)
        {
            IInteractionType type = Get(interaction);
            type.Process(interaction, state);
            Persistance.Flush();
        }

        #endregion

        #region Static Access

        private static FactoryContainer factories = new FactoryContainer(typeof(InteractionType));

        public static IInteractionType Get(Interaction interaction)
        {
            return Get(interaction.Type);
        }

        public static IInteractionType Get(string name)
        {
            return (IInteractionType)factories.create(name);
        }

        #endregion Static Access

        #region IFactory Members

        public object create(object args)
        {
            return this;
        }

        #endregion

    };

}

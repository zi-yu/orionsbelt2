using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using Loki.DataRepresentation;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents an entity that supports interaction between other entities
    /// </summary>
    public interface IInteractionType {

        /// <summary>
        /// The name
        /// </summary>
        string Name { get;}

        /// <summary>
        /// The context of this interaction
        /// </summary>
        InteractionContext Context { get;}

        /// <summary>
        /// Prepares the given interaction for this interaction type
        /// </summary>
        /// <param name="interaction">The interaction</param>
        /// <param name="source">The source object</param>
        /// <param name="target">The target object</param>
        void Prepare(Interaction interaction, IEntity source, IEntity target);

        /// <summary>
        /// Processes the interaction response
        /// </summary>
        /// <param name="interaction">The original interaction</param>
        /// <param name="state">Context state</param>
        void Process(Interaction interaction, IEntity state);

        /// <summary>
        /// Translates the given interaction for the source
        /// </summary>
        /// <param name="interaction">The interaction</param>
        /// <returns>The text represenation</returns>
        string TranslateForSource(Interaction interaction);

        /// <summary>
        /// Translates the given interaction for the target
        /// </summary>
        /// <param name="interaction">The interaction</param>
        /// <returns>The translation</returns>
        string TranslateForTarget(Interaction interaction);

        /// <summary>
        /// Checks if the given entity is the target of this interaction
        /// </summary>
        /// <param name="interaction">The interaction</param>
        /// <param name="target">the target</param>
        /// <returns>Turue if the entity is the target</returns>
        bool IsTarget(Interaction interaction, IEntity target);
    };
}

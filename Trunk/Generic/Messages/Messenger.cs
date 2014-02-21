using System;
using System.Collections.Generic;
using System.Reflection;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Text;
using DesignPatterns;
using Loki.DataRepresentation;
using System.Collections;

namespace OrionsBelt.Generic.Messages {

    /// <summary>
    /// Sends text messages to entities of the game
    /// </summary>
	public class Messenger {

		#region Fields

		private readonly static FactoryContainer messageFactories = new FactoryContainer(typeof(MessageBase));
		private static readonly char[] separator = new char[]{';'};

        public static ICollection AllMessages {
            get { return messageFactories.Values; }
        }

		#endregion Fields

		#region Private

		/// <summary>
		/// Converts to the Database format
		/// </summary>
		/// <param name="parameters">Parameters to convert</param>
		/// <returns>The parameters, comma separated</returns>
		private static string ConvertToDBFormat( List<string> parameters ) {
			StringBuilder builder = new StringBuilder();
			foreach( string s in parameters ) {
				builder.AppendFormat("{0};", s);
			}
			return builder.ToString();
		}

		/// <summary>
		/// Converts to object format
		/// </summary>
		/// <param name="parameters">Parameters to convert</param>
		/// <returns>The parameters, comma separated</returns>
		private static List<string> ConvertToObjectFormat( string parameters ) {
			return new List<string>(parameters.Split(separator,StringSplitOptions.RemoveEmptyEntries));
		}

		/// <summary>
		/// Converts a Message (DB format) into a IMessage (Core format)
		/// </summary>
		/// <param name="m">Message object</param>
		/// <returns>Core message format</returns>
		public static IMessage ConvertMessage( Message m ) {
			IMessage iMessage = (IMessage) messageFactories.create(m.SubCategory, m);

			iMessage.Date = m.Date;
			iMessage.Parameters = ConvertToObjectFormat(m.Parameters);
			iMessage.OwnerId = m.OwnerId;
			iMessage.Extended = m.Extended;
            iMessage.TickDeadline = m.TickDeadline;

			return iMessage;
		}

		private static List<IMessage> GenericGetAllMessages( Category category, int ownerId, string order ) {

            IList<Message> messages = Hql.Query<Message>(
                    string.Format("from SpecializedMessage e where e.OwnerId = :ownerId and e.Category = :category order by e.id {0}", order),
                    Hql.Param("ownerId", ownerId),
                    Hql.Param("category", category.ToString())
                );

            return ConvertMessages(messages);
		}

        private static List<IMessage> GenericGetByCategory( Category category, string order ) {
			
            IList<Message> messages = Hql.Query<Message>(
                    string.Format("from SpecializedMessage e where e.Category = :category order by e.id {0}", order),
                    Hql.Param("category", category.ToString())
                );

            return ConvertMessages(messages);
		}

        public static List<IMessage> ConvertMessages(IList<Message> messages)
        {
            List<IMessage> convertedMessages = new List<IMessage>();
            foreach (Message m in messages) {
                convertedMessages.Add(ConvertMessage(m));
            }
            return convertedMessages;
        }

		private static List<IMessage> GenericGetMessages( Category category, int ownerId, string order, int limit ) {

            IList<Message> messages = Hql.Query<Message>(
                    0, limit,
                    string.Format("from SpecializedMessage e where e.OwnerId = :ownerId and e.Category = :category order by e.id {0}", order),
                    Hql.GetParams(
                        Hql.Param("ownerId", ownerId),
                        Hql.Param("category", category.ToString())
                    )
                );
            return ConvertMessages(messages);
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Adds a new message to the Database
		/// </summary>
		/// <param name="category">Category of the message</param>
		/// <param name="subCategory">Sub category of the message</param>
		/// <param name="parameters">Parameters of the message</param>
		/// <param name="ownerId">Id of Owner of the message</param>
		public static void Add( Category category, string subCategory, List<string> parameters, int ownerId, string extended ) {
			using( IMessagePersistance persistance = Persistance.Instance.GetMessagePersistance() ) {
				Message message = persistance.Create();
				message.Category = category.ToString();
				message.SubCategory = subCategory;
				message.Parameters = ConvertToDBFormat(parameters);
				message.OwnerId = ownerId;
				message.Extended = extended;

                Type tp = Type.GetType(string.Format("OrionsBelt.Generic.Messages.{0}", subCategory));
                Object o = Activator.CreateInstance(tp);
                message.TickDeadline = (int)o.GetType().GetProperty("TickDeadline").GetValue(o, null);
				persistance.Update(message);
			}
		}
        /// <summary>
        /// Adds a new message to the database
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="subCategory">The subcategory</param>
        /// <param name="ownerId">The owner</param>
        /// <param name="flush">Flush</param>
        /// <param name="args">Arguments</param>
        public static void Add(bool flush, Category category, Type subCategory, int ownerId, params string[] args)
        {
            using (IMessagePersistance persistance = Persistance.Instance.GetMessagePersistance())
            {
                Add(category, subCategory.Name, new List<string>(args), ownerId, null);
                if (flush)
                {
                    persistance.Flush();
                }
            }
            
        }

        /// <summary>
        /// Adds a new message to the database
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="subCategory">The subcategory</param>
        /// <param name="ownerId">The owner</param>
        /// <param name="args">Arguments</param>
        public static void Add(Category category, Type subCategory, int ownerId, params string[] args)
        {
            Add(category, subCategory.Name, new List<string>(args), ownerId, null);
        }

		/// <summary>
		/// Adds a new message to the Database
		/// </summary>
		/// <param name="msg">Object that represents the message</param>
		public static void Add( IMessage msg, bool flush ) {
			using( IMessagePersistance persistance = Persistance.Instance.GetMessagePersistance() ) {
                Add(msg, persistance);
				if(flush){
					persistance.Flush();
				}
			}
		}

		/// <summary>
		/// Adds a new message to the Database
		/// </summary>
		/// <param name="msg">Object that represents the message</param>
		public static void Add(IMessage msg) {
			Add(msg,false);
		}

		public static void Add(IMessage msg, IPersistanceSession session)
        {
            using (IMessagePersistance persistance = Persistance.Instance.GetMessagePersistance(session))
            {
                Message message = persistance.Create();

                message.Category = msg.Category.ToString();
                message.SubCategory = msg.SubCategory;
                message.Parameters = ConvertToDBFormat(msg.Parameters);
                message.OwnerId = msg.OwnerId;
                message.Extended = msg.Extended;
                message.TickDeadline = msg.TickDeadline;

                persistance.Update(message);
            }
        }

		/// <summary>
		/// Gets the Messages of the passed category
		/// </summary>
		/// <param name="category">Category of messages</param>
		/// <param name="ownerId">Id of</param>
		/// <returns>A List with the messages of the category</returns>
		public static List<IMessage> GetMessages( Category category, int ownerId ) {
			return GenericGetMessages(category, ownerId, "desc", 10);
		}

		/// <summary>
		/// Gets the Messages of the passed category
		/// </summary>
		/// <param name="category">Category of messages</param>
		/// <param name="ownerId">Id of</param>
		/// <returns>A List with the messages of the category</returns>
		public static List<IMessage> GetMessagesInverted( Category category, int ownerId ) {
			return GenericGetMessages(category, ownerId, "asc", 10);
		}

		/// <summary>
		/// Gets the Messages of the passed category
		/// </summary>
		/// <param name="category">Category of messages</param>
		/// <param name="ownerId">Id of</param>
		/// <returns>A List with the messages of the category</returns>
		public static List<IMessage> GetAllMessages( Category category, int ownerId ) {
			return GenericGetAllMessages(category, ownerId, "desc");
		}

		/// <summary>
		/// Gets the Messages of the passed category
		/// </summary>
		/// <param name="category">Category of messages</param>
		/// <param name="ownerId">Id of</param>
		/// <returns>A List with the messages of the category</returns>
		public static List<IMessage> GetAllMessagesInverted( Category category, int ownerId ) {
			return GenericGetAllMessages(category, ownerId, "asc");
		}

        public static List<IMessage> GetMessagesByCategory(Category category)
        {
            return GenericGetByCategory(category, "desc");
        }

		#endregion Public

    };
}

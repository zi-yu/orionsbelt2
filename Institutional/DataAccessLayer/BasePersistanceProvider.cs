using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Provides persistance objects
    /// </summary>
    public abstract class BasePersistanceProvider : IPersistanceProvider {

        #region Generic

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <returns>The persistance object</returns>
        public virtual IPersistanceSession GetGenericPersistance()
        {
			return GetPrincipalPersistance();
        }

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance object</returns>
        public IPersistanceSession GetGenericPersistance( IPersistanceSession owner )
        {
			return GetPrincipalPersistance(owner);
        }
        
        /// <summary>
        /// Gets a persistance for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <returns>The persistance implementation</returns>
        public IPersistanceSession GetPersistance(Type type)
        {
            try {
                string methodName = string.Format("Get{0}Persistance", type.Name);
                MethodInfo method = GetType().GetMethod(methodName, new Type[0]);
                return (IPersistanceSession)method.Invoke(this, null);
            } catch( Exception ex ) {
                throw new DALException("Error getting IPersistance<{0}>", ex, type.Name);
            }
        }
        
        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <returns>The persistance</returns>
        public IPersistance<T> GetPersistance<T>()
        {
            return (IPersistance<T>)GetPersistance(typeof(T));
        }

        /// <summary>
        /// Gets a persistance implementation for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance session</returns>
        public IPersistanceSession GetPersistance(Type type, IPersistanceSession owner)
        {
            try {
                string methodName = string.Format("Get{0}Persistance", type.Name);
                MethodInfo method = GetType().GetMethod(methodName, new Type[] { typeof(IPersistanceSession) });
                return (IPersistanceSession)method.Invoke(this, new object[] { owner });
            } catch( Exception ex ) {
                throw new DALException("Error getting IPersistance<{0}>", ex, type.Name);
            }
        }

        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <param name="owner">The owner</param>
        /// <returns>The persistance</returns>
        public IPersistance<T> GetPersistance<T>(IPersistanceSession owner)
        {
            return (IPersistance<T>) GetPersistance(typeof(T), owner);
        }
        
        #endregion Generic

        #region Referral Persistance

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        public abstract IReferralPersistance GetReferralPersistance ();
        
        /// <summary>
        /// Gets a fresh Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        public abstract IReferralPersistance OpenReferralPersistance ();

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Referral persistance</returns>
        public abstract IReferralPersistance GetReferralPersistance ( IPersistanceSession owner );

        #endregion Referral Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public abstract IPrincipalPersistance GetPrincipalPersistance ();
        
        /// <summary>
        /// Gets a fresh Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public abstract IPrincipalPersistance OpenPrincipalPersistance ();

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        public abstract IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner );

        #endregion Principal Persistance
        
        #region Testimonial Persistance

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        public abstract ITestimonialPersistance GetTestimonialPersistance ();
        
        /// <summary>
        /// Gets a fresh Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        public abstract ITestimonialPersistance OpenTestimonialPersistance ();

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Testimonial persistance</returns>
        public abstract ITestimonialPersistance GetTestimonialPersistance ( IPersistanceSession owner );

        #endregion Testimonial Persistance
        
        #region Server Persistance

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        public abstract IServerPersistance GetServerPersistance ();
        
        /// <summary>
        /// Gets a fresh Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        public abstract IServerPersistance OpenServerPersistance ();

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Server persistance</returns>
        public abstract IServerPersistance GetServerPersistance ( IPersistanceSession owner );

        #endregion Server Persistance
        
        #region MediaArticle Persistance

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        public abstract IMediaArticlePersistance GetMediaArticlePersistance ();
        
        /// <summary>
        /// Gets a fresh MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        public abstract IMediaArticlePersistance OpenMediaArticlePersistance ();

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The MediaArticle persistance</returns>
        public abstract IMediaArticlePersistance GetMediaArticlePersistance ( IPersistanceSession owner );

        #endregion MediaArticle Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public abstract IExceptionInfoPersistance GetExceptionInfoPersistance ();
        
        /// <summary>
        /// Gets a fresh ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public abstract IExceptionInfoPersistance OpenExceptionInfoPersistance ();

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        public abstract IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner );

        #endregion ExceptionInfo Persistance
        
    };
}


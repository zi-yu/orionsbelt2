using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Provides persistance objects
    /// </summary>
    public interface IPersistanceProvider {

        #region Generic

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <returns>The persistance object</returns>
        IPersistanceSession GetGenericPersistance();

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance object</returns>
        IPersistanceSession GetGenericPersistance( IPersistanceSession owner );
        
        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <returns>The persistance</returns>
        IPersistance<T> GetPersistance<T>();

        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <param name="owner">The owner</param>
        /// <returns>The persistance</returns>
        IPersistance<T> GetPersistance<T>(IPersistanceSession owner);
        
        /// <summary>
        /// Gets a persistance implementation for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance session</returns>
        IPersistanceSession GetPersistance(Type type, IPersistanceSession owner);
        
        /// <summary>
        /// Gets a persistance for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <returns>The persistance implementation</returns>
        IPersistanceSession GetPersistance(Type type);
        
        #endregion Generic

        #region Referral Persistance

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        IReferralPersistance GetReferralPersistance ();
        
        /// <summary>
        /// Opens a Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        IReferralPersistance OpenReferralPersistance ();

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Referral persistance</returns>
        IReferralPersistance GetReferralPersistance ( IPersistanceSession owner );

        #endregion Referral Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        IPrincipalPersistance GetPrincipalPersistance ();
        
        /// <summary>
        /// Opens a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        IPrincipalPersistance OpenPrincipalPersistance ();

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner );

        #endregion Principal Persistance
        
        #region Testimonial Persistance

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        ITestimonialPersistance GetTestimonialPersistance ();
        
        /// <summary>
        /// Opens a Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        ITestimonialPersistance OpenTestimonialPersistance ();

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Testimonial persistance</returns>
        ITestimonialPersistance GetTestimonialPersistance ( IPersistanceSession owner );

        #endregion Testimonial Persistance
        
        #region Server Persistance

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        IServerPersistance GetServerPersistance ();
        
        /// <summary>
        /// Opens a Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        IServerPersistance OpenServerPersistance ();

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Server persistance</returns>
        IServerPersistance GetServerPersistance ( IPersistanceSession owner );

        #endregion Server Persistance
        
        #region MediaArticle Persistance

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        IMediaArticlePersistance GetMediaArticlePersistance ();
        
        /// <summary>
        /// Opens a MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        IMediaArticlePersistance OpenMediaArticlePersistance ();

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The MediaArticle persistance</returns>
        IMediaArticlePersistance GetMediaArticlePersistance ( IPersistanceSession owner );

        #endregion MediaArticle Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        IExceptionInfoPersistance GetExceptionInfoPersistance ();
        
        /// <summary>
        /// Opens a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        IExceptionInfoPersistance OpenExceptionInfoPersistance ();

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner );

        #endregion ExceptionInfo Persistance
        
    };
}


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
    public class NHibernateProvider : BasePersistanceProvider {

        #region Referral Persistance

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        public override IReferralPersistance GetReferralPersistance ()
        {
			return ReferralPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        public override IReferralPersistance OpenReferralPersistance ()
        {
			return ReferralPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Referral persistance</returns>
        public override IReferralPersistance GetReferralPersistance ( IPersistanceSession owner )
        {
			return ReferralPersistance.AttachSession (owner);
        }

        #endregion Referral Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ()
        {
			return PrincipalPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance OpenPrincipalPersistance ()
        {
			return PrincipalPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner )
        {
			return PrincipalPersistance.AttachSession (owner);
        }

        #endregion Principal Persistance
        
        #region Testimonial Persistance

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        public override ITestimonialPersistance GetTestimonialPersistance ()
        {
			return TestimonialPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        public override ITestimonialPersistance OpenTestimonialPersistance ()
        {
			return TestimonialPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Testimonial persistance</returns>
        public override ITestimonialPersistance GetTestimonialPersistance ( IPersistanceSession owner )
        {
			return TestimonialPersistance.AttachSession (owner);
        }

        #endregion Testimonial Persistance
        
        #region Server Persistance

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        public override IServerPersistance GetServerPersistance ()
        {
			return ServerPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        public override IServerPersistance OpenServerPersistance ()
        {
			return ServerPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Server persistance</returns>
        public override IServerPersistance GetServerPersistance ( IPersistanceSession owner )
        {
			return ServerPersistance.AttachSession (owner);
        }

        #endregion Server Persistance
        
        #region MediaArticle Persistance

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        public override IMediaArticlePersistance GetMediaArticlePersistance ()
        {
			return MediaArticlePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        public override IMediaArticlePersistance OpenMediaArticlePersistance ()
        {
			return MediaArticlePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The MediaArticle persistance</returns>
        public override IMediaArticlePersistance GetMediaArticlePersistance ( IPersistanceSession owner )
        {
			return MediaArticlePersistance.AttachSession (owner);
        }

        #endregion MediaArticle Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ()
        {
			return ExceptionInfoPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance OpenExceptionInfoPersistance ()
        {
			return ExceptionInfoPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner )
        {
			return ExceptionInfoPersistance.AttachSession (owner);
        }

        #endregion ExceptionInfo Persistance
        
    };
}


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
    public class MemoryProvider : BasePersistanceProvider {

        #region Server Persistance

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        public override IServerPersistance GetServerPersistance ()
        {
			return new MemoryServerPersistance ();
        }
        
        /// <summary>
        /// Opens a Server persistance
        /// </summary>
        /// <returns>The Server persistance</returns>
        public override IServerPersistance OpenServerPersistance ()
        {
			return new MemoryServerPersistance ();
        }

        /// <summary>
        /// Gets a Server persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Server persistance</returns>
        public override IServerPersistance GetServerPersistance ( IPersistanceSession owner )
        {
			return new MemoryServerPersistance ();
        }

        #endregion Server Persistance
        
        #region MediaArticle Persistance

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        public override IMediaArticlePersistance GetMediaArticlePersistance ()
        {
			return new MemoryMediaArticlePersistance ();
        }
        
        /// <summary>
        /// Opens a MediaArticle persistance
        /// </summary>
        /// <returns>The MediaArticle persistance</returns>
        public override IMediaArticlePersistance OpenMediaArticlePersistance ()
        {
			return new MemoryMediaArticlePersistance ();
        }

        /// <summary>
        /// Gets a MediaArticle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The MediaArticle persistance</returns>
        public override IMediaArticlePersistance GetMediaArticlePersistance ( IPersistanceSession owner )
        {
			return new MemoryMediaArticlePersistance ();
        }

        #endregion MediaArticle Persistance
        
        #region Testimonial Persistance

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        public override ITestimonialPersistance GetTestimonialPersistance ()
        {
			return new MemoryTestimonialPersistance ();
        }
        
        /// <summary>
        /// Opens a Testimonial persistance
        /// </summary>
        /// <returns>The Testimonial persistance</returns>
        public override ITestimonialPersistance OpenTestimonialPersistance ()
        {
			return new MemoryTestimonialPersistance ();
        }

        /// <summary>
        /// Gets a Testimonial persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Testimonial persistance</returns>
        public override ITestimonialPersistance GetTestimonialPersistance ( IPersistanceSession owner )
        {
			return new MemoryTestimonialPersistance ();
        }

        #endregion Testimonial Persistance
        
        #region Referral Persistance

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        public override IReferralPersistance GetReferralPersistance ()
        {
			return new MemoryReferralPersistance ();
        }
        
        /// <summary>
        /// Opens a Referral persistance
        /// </summary>
        /// <returns>The Referral persistance</returns>
        public override IReferralPersistance OpenReferralPersistance ()
        {
			return new MemoryReferralPersistance ();
        }

        /// <summary>
        /// Gets a Referral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Referral persistance</returns>
        public override IReferralPersistance GetReferralPersistance ( IPersistanceSession owner )
        {
			return new MemoryReferralPersistance ();
        }

        #endregion Referral Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ()
        {
			return new MemoryPrincipalPersistance ();
        }
        
        /// <summary>
        /// Opens a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance OpenPrincipalPersistance ()
        {
			return new MemoryPrincipalPersistance ();
        }

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner )
        {
			return new MemoryPrincipalPersistance ();
        }

        #endregion Principal Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ()
        {
			return new MemoryExceptionInfoPersistance ();
        }
        
        /// <summary>
        /// Opens a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance OpenExceptionInfoPersistance ()
        {
			return new MemoryExceptionInfoPersistance ();
        }

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner )
        {
			return new MemoryExceptionInfoPersistance ();
        }

        #endregion ExceptionInfo Persistance
        
    };
}



using System;
using System.Web.UI;
using System.ComponentModel;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Testimonial control renderer
    /// </summary>
	public class TestimonialItem : BaseEntityItem<Testimonial> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TestimonialItem () : base( Institutional.DataAccessLayer.Persistance.Instance.GetTestimonialPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Testimonial> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TestimonialId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Locale</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TestimonialLocale () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Content</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TestimonialContent () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Author</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TestimonialAuthor () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TestimonialCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TestimonialUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TestimonialLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Testimonial> Implementation
		
	};

}

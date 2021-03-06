﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Collections;

namespace Institutional.WebAdmin.Admin.Controls {
	public class StateManager : Control {
	
		#region Fields

		public enum StateItem { Application = 1, Session = 2, Cache = 3, Items = 4 }

		private StateItem stateItem = StateItem.Application;
		private string image = "Images/remove.gif";
		
		#endregion

		#region Properties

		public StateItem State {
			get { return stateItem; }
			set { stateItem = value; }
		}
	
		#endregion

		#region Private

		private void WriteStateItem( HtmlTextWriter writer ) {
			switch( stateItem ) {
				case StateItem.Application:
					WriteApplication( writer );
					break;
				case StateItem.Session:
					WriteSession( writer );
					break;
				case StateItem.Cache: 
					WriteCache( writer );
					break;	
				case StateItem.Items: 
					WriteItems( writer );
					break;		
				
			}
		}

		private void WriteTitle( HtmlTextWriter writer ) {
			writer.WriteLine( "<tr><th>Key</th><th>Value</th><th>Remove</th></tr>" );
		}

		private void WriteItem( HtmlTextWriter writer, string key, string value, int type ) {
			if( value == string.Empty ) {
				value = "&nbsp;";
			}
			writer.WriteLine( "<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key, value, GetJavascript(key,type) );
		}

		private object GetJavascript( string key, int type ) {
			return string.Format( "<a href='javascript:stateManagerDelete(\"{0}\",{2})'><img src='{1}' /></a></td>", key, image, type );
		}

		private void RegisterJavascript() {
			string function = @"
				<script language='javascript'>
					function stateManagerDelete(item, type) {
						var theform = document.forms[0];
						var resp = confirm('Do you really want to erase the item ' + item + '?');
						if( resp == false ) {
							return;
						}
						
						theform.stateManagerNotifier.value = 'true';
						theform.stateManagerItem.value = item;
						theform.stateManager.value = type;

						theform.submit();
					}
				</script> 
			";

			Page.ClientScript.RegisterClientScriptBlock( GetType(), "stateManager", function, false );
			Page.ClientScript.RegisterHiddenField( "stateManagerNotifier", "false" );
			Page.ClientScript.RegisterHiddenField( "stateManagerItem", "" );
			Page.ClientScript.RegisterHiddenField( "stateManager", "" );

			
		}

		private void DeleteStateItem( string key, int type ) {
			switch( (StateItem)type ) {
				case StateItem.Application:
					HttpContext.Current.Application.Remove( key );
					break;
				case StateItem.Session:
					HttpContext.Current.Session.Remove( key );
					break;
				case StateItem.Cache:
					HttpContext.Current.Cache.Remove( key );
					break;
			}
		}


		#endregion

		#region Write StateManagers

		private void WriteCache( HtmlTextWriter writer ) {
			if( HttpContext.Current.Cache.Count > 0 ) {
				writer.WriteLine( "<table id='stateManager'>" );
				WriteTitle( writer );
				foreach( DictionaryEntry item in HttpContext.Current.Cache ) {
					WriteItem( writer, item.Key.ToString(), item.Value.ToString(), 3 );
				}
				writer.WriteLine( "</table>" );
			} else {
				writer.WriteLine( "<div>Cache doesn't have any items</div>" );
			}
		}

		private void WriteApplication( HtmlTextWriter writer ) {
			if( HttpContext.Current.Application.Count > 0 ) {
				writer.WriteLine( "<table id='stateManager'>" );
				WriteTitle( writer );
				foreach( string key in HttpContext.Current.Application.AllKeys ) {
					WriteItem( writer, key, HttpContext.Current.Application[key].ToString(), 1 );
				}
				writer.WriteLine( "</table>" );
			} else {
				writer.WriteLine( "<div>Application doesn't have any items</div>" );
			}
		}

		private void WriteSession( HtmlTextWriter writer ) {
			if( HttpContext.Current.Session.Count > 0 ) {
				writer.WriteLine( "<table id='stateManager'>" );
				WriteTitle( writer );
				foreach( string key in HttpContext.Current.Session.Keys ) {
					WriteItem( writer, key, HttpContext.Current.Session[key].ToString(), 2 );
				}
				writer.WriteLine( "</table>" );
			} else {
				writer.WriteLine( "<div>Session doesn't have any items</div>" );
			}
		}

		private void WriteItems( HtmlTextWriter writer ) {
			if( HttpContext.Current.Items.Count > 0 ) {
				writer.WriteLine( "<table id='stateManager'>" );
				WriteTitle( writer );
				foreach( string key in HttpContext.Current.Items.Keys ) {
					WriteItem( writer, key, HttpContext.Current.Items[key].ToString(), 2 );
				}
				writer.WriteLine( "</table>" );
			} else {
				writer.WriteLine( "<div>Session doesn't have any items</div>" );
			}
		}

		#endregion

		#region Overriden Methods

		protected override void OnInit( EventArgs e ) {
			string notifier = Page.Request.Form["stateManagerNotifier"];

			if( !string.IsNullOrEmpty( notifier ) && notifier == "true" ) {
				string item = Page.Request.Form["stateManagerItem"];
				string state = Page.Request.Form["stateManager"];
				DeleteStateItem( item, int.Parse(state) );
			}

			RegisterJavascript();
			base.OnInit( e );
		}

		protected override void Render( HtmlTextWriter writer ) {
			WriteStateItem( writer );
			base.Render( writer );
		}
		
		#endregion


	}
}
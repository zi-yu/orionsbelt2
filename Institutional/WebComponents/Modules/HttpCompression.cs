﻿using System;
using System.Web;
using System.Web.UI;
using System.IO.Compression;

namespace Institutional.WebComponents.Modules {

	/// <summary>
	/// Compresses the output using standard gzip/deflate.
	/// </summary>
	public class CompressionModule : IHttpModule {

		#region IHttpModule Members

		void IHttpModule.Dispose() {}

		void IHttpModule.Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(context_BeginRequest);
		}
		
		#endregion

		#region Compression

		private const string GZIP = "gzip";
		private const string DEFLATE = "deflate";

		void context_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication app = sender as HttpApplication;

			if (IsEncodingAccepted(GZIP)) {
				app.Response.Filter = new GZipStream(app.Response.Filter, CompressionMode.Compress);
				SetEncoding(GZIP);
			} else if (IsEncodingAccepted(DEFLATE)) {
				app.Response.Filter = new DeflateStream(app.Response.Filter, CompressionMode.Compress);
				SetEncoding(DEFLATE);
			}
		}

		/// <summary>
		/// Checks the request headers to see if the specified
		/// encoding is accepted by the client.
		/// </summary>
		private bool IsEncodingAccepted(string encoding) 
		{
			return HttpContext.Current.Request.Headers["Accept-encoding"] != null &&
				HttpContext.Current.Request.Headers["Accept-encoding"].Contains(encoding);
		}

		/// <summary>
		/// Adds the specified encoding to the response headers.
		/// </summary>
		/// <param name="encoding"></param>
		private void SetEncoding(string encoding)
		{
			HttpContext.Current.Response.AppendHeader("Content-encoding", encoding);
		}

		#endregion
	};
}
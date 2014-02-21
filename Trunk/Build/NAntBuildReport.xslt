<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:param name="svnInfo" />
	<xsl:param name="date" />
	<xsl:param name="nantOutput" />
	<xsl:param name="nunitReport" />
  <xsl:param name="nunitFailedTests" />

	<xsl:output method="html" />

	<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		Variables
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~	-->

	<xsl:variable name="root" select="/buildresults" />
	<xsl:variable name="build-all" select="/buildresults" />
	<xsl:variable name="failure" select="/buildresults/failure" />

	<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		Main
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~	-->
	<xsl:template match="/">
		<html>
			<head>
				<title>Build log</title>
			</head>
			<body>
				<xsl:choose>
					<xsl:when test="$failure">
						<h1 style="color:#DC143C">Build FAILED</h1>
					</xsl:when>
					<xsl:otherwise>
						<h1 style="color:#2E8B57">Build OK</h1>
					</xsl:otherwise>
				</xsl:choose>

				<pre><xsl:value-of select="$svnInfo" /><xsl:text>Daily build Date: </xsl:text><xsl:value-of select="$date" /></pre>

				<h2>Unit Tests</h2>
				<table style="border:solid 1px black;text-align:center;padding:4px;">
					<tr>
						<th style="padding:4px;">Assembly</th>
						<th style="padding:4px;">Not Run</th>
						<th style="padding:4px;">Failed</th>
						<th style="padding:4px;">Success</th>
						<th style="padding:4px;">Total</th>
					</tr>
					<xsl:value-of select="$nunitReport" disable-output-escaping="yes"/>
				</table>
        <xsl:value-of select="$nunitFailedTests" disable-output-escaping="yes"/>

        <h2>Targets</h2>
				<ul>
					<xsl:apply-templates select="$build-all/target" />
				</ul>

				<xsl:if test="$failure">
					<h2>Errors</h2>
					<dl>
						<xsl:apply-templates select="$build-all/failure/builderror" />
					</dl>

					<h2>NAnt Output</h2>
					<pre>
						<xsl:value-of select="$nantOutput" />
					</pre>
				</xsl:if>
			</body>
		</html>
	</xsl:template>

	<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		Elements
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~	-->

	<xsl:template match="target">
		<li>
			<b><xsl:value-of select="@name" /></b>
		</li>
	</xsl:template>

	<xsl:template match="builderror">
		<dt style="color:#DC143C">
			<b><xsl:value-of select="message" /></b>
		</dt>
		<dd>
			<xsl:value-of select="type" />
		</dd>
	</xsl:template>

</xsl:stylesheet>


<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:param name="assembly" />

	<xsl:output method="html" />

	<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		Variables
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~	-->



	<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		Main
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~	-->
	<xsl:template match="/">
		<tr>
			<td><xsl:value-of select="$assembly" /></td>
			<td style="color:#0000FF"><xsl:value-of select="/test-results/@not-run" /></td>
			<td style="color:#DC143C"><xsl:value-of select="/test-results/@failures" /></td>
			<td style="color:#2E8B57"><xsl:value-of select="/test-results/@total - /test-results/@failures" /></td>
			<td><xsl:value-of select="/test-results/@total" /></td>
		</tr>
	</xsl:template>


</xsl:stylesheet>


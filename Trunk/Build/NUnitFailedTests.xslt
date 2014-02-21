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
    <dl>
      <xsl:apply-templates select="//test-case[ @executed='True' and @success='False']" />
    </dl>
	</xsl:template>

  <xsl:template match="test-case[ @executed='True' and @success='False']">
    <dt>
      <xsl:value-of select="@name"/>
    </dt>
    <dd style="color:#DC143C">
      <b>
        <xsl:value-of select="failure/message"/>
      </b>
      <p><xsl:value-of select="failure/stack-trace"/></p>
    </dd>
  </xsl:template>

</xsl:stylesheet>


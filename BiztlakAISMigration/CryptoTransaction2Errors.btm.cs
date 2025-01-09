namespace BiztlakAISMigration {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BiztlakAISMigration.CryptoTransaction", typeof(global::BiztlakAISMigration.CryptoTransaction))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BiztlakAISMigration.Errors", typeof(global::BiztlakAISMigration.Errors))]
    public sealed class CryptoTransaction2Errors : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var userCSharp"" version=""1.0"" xmlns:ns0=""http://example.com/Errors"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/CryptoTransactions"" />
  </xsl:template>
  <xsl:template match=""/CryptoTransactions"">
    <xsl:variable name=""var:v1"" select=""userCSharp:DateCurrentDateTime()"" />
    <ns0:Errors>
      <ns0:Timestamp>
        <xsl:value-of select=""$var:v1"" />
      </ns0:Timestamp>
      <ns0:TransactionIDs>
        <xsl:for-each select=""CryptoTransaction"">
          <ns0:TransactionID>
            <xsl:value-of select=""TransactionID/text()"" />
          </ns0:TransactionID>
        </xsl:for-each>
      </ns0:TransactionIDs>
    </ns0:Errors>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp""><![CDATA[
public string DateCurrentDateTime()
{
	DateTime dt = DateTime.Now;
	string curdate = dt.ToString(""yyyy-MM-dd"", System.Globalization.CultureInfo.InvariantCulture);
	string curtime = dt.ToString(""T"", System.Globalization.CultureInfo.InvariantCulture);
	string retval = curdate + ""T"" + curtime;
	return retval;
}



]]></msxsl:script>
</xsl:stylesheet>";
        
        private const string _xsltEngine = @"";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"BiztlakAISMigration.CryptoTransaction";
        
        private const global::BiztlakAISMigration.CryptoTransaction _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"BiztlakAISMigration.Errors";
        
        private const global::BiztlakAISMigration.Errors _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override string XsltEngine {
            get {
                return _xsltEngine;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"BiztlakAISMigration.CryptoTransaction";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"BiztlakAISMigration.Errors";
                return _TrgSchemas;
            }
        }
    }
}

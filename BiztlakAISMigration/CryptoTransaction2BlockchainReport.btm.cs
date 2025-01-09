namespace BiztlakAISMigration {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BiztlakAISMigration.CryptoTransaction", typeof(global::BiztlakAISMigration.CryptoTransaction))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BiztlakAISMigration.BlockchainReport", typeof(global::BiztlakAISMigration.BlockchainReport))]
    public sealed class CryptoTransaction2BlockchainReport : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var userCSharp"" version=""1.0"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/CryptoTransactions"" />
  </xsl:template>
  <xsl:template match=""/CryptoTransactions"">
    <xsl:variable name=""var:v1"" select=""count(/CryptoTransactions/CryptoTransaction)"" />
    <xsl:variable name=""var:v5"" select=""userCSharp:DateCurrentDateTime()"" />
    <BlockchainReport>
      <Blockchain>
        <xsl:value-of select=""CryptoTransaction/Blockchain/text()"" />
      </Blockchain>
      <Currency>
        <xsl:value-of select=""CryptoTransaction/Currency/text()"" />
      </Currency>
      <TotalTransactions>
        <xsl:value-of select=""$var:v1"" />
      </TotalTransactions>
      <xsl:variable name=""var:v2"" select=""userCSharp:InitCumulativeSum(0)"" />
      <xsl:for-each select=""/CryptoTransactions/CryptoTransaction"">
        <xsl:variable name=""var:v3"" select=""userCSharp:AddToCumulativeSum(0,string(Amount/text()),&quot;1000&quot;)"" />
      </xsl:for-each>
      <xsl:variable name=""var:v4"" select=""userCSharp:GetCumulativeSum(0)"" />
      <TotalVolume>
        <xsl:value-of select=""$var:v4"" />
      </TotalVolume>
      <ReportDate>
        <xsl:value-of select=""$var:v5"" />
      </ReportDate>
    </BlockchainReport>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp""><![CDATA[
public string InitCumulativeSum(int index)
{
	if (index >= 0)
	{
		if (index >= myCumulativeSumArray.Count)
		{
			int i = myCumulativeSumArray.Count;
			for (; i<=index; i++)
			{
				myCumulativeSumArray.Add("""");
			}
		}
		else
		{
			myCumulativeSumArray[index] = """";
		}
	}
	return """";
}

public System.Collections.ArrayList myCumulativeSumArray = new System.Collections.ArrayList();

public string AddToCumulativeSum(int index, string val, string notused)
{
	if (index < 0 || index >= myCumulativeSumArray.Count)
	{
		return """";
    }
	double d = 0;
	if (IsNumeric(val, ref d))
	{
		if (myCumulativeSumArray[index] == """")
		{
			myCumulativeSumArray[index] = d;
		}
		else
		{
			myCumulativeSumArray[index] = (double)(myCumulativeSumArray[index]) + d;
		}
	}
	return (myCumulativeSumArray[index] is double) ? ((double)myCumulativeSumArray[index]).ToString(System.Globalization.CultureInfo.InvariantCulture) : """";
}

public string GetCumulativeSum(int index)
{
	if (index < 0 || index >= myCumulativeSumArray.Count)
	{
		return """";
	}
	return (myCumulativeSumArray[index] is double) ? ((double)myCumulativeSumArray[index]).ToString(System.Globalization.CultureInfo.InvariantCulture) : """";
}

public string DateCurrentDateTime()
{
	DateTime dt = DateTime.Now;
	string curdate = dt.ToString(""yyyy-MM-dd"", System.Globalization.CultureInfo.InvariantCulture);
	string curtime = dt.ToString(""T"", System.Globalization.CultureInfo.InvariantCulture);
	string retval = curdate + ""T"" + curtime;
	return retval;
}


public bool IsNumeric(string val)
{
	if (val == null)
	{
		return false;
	}
	double d = 0;
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool IsNumeric(string val, ref double d)
{
	if (val == null)
	{
		return false;
	}
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}


]]></msxsl:script>
</xsl:stylesheet>";
        
        private const string _xsltEngine = @"";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"BiztlakAISMigration.CryptoTransaction";
        
        private const global::BiztlakAISMigration.CryptoTransaction _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"BiztlakAISMigration.BlockchainReport";
        
        private const global::BiztlakAISMigration.BlockchainReport _trgSchemaTypeReference0 = null;
        
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
                _TrgSchemas[0] = @"BiztlakAISMigration.BlockchainReport";
                return _TrgSchemas;
            }
        }
    }
}

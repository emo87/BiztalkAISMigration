namespace BiztlakAISMigration {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"",@"CryptoTransactions")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"CryptoTransactions"})]
    public sealed class CryptoTransaction : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""CryptoTransactions"">
    <xs:complexType>
      <xs:sequence>
        <xs:element maxOccurs=""unbounded"" name=""CryptoTransaction"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""TransactionID"" type=""xs:string"" />
              <xs:element name=""Blockchain"" type=""xs:string"" />
              <xs:element name=""FromAddress"" type=""xs:string"" />
              <xs:element name=""ToAddress"" type=""xs:string"" />
              <xs:element name=""Amount"" type=""xs:decimal"" />
              <xs:element name=""Currency"" type=""xs:string"" />
              <xs:element name=""Timestamp"" type=""xs:dateTime"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public CryptoTransaction() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "CryptoTransactions";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}

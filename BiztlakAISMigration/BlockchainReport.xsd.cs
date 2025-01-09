namespace BiztlakAISMigration {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"",@"BlockchainReport")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"BlockchainReport"})]
    public sealed class BlockchainReport : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""BlockchainReport"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Blockchain"" type=""xs:string"" />
        <xs:element name=""Currency"" type=""xs:string"" />
        <xs:element name=""TotalTransactions"" type=""xs:integer"" />
        <xs:element name=""TotalVolume"" type=""xs:decimal"" />
        <xs:element name=""ReportDate"" type=""xs:dateTime"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public BlockchainReport() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "BlockchainReport";
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

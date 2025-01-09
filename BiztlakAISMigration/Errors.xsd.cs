namespace BiztlakAISMigration {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://example.com/Errors",@"Errors")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Message", XPath = @"/*[local-name()='Errors' and namespace-uri()='http://example.com/Errors']/*[local-name()='Message' and namespace-uri()='http://example.com/Errors']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "ErrorType", XPath = @"/*[local-name()='Errors' and namespace-uri()='http://example.com/Errors']/*[local-name()='ErrorType' and namespace-uri()='http://example.com/Errors']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.DateTime), "Timestamp", XPath = @"/*[local-name()='Errors' and namespace-uri()='http://example.com/Errors']/*[local-name()='Timestamp' and namespace-uri()='http://example.com/Errors']", XsdType = @"dateTime")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Errors"})]
    public sealed class Errors : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://example.com/Errors"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" elementFormDefault=""qualified"" targetNamespace=""http://example.com/Errors"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Errors"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='Errors' and namespace-uri()='http://example.com/Errors']/*[local-name()='Message' and namespace-uri()='http://example.com/Errors']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Errors' and namespace-uri()='http://example.com/Errors']/*[local-name()='ErrorType' and namespace-uri()='http://example.com/Errors']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Errors' and namespace-uri()='http://example.com/Errors']/*[local-name()='Timestamp' and namespace-uri()='http://example.com/Errors']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Message"" type=""xs:string"" />
        <xs:element name=""ErrorType"" type=""xs:string"" />
        <xs:element name=""Timestamp"" type=""xs:dateTime"" />
        <xs:element name=""TransactionIDs"">
          <xs:complexType>
            <xs:sequence>
              <xs:element maxOccurs=""unbounded"" name=""TransactionID"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Errors() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Errors";
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

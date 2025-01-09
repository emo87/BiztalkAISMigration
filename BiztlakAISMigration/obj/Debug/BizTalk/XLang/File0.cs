
#pragma warning disable 162

namespace BiztlakAISMigration
{

    [Microsoft.XLANGs.BaseTypes.PortTypeOperationAttribute(
        "Operation_1",
        new System.Type[]{
            typeof(BiztlakAISMigration.__messagetype_BiztlakAISMigration_CryptoTransaction)
        },
        new string[]{
        }
    )]
    [Microsoft.XLANGs.BaseTypes.PortTypeAttribute(Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal, "")]
    [System.SerializableAttribute]
    sealed internal class PortType_1 : Microsoft.BizTalk.XLANGs.BTXEngine.BTXPortBase
    {
        public PortType_1(int portInfo, Microsoft.XLANGs.Core.IServiceProxy s)
            : base(portInfo, s)
        { }
        public PortType_1(PortType_1 p)
            : base(p)
        { }

        public override Microsoft.XLANGs.Core.PortBase Clone()
        {
            PortType_1 p = new PortType_1(this);
            return p;
        }

        public static readonly Microsoft.XLANGs.BaseTypes.EXLangSAccess __access = Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal;
        #region port reflection support
        static public Microsoft.XLANGs.Core.OperationInfo Operation_1 = new Microsoft.XLANGs.Core.OperationInfo
        (
            "Operation_1",
            System.Web.Services.Description.OperationFlow.OneWay,
            typeof(PortType_1),
            typeof(__messagetype_BiztlakAISMigration_CryptoTransaction),
            null,
            new System.Type[]{},
            new string[]{}
        );
        static public System.Collections.Hashtable OperationsInformation
        {
            get
            {
                System.Collections.Hashtable h = new System.Collections.Hashtable();
                h[ "Operation_1" ] = Operation_1;
                return h;
            }
        }
        #endregion // port reflection support
    }

    [Microsoft.XLANGs.BaseTypes.PortTypeOperationAttribute(
        "Operation_1",
        new System.Type[]{
            typeof(BiztlakAISMigration.__messagetype_BiztlakAISMigration_BlockchainReport)
        },
        new string[]{
        }
    )]
    [Microsoft.XLANGs.BaseTypes.PortTypeAttribute(Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal, "")]
    [System.SerializableAttribute]
    sealed internal class PortType_2 : Microsoft.BizTalk.XLANGs.BTXEngine.BTXPortBase
    {
        public PortType_2(int portInfo, Microsoft.XLANGs.Core.IServiceProxy s)
            : base(portInfo, s)
        { }
        public PortType_2(PortType_2 p)
            : base(p)
        { }

        public override Microsoft.XLANGs.Core.PortBase Clone()
        {
            PortType_2 p = new PortType_2(this);
            return p;
        }

        public static readonly Microsoft.XLANGs.BaseTypes.EXLangSAccess __access = Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal;
        #region port reflection support
        static public Microsoft.XLANGs.Core.OperationInfo Operation_1 = new Microsoft.XLANGs.Core.OperationInfo
        (
            "Operation_1",
            System.Web.Services.Description.OperationFlow.OneWay,
            typeof(PortType_2),
            typeof(__messagetype_BiztlakAISMigration_BlockchainReport),
            null,
            new System.Type[]{},
            new string[]{}
        );
        static public System.Collections.Hashtable OperationsInformation
        {
            get
            {
                System.Collections.Hashtable h = new System.Collections.Hashtable();
                h[ "Operation_1" ] = Operation_1;
                return h;
            }
        }
        #endregion // port reflection support
    }

    [Microsoft.XLANGs.BaseTypes.PortTypeOperationAttribute(
        "Operation_1",
        new System.Type[]{
            typeof(BiztlakAISMigration.__messagetype_BiztlakAISMigration_Errors)
        },
        new string[]{
        }
    )]
    [Microsoft.XLANGs.BaseTypes.PortTypeAttribute(Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal, "")]
    [System.SerializableAttribute]
    sealed internal class PortType_3 : Microsoft.BizTalk.XLANGs.BTXEngine.BTXPortBase
    {
        public PortType_3(int portInfo, Microsoft.XLANGs.Core.IServiceProxy s)
            : base(portInfo, s)
        { }
        public PortType_3(PortType_3 p)
            : base(p)
        { }

        public override Microsoft.XLANGs.Core.PortBase Clone()
        {
            PortType_3 p = new PortType_3(this);
            return p;
        }

        public static readonly Microsoft.XLANGs.BaseTypes.EXLangSAccess __access = Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal;
        #region port reflection support
        static public Microsoft.XLANGs.Core.OperationInfo Operation_1 = new Microsoft.XLANGs.Core.OperationInfo
        (
            "Operation_1",
            System.Web.Services.Description.OperationFlow.OneWay,
            typeof(PortType_3),
            typeof(__messagetype_BiztlakAISMigration_Errors),
            null,
            new System.Type[]{},
            new string[]{}
        );
        static public System.Collections.Hashtable OperationsInformation
        {
            get
            {
                System.Collections.Hashtable h = new System.Collections.Hashtable();
                h[ "Operation_1" ] = Operation_1;
                return h;
            }
        }
        #endregion // port reflection support
    }
    //#line 273 "C:\Users\emilio.marino\source\repos\BiztlakAISMigration\BiztlakAISMigration\CrytpoReport.odx"
    [Microsoft.XLANGs.BaseTypes.StaticSubscriptionAttribute(
        0, "Port_1", "Operation_1", -1, -1, true
    )]
    [Microsoft.XLANGs.BaseTypes.ServicePortsAttribute(
        new Microsoft.XLANGs.BaseTypes.EXLangSParameter[] {
            Microsoft.XLANGs.BaseTypes.EXLangSParameter.ePort|Microsoft.XLANGs.BaseTypes.EXLangSParameter.eImplements,
            Microsoft.XLANGs.BaseTypes.EXLangSParameter.ePort|Microsoft.XLANGs.BaseTypes.EXLangSParameter.eUses,
            Microsoft.XLANGs.BaseTypes.EXLangSParameter.ePort|Microsoft.XLANGs.BaseTypes.EXLangSParameter.eUses
        },
        new System.Type[] {
            typeof(BiztlakAISMigration.PortType_1),
            typeof(BiztlakAISMigration.PortType_2),
            typeof(BiztlakAISMigration.PortType_3)
        },
        new System.String[] {
            "Port_1",
            "Port_2",
            "Errori"
        },
        new System.Type[] {
            null,
            null,
            null
        }
    )]
    [Microsoft.XLANGs.BaseTypes.ServiceCallTreeAttribute(
        new System.Type[] {
        },
        new System.Type[] {
        },
        new System.Type[] {
        }
    )]
    [Microsoft.XLANGs.BaseTypes.ServiceAttribute(
        Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal,
        Microsoft.XLANGs.BaseTypes.EXLangSServiceInfo.eNone
    )]
    [System.SerializableAttribute]
    [Microsoft.XLANGs.BaseTypes.BPELExportableAttribute(false)]
    sealed internal class CrytpoReport : Microsoft.BizTalk.XLANGs.BTXEngine.BTXService
    {
        public static readonly Microsoft.XLANGs.BaseTypes.EXLangSAccess __access = Microsoft.XLANGs.BaseTypes.EXLangSAccess.eInternal;
        public static readonly bool __execable = false;
        [Microsoft.XLANGs.BaseTypes.CallCompensationAttribute(
            Microsoft.XLANGs.BaseTypes.EXLangSCallCompensationInfo.eNone,
            new System.String[] {
            },
            new System.String[] {
            }
        )]
        public static void __bodyProxy()
        {
        }
        private static System.Guid _serviceId = Microsoft.XLANGs.Core.HashHelper.HashServiceType(typeof(CrytpoReport));
        private static volatile System.Guid[] _activationSubIds;

        private static new object _lockIdentity = new object();

        public static System.Guid UUID { get { return _serviceId; } }
        public override System.Guid ServiceId { get { return UUID; } }

        protected override System.Guid[] ActivationSubGuids
        {
            get { return _activationSubIds; }
            set { _activationSubIds = value; }
        }

        protected override object StaleStateLock
        {
            get { return _lockIdentity; }
        }

        protected override bool HasActivation { get { return true; } }

        internal bool IsExeced = false;

        static CrytpoReport()
        {
            Microsoft.BizTalk.XLANGs.BTXEngine.BTXService.CacheStaticState( _serviceId );
        }

        private void ConstructorHelper()
        {
            _segments = new Microsoft.XLANGs.Core.Segment[] {
                new Microsoft.XLANGs.Core.Segment( new Microsoft.XLANGs.Core.Segment.SegmentCode(this.segment0), 0, 0, 0),
                new Microsoft.XLANGs.Core.Segment( new Microsoft.XLANGs.Core.Segment.SegmentCode(this.segment1), 1, 1, 1),
                new Microsoft.XLANGs.Core.Segment( new Microsoft.XLANGs.Core.Segment.SegmentCode(this.segment2), 1, 2, 2),
                new Microsoft.XLANGs.Core.Segment( new Microsoft.XLANGs.Core.Segment.SegmentCode(this.segment3), 1, 2, 3)
            };

            _Locks = 0;
            _rootContext = new __CrytpoReport_root_0(this);
            _stateMgrs = new Microsoft.XLANGs.Core.IStateManager[3];
            _stateMgrs[0] = _rootContext;
            FinalConstruct();
        }

        public CrytpoReport(System.Guid instanceId, Microsoft.BizTalk.XLANGs.BTXEngine.BTXSession session, Microsoft.BizTalk.XLANGs.BTXEngine.BTXEvents tracker)
            : base(instanceId, session, "CrytpoReport", tracker)
        {
            ConstructorHelper();
        }

        public CrytpoReport(int callIndex, System.Guid instanceId, Microsoft.BizTalk.XLANGs.BTXEngine.BTXService parent)
            : base(callIndex, instanceId, parent, "CrytpoReport")
        {
            ConstructorHelper();
        }

        private const string _symInfo = @"
<XsymFile>
<ProcessFlow xmlns:om='http://schemas.microsoft.com/BizTalk/2003/DesignerData'>      <shapeType>RootShape</shapeType>      <ShapeID>a5bc611e-a08f-473a-bae6-fe871655fd41</ShapeID>      
<children>                          
<ShapeInfo>      <shapeType>ReceiveShape</shapeType>      <ShapeID>5c7bd00c-9f4e-40b8-a1c1-89415bfe6b8f</ShapeID>      <ParentLink>ServiceBody_Statement</ParentLink>                <shapeText>Receive_1</shapeText>                  
<children>                </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>ScopeShape</shapeType>      <ShapeID>16dbf80d-74be-4719-b152-fe4fbd6b2f9a</ShapeID>      <ParentLink>ServiceBody_Statement</ParentLink>                <shapeText>Scope_1</shapeText>                  
<children>                          
<ShapeInfo>      <shapeType>ConstructShape</shapeType>      <ShapeID>338e8a59-b4fb-4219-8189-0f57d6a8a150</ShapeID>      <ParentLink>ComplexStatement_Statement</ParentLink>                <shapeText>ConstructMessage_1</shapeText>                  
<children>                          
<ShapeInfo>      <shapeType>TransformShape</shapeType>      <ShapeID>e67099ae-7d2a-4223-a3bc-f92b82372833</ShapeID>      <ParentLink>ComplexStatement_Statement</ParentLink>                <shapeText>Transform_1</shapeText>                  
<children>                          
<ShapeInfo>      <shapeType>MessagePartRefShape</shapeType>      <ShapeID>0d13a552-f565-4b36-b550-420a403a0321</ShapeID>      <ParentLink>Transform_InputMessagePartRef</ParentLink>                <shapeText>MessagePartReference_1</shapeText>                  
<children>                </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>MessagePartRefShape</shapeType>      <ShapeID>e15a0c9c-3e15-49d1-bd6e-8463569f88b7</ShapeID>      <ParentLink>Transform_OutputMessagePartRef</ParentLink>                <shapeText>MessagePartReference_2</shapeText>                  
<children>                </children>
  </ShapeInfo>
                  </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>MessageRefShape</shapeType>      <ShapeID>d802d832-455a-4305-8a88-b704d56f3f25</ShapeID>      <ParentLink>Construct_MessageRef</ParentLink>                  
<children>                </children>
  </ShapeInfo>
                  </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>SendShape</shapeType>      <ShapeID>00d2a679-775d-4c73-9549-5dbd3a3f2175</ShapeID>      <ParentLink>ComplexStatement_Statement</ParentLink>                <shapeText>Send_1</shapeText>                  
<children>                </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>CatchShape</shapeType>      <ShapeID>fbe314f0-5308-4c65-ae9e-9ea4ff916094</ShapeID>      <ParentLink>Scope_Catch</ParentLink>                <shapeText>CatchException_1</shapeText>                      <ExceptionType>System.SystemException</ExceptionType>            
<children>                          
<ShapeInfo>      <shapeType>ConstructShape</shapeType>      <ShapeID>dbe2ae1f-c6ce-4450-8479-88fa4b3d572b</ShapeID>      <ParentLink>Catch_Statement</ParentLink>                <shapeText>ConstructMessage_2</shapeText>                  
<children>                          
<ShapeInfo>      <shapeType>TransformShape</shapeType>      <ShapeID>d0d60a8c-9b25-4380-88e7-4b7fb977cd09</ShapeID>      <ParentLink>ComplexStatement_Statement</ParentLink>                <shapeText>Transform_2</shapeText>                  
<children>                          
<ShapeInfo>      <shapeType>MessagePartRefShape</shapeType>      <ShapeID>0155aa7a-5741-4576-9f1e-5b14a384844a</ShapeID>      <ParentLink>Transform_InputMessagePartRef</ParentLink>                <shapeText>MessagePartReference_3</shapeText>                  
<children>                </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>MessagePartRefShape</shapeType>      <ShapeID>26416456-d04d-4881-b5f8-76a6fba3137e</ShapeID>      <ParentLink>Transform_OutputMessagePartRef</ParentLink>                <shapeText>MessagePartReference_4</shapeText>                  
<children>                </children>
  </ShapeInfo>
                  </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>MessageRefShape</shapeType>      <ShapeID>8d961948-5a79-4f0e-a2a8-602154bbb962</ShapeID>      <ParentLink>Construct_MessageRef</ParentLink>                  
<children>                </children>
  </ShapeInfo>
                  </children>
  </ShapeInfo>
                            
<ShapeInfo>      <shapeType>SendShape</shapeType>      <ShapeID>5e6adb9f-c827-4c9a-9823-b838e28de992</ShapeID>      <ParentLink>Catch_Statement</ParentLink>                <shapeText>Send_2</shapeText>                  
<children>                </children>
  </ShapeInfo>
                  </children>
  </ShapeInfo>
                  </children>
  </ShapeInfo>
                  </children>
  </ProcessFlow><Metadata>

<TrkMetadata>
<ActionName>'CrytpoReport'</ActionName><IsAtomic>0</IsAtomic><Line>273</Line><Position>14</Position><ShapeID>'e211a116-cb8b-44e7-a052-0de295aa0001'</ShapeID>
</TrkMetadata>

<TrkMetadata>
<Line>287</Line><Position>22</Position><ShapeID>'5c7bd00c-9f4e-40b8-a1c1-89415bfe6b8f'</ShapeID>
<Messages>
	<MsgInfo><name>Crypto</name><part>part</part><schema>BiztlakAISMigration.CryptoTransaction</schema><direction>Out</direction></MsgInfo>
</Messages>
</TrkMetadata>

<TrkMetadata>
<ActionName>'??__scope33'</ActionName><IsAtomic>0</IsAtomic><Line>289</Line><Position>13</Position><ShapeID>'16dbf80d-74be-4719-b152-fe4fbd6b2f9a'</ShapeID>
<Messages>
</Messages>
</TrkMetadata>

<TrkMetadata>
<Line>294</Line><Position>21</Position><ShapeID>'338e8a59-b4fb-4219-8189-0f57d6a8a150'</ShapeID>
<Messages>
	<MsgInfo><name>CryptoReport</name><part>part</part><schema>BiztlakAISMigration.BlockchainReport</schema><direction>Out</direction></MsgInfo>
	<MsgInfo><name>Crypto</name><part>part</part><schema>BiztlakAISMigration.CryptoTransaction</schema><direction>In</direction></MsgInfo>
</Messages>
</TrkMetadata>

<TrkMetadata>
<Line>300</Line><Position>21</Position><ShapeID>'00d2a679-775d-4c73-9549-5dbd3a3f2175'</ShapeID>
<Messages>
	<MsgInfo><name>CryptoReport</name><part>part</part><schema>BiztlakAISMigration.BlockchainReport</schema><direction>Out</direction></MsgInfo>
</Messages>
</TrkMetadata>

<TrkMetadata>
<Line>305</Line><Position>21</Position><ShapeID>'fbe314f0-5308-4c65-ae9e-9ea4ff916094'</ShapeID>
<Messages>
</Messages>
</TrkMetadata>

<TrkMetadata>
<Line>308</Line><Position>25</Position><ShapeID>'dbe2ae1f-c6ce-4450-8479-88fa4b3d572b'</ShapeID>
<Messages>
	<MsgInfo><name>ErrorMsg</name><part>part</part><schema>BiztlakAISMigration.Errors</schema><direction>Out</direction></MsgInfo>
	<MsgInfo><name>Crypto</name><part>part</part><schema>BiztlakAISMigration.CryptoTransaction</schema><direction>In</direction></MsgInfo>
</Messages>
</TrkMetadata>

<TrkMetadata>
<Line>314</Line><Position>25</Position><ShapeID>'5e6adb9f-c827-4c9a-9823-b838e28de992'</ShapeID>
<Messages>
	<MsgInfo><name>ErrorMsg</name><part>part</part><schema>BiztlakAISMigration.Errors</schema><direction>Out</direction></MsgInfo>
</Messages>
</TrkMetadata>
</Metadata>
</XsymFile>";

        public override string odXml { get { return _symODXML; } }

        private const string _symODXML = @"
<?xml version='1.0' encoding='utf-8' standalone='yes'?>
<om:MetaModel MajorVersion='1' MinorVersion='3' Core='2b131234-7959-458d-834f-2dc0769ce683' ScheduleModel='66366196-361d-448d-976f-cab5e87496d2' xmlns:om='http://schemas.microsoft.com/BizTalk/2003/DesignerData'>
    <om:Element Type='Module' OID='f196eb56-d559-40e2-92f3-8c48a0be679a' LowerBound='1.1' HigherBound='74.1'>
        <om:Property Name='ReportToAnalyst' Value='True' />
        <om:Property Name='Name' Value='BiztlakAISMigration' />
        <om:Property Name='Signal' Value='False' />
        <om:Element Type='PortType' OID='97ee1a60-251f-4711-996a-abab83caf587' ParentLink='Module_PortType' LowerBound='4.1' HigherBound='11.1'>
            <om:Property Name='Synchronous' Value='False' />
            <om:Property Name='TypeModifier' Value='Internal' />
            <om:Property Name='ReportToAnalyst' Value='True' />
            <om:Property Name='Name' Value='PortType_1' />
            <om:Property Name='Signal' Value='False' />
            <om:Element Type='OperationDeclaration' OID='2ac12c45-7545-4e68-b3f5-f41aa193fe6c' ParentLink='PortType_OperationDeclaration' LowerBound='6.1' HigherBound='10.1'>
                <om:Property Name='OperationType' Value='OneWay' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='Operation_1' />
                <om:Property Name='Signal' Value='False' />
                <om:Element Type='MessageRef' OID='41d87a46-d855-4ab5-9ffd-e5fce4f9152e' ParentLink='OperationDeclaration_RequestMessageRef' LowerBound='8.13' HigherBound='8.30'>
                    <om:Property Name='Ref' Value='BiztlakAISMigration.CryptoTransaction' />
                    <om:Property Name='ReportToAnalyst' Value='True' />
                    <om:Property Name='Name' Value='Request' />
                    <om:Property Name='Signal' Value='True' />
                </om:Element>
            </om:Element>
        </om:Element>
        <om:Element Type='PortType' OID='fa8cddb7-5960-442b-8713-e12567b7ad6c' ParentLink='Module_PortType' LowerBound='11.1' HigherBound='18.1'>
            <om:Property Name='Synchronous' Value='False' />
            <om:Property Name='TypeModifier' Value='Internal' />
            <om:Property Name='ReportToAnalyst' Value='True' />
            <om:Property Name='Name' Value='PortType_2' />
            <om:Property Name='Signal' Value='False' />
            <om:Element Type='OperationDeclaration' OID='eb219ed5-7674-4d1d-aa2b-5a89586376b0' ParentLink='PortType_OperationDeclaration' LowerBound='13.1' HigherBound='17.1'>
                <om:Property Name='OperationType' Value='OneWay' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='Operation_1' />
                <om:Property Name='Signal' Value='False' />
                <om:Element Type='MessageRef' OID='d8a01684-cfb2-4960-abb4-4550d9528602' ParentLink='OperationDeclaration_RequestMessageRef' LowerBound='15.13' HigherBound='15.29'>
                    <om:Property Name='Ref' Value='BiztlakAISMigration.BlockchainReport' />
                    <om:Property Name='ReportToAnalyst' Value='True' />
                    <om:Property Name='Name' Value='Request' />
                    <om:Property Name='Signal' Value='True' />
                </om:Element>
            </om:Element>
        </om:Element>
        <om:Element Type='PortType' OID='bf194714-5929-43e0-81db-c2c767142f32' ParentLink='Module_PortType' LowerBound='18.1' HigherBound='25.1'>
            <om:Property Name='Synchronous' Value='False' />
            <om:Property Name='TypeModifier' Value='Internal' />
            <om:Property Name='ReportToAnalyst' Value='True' />
            <om:Property Name='Name' Value='PortType_3' />
            <om:Property Name='Signal' Value='False' />
            <om:Element Type='OperationDeclaration' OID='5746fb0b-af56-4ea6-8911-0c8509fbecb5' ParentLink='PortType_OperationDeclaration' LowerBound='20.1' HigherBound='24.1'>
                <om:Property Name='OperationType' Value='OneWay' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='Operation_1' />
                <om:Property Name='Signal' Value='False' />
                <om:Element Type='MessageRef' OID='46211521-b5a7-4410-9561-09ac898c3907' ParentLink='OperationDeclaration_RequestMessageRef' LowerBound='22.13' HigherBound='22.19'>
                    <om:Property Name='Ref' Value='BiztlakAISMigration.Errors' />
                    <om:Property Name='ReportToAnalyst' Value='True' />
                    <om:Property Name='Name' Value='Request' />
                    <om:Property Name='Signal' Value='True' />
                </om:Element>
            </om:Element>
        </om:Element>
        <om:Element Type='ServiceDeclaration' OID='8ee48202-9d23-48f6-b3d4-14155772c3a3' ParentLink='Module_ServiceDeclaration' LowerBound='25.1' HigherBound='73.1'>
            <om:Property Name='InitializedTransactionType' Value='False' />
            <om:Property Name='IsInvokable' Value='False' />
            <om:Property Name='TypeModifier' Value='Internal' />
            <om:Property Name='ReportToAnalyst' Value='True' />
            <om:Property Name='Name' Value='CrytpoReport' />
            <om:Property Name='Signal' Value='False' />
            <om:Element Type='ServiceBody' OID='a5bc611e-a08f-473a-bae6-fe871655fd41' ParentLink='ServiceDeclaration_ServiceBody'>
                <om:Property Name='Signal' Value='False' />
                <om:Element Type='Receive' OID='5c7bd00c-9f4e-40b8-a1c1-89415bfe6b8f' ParentLink='ServiceBody_Statement' LowerBound='39.1' HigherBound='41.1'>
                    <om:Property Name='Activate' Value='True' />
                    <om:Property Name='PortName' Value='Port_1' />
                    <om:Property Name='MessageName' Value='Crypto' />
                    <om:Property Name='OperationName' Value='Operation_1' />
                    <om:Property Name='OperationMessageName' Value='Request' />
                    <om:Property Name='ReportToAnalyst' Value='True' />
                    <om:Property Name='Name' Value='Receive_1' />
                    <om:Property Name='Signal' Value='True' />
                </om:Element>
                <om:Element Type='Scope' OID='16dbf80d-74be-4719-b152-fe4fbd6b2f9a' ParentLink='ServiceBody_Statement' LowerBound='41.1' HigherBound='71.1'>
                    <om:Property Name='InitializedTransactionType' Value='True' />
                    <om:Property Name='IsSynchronized' Value='False' />
                    <om:Property Name='ReportToAnalyst' Value='True' />
                    <om:Property Name='Name' Value='Scope_1' />
                    <om:Property Name='Signal' Value='True' />
                    <om:Element Type='Construct' OID='338e8a59-b4fb-4219-8189-0f57d6a8a150' ParentLink='ComplexStatement_Statement' LowerBound='46.1' HigherBound='52.1'>
                        <om:Property Name='ReportToAnalyst' Value='True' />
                        <om:Property Name='Name' Value='ConstructMessage_1' />
                        <om:Property Name='Signal' Value='False' />
                        <om:Element Type='Transform' OID='e67099ae-7d2a-4223-a3bc-f92b82372833' ParentLink='ComplexStatement_Statement' LowerBound='49.1' HigherBound='51.1'>
                            <om:Property Name='ClassName' Value='BiztlakAISMigration.CryptoTransaction2BlockchainReport' />
                            <om:Property Name='ReportToAnalyst' Value='True' />
                            <om:Property Name='Name' Value='Transform_1' />
                            <om:Property Name='Signal' Value='True' />
                            <om:Element Type='MessagePartRef' OID='0d13a552-f565-4b36-b550-420a403a0321' ParentLink='Transform_InputMessagePartRef' LowerBound='50.108' HigherBound='50.114'>
                                <om:Property Name='MessageRef' Value='Crypto' />
                                <om:Property Name='ReportToAnalyst' Value='True' />
                                <om:Property Name='Name' Value='MessagePartReference_1' />
                                <om:Property Name='Signal' Value='False' />
                            </om:Element>
                            <om:Element Type='MessagePartRef' OID='e15a0c9c-3e15-49d1-bd6e-8463569f88b7' ParentLink='Transform_OutputMessagePartRef' LowerBound='50.36' HigherBound='50.48'>
                                <om:Property Name='MessageRef' Value='CryptoReport' />
                                <om:Property Name='ReportToAnalyst' Value='True' />
                                <om:Property Name='Name' Value='MessagePartReference_2' />
                                <om:Property Name='Signal' Value='False' />
                            </om:Element>
                        </om:Element>
                        <om:Element Type='MessageRef' OID='d802d832-455a-4305-8a88-b704d56f3f25' ParentLink='Construct_MessageRef' LowerBound='47.31' HigherBound='47.43'>
                            <om:Property Name='Ref' Value='CryptoReport' />
                            <om:Property Name='ReportToAnalyst' Value='True' />
                            <om:Property Name='Signal' Value='False' />
                        </om:Element>
                    </om:Element>
                    <om:Element Type='Send' OID='00d2a679-775d-4c73-9549-5dbd3a3f2175' ParentLink='ComplexStatement_Statement' LowerBound='52.1' HigherBound='54.1'>
                        <om:Property Name='PortName' Value='Port_2' />
                        <om:Property Name='MessageName' Value='CryptoReport' />
                        <om:Property Name='OperationName' Value='Operation_1' />
                        <om:Property Name='OperationMessageName' Value='Request' />
                        <om:Property Name='ReportToAnalyst' Value='True' />
                        <om:Property Name='Name' Value='Send_1' />
                        <om:Property Name='Signal' Value='True' />
                    </om:Element>
                    <om:Element Type='Catch' OID='fbe314f0-5308-4c65-ae9e-9ea4ff916094' ParentLink='Scope_Catch' LowerBound='57.1' HigherBound='69.1'>
                        <om:Property Name='ExceptionName' Value='sysex' />
                        <om:Property Name='ExceptionType' Value='System.SystemException' />
                        <om:Property Name='IsFaultMessage' Value='False' />
                        <om:Property Name='ReportToAnalyst' Value='True' />
                        <om:Property Name='Name' Value='CatchException_1' />
                        <om:Property Name='Signal' Value='True' />
                        <om:Element Type='Construct' OID='dbe2ae1f-c6ce-4450-8479-88fa4b3d572b' ParentLink='Catch_Statement' LowerBound='60.1' HigherBound='66.1'>
                            <om:Property Name='ReportToAnalyst' Value='True' />
                            <om:Property Name='Name' Value='ConstructMessage_2' />
                            <om:Property Name='Signal' Value='False' />
                            <om:Element Type='Transform' OID='d0d60a8c-9b25-4380-88e7-4b7fb977cd09' ParentLink='ComplexStatement_Statement' LowerBound='63.1' HigherBound='65.1'>
                                <om:Property Name='ClassName' Value='BiztlakAISMigration.CryptoTransaction2Errors' />
                                <om:Property Name='ReportToAnalyst' Value='True' />
                                <om:Property Name='Name' Value='Transform_2' />
                                <om:Property Name='Signal' Value='True' />
                                <om:Element Type='MessagePartRef' OID='0155aa7a-5741-4576-9f1e-5b14a384844a' ParentLink='Transform_InputMessagePartRef' LowerBound='64.98' HigherBound='64.104'>
                                    <om:Property Name='MessageRef' Value='Crypto' />
                                    <om:Property Name='ReportToAnalyst' Value='True' />
                                    <om:Property Name='Name' Value='MessagePartReference_3' />
                                    <om:Property Name='Signal' Value='False' />
                                </om:Element>
                                <om:Element Type='MessagePartRef' OID='26416456-d04d-4881-b5f8-76a6fba3137e' ParentLink='Transform_OutputMessagePartRef' LowerBound='64.40' HigherBound='64.48'>
                                    <om:Property Name='MessageRef' Value='ErrorMsg' />
                                    <om:Property Name='ReportToAnalyst' Value='True' />
                                    <om:Property Name='Name' Value='MessagePartReference_4' />
                                    <om:Property Name='Signal' Value='False' />
                                </om:Element>
                            </om:Element>
                            <om:Element Type='MessageRef' OID='8d961948-5a79-4f0e-a2a8-602154bbb962' ParentLink='Construct_MessageRef' LowerBound='61.35' HigherBound='61.43'>
                                <om:Property Name='Ref' Value='ErrorMsg' />
                                <om:Property Name='ReportToAnalyst' Value='True' />
                                <om:Property Name='Signal' Value='False' />
                            </om:Element>
                        </om:Element>
                        <om:Element Type='Send' OID='5e6adb9f-c827-4c9a-9823-b838e28de992' ParentLink='Catch_Statement' LowerBound='66.1' HigherBound='68.1'>
                            <om:Property Name='PortName' Value='Errori' />
                            <om:Property Name='MessageName' Value='ErrorMsg' />
                            <om:Property Name='OperationName' Value='Operation_1' />
                            <om:Property Name='OperationMessageName' Value='Request' />
                            <om:Property Name='ReportToAnalyst' Value='True' />
                            <om:Property Name='Name' Value='Send_2' />
                            <om:Property Name='Signal' Value='True' />
                        </om:Element>
                    </om:Element>
                </om:Element>
            </om:Element>
            <om:Element Type='PortDeclaration' OID='a0eb0705-88ac-4e71-b400-bb603bd56801' ParentLink='ServiceDeclaration_PortDeclaration' LowerBound='28.1' HigherBound='30.1'>
                <om:Property Name='PortModifier' Value='Implements' />
                <om:Property Name='Orientation' Value='Left' />
                <om:Property Name='PortIndex' Value='-1' />
                <om:Property Name='IsWebPort' Value='False' />
                <om:Property Name='OrderedDelivery' Value='False' />
                <om:Property Name='DeliveryNotification' Value='None' />
                <om:Property Name='Type' Value='BiztlakAISMigration.PortType_1' />
                <om:Property Name='ParamDirection' Value='In' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='Port_1' />
                <om:Property Name='Signal' Value='False' />
                <om:Element Type='LogicalBindingAttribute' OID='1ced4087-c0f8-41a0-b101-cc1deb287b9d' ParentLink='PortDeclaration_CLRAttribute' LowerBound='28.1' HigherBound='29.1'>
                    <om:Property Name='Signal' Value='False' />
                </om:Element>
            </om:Element>
            <om:Element Type='PortDeclaration' OID='701312b1-333a-4b21-a783-792dd358f8a1' ParentLink='ServiceDeclaration_PortDeclaration' LowerBound='30.1' HigherBound='32.1'>
                <om:Property Name='PortModifier' Value='Uses' />
                <om:Property Name='Orientation' Value='Right' />
                <om:Property Name='PortIndex' Value='-1' />
                <om:Property Name='IsWebPort' Value='False' />
                <om:Property Name='OrderedDelivery' Value='False' />
                <om:Property Name='DeliveryNotification' Value='None' />
                <om:Property Name='Type' Value='BiztlakAISMigration.PortType_2' />
                <om:Property Name='ParamDirection' Value='In' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='Port_2' />
                <om:Property Name='Signal' Value='False' />
                <om:Element Type='LogicalBindingAttribute' OID='28f727de-be9e-456e-a9db-fea7ad2c3f07' ParentLink='PortDeclaration_CLRAttribute' LowerBound='30.1' HigherBound='31.1'>
                    <om:Property Name='Signal' Value='False' />
                </om:Element>
            </om:Element>
            <om:Element Type='PortDeclaration' OID='c39ef945-12d5-469f-8ff7-d88822ce973f' ParentLink='ServiceDeclaration_PortDeclaration' LowerBound='32.1' HigherBound='34.1'>
                <om:Property Name='PortModifier' Value='Uses' />
                <om:Property Name='Orientation' Value='Right' />
                <om:Property Name='PortIndex' Value='17' />
                <om:Property Name='IsWebPort' Value='False' />
                <om:Property Name='OrderedDelivery' Value='False' />
                <om:Property Name='DeliveryNotification' Value='None' />
                <om:Property Name='Type' Value='BiztlakAISMigration.PortType_3' />
                <om:Property Name='ParamDirection' Value='In' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='Errori' />
                <om:Property Name='Signal' Value='False' />
                <om:Element Type='LogicalBindingAttribute' OID='9d8b7ed1-7310-4e07-baeb-759aebb6efbc' ParentLink='PortDeclaration_CLRAttribute' LowerBound='32.1' HigherBound='33.1'>
                    <om:Property Name='Signal' Value='False' />
                </om:Element>
            </om:Element>
            <om:Element Type='MessageDeclaration' OID='eeb396d0-8454-482e-9bbd-31e33fc0984f' ParentLink='ServiceDeclaration_MessageDeclaration' LowerBound='34.1' HigherBound='35.1'>
                <om:Property Name='Type' Value='BiztlakAISMigration.CryptoTransaction' />
                <om:Property Name='ParamDirection' Value='In' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='Crypto' />
                <om:Property Name='Signal' Value='True' />
            </om:Element>
            <om:Element Type='MessageDeclaration' OID='f3385918-6778-4f39-9cc8-d0f614f471ef' ParentLink='ServiceDeclaration_MessageDeclaration' LowerBound='35.1' HigherBound='36.1'>
                <om:Property Name='Type' Value='BiztlakAISMigration.BlockchainReport' />
                <om:Property Name='ParamDirection' Value='In' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='CryptoReport' />
                <om:Property Name='Signal' Value='True' />
            </om:Element>
            <om:Element Type='MessageDeclaration' OID='1aa26cea-c05a-4ecd-a8bf-9c767774235b' ParentLink='ServiceDeclaration_MessageDeclaration' LowerBound='36.1' HigherBound='37.1'>
                <om:Property Name='Type' Value='BiztlakAISMigration.Errors' />
                <om:Property Name='ParamDirection' Value='In' />
                <om:Property Name='ReportToAnalyst' Value='True' />
                <om:Property Name='Name' Value='ErrorMsg' />
                <om:Property Name='Signal' Value='True' />
            </om:Element>
        </om:Element>
    </om:Element>
</om:MetaModel>
";

        [System.SerializableAttribute]
        public class __CrytpoReport_root_0 : Microsoft.XLANGs.Core.ServiceContext
        {
            public __CrytpoReport_root_0(Microsoft.XLANGs.Core.Service svc)
                : base(svc, "CrytpoReport")
            {
            }

            public override int Index { get { return 0; } }

            public override Microsoft.XLANGs.Core.Segment InitialSegment
            {
                get { return _service._segments[0]; }
            }
            public override Microsoft.XLANGs.Core.Segment FinalSegment
            {
                get { return _service._segments[0]; }
            }

            public override int CompensationSegment { get { return -1; } }
            public override bool OnError()
            {
                Finally();
                return false;
            }

            public override void Finally()
            {
                CrytpoReport __svc__ = (CrytpoReport)_service;
                __CrytpoReport_root_0 __ctx0__ = (__CrytpoReport_root_0)(__svc__._stateMgrs[0]);

                if (__svc__.Port_2 != null)
                {
                    __svc__.Port_2.Close(this, null);
                    __svc__.Port_2 = null;
                }
                if (__svc__.Errori != null)
                {
                    __svc__.Errori.Close(this, null);
                    __svc__.Errori = null;
                }
                if (__svc__.Port_1 != null)
                {
                    __svc__.Port_1.Close(this, null);
                    __svc__.Port_1 = null;
                }
                base.Finally();
            }

            internal Microsoft.XLANGs.Core.SubscriptionWrapper __subWrapper0;
        }


        [System.SerializableAttribute]
        public class __CrytpoReport_1 : Microsoft.XLANGs.Core.ExceptionHandlingContext
        {
            public __CrytpoReport_1(Microsoft.XLANGs.Core.Service svc)
                : base(svc, "CrytpoReport")
            {
            }

            public override int Index { get { return 1; } }

            public override bool CombineParentCommit { get { return true; } }

            public override Microsoft.XLANGs.Core.Segment InitialSegment
            {
                get { return _service._segments[1]; }
            }
            public override Microsoft.XLANGs.Core.Segment FinalSegment
            {
                get { return _service._segments[1]; }
            }

            public override int CompensationSegment { get { return -1; } }
            public override bool OnError()
            {
                Finally();
                return false;
            }

            public override void Finally()
            {
                CrytpoReport __svc__ = (CrytpoReport)_service;
                __CrytpoReport_1 __ctx1__ = (__CrytpoReport_1)(__svc__._stateMgrs[1]);

                if (__ctx1__ != null && __ctx1__.__Crypto != null)
                {
                    __ctx1__.UnrefMessage(__ctx1__.__Crypto);
                    __ctx1__.__Crypto = null;
                }
                base.Finally();
            }

            [Microsoft.XLANGs.Core.UserVariableAttribute("Crypto")]
            public __messagetype_BiztlakAISMigration_CryptoTransaction __Crypto;
            [Microsoft.XLANGs.Core.UserVariableAttribute("CryptoReport")]
            public __messagetype_BiztlakAISMigration_BlockchainReport __CryptoReport;
            [Microsoft.XLANGs.Core.UserVariableAttribute("ErrorMsg")]
            public __messagetype_BiztlakAISMigration_Errors __ErrorMsg;
        }


        [System.SerializableAttribute]
        public class ____scope33_2 : Microsoft.XLANGs.Core.ExceptionHandlingContext
        {
            public ____scope33_2(Microsoft.XLANGs.Core.Service svc)
                : base(svc, "??__scope33")
            {
            }

            public override int Index { get { return 2; } }

            public override bool CombineParentCommit { get { return true; } }

            public override Microsoft.XLANGs.Core.Segment InitialSegment
            {
                get { return _service._segments[2]; }
            }
            public override Microsoft.XLANGs.Core.Segment FinalSegment
            {
                get { return _service._segments[2]; }
            }

            public override int CompensationSegment { get { return -1; } }
            public override bool OnError()
            {
                Microsoft.XLANGs.Core.Segment __seg__;
                Microsoft.XLANGs.Core.FaultReceiveException __fault__;

                __exv__ = _exception;
                if (!(__exv__ is Microsoft.XLANGs.Core.UnknownException))
                {
                    __fault__ = __exv__ as Microsoft.XLANGs.Core.FaultReceiveException;
                    if ((__fault__ == null) && (__exv__ is System.SystemException))
                    {
                        __seg__ = _service._segments[3];
                        __seg__.Reset(1);
                        __seg__.PredecessorDone(_service);
                        return true;
                    }
                }

                Finally();
                return false;
            }

            public override void Finally()
            {
                CrytpoReport __svc__ = (CrytpoReport)_service;
                __CrytpoReport_1 __ctx1__ = (__CrytpoReport_1)(__svc__._stateMgrs[1]);

                if (__ctx1__ != null && __ctx1__.__CryptoReport != null)
                {
                    __ctx1__.UnrefMessage(__ctx1__.__CryptoReport);
                    __ctx1__.__CryptoReport = null;
                }
                if (__ctx1__ != null && __ctx1__.__ErrorMsg != null)
                {
                    __ctx1__.UnrefMessage(__ctx1__.__ErrorMsg);
                    __ctx1__.__ErrorMsg = null;
                }
                base.Finally();
            }

            internal object __exv__;
            internal System.SystemException __sysex_0
            {
                get { return (System.SystemException)__exv__; }
                set { __exv__ = value; }
            }
        }

        private static Microsoft.XLANGs.Core.CorrelationType[] _correlationTypes = null;
        public override Microsoft.XLANGs.Core.CorrelationType[] CorrelationTypes { get { return _correlationTypes; } }

        private static System.Guid[] _convoySetIds;

        public override System.Guid[] ConvoySetGuids
        {
            get { return _convoySetIds; }
            set { _convoySetIds = value; }
        }

        public static object[] StaticConvoySetInformation
        {
            get {
                return null;
            }
        }

        [Microsoft.XLANGs.BaseTypes.LogicalBindingAttribute()]
        [Microsoft.XLANGs.BaseTypes.PortAttribute(
            Microsoft.XLANGs.BaseTypes.EXLangSParameter.eImplements
        )]
        [Microsoft.XLANGs.Core.UserVariableAttribute("Port_1")]
        internal PortType_1 Port_1;
        [Microsoft.XLANGs.BaseTypes.LogicalBindingAttribute()]
        [Microsoft.XLANGs.BaseTypes.PortAttribute(
            Microsoft.XLANGs.BaseTypes.EXLangSParameter.eUses
        )]
        [Microsoft.XLANGs.Core.UserVariableAttribute("Port_2")]
        internal PortType_2 Port_2;
        [Microsoft.XLANGs.BaseTypes.LogicalBindingAttribute()]
        [Microsoft.XLANGs.BaseTypes.PortAttribute(
            Microsoft.XLANGs.BaseTypes.EXLangSParameter.eUses
        )]
        [Microsoft.XLANGs.Core.UserVariableAttribute("Errori")]
        internal PortType_3 Errori;

        public static Microsoft.XLANGs.Core.PortInfo[] _portInfo = new Microsoft.XLANGs.Core.PortInfo[] {
            new Microsoft.XLANGs.Core.PortInfo(new Microsoft.XLANGs.Core.OperationInfo[] {PortType_1.Operation_1},
                                               typeof(CrytpoReport).GetField("Port_1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance),
                                               Microsoft.XLANGs.BaseTypes.Polarity.implements,
                                               false,
                                               Microsoft.XLANGs.Core.HashHelper.HashPort(typeof(CrytpoReport), "Port_1"),
                                               null),
            new Microsoft.XLANGs.Core.PortInfo(new Microsoft.XLANGs.Core.OperationInfo[] {PortType_2.Operation_1},
                                               typeof(CrytpoReport).GetField("Port_2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance),
                                               Microsoft.XLANGs.BaseTypes.Polarity.uses,
                                               false,
                                               Microsoft.XLANGs.Core.HashHelper.HashPort(typeof(CrytpoReport), "Port_2"),
                                               null),
            new Microsoft.XLANGs.Core.PortInfo(new Microsoft.XLANGs.Core.OperationInfo[] {PortType_3.Operation_1},
                                               typeof(CrytpoReport).GetField("Errori", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance),
                                               Microsoft.XLANGs.BaseTypes.Polarity.uses,
                                               false,
                                               Microsoft.XLANGs.Core.HashHelper.HashPort(typeof(CrytpoReport), "Errori"),
                                               null)
        };

        public override Microsoft.XLANGs.Core.PortInfo[] PortInformation
        {
            get { return _portInfo; }
        }

        static public System.Collections.Hashtable PortsInformation
        {
            get
            {
                System.Collections.Hashtable h = new System.Collections.Hashtable();
                h[_portInfo[0].Name] = _portInfo[0];
                h[_portInfo[1].Name] = _portInfo[1];
                h[_portInfo[2].Name] = _portInfo[2];
                return h;
            }
        }

        public static System.Type[] InvokedServicesTypes
        {
            get
            {
                return new System.Type[] {
                    // type of each service invoked by this service
                };
            }
        }

        public static System.Type[] CalledServicesTypes
        {
            get
            {
                return new System.Type[] {
                };
            }
        }

        public static System.Type[] ExecedServicesTypes
        {
            get
            {
                return new System.Type[] {
                };
            }
        }

        public static object[] StaticSubscriptionsInformation {
            get {
                return new object[1]{
                     new object[5] { _portInfo[0], 0, null , -1, true }
                };
            }
        }

        public static Microsoft.XLANGs.RuntimeTypes.Location[] __eventLocations = new Microsoft.XLANGs.RuntimeTypes.Location[] {
            new Microsoft.XLANGs.RuntimeTypes.Location(0, "00000000-0000-0000-0000-000000000000", 1, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(1, "5c7bd00c-9f4e-40b8-a1c1-89415bfe6b8f", 1, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(2, "5c7bd00c-9f4e-40b8-a1c1-89415bfe6b8f", 1, false),
            new Microsoft.XLANGs.RuntimeTypes.Location(3, "16dbf80d-74be-4719-b152-fe4fbd6b2f9a", 1, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(4, "00000000-0000-0000-0000-000000000000", 2, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(5, "338e8a59-b4fb-4219-8189-0f57d6a8a150", 2, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(6, "338e8a59-b4fb-4219-8189-0f57d6a8a150", 2, false),
            new Microsoft.XLANGs.RuntimeTypes.Location(7, "00d2a679-775d-4c73-9549-5dbd3a3f2175", 2, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(8, "00d2a679-775d-4c73-9549-5dbd3a3f2175", 2, false),
            new Microsoft.XLANGs.RuntimeTypes.Location(9, "fbe314f0-5308-4c65-ae9e-9ea4ff916094", 3, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(10, "dbe2ae1f-c6ce-4450-8479-88fa4b3d572b", 3, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(11, "dbe2ae1f-c6ce-4450-8479-88fa4b3d572b", 3, false),
            new Microsoft.XLANGs.RuntimeTypes.Location(12, "5e6adb9f-c827-4c9a-9823-b838e28de992", 3, true),
            new Microsoft.XLANGs.RuntimeTypes.Location(13, "5e6adb9f-c827-4c9a-9823-b838e28de992", 3, false),
            new Microsoft.XLANGs.RuntimeTypes.Location(14, "fbe314f0-5308-4c65-ae9e-9ea4ff916094", 3, false),
            new Microsoft.XLANGs.RuntimeTypes.Location(15, "16dbf80d-74be-4719-b152-fe4fbd6b2f9a", 1, false),
            new Microsoft.XLANGs.RuntimeTypes.Location(16, "00000000-0000-0000-0000-000000000000", 1, false)
        };

        public override Microsoft.XLANGs.RuntimeTypes.Location[] EventLocations
        {
            get { return __eventLocations; }
        }

        public static Microsoft.XLANGs.RuntimeTypes.EventData[] __eventData = new Microsoft.XLANGs.RuntimeTypes.EventData[] {
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.Start | Microsoft.XLANGs.RuntimeTypes.Operation.Body),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.Start | Microsoft.XLANGs.RuntimeTypes.Operation.Receive),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.Start | Microsoft.XLANGs.RuntimeTypes.Operation.Scope),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.Start | Microsoft.XLANGs.RuntimeTypes.Operation.Construct),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.Start | Microsoft.XLANGs.RuntimeTypes.Operation.Send),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.Start | Microsoft.XLANGs.RuntimeTypes.Operation.Catch),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Catch),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Scope),
            new Microsoft.XLANGs.RuntimeTypes.EventData( Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Body)
        };

        public static int[] __progressLocation0 = new int[] { 0,0,0,16,16,};
        public static int[] __progressLocation1 = new int[] { 0,0,1,1,2,3,3,3,15,16,16,16,16,};
        public static int[] __progressLocation2 = new int[] { 5,5,5,6,7,7,7,8,8,8,8,};
        public static int[] __progressLocation3 = new int[] { 9,9,10,10,11,12,12,12,13,14,14,};

        public static int[][] __progressLocations = new int[4] [] {__progressLocation0,__progressLocation1,__progressLocation2,__progressLocation3};
        public override int[][] ProgressLocations {get {return __progressLocations;} }

        public Microsoft.XLANGs.Core.StopConditions segment0(Microsoft.XLANGs.Core.StopConditions stopOn)
        {
            Microsoft.XLANGs.Core.Segment __seg__ = _segments[0];
            Microsoft.XLANGs.Core.Context __ctx__ = (Microsoft.XLANGs.Core.Context)_stateMgrs[0];
            __CrytpoReport_1 __ctx1__ = (__CrytpoReport_1)_stateMgrs[1];
            __CrytpoReport_root_0 __ctx0__ = (__CrytpoReport_root_0)_stateMgrs[0];

            switch (__seg__.Progress)
            {
            case 0:
                Port_1 = new PortType_1(0, this);
                Port_2 = new PortType_2(1, this);
                Errori = new PortType_3(2, this);
                __ctx__.PrologueCompleted = true;
                __ctx0__.__subWrapper0 = new Microsoft.XLANGs.Core.SubscriptionWrapper(ActivationSubGuids[0], Port_1, this);
                if ( !PostProgressInc( __seg__, __ctx__, 1 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                if ((stopOn & Microsoft.XLANGs.Core.StopConditions.Initialized) != 0)
                    return Microsoft.XLANGs.Core.StopConditions.Initialized;
                goto case 1;
            case 1:
                __ctx1__ = new __CrytpoReport_1(this);
                _stateMgrs[1] = __ctx1__;
                if ( !PostProgressInc( __seg__, __ctx__, 2 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 2;
            case 2:
                __ctx0__.StartContext(__seg__, __ctx1__);
                if ( !PostProgressInc( __seg__, __ctx__, 3 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                return Microsoft.XLANGs.Core.StopConditions.Blocked;
            case 3:
                if (!__ctx0__.CleanupAndPrepareToCommit(__seg__))
                    return Microsoft.XLANGs.Core.StopConditions.Blocked;
                if ( !PostProgressInc( __seg__, __ctx__, 4 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 4;
            case 4:
                __ctx1__.Finally();
                ServiceDone(__seg__, (Microsoft.XLANGs.Core.Context)_stateMgrs[0]);
                __ctx0__.OnCommit();
                break;
            }
            return Microsoft.XLANGs.Core.StopConditions.Completed;
        }

        public Microsoft.XLANGs.Core.StopConditions segment1(Microsoft.XLANGs.Core.StopConditions stopOn)
        {
            Microsoft.XLANGs.Core.Envelope __msgEnv__ = null;
            Microsoft.XLANGs.Core.Segment __seg__ = _segments[1];
            Microsoft.XLANGs.Core.Context __ctx__ = (Microsoft.XLANGs.Core.Context)_stateMgrs[1];
            __CrytpoReport_1 __ctx1__ = (__CrytpoReport_1)_stateMgrs[1];
            ____scope33_2 __ctx2__ = (____scope33_2)_stateMgrs[2];
            __CrytpoReport_root_0 __ctx0__ = (__CrytpoReport_root_0)_stateMgrs[0];

            switch (__seg__.Progress)
            {
            case 0:
                __ctx__.PrologueCompleted = true;
                if ( !PostProgressInc( __seg__, __ctx__, 1 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 1;
            case 1:
                if ( !PreProgressInc( __seg__, __ctx__, 2 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[0],__eventData[0],_stateMgrs[1].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 2;
            case 2:
                if ( !PreProgressInc( __seg__, __ctx__, 3 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[1],__eventData[1],_stateMgrs[1].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 3;
            case 3:
                if (!Port_1.GetMessageId(__ctx0__.__subWrapper0.getSubscription(this), __seg__, __ctx1__, out __msgEnv__))
                    return Microsoft.XLANGs.Core.StopConditions.Blocked;
                if (__ctx1__.__Crypto != null)
                    __ctx1__.UnrefMessage(__ctx1__.__Crypto);
                __ctx1__.__Crypto = new __messagetype_BiztlakAISMigration_CryptoTransaction("Crypto", __ctx1__);
                __ctx1__.RefMessage(__ctx1__.__Crypto);
                Port_1.ReceiveMessage(0, __msgEnv__, __ctx1__.__Crypto, null, (Microsoft.XLANGs.Core.Context)_stateMgrs[1], __seg__);
                if (Port_1 != null)
                {
                    Port_1.Close(__ctx1__, __seg__);
                    Port_1 = null;
                }
                if ( !PostProgressInc( __seg__, __ctx__, 4 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 4;
            case 4:
                if ( !PreProgressInc( __seg__, __ctx__, 5 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                {
                    Microsoft.XLANGs.RuntimeTypes.EventData __edata = new Microsoft.XLANGs.RuntimeTypes.EventData(Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Receive);
                    __edata.Messages.Add(__ctx1__.__Crypto);
                    __edata.PortName = @"Port_1";
                    Tracker.FireEvent(__eventLocations[2],__edata,_stateMgrs[1].TrackDataStream );
                }
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 5;
            case 5:
                if ( !PreProgressInc( __seg__, __ctx__, 6 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[3],__eventData[2],_stateMgrs[1].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 6;
            case 6:
                __ctx2__ = new ____scope33_2(this);
                _stateMgrs[2] = __ctx2__;
                if ( !PostProgressInc( __seg__, __ctx__, 7 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 7;
            case 7:
                __ctx1__.StartContext(__seg__, __ctx2__);
                if ( !PostProgressInc( __seg__, __ctx__, 8 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                return Microsoft.XLANGs.Core.StopConditions.Blocked;
            case 8:
                if ( !PreProgressInc( __seg__, __ctx__, 9 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                if (__ctx1__ != null && __ctx1__.__Crypto != null)
                {
                    __ctx1__.UnrefMessage(__ctx1__.__Crypto);
                    __ctx1__.__Crypto = null;
                }
                if (Errori != null)
                {
                    Errori.Close(__ctx1__, __seg__);
                    Errori = null;
                }
                if (Port_2 != null)
                {
                    Port_2.Close(__ctx1__, __seg__);
                    Port_2 = null;
                }
                Tracker.FireEvent(__eventLocations[15],__eventData[7],_stateMgrs[1].TrackDataStream );
                __ctx2__.Finally();
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 9;
            case 9:
                if ( !PreProgressInc( __seg__, __ctx__, 10 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[16],__eventData[8],_stateMgrs[1].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 10;
            case 10:
                if (!__ctx1__.CleanupAndPrepareToCommit(__seg__))
                    return Microsoft.XLANGs.Core.StopConditions.Blocked;
                if ( !PostProgressInc( __seg__, __ctx__, 11 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 11;
            case 11:
                if ( !PreProgressInc( __seg__, __ctx__, 12 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                __ctx1__.OnCommit();
                goto case 12;
            case 12:
                __seg__.SegmentDone();
                _segments[0].PredecessorDone(this);
                break;
            }
            return Microsoft.XLANGs.Core.StopConditions.Completed;
        }

        public Microsoft.XLANGs.Core.StopConditions segment2(Microsoft.XLANGs.Core.StopConditions stopOn)
        {
            Microsoft.XLANGs.Core.Segment __seg__ = _segments[2];
            Microsoft.XLANGs.Core.Context __ctx__ = (Microsoft.XLANGs.Core.Context)_stateMgrs[2];
            __CrytpoReport_1 __ctx1__ = (__CrytpoReport_1)_stateMgrs[1];
            ____scope33_2 __ctx2__ = (____scope33_2)_stateMgrs[2];
            __CrytpoReport_root_0 __ctx0__ = (__CrytpoReport_root_0)_stateMgrs[0];

            switch (__seg__.Progress)
            {
            case 0:
                __ctx__.PrologueCompleted = true;
                if ( !PostProgressInc( __seg__, __ctx__, 1 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 1;
            case 1:
                if ( !PreProgressInc( __seg__, __ctx__, 2 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[5],__eventData[3],_stateMgrs[2].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 2;
            case 2:
                {
                    __messagetype_BiztlakAISMigration_BlockchainReport __CryptoReport = new __messagetype_BiztlakAISMigration_BlockchainReport("CryptoReport", __ctx1__);

                    ApplyTransform(typeof(BiztlakAISMigration.CryptoTransaction2BlockchainReport), new object[] {__CryptoReport.part}, new object[] {__ctx1__.__Crypto.part});

                    if (__ctx1__.__CryptoReport != null)
                        __ctx1__.UnrefMessage(__ctx1__.__CryptoReport);
                    __ctx1__.__CryptoReport = __CryptoReport;
                    __ctx1__.RefMessage(__ctx1__.__CryptoReport);
                }
                __ctx1__.__CryptoReport.ConstructionCompleteEvent(true);
                if ( !PostProgressInc( __seg__, __ctx__, 3 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 3;
            case 3:
                if ( !PreProgressInc( __seg__, __ctx__, 4 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                {
                    Microsoft.XLANGs.RuntimeTypes.EventData __edata = new Microsoft.XLANGs.RuntimeTypes.EventData(Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Construct);
                    __edata.Messages.Add(__ctx1__.__CryptoReport);
                    __edata.Messages.Add(__ctx1__.__Crypto);
                    Tracker.FireEvent(__eventLocations[6],__edata,_stateMgrs[2].TrackDataStream );
                }
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 4;
            case 4:
                if ( !PreProgressInc( __seg__, __ctx__, 5 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[7],__eventData[4],_stateMgrs[2].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 5;
            case 5:
                if (!__ctx2__.PrepareToPendingCommit(__seg__))
                    return Microsoft.XLANGs.Core.StopConditions.Blocked;
                if ( !PostProgressInc( __seg__, __ctx__, 6 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 6;
            case 6:
                if ( !PreProgressInc( __seg__, __ctx__, 7 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Port_2.SendMessage(0, __ctx1__.__CryptoReport, null, null, __ctx2__, __seg__ , Microsoft.XLANGs.Core.ActivityFlags.NextActivityPersists );
                if ((stopOn & Microsoft.XLANGs.Core.StopConditions.OutgoingRqst) != 0)
                    return Microsoft.XLANGs.Core.StopConditions.OutgoingRqst;
                goto case 7;
            case 7:
                if ( !PreProgressInc( __seg__, __ctx__, 8 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                {
                    Microsoft.XLANGs.RuntimeTypes.EventData __edata = new Microsoft.XLANGs.RuntimeTypes.EventData(Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Send);
                    __edata.Messages.Add(__ctx1__.__CryptoReport);
                    __edata.PortName = @"Port_2";
                    Tracker.FireEvent(__eventLocations[8],__edata,_stateMgrs[2].TrackDataStream );
                }
                if (__ctx1__ != null && __ctx1__.__CryptoReport != null)
                {
                    __ctx1__.UnrefMessage(__ctx1__.__CryptoReport);
                    __ctx1__.__CryptoReport = null;
                }
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 8;
            case 8:
                if (!__ctx2__.CleanupAndPrepareToCommit(__seg__))
                    return Microsoft.XLANGs.Core.StopConditions.Blocked;
                if ( !PostProgressInc( __seg__, __ctx__, 9 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 9;
            case 9:
                if ( !PreProgressInc( __seg__, __ctx__, 10 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                __ctx2__.OnCommit();
                goto case 10;
            case 10:
                __seg__.SegmentDone();
                _segments[1].PredecessorDone(this);
                break;
            }
            return Microsoft.XLANGs.Core.StopConditions.Completed;
        }

        public Microsoft.XLANGs.Core.StopConditions segment3(Microsoft.XLANGs.Core.StopConditions stopOn)
        {
            Microsoft.XLANGs.Core.Segment __seg__ = _segments[3];
            Microsoft.XLANGs.Core.Context __ctx__ = (Microsoft.XLANGs.Core.Context)_stateMgrs[2];
            __CrytpoReport_1 __ctx1__ = (__CrytpoReport_1)_stateMgrs[1];
            ____scope33_2 __ctx2__ = (____scope33_2)_stateMgrs[2];
            __CrytpoReport_root_0 __ctx0__ = (__CrytpoReport_root_0)_stateMgrs[0];

            switch (__seg__.Progress)
            {
            case 0:
                OnBeginCatchHandler(2);
                if ( !PostProgressInc( __seg__, __ctx__, 1 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 1;
            case 1:
                if ( !PreProgressInc( __seg__, __ctx__, 2 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[9],__eventData[5],_stateMgrs[2].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 2;
            case 2:
                if ( !PreProgressInc( __seg__, __ctx__, 3 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[10],__eventData[3],_stateMgrs[2].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 3;
            case 3:
                {
                    __messagetype_BiztlakAISMigration_Errors __ErrorMsg = new __messagetype_BiztlakAISMigration_Errors("ErrorMsg", __ctx1__);

                    ApplyTransform(typeof(BiztlakAISMigration.CryptoTransaction2Errors), new object[] {__ErrorMsg.part}, new object[] {__ctx1__.__Crypto.part});

                    if (__ctx1__.__ErrorMsg != null)
                        __ctx1__.UnrefMessage(__ctx1__.__ErrorMsg);
                    __ctx1__.__ErrorMsg = __ErrorMsg;
                    __ctx1__.RefMessage(__ctx1__.__ErrorMsg);
                }
                __ctx1__.__ErrorMsg.ConstructionCompleteEvent(true);
                if ( !PostProgressInc( __seg__, __ctx__, 4 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 4;
            case 4:
                if ( !PreProgressInc( __seg__, __ctx__, 5 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                {
                    Microsoft.XLANGs.RuntimeTypes.EventData __edata = new Microsoft.XLANGs.RuntimeTypes.EventData(Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Construct);
                    __edata.Messages.Add(__ctx1__.__ErrorMsg);
                    __edata.Messages.Add(__ctx1__.__Crypto);
                    Tracker.FireEvent(__eventLocations[11],__edata,_stateMgrs[2].TrackDataStream );
                }
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 5;
            case 5:
                if ( !PreProgressInc( __seg__, __ctx__, 6 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[12],__eventData[4],_stateMgrs[2].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 6;
            case 6:
                if (!__ctx2__.PrepareToPendingCommit(__seg__))
                    return Microsoft.XLANGs.Core.StopConditions.Blocked;
                if ( !PostProgressInc( __seg__, __ctx__, 7 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                goto case 7;
            case 7:
                if ( !PreProgressInc( __seg__, __ctx__, 8 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Errori.SendMessage(0, __ctx1__.__ErrorMsg, null, null, __ctx2__, __seg__ , Microsoft.XLANGs.Core.ActivityFlags.None );
                if ((stopOn & Microsoft.XLANGs.Core.StopConditions.OutgoingRqst) != 0)
                    return Microsoft.XLANGs.Core.StopConditions.OutgoingRqst;
                goto case 8;
            case 8:
                if ( !PreProgressInc( __seg__, __ctx__, 9 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                {
                    Microsoft.XLANGs.RuntimeTypes.EventData __edata = new Microsoft.XLANGs.RuntimeTypes.EventData(Microsoft.XLANGs.RuntimeTypes.Operation.End | Microsoft.XLANGs.RuntimeTypes.Operation.Send);
                    __edata.Messages.Add(__ctx1__.__ErrorMsg);
                    __edata.PortName = @"Errori";
                    Tracker.FireEvent(__eventLocations[13],__edata,_stateMgrs[2].TrackDataStream );
                }
                if (__ctx1__ != null && __ctx1__.__ErrorMsg != null)
                {
                    __ctx1__.UnrefMessage(__ctx1__.__ErrorMsg);
                    __ctx1__.__ErrorMsg = null;
                }
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 9;
            case 9:
                if ( !PreProgressInc( __seg__, __ctx__, 10 ) )
                    return Microsoft.XLANGs.Core.StopConditions.Paused;
                Tracker.FireEvent(__eventLocations[14],__eventData[6],_stateMgrs[2].TrackDataStream );
                if (IsDebugged)
                    return Microsoft.XLANGs.Core.StopConditions.InBreakpoint;
                goto case 10;
            case 10:
                __ctx2__.__exv__ = null;
                OnEndCatchHandler(2, __seg__);
                __seg__.SegmentDone();
                break;
            }
            return Microsoft.XLANGs.Core.StopConditions.Completed;
        }
    }

    [System.SerializableAttribute]
    sealed public class __BiztlakAISMigration_CryptoTransaction__ : Microsoft.XLANGs.Core.XSDPart
    {
        private static BiztlakAISMigration.CryptoTransaction _schema = new BiztlakAISMigration.CryptoTransaction();

        public __BiztlakAISMigration_CryptoTransaction__(Microsoft.XLANGs.Core.XMessage msg, string name, int index) : base(msg, name, index) { }

        
        #region part reflection support
        public static Microsoft.XLANGs.BaseTypes.SchemaBase PartSchema { get { return (Microsoft.XLANGs.BaseTypes.SchemaBase)_schema; } }
        #endregion // part reflection support
    }

    [Microsoft.XLANGs.BaseTypes.MessageTypeAttribute(
        Microsoft.XLANGs.BaseTypes.EXLangSAccess.ePublic,
        Microsoft.XLANGs.BaseTypes.EXLangSMessageInfo.eThirdKind,
        "BiztlakAISMigration.CryptoTransaction",
        new System.Type[]{
            typeof(BiztlakAISMigration.CryptoTransaction)
        },
        new string[]{
            "part"
        },
        new System.Type[]{
            typeof(__BiztlakAISMigration_CryptoTransaction__)
        },
        0,
        @"CryptoTransactions"
    )]
    [System.SerializableAttribute]
    sealed public class __messagetype_BiztlakAISMigration_CryptoTransaction : Microsoft.BizTalk.XLANGs.BTXEngine.BTXMessage
    {
        public __BiztlakAISMigration_CryptoTransaction__ part;

        private void __CreatePartWrappers()
        {
            part = new __BiztlakAISMigration_CryptoTransaction__(this, "part", 0);
            this.AddPart("part", 0, part);
        }

        public __messagetype_BiztlakAISMigration_CryptoTransaction(string msgName, Microsoft.XLANGs.Core.Context ctx) : base(msgName, ctx)
        {
            __CreatePartWrappers();
        }
    }

    [System.SerializableAttribute]
    sealed public class __BiztlakAISMigration_BlockchainReport__ : Microsoft.XLANGs.Core.XSDPart
    {
        private static BiztlakAISMigration.BlockchainReport _schema = new BiztlakAISMigration.BlockchainReport();

        public __BiztlakAISMigration_BlockchainReport__(Microsoft.XLANGs.Core.XMessage msg, string name, int index) : base(msg, name, index) { }

        
        #region part reflection support
        public static Microsoft.XLANGs.BaseTypes.SchemaBase PartSchema { get { return (Microsoft.XLANGs.BaseTypes.SchemaBase)_schema; } }
        #endregion // part reflection support
    }

    [Microsoft.XLANGs.BaseTypes.MessageTypeAttribute(
        Microsoft.XLANGs.BaseTypes.EXLangSAccess.ePublic,
        Microsoft.XLANGs.BaseTypes.EXLangSMessageInfo.eThirdKind,
        "BiztlakAISMigration.BlockchainReport",
        new System.Type[]{
            typeof(BiztlakAISMigration.BlockchainReport)
        },
        new string[]{
            "part"
        },
        new System.Type[]{
            typeof(__BiztlakAISMigration_BlockchainReport__)
        },
        0,
        @"BlockchainReport"
    )]
    [System.SerializableAttribute]
    sealed public class __messagetype_BiztlakAISMigration_BlockchainReport : Microsoft.BizTalk.XLANGs.BTXEngine.BTXMessage
    {
        public __BiztlakAISMigration_BlockchainReport__ part;

        private void __CreatePartWrappers()
        {
            part = new __BiztlakAISMigration_BlockchainReport__(this, "part", 0);
            this.AddPart("part", 0, part);
        }

        public __messagetype_BiztlakAISMigration_BlockchainReport(string msgName, Microsoft.XLANGs.Core.Context ctx) : base(msgName, ctx)
        {
            __CreatePartWrappers();
        }
    }

    [System.SerializableAttribute]
    sealed public class __BiztlakAISMigration_Errors__ : Microsoft.XLANGs.Core.XSDPart
    {
        private static BiztlakAISMigration.Errors _schema = new BiztlakAISMigration.Errors();

        public __BiztlakAISMigration_Errors__(Microsoft.XLANGs.Core.XMessage msg, string name, int index) : base(msg, name, index) { }

        
        #region part reflection support
        public static Microsoft.XLANGs.BaseTypes.SchemaBase PartSchema { get { return (Microsoft.XLANGs.BaseTypes.SchemaBase)_schema; } }
        #endregion // part reflection support
    }

    [Microsoft.XLANGs.BaseTypes.MessageTypeAttribute(
        Microsoft.XLANGs.BaseTypes.EXLangSAccess.ePublic,
        Microsoft.XLANGs.BaseTypes.EXLangSMessageInfo.eThirdKind,
        "BiztlakAISMigration.Errors",
        new System.Type[]{
            typeof(BiztlakAISMigration.Errors)
        },
        new string[]{
            "part"
        },
        new System.Type[]{
            typeof(__BiztlakAISMigration_Errors__)
        },
        0,
        @"http://example.com/Errors#Errors"
    )]
    [System.SerializableAttribute]
    sealed public class __messagetype_BiztlakAISMigration_Errors : Microsoft.BizTalk.XLANGs.BTXEngine.BTXMessage
    {
        public __BiztlakAISMigration_Errors__ part;

        private void __CreatePartWrappers()
        {
            part = new __BiztlakAISMigration_Errors__(this, "part", 0);
            this.AddPart("part", 0, part);
        }

        public __messagetype_BiztlakAISMigration_Errors(string msgName, Microsoft.XLANGs.Core.Context ctx) : base(msgName, ctx)
        {
            __CreatePartWrappers();
        }
    }

    [Microsoft.XLANGs.BaseTypes.BPELExportableAttribute(false)]
    sealed public class _MODULE_PROXY_ { }
}

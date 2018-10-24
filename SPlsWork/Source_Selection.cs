using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_SOURCE_SELECTION
{
    public class UserModuleClass_SOURCE_SELECTION : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SELECTSOURCE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SOURCEHOSTNAME;
        Crestron.Logos.SplusObjects.AnalogOutput SELECTEDSOURCE;
        Crestron.Logos.SplusObjects.AnalogOutput SELECTEDCLASS;
        Crestron.Logos.SplusObjects.AnalogOutput SELECTEDTYPE;
        InOutArray<StringParameter> HOSTNAME;
        private void READHOSTNAMES (  SplusExecutionContext __context__ ) 
            { 
            ushort LOOP = 0;
            
            CrestronString TEMPHOSTNAME;
            TEMPHOSTNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 59;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)100; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( LOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (LOOP  >= __FN_FORSTART_VAL__1) && (LOOP  <= __FN_FOREND_VAL__1) ) : ( (LOOP  <= __FN_FORSTART_VAL__1) && (LOOP  >= __FN_FOREND_VAL__1) ) ; LOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 61;
                TEMPHOSTNAME  .UpdateValue ( _SplusNVRAM.SOURCE [ LOOP] . HOSTNAME  ) ; 
                __context__.SourceCodeLine = 62;
                _SplusNVRAM.SOURCE [ LOOP] . HOSTNAME  .UpdateValue ( SOURCEHOSTNAME [ LOOP ]  ) ; 
                __context__.SourceCodeLine = 65;
                if ( Functions.TestForTrue  ( ( Functions.Find( "WKSTN" , TEMPHOSTNAME ))  ) ) 
                    {
                    __context__.SourceCodeLine = 65;
                    _SplusNVRAM.SOURCE [ LOOP] . TYPE = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 66;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "VTC" , TEMPHOSTNAME ))  ) ) 
                        {
                        __context__.SourceCodeLine = 66;
                        _SplusNVRAM.SOURCE [ LOOP] . TYPE = (ushort) ( 2 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 67;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "BLURAY" , TEMPHOSTNAME ) ) || Functions.TestForTrue ( Functions.Find( "TUNER" , TEMPHOSTNAME ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 67;
                            _SplusNVRAM.SOURCE [ LOOP] . TYPE = (ushort) ( 4 ) ; 
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 70;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.SOURCE[ LOOP ].TYPE == 4))  ) ) 
                    {
                    __context__.SourceCodeLine = 70;
                    _SplusNVRAM.SOURCE [ LOOP] . CLASSIFICATION = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 71;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "SBU" , TEMPHOSTNAME ))  ) ) 
                        {
                        __context__.SourceCodeLine = 71;
                        _SplusNVRAM.SOURCE [ LOOP] . CLASSIFICATION = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 72;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "SEC" , TEMPHOSTNAME ))  ) ) 
                            {
                            __context__.SourceCodeLine = 72;
                            _SplusNVRAM.SOURCE [ LOOP] . CLASSIFICATION = (ushort) ( 2 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 73;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "COAL" , TEMPHOSTNAME ))  ) ) 
                                {
                                __context__.SourceCodeLine = 73;
                                _SplusNVRAM.SOURCE [ LOOP] . CLASSIFICATION = (ushort) ( 3 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 74;
                                if ( Functions.TestForTrue  ( ( Functions.Find( "TS" , TEMPHOSTNAME ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 74;
                                    _SplusNVRAM.SOURCE [ LOOP] . CLASSIFICATION = (ushort) ( 4 ) ; 
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 59;
                } 
            
            
            }
            
        object SOURCEHOSTNAME_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 80;
                READHOSTNAMES (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SELECTSOURCE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            ushort LOOP = 0;
            
            
            __context__.SourceCodeLine = 86;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 87;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)100; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( LOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (LOOP  >= __FN_FORSTART_VAL__1) && (LOOP  <= __FN_FOREND_VAL__1) ) : ( (LOOP  <= __FN_FORSTART_VAL__1) && (LOOP  >= __FN_FOREND_VAL__1) ) ; LOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 89;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.SOURCE[ LOOP ].HOSTNAME == HOSTNAME[ I ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 91;
                    SELECTEDSOURCE  .Value = (ushort) ( LOOP ) ; 
                    __context__.SourceCodeLine = 92;
                    SELECTEDCLASS  .Value = (ushort) ( _SplusNVRAM.SOURCE[ LOOP ].CLASSIFICATION ) ; 
                    __context__.SourceCodeLine = 93;
                    SELECTEDTYPE  .Value = (ushort) ( _SplusNVRAM.SOURCE[ LOOP ].TYPE ) ; 
                    __context__.SourceCodeLine = 94;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 87;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 101;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 102;
        READHOSTNAMES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.SOURCE  = new STSOURCE[ 101 ];
    for( uint i = 0; i < 101; i++ )
    {
        _SplusNVRAM.SOURCE [i] = new STSOURCE( this, false );
        
    }
    
    SELECTSOURCE = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        SELECTSOURCE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SELECTSOURCE__DigitalInput__ + i, SELECTSOURCE__DigitalInput__, this );
        m_DigitalInputList.Add( SELECTSOURCE__DigitalInput__ + i, SELECTSOURCE[i+1] );
    }
    
    SELECTEDSOURCE = new Crestron.Logos.SplusObjects.AnalogOutput( SELECTEDSOURCE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SELECTEDSOURCE__AnalogSerialOutput__, SELECTEDSOURCE );
    
    SELECTEDCLASS = new Crestron.Logos.SplusObjects.AnalogOutput( SELECTEDCLASS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SELECTEDCLASS__AnalogSerialOutput__, SELECTEDCLASS );
    
    SELECTEDTYPE = new Crestron.Logos.SplusObjects.AnalogOutput( SELECTEDTYPE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SELECTEDTYPE__AnalogSerialOutput__, SELECTEDTYPE );
    
    SOURCEHOSTNAME = new InOutArray<StringInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        SOURCEHOSTNAME[i+1] = new Crestron.Logos.SplusObjects.StringInput( SOURCEHOSTNAME__AnalogSerialInput__ + i, SOURCEHOSTNAME__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( SOURCEHOSTNAME__AnalogSerialInput__ + i, SOURCEHOSTNAME[i+1] );
    }
    
    HOSTNAME = new InOutArray<StringParameter>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        HOSTNAME[i+1] = new StringParameter( HOSTNAME__Parameter__ + i, HOSTNAME__Parameter__, this );
        m_ParameterList.Add( HOSTNAME__Parameter__ + i, HOSTNAME[i+1] );
    }
    
    
    for( uint i = 0; i < 100; i++ )
        SOURCEHOSTNAME[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( SOURCEHOSTNAME_OnChange_0, false ) );
        
    for( uint i = 0; i < 100; i++ )
        SELECTSOURCE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTSOURCE_OnPush_1, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SOURCE_SELECTION ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SELECTSOURCE__DigitalInput__ = 0;
const uint SOURCEHOSTNAME__AnalogSerialInput__ = 0;
const uint SELECTEDSOURCE__AnalogSerialOutput__ = 0;
const uint SELECTEDCLASS__AnalogSerialOutput__ = 1;
const uint SELECTEDTYPE__AnalogSerialOutput__ = 2;
const uint HOSTNAME__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, true, true)]
            public STSOURCE [] SOURCE;
            
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}

[SplusStructAttribute(-1, true, false)]
public class STSOURCE : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  CLASSIFICATION = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  TYPE = 0;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  HOSTNAME;
    
    
    public STSOURCE( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        HOSTNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, Owner );
        
        
    }
    
}

}

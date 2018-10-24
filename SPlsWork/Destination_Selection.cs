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

namespace UserModule_DESTINATION_SELECTION
{
    public class UserModuleClass_DESTINATION_SELECTION : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ROUTEDESTINATION;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDSOURCE;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDCLASS;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDTYPE;
        Crestron.Logos.SplusObjects.AnalogInput ROOMCLASS;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DESTHOSTNAME;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VIDEOSOURCE;
        InOutArray<StringParameter> HOSTNAME;
        private void READHOSTNAMES (  SplusExecutionContext __context__ ) 
            { 
            ushort LOOP = 0;
            
            CrestronString TEMPHOSTNAME;
            TEMPHOSTNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 62;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)100; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( LOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (LOOP  >= __FN_FORSTART_VAL__1) && (LOOP  <= __FN_FOREND_VAL__1) ) : ( (LOOP  <= __FN_FORSTART_VAL__1) && (LOOP  >= __FN_FOREND_VAL__1) ) ; LOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 64;
                TEMPHOSTNAME  .UpdateValue ( _SplusNVRAM.DEST [ LOOP] . HOSTNAME  ) ; 
                __context__.SourceCodeLine = 65;
                _SplusNVRAM.DEST [ LOOP] . HOSTNAME  .UpdateValue ( DESTHOSTNAME [ LOOP ]  ) ; 
                __context__.SourceCodeLine = 68;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "DISP" , TEMPHOSTNAME ) ) || Functions.TestForTrue ( Functions.Find( "AUD" , TEMPHOSTNAME ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 68;
                    _SplusNVRAM.DEST [ LOOP] . TYPE = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 69;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "VTC_CAM" , TEMPHOSTNAME ))  ) ) 
                        {
                        __context__.SourceCodeLine = 69;
                        _SplusNVRAM.DEST [ LOOP] . TYPE = (ushort) ( 2 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 70;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "VTC_CON" , TEMPHOSTNAME ))  ) ) 
                            {
                            __context__.SourceCodeLine = 70;
                            _SplusNVRAM.DEST [ LOOP] . TYPE = (ushort) ( 3 ) ; 
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 73;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.DEST[ LOOP ].TYPE == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 73;
                    _SplusNVRAM.DEST [ LOOP] . CLASSIFICATION = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 74;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "SBU" , TEMPHOSTNAME ))  ) ) 
                        {
                        __context__.SourceCodeLine = 74;
                        _SplusNVRAM.DEST [ LOOP] . CLASSIFICATION = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 75;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "SEC" , TEMPHOSTNAME ))  ) ) 
                            {
                            __context__.SourceCodeLine = 75;
                            _SplusNVRAM.DEST [ LOOP] . CLASSIFICATION = (ushort) ( 2 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 76;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "COAL" , TEMPHOSTNAME ))  ) ) 
                                {
                                __context__.SourceCodeLine = 76;
                                _SplusNVRAM.DEST [ LOOP] . CLASSIFICATION = (ushort) ( 3 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 77;
                                if ( Functions.TestForTrue  ( ( Functions.Find( "TS" , TEMPHOSTNAME ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 77;
                                    _SplusNVRAM.DEST [ LOOP] . CLASSIFICATION = (ushort) ( 4 ) ; 
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 62;
                } 
            
            
            }
            
        object ROUTEDESTINATION_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                ushort LOOP = 0;
                ushort SELECTED = 0;
                
                
                __context__.SourceCodeLine = 85;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 87;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)100; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( LOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (LOOP  >= __FN_FORSTART_VAL__1) && (LOOP  <= __FN_FOREND_VAL__1) ) : ( (LOOP  <= __FN_FORSTART_VAL__1) && (LOOP  >= __FN_FOREND_VAL__1) ) ; LOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 89;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HOSTNAME[ I ] == _SplusNVRAM.DEST[ LOOP ].HOSTNAME))  ) ) 
                        { 
                        __context__.SourceCodeLine = 91;
                        SELECTED = (ushort) ( LOOP ) ; 
                        __context__.SourceCodeLine = 92;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 87;
                    } 
                
                __context__.SourceCodeLine = 97;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.DEST[ SELECTED ].TYPE == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 99;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SELECTEDTYPE  .UshortValue == 2) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .UshortValue == SELECTEDCLASS  .UshortValue) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 99;
                        VIDEOSOURCE [ SELECTED]  .Value = (ushort) ( SELECTEDSOURCE  .UshortValue ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 100;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SELECTEDTYPE  .UshortValue == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( ROOMCLASS  .UshortValue >= SELECTEDCLASS  .UshortValue ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 100;
                            VIDEOSOURCE [ SELECTED]  .Value = (ushort) ( SELECTEDSOURCE  .UshortValue ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 101;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SELECTEDTYPE  .UshortValue == 4))  ) ) 
                                {
                                __context__.SourceCodeLine = 101;
                                VIDEOSOURCE [ SELECTED]  .Value = (ushort) ( SELECTEDSOURCE  .UshortValue ) ; 
                                }
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 105;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.DEST[ SELECTED ].TYPE == 2))  ) ) 
                        { 
                        __context__.SourceCodeLine = 107;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SELECTEDTYPE  .UshortValue == 3) ) && Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .UshortValue == _SplusNVRAM.DEST[ SELECTED ].CLASSIFICATION) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 107;
                            VIDEOSOURCE [ SELECTED]  .Value = (ushort) ( SELECTEDSOURCE  .UshortValue ) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 111;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.DEST[ SELECTED ].TYPE == 3))  ) ) 
                            { 
                            __context__.SourceCodeLine = 113;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SELECTEDTYPE  .UshortValue == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.BoolToInt ( 1 <= SELECTEDCLASS  .UshortValue ) <= _SplusNVRAM.DEST[ SELECTED ].CLASSIFICATION ) )) ))  ) ) 
                                {
                                __context__.SourceCodeLine = 113;
                                VIDEOSOURCE [ SELECTED]  .Value = (ushort) ( SELECTEDSOURCE  .UshortValue ) ; 
                                }
                            
                            } 
                        
                        }
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DESTHOSTNAME_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 119;
            READHOSTNAMES (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.DEST  = new STDEST[ 101 ];
    for( uint i = 0; i < 101; i++ )
    {
        _SplusNVRAM.DEST [i] = new STDEST( this, false );
        
    }
    
    ROUTEDESTINATION = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        ROUTEDESTINATION[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ROUTEDESTINATION__DigitalInput__ + i, ROUTEDESTINATION__DigitalInput__, this );
        m_DigitalInputList.Add( ROUTEDESTINATION__DigitalInput__ + i, ROUTEDESTINATION[i+1] );
    }
    
    SELECTEDSOURCE = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDSOURCE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SELECTEDSOURCE__AnalogSerialInput__, SELECTEDSOURCE );
    
    SELECTEDCLASS = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDCLASS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SELECTEDCLASS__AnalogSerialInput__, SELECTEDCLASS );
    
    SELECTEDTYPE = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDTYPE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SELECTEDTYPE__AnalogSerialInput__, SELECTEDTYPE );
    
    ROOMCLASS = new Crestron.Logos.SplusObjects.AnalogInput( ROOMCLASS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( ROOMCLASS__AnalogSerialInput__, ROOMCLASS );
    
    VIDEOSOURCE = new InOutArray<AnalogOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        VIDEOSOURCE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VIDEOSOURCE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( VIDEOSOURCE__AnalogSerialOutput__ + i, VIDEOSOURCE[i+1] );
    }
    
    DESTHOSTNAME = new InOutArray<StringInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        DESTHOSTNAME[i+1] = new Crestron.Logos.SplusObjects.StringInput( DESTHOSTNAME__AnalogSerialInput__ + i, DESTHOSTNAME__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( DESTHOSTNAME__AnalogSerialInput__ + i, DESTHOSTNAME[i+1] );
    }
    
    HOSTNAME = new InOutArray<StringParameter>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        HOSTNAME[i+1] = new StringParameter( HOSTNAME__Parameter__ + i, HOSTNAME__Parameter__, this );
        m_ParameterList.Add( HOSTNAME__Parameter__ + i, HOSTNAME[i+1] );
    }
    
    
    for( uint i = 0; i < 100; i++ )
        ROUTEDESTINATION[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTEDESTINATION_OnPush_0, false ) );
        
    for( uint i = 0; i < 100; i++ )
        DESTHOSTNAME[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DESTHOSTNAME_OnChange_1, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_DESTINATION_SELECTION ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ROUTEDESTINATION__DigitalInput__ = 0;
const uint SELECTEDSOURCE__AnalogSerialInput__ = 0;
const uint SELECTEDCLASS__AnalogSerialInput__ = 1;
const uint SELECTEDTYPE__AnalogSerialInput__ = 2;
const uint ROOMCLASS__AnalogSerialInput__ = 3;
const uint DESTHOSTNAME__AnalogSerialInput__ = 4;
const uint VIDEOSOURCE__AnalogSerialOutput__ = 0;
const uint HOSTNAME__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, true, true)]
            public STDEST [] DEST;
            
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
public class STDEST : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  XIO = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  CLASSIFICATION = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  TYPE = 0;
    
    [SplusStructAttribute(3, false, false)]
    public CrestronString  HOSTNAME;
    
    
    public STDEST( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        HOSTNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, Owner );
        
        
    }
    
}

}

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

namespace UserModule_SELECT_INCOMING_SHARES
{
    public class UserModuleClass_SELECT_INCOMING_SHARES : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SELECTSHARE;
        Crestron.Logos.SplusObjects.AnalogInput ROOMCLASS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INCOMINGSOURCE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INCOMINGCLASS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> INCOMINGTYPE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ENABLESHARE;
        Crestron.Logos.SplusObjects.AnalogOutput SELECTEDSOURCE;
        Crestron.Logos.SplusObjects.AnalogOutput SELECTEDCLASS;
        Crestron.Logos.SplusObjects.AnalogOutput SELECTEDTYPE;
        private void CHECKSHAREENABLE (  SplusExecutionContext __context__, ushort _SHARE ) 
            { 
            
            __context__.SourceCodeLine = 33;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (INCOMINGTYPE[ _SHARE ] .UshortValue == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (INCOMINGTYPE[ _SHARE ] .UshortValue == 3) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 35;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOMCLASS  .UshortValue == INCOMINGCLASS[ _SHARE ] .UshortValue))  ) ) 
                    {
                    __context__.SourceCodeLine = 35;
                    ENABLESHARE [ _SHARE]  .Value = (ushort) ( 1 ) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 37;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ROOMCLASS  .UshortValue >= INCOMINGCLASS[ _SHARE ] .UshortValue ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 39;
                    ENABLESHARE [ _SHARE]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 40;
                    ENABLESHARE [ _SHARE]  .Value = (ushort) ( 0 ) ; 
                    }
                
                }
            
            
            }
            
        object ROOMCLASS_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort LOOP = 0;
                
                
                __context__.SourceCodeLine = 46;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)100; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( LOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (LOOP  >= __FN_FORSTART_VAL__1) && (LOOP  <= __FN_FOREND_VAL__1) ) : ( (LOOP  <= __FN_FORSTART_VAL__1) && (LOOP  >= __FN_FOREND_VAL__1) ) ; LOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 48;
                    CHECKSHAREENABLE (  __context__ , (ushort)( LOOP )) ; 
                    __context__.SourceCodeLine = 46;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object INCOMINGSOURCE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 55;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 56;
            CHECKSHAREENABLE (  __context__ , (ushort)( I )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SELECTSHARE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 62;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 63;
        SELECTEDSOURCE  .Value = (ushort) ( INCOMINGSOURCE[ I ] .UshortValue ) ; 
        __context__.SourceCodeLine = 64;
        SELECTEDCLASS  .Value = (ushort) ( INCOMINGCLASS[ I ] .UshortValue ) ; 
        __context__.SourceCodeLine = 65;
        SELECTEDTYPE  .Value = (ushort) ( INCOMINGTYPE[ I ] .UshortValue ) ; 
        
        
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
    
    SELECTSHARE = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        SELECTSHARE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SELECTSHARE__DigitalInput__ + i, SELECTSHARE__DigitalInput__, this );
        m_DigitalInputList.Add( SELECTSHARE__DigitalInput__ + i, SELECTSHARE[i+1] );
    }
    
    ENABLESHARE = new InOutArray<DigitalOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        ENABLESHARE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESHARE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ENABLESHARE__DigitalOutput__ + i, ENABLESHARE[i+1] );
    }
    
    ROOMCLASS = new Crestron.Logos.SplusObjects.AnalogInput( ROOMCLASS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( ROOMCLASS__AnalogSerialInput__, ROOMCLASS );
    
    INCOMINGSOURCE = new InOutArray<AnalogInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        INCOMINGSOURCE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( INCOMINGSOURCE__AnalogSerialInput__ + i, INCOMINGSOURCE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INCOMINGSOURCE__AnalogSerialInput__ + i, INCOMINGSOURCE[i+1] );
    }
    
    INCOMINGCLASS = new InOutArray<AnalogInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        INCOMINGCLASS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( INCOMINGCLASS__AnalogSerialInput__ + i, INCOMINGCLASS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INCOMINGCLASS__AnalogSerialInput__ + i, INCOMINGCLASS[i+1] );
    }
    
    INCOMINGTYPE = new InOutArray<AnalogInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        INCOMINGTYPE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( INCOMINGTYPE__AnalogSerialInput__ + i, INCOMINGTYPE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INCOMINGTYPE__AnalogSerialInput__ + i, INCOMINGTYPE[i+1] );
    }
    
    SELECTEDSOURCE = new Crestron.Logos.SplusObjects.AnalogOutput( SELECTEDSOURCE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SELECTEDSOURCE__AnalogSerialOutput__, SELECTEDSOURCE );
    
    SELECTEDCLASS = new Crestron.Logos.SplusObjects.AnalogOutput( SELECTEDCLASS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SELECTEDCLASS__AnalogSerialOutput__, SELECTEDCLASS );
    
    SELECTEDTYPE = new Crestron.Logos.SplusObjects.AnalogOutput( SELECTEDTYPE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SELECTEDTYPE__AnalogSerialOutput__, SELECTEDTYPE );
    
    
    ROOMCLASS.OnAnalogChange.Add( new InputChangeHandlerWrapper( ROOMCLASS_OnChange_0, false ) );
    for( uint i = 0; i < 100; i++ )
        INCOMINGSOURCE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( INCOMINGSOURCE_OnChange_1, false ) );
        
    for( uint i = 0; i < 100; i++ )
        SELECTSHARE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTSHARE_OnPush_2, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SELECT_INCOMING_SHARES ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SELECTSHARE__DigitalInput__ = 0;
const uint ROOMCLASS__AnalogSerialInput__ = 0;
const uint INCOMINGSOURCE__AnalogSerialInput__ = 1;
const uint INCOMINGCLASS__AnalogSerialInput__ = 101;
const uint INCOMINGTYPE__AnalogSerialInput__ = 201;
const uint ENABLESHARE__DigitalOutput__ = 0;
const uint SELECTEDSOURCE__AnalogSerialOutput__ = 0;
const uint SELECTEDCLASS__AnalogSerialOutput__ = 1;
const uint SELECTEDTYPE__AnalogSerialOutput__ = 2;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
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


}

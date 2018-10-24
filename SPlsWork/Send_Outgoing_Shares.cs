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

namespace UserModule_SEND_OUTGOING_SHARES
{
    public class UserModuleClass_SEND_OUTGOING_SHARES : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SENDTOSHARE;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDSOURCE;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDCLASS;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDTYPE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> OUTGOINGSOURCE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> OUTGOINGCLASS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> OUTGOINGTYPE;
        object SENDTOSHARE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 20;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 22;
                OUTGOINGSOURCE [ I]  .Value = (ushort) ( SELECTEDSOURCE  .UshortValue ) ; 
                __context__.SourceCodeLine = 23;
                OUTGOINGCLASS [ I]  .Value = (ushort) ( SELECTEDCLASS  .UshortValue ) ; 
                __context__.SourceCodeLine = 24;
                OUTGOINGTYPE [ I]  .Value = (ushort) ( SELECTEDTYPE  .UshortValue ) ; 
                
                
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
        
        SENDTOSHARE = new InOutArray<DigitalInput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            SENDTOSHARE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SENDTOSHARE__DigitalInput__ + i, SENDTOSHARE__DigitalInput__, this );
            m_DigitalInputList.Add( SENDTOSHARE__DigitalInput__ + i, SENDTOSHARE[i+1] );
        }
        
        SELECTEDSOURCE = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDSOURCE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( SELECTEDSOURCE__AnalogSerialInput__, SELECTEDSOURCE );
        
        SELECTEDCLASS = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDCLASS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( SELECTEDCLASS__AnalogSerialInput__, SELECTEDCLASS );
        
        SELECTEDTYPE = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDTYPE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( SELECTEDTYPE__AnalogSerialInput__, SELECTEDTYPE );
        
        OUTGOINGSOURCE = new InOutArray<AnalogOutput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            OUTGOINGSOURCE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( OUTGOINGSOURCE__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( OUTGOINGSOURCE__AnalogSerialOutput__ + i, OUTGOINGSOURCE[i+1] );
        }
        
        OUTGOINGCLASS = new InOutArray<AnalogOutput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            OUTGOINGCLASS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( OUTGOINGCLASS__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( OUTGOINGCLASS__AnalogSerialOutput__ + i, OUTGOINGCLASS[i+1] );
        }
        
        OUTGOINGTYPE = new InOutArray<AnalogOutput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            OUTGOINGTYPE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( OUTGOINGTYPE__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( OUTGOINGTYPE__AnalogSerialOutput__ + i, OUTGOINGTYPE[i+1] );
        }
        
        
        for( uint i = 0; i < 100; i++ )
            SENDTOSHARE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SENDTOSHARE_OnPush_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_SEND_OUTGOING_SHARES ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint SENDTOSHARE__DigitalInput__ = 0;
    const uint SELECTEDSOURCE__AnalogSerialInput__ = 0;
    const uint SELECTEDCLASS__AnalogSerialInput__ = 1;
    const uint SELECTEDTYPE__AnalogSerialInput__ = 2;
    const uint OUTGOINGSOURCE__AnalogSerialOutput__ = 0;
    const uint OUTGOINGCLASS__AnalogSerialOutput__ = 100;
    const uint OUTGOINGTYPE__AnalogSerialOutput__ = 200;
    
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

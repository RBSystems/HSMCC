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

namespace UserModule_ENDPOINT_CONFIGURATIONS
{
    public class UserModuleClass_ENDPOINT_CONFIGURATIONS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SOURCEHOSTNAME;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DESTHOSTNAME;
        Crestron.Logos.SplusObjects.DigitalOutput FILEUPDATED;
        
        public override void LogosSplusInitialize()
        {
            SocketInfo __socketinfo__ = new SocketInfo( 1, this );
            InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
            _SplusNVRAM = new SplusNVRAM( this );
            
            FILEUPDATED = new Crestron.Logos.SplusObjects.DigitalOutput( FILEUPDATED__DigitalOutput__, this );
            m_DigitalOutputList.Add( FILEUPDATED__DigitalOutput__, FILEUPDATED );
            
            SOURCEHOSTNAME = new InOutArray<StringInput>( 128, this );
            for( uint i = 0; i < 128; i++ )
            {
                SOURCEHOSTNAME[i+1] = new Crestron.Logos.SplusObjects.StringInput( SOURCEHOSTNAME__AnalogSerialInput__ + i, SOURCEHOSTNAME__AnalogSerialInput__, 50, this );
                m_StringInputList.Add( SOURCEHOSTNAME__AnalogSerialInput__ + i, SOURCEHOSTNAME[i+1] );
            }
            
            DESTHOSTNAME = new InOutArray<StringInput>( 128, this );
            for( uint i = 0; i < 128; i++ )
            {
                DESTHOSTNAME[i+1] = new Crestron.Logos.SplusObjects.StringInput( DESTHOSTNAME__AnalogSerialInput__ + i, DESTHOSTNAME__AnalogSerialInput__, 50, this );
                m_StringInputList.Add( DESTHOSTNAME__AnalogSerialInput__ + i, DESTHOSTNAME[i+1] );
            }
            
            
            
            _SplusNVRAM.PopulateCustomAttributeList( true );
            
            NVRAM = _SplusNVRAM;
            
        }
        
        public override void LogosSimplSharpInitialize()
        {
            
            
        }
        
        public UserModuleClass_ENDPOINT_CONFIGURATIONS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
        
        
        
        
        const uint SOURCEHOSTNAME__AnalogSerialInput__ = 0;
        const uint DESTHOSTNAME__AnalogSerialInput__ = 128;
        const uint FILEUPDATED__DigitalOutput__ = 0;
        
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

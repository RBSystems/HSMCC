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

namespace UserModule_MULTICLASS_ROUTING
{
    public class UserModuleClass_MULTICLASS_ROUTING : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VIDEOOUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VIDEOOUTBUFF;
        InOutArray<StringParameter> OUTPUTFUNCTION;
        ENDPOINT [] SOURCE;
        ENDPOINT [] DESTINATION;
        
        public override void LogosSplusInitialize()
        {
            SocketInfo __socketinfo__ = new SocketInfo( 1, this );
            InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
            _SplusNVRAM = new SplusNVRAM( this );
            SOURCE  = new ENDPOINT[ 201 ];
            for( uint i = 0; i < 201; i++ )
            {
                SOURCE [i] = new ENDPOINT( this, true );
                SOURCE [i].PopulateCustomAttributeList( false );
                
            }
            DESTINATION  = new ENDPOINT[ 201 ];
            for( uint i = 0; i < 201; i++ )
            {
                DESTINATION [i] = new ENDPOINT( this, true );
                DESTINATION [i].PopulateCustomAttributeList( false );
                
            }
            
            VIDEOOUT = new InOutArray<AnalogInput>( 200, this );
            for( uint i = 0; i < 200; i++ )
            {
                VIDEOOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( VIDEOOUT__AnalogSerialInput__ + i, VIDEOOUT__AnalogSerialInput__, this );
                m_AnalogInputList.Add( VIDEOOUT__AnalogSerialInput__ + i, VIDEOOUT[i+1] );
            }
            
            VIDEOOUTBUFF = new InOutArray<AnalogOutput>( 200, this );
            for( uint i = 0; i < 200; i++ )
            {
                VIDEOOUTBUFF[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VIDEOOUTBUFF__AnalogSerialOutput__ + i, this );
                m_AnalogOutputList.Add( VIDEOOUTBUFF__AnalogSerialOutput__ + i, VIDEOOUTBUFF[i+1] );
            }
            
            OUTPUTFUNCTION = new InOutArray<StringParameter>( 200, this );
            for( uint i = 0; i < 200; i++ )
            {
                OUTPUTFUNCTION[i+1] = new StringParameter( OUTPUTFUNCTION__Parameter__ + i, OUTPUTFUNCTION__Parameter__, this );
                m_ParameterList.Add( OUTPUTFUNCTION__Parameter__ + i, OUTPUTFUNCTION[i+1] );
            }
            
            
            
            _SplusNVRAM.PopulateCustomAttributeList( true );
            
            NVRAM = _SplusNVRAM;
            
        }
        
        public override void LogosSimplSharpInitialize()
        {
            
            
        }
        
        public UserModuleClass_MULTICLASS_ROUTING ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
        
        
        
        
        const uint VIDEOOUT__AnalogSerialInput__ = 0;
        const uint VIDEOOUTBUFF__AnalogSerialOutput__ = 0;
        const uint OUTPUTFUNCTION__Parameter__ = 10;
        
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
    
    [SplusStructAttribute(-1, true, false)]
    public class ENDPOINT : SplusStructureBase
    {
    
        [SplusStructAttribute(0, false, false)]
        public ushort  CLASSIFICATION = 0;
        
        [SplusStructAttribute(1, false, false)]
        public ushort  TYPE = 0;
        
        
        public ENDPOINT( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
        {
            
            
        }
        
    }
    
}

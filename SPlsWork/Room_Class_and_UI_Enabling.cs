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

namespace UserModule_ROOM_CLASS_AND_UI_ENABLING
{
    public class UserModuleClass_ROOM_CLASS_AND_UI_ENABLING : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SELECTNONE;
        Crestron.Logos.SplusObjects.DigitalInput SELECTSBU;
        Crestron.Logos.SplusObjects.DigitalInput SELECTSEC;
        Crestron.Logos.SplusObjects.DigitalInput SELECTCOAL;
        Crestron.Logos.SplusObjects.DigitalInput SELECTTS;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDSOURCECLASS;
        Crestron.Logos.SplusObjects.AnalogInput SELECTEDSOURCETYPE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESBUNONVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESECNONVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLECOALNONVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLETSNONVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESBUVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESECVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLECOALVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLETSVTCSOURCE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESBUVTCCAMDESTS;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESECVTCCAMDESTS;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLECOALVTCCAMDESTS;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLETSVTCCAMDESTS;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESBUVTCCONTENTDESTS;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLESECVTCCONTENTDESTS;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLECOALVTCCONTENTDESTS;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLETSVTCCONTENTDESTS;
        Crestron.Logos.SplusObjects.AnalogOutput ROOMCLASS;
        Crestron.Logos.SplusObjects.StringOutput ROOMCLASSTEXT;
        private void SETENABLES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 64;
            ENABLESBUNONVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt ( ROOMCLASS  .Value >= 1 ) ) ; 
            __context__.SourceCodeLine = 65;
            ENABLESECNONVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt ( ROOMCLASS  .Value >= 2 ) ) ; 
            __context__.SourceCodeLine = 66;
            ENABLECOALNONVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt ( ROOMCLASS  .Value >= 3 ) ) ; 
            __context__.SourceCodeLine = 67;
            ENABLETSNONVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt ( ROOMCLASS  .Value >= 4 ) ) ; 
            __context__.SourceCodeLine = 70;
            ENABLESBUVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt (ROOMCLASS  .Value == 1) ) ; 
            __context__.SourceCodeLine = 71;
            ENABLESECVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt (ROOMCLASS  .Value == 2) ) ; 
            __context__.SourceCodeLine = 72;
            ENABLECOALVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt (ROOMCLASS  .Value == 3) ) ; 
            __context__.SourceCodeLine = 73;
            ENABLETSVTCSOURCE  .Value = (ushort) ( Functions.BoolToInt (ROOMCLASS  .Value == 4) ) ; 
            __context__.SourceCodeLine = 76;
            ENABLESBUVTCCAMDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 3) )) ) ) ; 
            __context__.SourceCodeLine = 77;
            ENABLESECVTCCAMDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 2) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 3) )) ) ) ; 
            __context__.SourceCodeLine = 78;
            ENABLECOALVTCCAMDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 3) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 3) )) ) ) ; 
            __context__.SourceCodeLine = 79;
            ENABLETSVTCCAMDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 4) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 3) )) ) ) ; 
            __context__.SourceCodeLine = 82;
            ENABLESBUVTCCONTENTDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCECLASS  .UshortValue == 1) )) ) ) ; 
            __context__.SourceCodeLine = 83;
            ENABLESECVTCCONTENTDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 2) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.BoolToInt ( 1 <= SELECTEDSOURCECLASS  .UshortValue ) <= 2 ) )) ) ) ; 
            __context__.SourceCodeLine = 84;
            ENABLECOALVTCCONTENTDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 3) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.BoolToInt ( 1 <= SELECTEDSOURCECLASS  .UshortValue ) <= 3 ) )) ) ) ; 
            __context__.SourceCodeLine = 85;
            ENABLETSVTCCONTENTDESTS  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ROOMCLASS  .Value == 4) ) && Functions.TestForTrue ( Functions.BoolToInt (SELECTEDSOURCETYPE  .UshortValue == 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( SELECTEDSOURCECLASS  .UshortValue >= 1 ) )) ) ) ; 
            
            }
            
        object SELECTNONE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 90;
                ROOMCLASS  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 91;
                ROOMCLASSTEXT  .UpdateValue ( "Vacant"  ) ; 
                __context__.SourceCodeLine = 92;
                SETENABLES (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SELECTSBU_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 97;
            ROOMCLASS  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 98;
            ROOMCLASSTEXT  .UpdateValue ( "UNCLASSIFIED"  ) ; 
            __context__.SourceCodeLine = 99;
            SETENABLES (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SELECTSEC_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 104;
        ROOMCLASS  .Value = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 105;
        ROOMCLASSTEXT  .UpdateValue ( "US SECRET"  ) ; 
        __context__.SourceCodeLine = 106;
        SETENABLES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECTCOAL_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 111;
        ROOMCLASS  .Value = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 112;
        ROOMCLASSTEXT  .UpdateValue ( "COALITION SECRET"  ) ; 
        __context__.SourceCodeLine = 113;
        SETENABLES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECTTS_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 118;
        ROOMCLASS  .Value = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 119;
        ROOMCLASSTEXT  .UpdateValue ( "TS/SCI"  ) ; 
        __context__.SourceCodeLine = 120;
        SETENABLES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECTEDSOURCECLASS_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 125;
        SETENABLES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECTEDSOURCETYPE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 130;
        SETENABLES (  __context__  ) ; 
        
        
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
    
    SELECTNONE = new Crestron.Logos.SplusObjects.DigitalInput( SELECTNONE__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTNONE__DigitalInput__, SELECTNONE );
    
    SELECTSBU = new Crestron.Logos.SplusObjects.DigitalInput( SELECTSBU__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTSBU__DigitalInput__, SELECTSBU );
    
    SELECTSEC = new Crestron.Logos.SplusObjects.DigitalInput( SELECTSEC__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTSEC__DigitalInput__, SELECTSEC );
    
    SELECTCOAL = new Crestron.Logos.SplusObjects.DigitalInput( SELECTCOAL__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTCOAL__DigitalInput__, SELECTCOAL );
    
    SELECTTS = new Crestron.Logos.SplusObjects.DigitalInput( SELECTTS__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTTS__DigitalInput__, SELECTTS );
    
    ENABLESBUNONVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESBUNONVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESBUNONVTCSOURCE__DigitalOutput__, ENABLESBUNONVTCSOURCE );
    
    ENABLESECNONVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESECNONVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESECNONVTCSOURCE__DigitalOutput__, ENABLESECNONVTCSOURCE );
    
    ENABLECOALNONVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLECOALNONVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLECOALNONVTCSOURCE__DigitalOutput__, ENABLECOALNONVTCSOURCE );
    
    ENABLETSNONVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLETSNONVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLETSNONVTCSOURCE__DigitalOutput__, ENABLETSNONVTCSOURCE );
    
    ENABLESBUVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESBUVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESBUVTCSOURCE__DigitalOutput__, ENABLESBUVTCSOURCE );
    
    ENABLESECVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESECVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESECVTCSOURCE__DigitalOutput__, ENABLESECVTCSOURCE );
    
    ENABLECOALVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLECOALVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLECOALVTCSOURCE__DigitalOutput__, ENABLECOALVTCSOURCE );
    
    ENABLETSVTCSOURCE = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLETSVTCSOURCE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLETSVTCSOURCE__DigitalOutput__, ENABLETSVTCSOURCE );
    
    ENABLESBUVTCCAMDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESBUVTCCAMDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESBUVTCCAMDESTS__DigitalOutput__, ENABLESBUVTCCAMDESTS );
    
    ENABLESECVTCCAMDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESECVTCCAMDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESECVTCCAMDESTS__DigitalOutput__, ENABLESECVTCCAMDESTS );
    
    ENABLECOALVTCCAMDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLECOALVTCCAMDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLECOALVTCCAMDESTS__DigitalOutput__, ENABLECOALVTCCAMDESTS );
    
    ENABLETSVTCCAMDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLETSVTCCAMDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLETSVTCCAMDESTS__DigitalOutput__, ENABLETSVTCCAMDESTS );
    
    ENABLESBUVTCCONTENTDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESBUVTCCONTENTDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESBUVTCCONTENTDESTS__DigitalOutput__, ENABLESBUVTCCONTENTDESTS );
    
    ENABLESECVTCCONTENTDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLESECVTCCONTENTDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLESECVTCCONTENTDESTS__DigitalOutput__, ENABLESECVTCCONTENTDESTS );
    
    ENABLECOALVTCCONTENTDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLECOALVTCCONTENTDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLECOALVTCCONTENTDESTS__DigitalOutput__, ENABLECOALVTCCONTENTDESTS );
    
    ENABLETSVTCCONTENTDESTS = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLETSVTCCONTENTDESTS__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLETSVTCCONTENTDESTS__DigitalOutput__, ENABLETSVTCCONTENTDESTS );
    
    SELECTEDSOURCECLASS = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDSOURCECLASS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SELECTEDSOURCECLASS__AnalogSerialInput__, SELECTEDSOURCECLASS );
    
    SELECTEDSOURCETYPE = new Crestron.Logos.SplusObjects.AnalogInput( SELECTEDSOURCETYPE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SELECTEDSOURCETYPE__AnalogSerialInput__, SELECTEDSOURCETYPE );
    
    ROOMCLASS = new Crestron.Logos.SplusObjects.AnalogOutput( ROOMCLASS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ROOMCLASS__AnalogSerialOutput__, ROOMCLASS );
    
    ROOMCLASSTEXT = new Crestron.Logos.SplusObjects.StringOutput( ROOMCLASSTEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ROOMCLASSTEXT__AnalogSerialOutput__, ROOMCLASSTEXT );
    
    
    SELECTNONE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTNONE_OnPush_0, false ) );
    SELECTSBU.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTSBU_OnPush_1, false ) );
    SELECTSEC.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTSEC_OnPush_2, false ) );
    SELECTCOAL.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTCOAL_OnPush_3, false ) );
    SELECTTS.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTTS_OnPush_4, false ) );
    SELECTEDSOURCECLASS.OnAnalogChange.Add( new InputChangeHandlerWrapper( SELECTEDSOURCECLASS_OnChange_5, false ) );
    SELECTEDSOURCETYPE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SELECTEDSOURCETYPE_OnChange_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_ROOM_CLASS_AND_UI_ENABLING ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SELECTNONE__DigitalInput__ = 0;
const uint SELECTSBU__DigitalInput__ = 1;
const uint SELECTSEC__DigitalInput__ = 2;
const uint SELECTCOAL__DigitalInput__ = 3;
const uint SELECTTS__DigitalInput__ = 4;
const uint SELECTEDSOURCECLASS__AnalogSerialInput__ = 0;
const uint SELECTEDSOURCETYPE__AnalogSerialInput__ = 1;
const uint ENABLESBUNONVTCSOURCE__DigitalOutput__ = 0;
const uint ENABLESECNONVTCSOURCE__DigitalOutput__ = 1;
const uint ENABLECOALNONVTCSOURCE__DigitalOutput__ = 2;
const uint ENABLETSNONVTCSOURCE__DigitalOutput__ = 3;
const uint ENABLESBUVTCSOURCE__DigitalOutput__ = 4;
const uint ENABLESECVTCSOURCE__DigitalOutput__ = 5;
const uint ENABLECOALVTCSOURCE__DigitalOutput__ = 6;
const uint ENABLETSVTCSOURCE__DigitalOutput__ = 7;
const uint ENABLESBUVTCCAMDESTS__DigitalOutput__ = 8;
const uint ENABLESECVTCCAMDESTS__DigitalOutput__ = 9;
const uint ENABLECOALVTCCAMDESTS__DigitalOutput__ = 10;
const uint ENABLETSVTCCAMDESTS__DigitalOutput__ = 11;
const uint ENABLESBUVTCCONTENTDESTS__DigitalOutput__ = 12;
const uint ENABLESECVTCCONTENTDESTS__DigitalOutput__ = 13;
const uint ENABLECOALVTCCONTENTDESTS__DigitalOutput__ = 14;
const uint ENABLETSVTCCONTENTDESTS__DigitalOutput__ = 15;
const uint ROOMCLASS__AnalogSerialOutput__ = 0;
const uint ROOMCLASSTEXT__AnalogSerialOutput__ = 1;

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

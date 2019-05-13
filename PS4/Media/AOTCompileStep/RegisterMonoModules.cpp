
#if defined(TARGET_IPHONE_SIMULATOR) && TARGET_IPHONE_SIMULATOR
    #define DECL_USER_FUNC(f) void f() __attribute__((weak_import))
    #define REGISTER_USER_FUNC(f)\
        do {\
        if(f != NULL)\
            mono_dl_register_symbol(#f, (void*)f);\
        else\
            ::printf_console("Symbol '%s' not found. Maybe missing implementation for Simulator?\n", #f);\
        }while(0)
#else
    #define DECL_USER_FUNC(f) void f() 
    #if !defined(__arm64__)
    #define REGISTER_USER_FUNC(f) mono_dl_register_symbol(#f, (void*)&f)
    #else
        #define REGISTER_USER_FUNC(f)
    #endif
#endif
extern "C"
{
    typedef void* gpointer;
    typedef int gboolean;
    void                mono_aot_register_module(gpointer *aot_info);
#if __ORBIS__ || SN_TARGET_PSP2
#define DLL_EXPORT __declspec(dllexport)
#else
#define DLL_EXPORT
#endif
#if !(TARGET_IPHONE_SIMULATOR)
    extern gboolean     mono_aot_only;
    extern gpointer*    mono_aot_module_Assembly_CSharp_info; // Assembly-CSharp.dll
    extern gpointer*    mono_aot_module_DiscUtils_info; // DiscUtils.dll
    extern gpointer*    mono_aot_module_Mono_Data_Tds_info; // Mono.Data.Tds.dll
    extern gpointer*    mono_aot_module_Mono_Posix_info; // Mono.Posix.dll
    extern gpointer*    mono_aot_module_Mono_Security_info; // Mono.Security.dll
    extern gpointer*    mono_aot_module_mscorlib_info; // mscorlib.dll
    extern gpointer*    mono_aot_module_System_Configuration_info; // System.Configuration.dll
    extern gpointer*    mono_aot_module_System_Core_info; // System.Core.dll
    extern gpointer*    mono_aot_module_System_Data_info; // System.Data.dll
    extern gpointer*    mono_aot_module_System_Data_Linq_info; // System.Data.Linq.dll
    extern gpointer*    mono_aot_module_System_info; // System.dll
    extern gpointer*    mono_aot_module_System_EnterpriseServices_info; // System.EnterpriseServices.dll
    extern gpointer*    mono_aot_module_System_Runtime_Serialization_info; // System.Runtime.Serialization.dll
    extern gpointer*    mono_aot_module_System_Security_info; // System.Security.dll
    extern gpointer*    mono_aot_module_System_Transactions_info; // System.Transactions.dll
    extern gpointer*    mono_aot_module_System_Xml_info; // System.Xml.dll
    extern gpointer*    mono_aot_module_UnityEngine_AccessibilityModule_info; // UnityEngine.AccessibilityModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_AIModule_info; // UnityEngine.AIModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_AnimationModule_info; // UnityEngine.AnimationModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_ARModule_info; // UnityEngine.ARModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_AudioModule_info; // UnityEngine.AudioModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_ClothModule_info; // UnityEngine.ClothModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_CoreModule_info; // UnityEngine.CoreModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_CrashReportingModule_info; // UnityEngine.CrashReportingModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_DirectorModule_info; // UnityEngine.DirectorModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_info; // UnityEngine.dll
    extern gpointer*    mono_aot_module_UnityEngine_GameCenterModule_info; // UnityEngine.GameCenterModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_GridModule_info; // UnityEngine.GridModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_ImageConversionModule_info; // UnityEngine.ImageConversionModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_IMGUIModule_info; // UnityEngine.IMGUIModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_InputModule_info; // UnityEngine.InputModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_JSONSerializeModule_info; // UnityEngine.JSONSerializeModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_Networking_info; // UnityEngine.Networking.dll
    extern gpointer*    mono_aot_module_UnityEngine_ParticlesLegacyModule_info; // UnityEngine.ParticlesLegacyModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_ParticleSystemModule_info; // UnityEngine.ParticleSystemModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_PerformanceReportingModule_info; // UnityEngine.PerformanceReportingModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_Physics2DModule_info; // UnityEngine.Physics2DModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_PhysicsModule_info; // UnityEngine.PhysicsModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_ScreenCaptureModule_info; // UnityEngine.ScreenCaptureModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_SpatialTracking_info; // UnityEngine.SpatialTracking.dll
    extern gpointer*    mono_aot_module_UnityEngine_SpriteMaskModule_info; // UnityEngine.SpriteMaskModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_StyleSheetsModule_info; // UnityEngine.StyleSheetsModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_TerrainModule_info; // UnityEngine.TerrainModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_TerrainPhysicsModule_info; // UnityEngine.TerrainPhysicsModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_TextRenderingModule_info; // UnityEngine.TextRenderingModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_TilemapModule_info; // UnityEngine.TilemapModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_Timeline_info; // UnityEngine.Timeline.dll
    extern gpointer*    mono_aot_module_UnityEngine_UI_info; // UnityEngine.UI.dll
    extern gpointer*    mono_aot_module_UnityEngine_UIElementsModule_info; // UnityEngine.UIElementsModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UIModule_info; // UnityEngine.UIModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UNETModule_info; // UnityEngine.UNETModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UnityAnalyticsModule_info; // UnityEngine.UnityAnalyticsModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UnityConnectModule_info; // UnityEngine.UnityConnectModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UnityWebRequestAudioModule_info; // UnityEngine.UnityWebRequestAudioModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UnityWebRequestModule_info; // UnityEngine.UnityWebRequestModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UnityWebRequestTextureModule_info; // UnityEngine.UnityWebRequestTextureModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_UnityWebRequestWWWModule_info; // UnityEngine.UnityWebRequestWWWModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_VehiclesModule_info; // UnityEngine.VehiclesModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_VideoModule_info; // UnityEngine.VideoModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_VRModule_info; // UnityEngine.VRModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_WebModule_info; // UnityEngine.WebModule.dll
    extern gpointer*    mono_aot_module_UnityEngine_WindModule_info; // UnityEngine.WindModule.dll
#endif // !(TARGET_IPHONE_SIMULATOR)
}
DLL_EXPORT void RegisterMonoModules()
{
#if !(TARGET_IPHONE_SIMULATOR) && !defined(__arm64__)
    mono_aot_only = true;
    mono_aot_register_module(mono_aot_module_Assembly_CSharp_info);
    mono_aot_register_module(mono_aot_module_DiscUtils_info);
    mono_aot_register_module(mono_aot_module_Mono_Data_Tds_info);
    mono_aot_register_module(mono_aot_module_Mono_Posix_info);
    mono_aot_register_module(mono_aot_module_Mono_Security_info);
    mono_aot_register_module(mono_aot_module_mscorlib_info);
    mono_aot_register_module(mono_aot_module_System_Configuration_info);
    mono_aot_register_module(mono_aot_module_System_Core_info);
    mono_aot_register_module(mono_aot_module_System_Data_info);
    mono_aot_register_module(mono_aot_module_System_Data_Linq_info);
    mono_aot_register_module(mono_aot_module_System_info);
    mono_aot_register_module(mono_aot_module_System_EnterpriseServices_info);
    mono_aot_register_module(mono_aot_module_System_Runtime_Serialization_info);
    mono_aot_register_module(mono_aot_module_System_Security_info);
    mono_aot_register_module(mono_aot_module_System_Transactions_info);
    mono_aot_register_module(mono_aot_module_System_Xml_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_AccessibilityModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_AIModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_AnimationModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_ARModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_AudioModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_ClothModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_CoreModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_CrashReportingModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_DirectorModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_GameCenterModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_GridModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_ImageConversionModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_IMGUIModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_InputModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_JSONSerializeModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_Networking_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_ParticlesLegacyModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_ParticleSystemModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_PerformanceReportingModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_Physics2DModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_PhysicsModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_ScreenCaptureModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_SpatialTracking_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_SpriteMaskModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_StyleSheetsModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_TerrainModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_TerrainPhysicsModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_TextRenderingModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_TilemapModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_Timeline_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UI_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UIElementsModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UIModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UNETModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UnityAnalyticsModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UnityConnectModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UnityWebRequestAudioModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UnityWebRequestModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UnityWebRequestTextureModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_UnityWebRequestWWWModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_VehiclesModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_VideoModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_VRModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_WebModule_info);
    mono_aot_register_module(mono_aot_module_UnityEngine_WindModule_info);
#endif // !(TARGET_IPHONE_SIMULATOR) && !defined(__arm64__)

}


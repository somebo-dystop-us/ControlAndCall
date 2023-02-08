/// dystop.us | 08.02.2023 03:13
namespace CnC.App
{
    /// <summary>
    /// All of project's scenes should be listed here
    /// </summary>
    public enum AppSceneID 
    {
        /// <summary>
        /// CnC | App Launcher
        /// <para>Contains:</para>
        /// <para>* AppManager prefab</para>
        /// </summary>
        CnC_AppBoot = 0,

        /// <summary>
        /// CnC | World Root
        /// <para>Contains:</para>
        /// <para>* MonoSingleton | </para>
        /// </summary>
        CnC_SubrealEnvironment = 1,

        /// <summary>
        /// CnC | UI Additional Scene
        /// <para>Contains:</para>
        /// <para>* MonoSingleton | UI Manager </para>
        /// </summary>
        CnC_UI = 2,

        /// <summary>
        /// CnC | Cannabees's Sandbox
        /// <para>Contains:</para>
        /// <para>* AppManager prefab</para>
        /// </summary>
        CnC_Sandbox = 3,

    }
}

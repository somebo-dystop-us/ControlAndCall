/// 

namespace CnC.AppManagement
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
        AppBoot = 0,

        /// <summary>
        /// CnC | World Root
        /// <para>Contains:</para>
        /// <para>* MonoSingleton | </para>
        /// </summary>
        SubrealEnvironment = 1,

        /// <summary>
        /// CnC | UI Additional Scene
        /// <para>Contains:</para>
        /// <para>* MonoSingleton | UI Manager </para>
        /// </summary>
        UIManagement = 2,

        /// <summary>
        /// CnC | Cannabees's Sandbox
        /// <para>Contains:</para>
        /// <para>* AppManager prefab</para>
        /// </summary>
        Sandbox = 3,



    }
}

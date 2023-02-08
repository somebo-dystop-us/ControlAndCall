/// dystop.us | 08.02.2023
using System;

//using Steamworks;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using CnC;
using CnC.GameData;
using CnC.Events;
using CnC.Pools;
using CnC.Dev;
using CnC.Utils;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevTools : MonoBehaviour //MonoSingleton<DevTools>
    {
        #region Public static properties

        public static bool AreDevToolsAvailable
        {
            get
            {
                if (!_areDevToolsAvailable)
                {
                    //if (InteropHelp.DevTestIfAvailableClient())
                    //{
                    _areDevToolsAvailable = true; //CheckSteamID(SteamUser.GetSteamID().m_SteamID);
                    //}
                    //else
                    //{
                    //    DevLogger.DevLog(nameof(DevTools), "Exception: Steamworks is not initialized yet.");
                    //}
                }
                return _areDevToolsAvailable;
            }
        }

        #endregion

        #region Private static properties

        private static bool _areDevToolsAvailable = false;

        #endregion

        #region private static methods

        /// <summary>
        /// Hardcoded ulong values of team members ID on Steam
        /// </summary>
        /// <param name="idToCheck"></param>
        /// <returns></returns>
        private static bool CheckSteamID(ulong idToCheck)
        {
            DevLogger.DevLog("Dev Tools", "Checks Steam ID: " + idToCheck);

            switch (idToCheck)
            {
                case 76561198005454076: // Rafa³
                case 76561198858088612: // Ewelinka
                case 76561198134227923: // Damian
                case 76561198053487790: // Marcin
                case 76561198313646091: // Kuba
                case 76561198805769253: // Daniu
                case 76561198388000481: // Sielscore
                    return true;
                case 76561198387208392: // Radek
                default:
                    return false;
            }
        }

        #endregion

        #region Serialized Fields | Dev Tools Config

        [Header("Dev Tools | Reference to Tools Config SO")]

        [SerializeField] private DevToolsConfigSO _devToolsConfigReference;

        [Space()]

        [Header("Dev Tools | Release Date")]
        [SerializeField] private string _devToolsReleaseDateString = "Release Date needs to be updated.";

        #endregion


        #region Serialized Fields | Cheat | Instant Fish Catch
        /*
        [Header("Instant Fish Catch")]

        [Header("Selected Fish SPECIES")]
        [SerializeField] private FishSpecies fishSpeciesToInstantCatch = FishSpecies.SharkTiger;

        [Header("Custom fish WEIGHT")]
        [Range(0.01f, 2023f)]
        [SerializeField] private float fishWeightToInstantCatch = 420f;

        [Header("Keyboard shortcut to Activate Instant Fish Catch cheat.")]
        [SerializeField] private KeyboardShortcut _shortcutToInstantFishCatch = new KeyboardShortcut(KeyCode.CapsLock, KeyCode.L);
         */
        #endregion



        #region Serialized Fields | Keyboard shortcuts
        /*

       [Header("Dev Tools Console")]

       [Space]
       [Header("Keyboard shortcuts | Switching visibility of all Dev Tools windows")]
       [SerializeField] private KeyboardShortcut _shortcutToShowDevTools = new KeyboardShortcut(KeyCode.CapsLock, KeyCode.D);
       [SerializeField] private KeyboardShortcut _shortcutToHideDevTools = new KeyboardShortcut(KeyCode.CapsLock, KeyCode.D, KeyCode.LeftShift);

       [Space]
       [Header("Keyboard shortcuts | Showing single Dev Tool windows")]
       [SerializeField] 
       private KeyboardShortcut[] _shortcutsToShowToolWindow = 
       { 
           new KeyboardShortcut(KeyCode.CapsLock, KeyCode.Alpha7), // tools selector
           new KeyboardShortcut(KeyCode.CapsLock, KeyCode.Alpha8), // logger console
           new KeyboardShortcut(KeyCode.CapsLock, KeyCode.Alpha9)  // pools monitor
       };

       [Space]
       [Header("Keyboard shortcuts | Hiding single Dev Tool window")]
       [SerializeField] 
       private KeyboardShortcut[] _shortcutsToHideToolWindow = 
       { 
           new KeyboardShortcut(KeyCode.CapsLock, KeyCode.Alpha7, KeyCode.LeftShift), // tools selector
           new KeyboardShortcut(KeyCode.CapsLock, KeyCode.Alpha8, KeyCode.LeftShift), // logger console
           new KeyboardShortcut(KeyCode.CapsLock, KeyCode.Alpha9, KeyCode.LeftShift)  // pools monitor
       };
        */
        #endregion


        #region Public getters

        public string DevToolsReleaseDateString { get => _devToolsReleaseDateString; }

        /*
        public KeyboardShortcut ShortcutToShowDevTools { get { return _shortcutToShowDevTools; } }
        public KeyboardShortcut ShortcutToHideDevTools { get { return _shortcutToHideDevTools; } }

        public KeyboardShortcut[] ShortcutsToShowToolWindow { get { return _shortcutsToShowToolWindow; } }
        public KeyboardShortcut[] ShortcutsToHideToolWindow { get { return _shortcutsToHideToolWindow; } }


        public FishSpecies FishSpeciesToInstantCatch { get => fishSpeciesToInstantCatch; }
        public float FishWeightToInstantCatch { get => fishWeightToInstantCatch; }
        */
        #endregion

        #region MonoBehaviour callbacks

        void OnEnable()
        {
            ApplyAuthorization();

            //InvokeRepeating(nameof(CustomUpdate), 1f, .2f);
        }

        private void CustomUpdate()
        {
            if (!AreDevToolsAvailable)
            {
                return;
            }

            this.DevLog("Custom Update ");

        }

        #endregion

        #region Public methods | Remote Initialization


        public void InitAuthorization()
        {
            if (ApplyAuthorization())
            {
                gameObject.SetActive(true);
            }
        }


        #endregion

        #region Public methods | Editor's buttons callbacks

        /// <summary>
        /// 
        /// </summary>
        public void UpdateReleaseDate()
        {
            this.DevLog("Button Clicked! | UpdateReleaseDate()");

            if (_devToolsConfigReference != null)
            {
                _devToolsConfigReference.UpdateReleaseDate();
                _devToolsReleaseDateString = _devToolsConfigReference.ReleaseDateString;
            }
        }

        #endregion

        #region Private methods | Special features 

        /*
        private void SwitchAllDevToolsVisibility(bool isVisible = true)
        {
            AreDevToolsAvailable = isVisible;

            if (AreDevToolsAvailable)
            {
                DevToolsLauncher.Instance.Hide();
            }

            this.DevLog("Dev Tools" 
                    + " | Visible: " + AreDevToolsAvailable 
                    + " | Shortcut: " + (isVisible ? _shortcutToShowDevTools : _shortcutToHideDevTools));
        }
        */

        /*
        private void PerformInstantFishCatch()
        {
            // FScriptsHandler.Instance.m_PlayerMain.currentRod.currentFish
            GameplayEventsManager.DispatchEvent(GameplayEvent.InstantFishCatch, fishSpeciesToInstantCatch, fishWeightToInstantCatch);

            gameObject.DevLog("Performs Cheat | Instant Fish Catch | Shortcut: " + _shortcutToInstantFishCatch.KeyCodes);
        }
        */

        #endregion

        #region Private methods | Steam Authorization

        private bool ApplyAuthorization()
        {
            this.DevLog("Dev Tools authorized: " + AreDevToolsAvailable);

            return gameObject.active = enabled = AreDevToolsAvailable;
        }

        #endregion
    }

    #region Custom Editor | Dev Tools Editor

#if UNITY_EDITOR

    [CustomEditor(typeof(DevTools))]
    public class DevToolsEditor : DevEditor<DevTools>
    {
        protected override void AddButtons()
        {
            AddButtonForMethod(Target.UpdateReleaseDate);
        }
    }

#endif

    #endregion
}

#region CnC.Utils | Generic DevEditor<T> | Note: The definition is placed here because of an inability to place it in a separated file

namespace CnC.Utils
{
    /// <summary>
    /// Editor's inspector utilities. 
    /// <para>Contains:</para>
    /// <para>+ AddButtonForMethod(Action) method.</para>
    /// </summary>
    /// <typeparam name="TargetType">The type for which Custom Editor will be setup for.</typeparam>

#if UNITY_EDITOR

    public abstract class DevEditor<TargetType> : Editor where TargetType : UnityEngine.Object
    {
        #region Public static methods | Button helpers

        /// <summary>
        /// Helper used to create Editors text buttons.
        /// </summary>
        /// <param name="prefixText">optional</param>
        /// <param name="infixText">optional</param>
        /// <param name="postfixText">optional</param>
        /// <returns>Default: string "\t[ Change that name (; ]\t"</returns>
        public static string GetButtonLabelText(string prefixText = "", string infixText = "Change that name (;", string postfixText = "")
        {
            return prefixText + "\t[ " + infixText + " ]\t" + postfixText;
        }

        #endregion

        #region Protected getter

        protected TargetType Target { get => (TargetType)target; }

        #endregion

        #region Public get-methods

        /*
         * TODO: fix and/or remove
        public TypeToCastTo GetCastedTarget<TypeToCastTo> () where TypeToCastTo : UnityEngine.Object
        {
            var returnType = (TypeToCastTo)Target;

            return returnType;
        }
        */

        #endregion

        #region Public overrided methods

        /// <summary>
        /// Do nothing but Invokes base.OnInspectorGUI() method
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Target != null)
            {
                AddButtons();
            }
        }

        #endregion

        #region Protected methods | Buttons adding

        protected void AddButtonForMethod(Action onClickCallback)
        {
            if (GUILayout.Button(GetButtonLabelText(infixText: onClickCallback.Method.Name)))
            {
                onClickCallback?.Invoke();
            }
        }

        protected void AddButtonForLoadGameData(Action onClickCallback, string gameDataType, string buttonTextPostfix = "")
        {
            if (GUILayout.Button(GetButtonLabelText("Load", gameDataType, "Data " + buttonTextPostfix)))
            {
                onClickCallback?.Invoke();
            }
        }

        #endregion

        #region Protected abstract methods | Add Buttons

        /// <summary>
        /// This method has to be implemented by deriving classes.
        /// <para>This is the place for adding buttons to the Custom Inspector by calling AddButtonForMethod() method. </para>
        /// </summary>
        protected abstract void AddButtons();

        #endregion


    }

#endif

}


#endregion
/// dystop.us | 08.02.2023
using System.Collections;
using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using CnC.GameData;
using CnC.Pools;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public abstract class DevToolUIWindowBase : DevBehaviour, IDragHandler
    {
        #region Serialized protected fields | References

        [Header("Window ID")]
        [SerializeField] protected DevToolUIWindowEnum _windowEnum = DevToolUIWindowEnum.Count;

        #endregion

        #region Serialized protected and private fields | References

        [Space]
        [Header("Window components references")]

        [SerializeField] protected TextMeshProUGUI _windowTitleLabel;
        [SerializeField] protected Image _windowBackgroundImage;
        [SerializeField] private Slider _transparencySlider;

        #endregion

        #region Serialized private fields | Window Transparency

        [Space]
        [Header("Window Transparency")]

        [SerializeField] private float _transparencyChangeDuration = .5f;

        #endregion

        #region Public/private properties

        public string WindowTitle { get => _windowTitleLabel.text; private set => _windowTitleLabel.text = value; }
        public DevToolUIWindowEnum WindowID { get => _windowEnum; private set => _windowEnum = value; }

        public int WindowIndex { get => (int)_windowEnum; }

        private bool IsToolVisible { get => DevUISelector.IsToolVisible[WindowIndex]; }

        #endregion

        #region Private fields | 


        #endregion

        #region MonoBehaviours

        private void OnEnable()
        {
            ApplyAlpha(true);
        }

        private void Awake()
        {
            InitWindow();
        }

        #endregion

        #region Public methods

        public void ShowIfAvailable()
        {
            if (WindowID == DevToolUIWindowEnum.Count)
            {
                this.DevLog("Warning: Dev Tool Window not initialised. !@#");
                return;
            }

            this.DevLog("ShowIfAvailable | IsToolVisible: " + IsToolVisible);

            gameObject.SetActive(IsToolVisible);
        }

        #endregion

        #region Public methods | Alpha Change and Dragging

        public void ApplyAlpha(bool isInstant = false)
        {
            this.DevLog("Change alpha to: " + _transparencySlider.normalizedValue);

            _windowBackgroundImage.CrossFadeAlpha(_transparencySlider.normalizedValue, isInstant ? 0f : _transparencyChangeDuration, true);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        #endregion

        #region Protected abstract methods

        protected abstract void InitWindow();

        #endregion

        #region Protected methods

        protected void SetupWindow(DevToolUIWindowEnum toolID, string windowTitleText, bool isVisible = false)
        {
            if (_windowTitleLabel != null)
            {
                WindowTitle = windowTitleText;
            }

            WindowID = toolID;

            DevUISelector.ShowToolWindow(WindowID, isVisible);
        }

        #endregion
    }
}


/*
 * OLD GUI VERSION
 


namespace UFS2.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    [Serializable]
    public class DevWindow
    {
        #region Serialized fields

        [Header("Window ID")]
        [SerializeField] private DevToolWindowEnum _windowID = 0;

        [Header("Window Title")]
        [SerializeField] private string _windowTitle = "Uninitialized Window";

        [Header("Position (x & y) and Size (width & height)")]
        [SerializeField] private Rect _positionAndSizeOfWindow = new Rect(10, 10, 240, 960);

        [Header("Scroll position (optional)")]
        [SerializeField] private Vector2 scrollPosition;

        [Header("List of entries (optional)")]
        [SerializeField] private ArrayList entries = new ArrayList();

        [Header("GameplayFishPool reference (optional)")]
        [SerializeField] private GameplayFishPool _gameplayFishPool = null;

        #endregion

        #region Public getters

        public int ID { get => (int)_windowID; }

        public string WindowTitle { get => (string)_windowTitle; }

        #endregion

        #region Public methods

        public void Init(DevToolWindowEnum id)
        {
            _windowID = id;

        }

        /// <summary>
        /// 
        /// </summary>
        public void Show()
        {
            _positionAndSizeOfWindow = GUI.Window(ID, _positionAndSizeOfWindow, DevToolWindow, _windowTitle);
        }

        #endregion

        #region Private fields

        private string consoleLogInputText = "Click here, write then push Caps Lock.";

        private bool[] toggleBools = null;

        #endregion

        #region Window function
        void DevToolWindow(int id)
        {
            // GUILayout.Space(1);

            switch ((DevToolWindowEnum)id)
            {
                #region Dev Tools Selector

                case DevToolWindowEnum.DevToolSelector:
                    {
                        GUI.contentColor = Color.black;

                        
                        var devWindows = DevGUI.Instance.DevToolWindows;

                        if (devWindows != null)
                        {
                            for (int iTool = 0; iTool < devWindows.Length; iTool++)
                            {
                                // Keyboard Shotcuts for hiding/showing a window tool
                                DevGUIUtils.CreateDevToolSelectorLabel(devWindows[iTool]);

                                GUILayout.Space(3);
                            }
                        }
                        

                    }
                    break;

                #endregion

                #region Dev Log Console

                case DevToolWindowEnum.DevLogConsole:
                    {

                        GUI.contentColor = Color.black;

                        GUILayout.Label("Log:");

                        //GUILayout.Label("Instant Fish Catch");

                        // text input
                        consoleLogInputText = GUI.TextField(new Rect(0, _positionAndSizeOfWindow.height - 50, _positionAndSizeOfWindow.width, 50), consoleLogInputText);

                        // Dev Logs
                        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

                        DevGUIUtils.CreateLabel("...", Color.white);

                        GUILayout.EndScrollView();


                        //GUI.FocusControl(consoleLogInputText);
                    }
                    break;

                #endregion

                #region Fish Pools Monitor

                case DevToolWindowEnum.FishPoolsMonitor:
                    {
                        //GUILayout.SelectionGrid(0, text, count, "toggle");

                        // var textOptions = new string[] { "option1", "option2", "option3", "option4" };
                        // selectionNumber = GUILayout.SelectionGrid(0, textOptions, selectionNumber, EditorStyles.radioButton);

                        DevGUIUtils.CreateLabel("      | Fish Species\t|\tMin - Max Weight\t|\tActive / All", Color.blue);
                        GUILayout.Space(2);

                        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

                        // current version 
                        for (var iSpecies = (FishSpecies)0; iSpecies < FishSpecies.Count; iSpecies++)
                        {
                            FishSpeciesSO singleSpecies = GameDataManager.Instance.GetSingleFishSpecies(iSpecies);
                            var weightVariantsExtremes = singleSpecies.GetWeightExtremesForAllVariants();

                            // Label: No. | Fish Species name / Species Code
                            DevGUIUtils.CreateLabel("#" + (int)iSpecies + " | " + iSpecies + " / " + singleSpecies.GetFishName(), Color.white);

                            // Labels: Weight variants of the species
                            for (var iVariant = 0; iVariant < singleSpecies.NumberOfVariants; iVariant++)
                            {
                                string variantPoolKey = GameplayFishPool.GetKeyByType<FFish>(iSpecies, iVariant);

                                if (!_gameplayFishPool.PoolDictionary.ContainsKey(variantPoolKey))
                                {
                                    this.DevLog("There is no any Pool provided for key: " + variantPoolKey);
                                    continue;
                                }

                                var speciesVariantPoolStats = _gameplayFishPool.GetCurrentPoolStatsForKey(variantPoolKey);
                                DevGUIUtils.CreateFishPoolStatsLabel(iVariant, weightVariantsExtremes[iVariant], speciesVariantPoolStats);

                                GUILayout.Space(1);
                            }

                        }

                        GUILayout.EndScrollView();
                        GUILayout.Space(50);

                        if (GUI.Button(new Rect(0, _positionAndSizeOfWindow.height - 50, _positionAndSizeOfWindow.width / 2, 50), "Refresh Pools Stats"))
                        {
                            //DevTools.Instance.RefreshDevToolWindow(_windowID);
                        }


                        if (GUI.Button(new Rect(_positionAndSizeOfWindow.width / 2, _positionAndSizeOfWindow.height - 50, _positionAndSizeOfWindow.width / 2, 50), "Instant Catch"))
                        {
                            //GameplayEventsManager.DispatchEvent(GameplayEvent.InstantFishCatch, DevTools.Instance.FishSpeciesToInstantCatch, DevTools.Instance.FishWeightToInstantCatch);
                        }


                    }
                    break;

                    #endregion
            }

            GUI.DragWindow();
        }

        #endregion

        private int selectionNumber = 1;
        private string[] text = { "aaa", "bbb" };
        private string[] texts = new string[] { "option1", "option2", "option3", "option4" };

        #region Private methods



        #endregion
    }
*/
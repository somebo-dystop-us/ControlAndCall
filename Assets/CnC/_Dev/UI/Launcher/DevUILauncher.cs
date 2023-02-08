/// dystop.us | 08.02.2023
using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace CnC.Dev
{
    public class DevUILauncher : DevBehaviour
    {
        #region Public / private static properties

        public static bool IsLauncherVisible { get; private set; }

        #endregion

        #region Serialized private fields | Title Text

        [SerializeField]
        private string _launcherTitleText = "UFS2 | DEV TOOLS | ";

        #endregion

        #region Serialized private fields | References

        [SerializeField] private DevToolsConfigSO _configSO;

        [SerializeField] private Button _launcherButton;
        [SerializeField] private TextMeshProUGUI _launcherLabel;

        [SerializeField] private Image _launcherButtonImage;

        [SerializeField] private RectTransform _selectorOptionsContainer;

        [SerializeField] private DevUISelector _windowsSelector;

        #endregion

        #region Public / private properties

        #endregion

        #region MonoBehaviours

        private void Awake()
        {
            IsLauncherVisible = false;
        }

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        #endregion

        #region Public methods | Button's OnClick() OnEnter() OnExit()

        public void OnLauncherButtonClick()
        {
            this.DevLog("Dev Tools Launcher button clicked!");

            SwitchVisibility();
        }

        public void OnLauncherButtonEnter()
        {
            this.DevLog("Dev Tools Launcher button ENTER!");

            ShowTitleLabel();
            ShowButtonImage();
        }

        public void OnLaucherButtonExit()
        {
            this.DevLog("Dev Tools Launcher button EXIT!");

            ShowTitleLabel(false);
            ShowButtonImage(false);
        }

        #endregion

        #region Private methods 

        private void Init()
        {
            this.DevLog("Inits");

            SetupTitle();

            _windowsSelector.InitSelector();

            ApplyVisibility();
        }

        private void SetupTitle()
        {
            _launcherLabel.text = _launcherTitleText + _configSO.ReleaseDateString ;
        }

        private void SwitchVisibility()
        {
            IsLauncherVisible = !IsLauncherVisible;

            ApplyVisibility();
        }

        private void ApplyVisibility()
        {
            ShowTitleLabel(IsLauncherVisible);
            ShowSelector(IsLauncherVisible);
            ShowButtonImage(IsLauncherVisible);
        }

        private void ShowTitleLabel(bool isVisible = true)
        {
            _launcherLabel.enabled = isVisible || IsLauncherVisible;
        }

        private void ShowSelector(bool isVisible = true)
        {
            _selectorOptionsContainer.gameObject.SetActive(isVisible || IsLauncherVisible);
        }

        private void ShowButtonImage(bool isVisible = true)
        {
            _launcherButtonImage.enabled = isVisible || IsLauncherVisible;
        }

        #endregion
    }
}


/*
 * OLD VERSION
 * 
public class DevToolsLauncher : MonoSingleton<DevToolsLauncher>
{
    #region Private/serialized fields

    //[Header("Dev Tools Launcher | Window Title")]
    //[SerializeField]
    private string _windowTitle = "";

    [Header("Dev Tools Launcher | Button Icon")]
    [SerializeField] private Texture2D _launcherButtonIcon;

    //[Space(2)]

    //[Header("Position (x & y) of the window")]
    //[SerializeField] 
    private Vector2 _windowPosition = new Vector2(50, 50);

    //[Header("Size (width & height) of the window")]
    //[SerializeField] 
    private Vector2 _windowSize = new Vector2(359, 124);

    //[Header("Current Position (x & y) and Size (width & height) of the window")]
    //[SerializeField] 
    private Rect _positionAndSizeOfWindow;

    private bool _isVisible = true;

   // private string ButtonTooltip { get => "Press " + DevTools.Instance.ShortcutToShowDevTools + " to show/hide Dev Tools."; }

    #endregion

    #region MonoBehaviour callbacks

    private void Update()
    {
       VerifyAuthorization();
    }

    #endregion

    #region Public Methods

    public void Show()
    {
        VerifyAuthorization();

        _isVisible = true;
        enabled = true;
    }

    public void Hide()
    {
       // Debug.Log("hide >>>> ");
        _isVisible = false;
        enabled = false;
    }

    #endregion

    #region OnGUI

    void OnGUI()
    {
        if (_isVisible)
        {
            _positionAndSizeOfWindow = GUI.Window(7, new Rect(_windowPosition, _windowSize), DevToolsLauncherWindow, _windowTitle);
        }
    }

    #endregion

    #region Window function

    void DevToolsLauncherWindow(int id)
    {
        if (!VerifyAuthorization())
        {
            return;
        }

        if (GUI.Button(new Rect(0, 0, 359, 124), new GUIContent(_launcherButtonIcon, ButtonTooltip)))
        {
            DevTools.Instance.OnLauncherButtonClick();
            Hide();
        }

        // This line reads and displays the contents of GUI.tooltip
        GUI.Label(new Rect(10, 104, 349, 50), GUI.tooltip);
    }

    #endregion

    #region Private Methods

    private bool VerifyAuthorization()
    {

        if (!DevTools.IsAuthorized)
        {
            Hide();
            return false;
        }

        return true;
    }

    #endregion
}
*/
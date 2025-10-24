using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : PersistentSingleton<InputHandler>
{
    // https://www.youtube.com/watch?v=lclDl-NGUMg

    [SerializeField] private InputActionAsset _inputActionAsset;
    
    /* Names */
    // Action Maps
    readonly string _USERINTERFACE_ACTIONMAP_NAME_ = "UI";
    readonly string _PLAYER_ACTIONMAP_NAME_ = "Player";
    // Actions
    readonly string _USERINTERFACE_PAUSEACTION_NAME_ = "Pause";
    readonly string _PLAYER_MOVEACTION_NAME_ = "Move";
    readonly string _PLAYER_SHOOTACTION_NAME_ = "Shoot";
    readonly string _PLAYER_SPECIALACTION_NAME_ = "Special";

    /* Action Map References */
    private InputActionMap _userInterfaceActionMap;
    private InputActionMap _playerActionMap;

    /* Input Actions */
    // UI
    private InputAction _uiPauseAction;
    // Player
    private InputAction _playerMoveAction;
    private InputAction _playerShootAction;
    private InputAction _playerSpecialAction;

    /* Input Values */

    private Vector2 _playerMoveInput;
    public Vector2 PlayerMoveInput { get { return this._playerMoveInput; } }

    private bool _playerShootInput;
    public bool PlayerShootInput { get { return this._playerShootInput; } }

    private void OnEnable()
    {
        this._uiPauseAction.Enable();
        this._playerMoveAction.Enable();
        this._playerShootAction.Enable();
        this._playerSpecialAction.Enable();
    }

    private void OnDisable()
    {
        this._uiPauseAction.Disable();
        this._playerMoveAction.Disable();
        this._playerShootAction.Disable();
        this._playerSpecialAction.Disable();
    }

    protected override void Awake()
    {
        base.Awake();

        // Input Maps
        this._userInterfaceActionMap = this._inputActionAsset.FindActionMap(_USERINTERFACE_ACTIONMAP_NAME_);
        this._playerActionMap = this._inputActionAsset.FindActionMap(_PLAYER_ACTIONMAP_NAME_);

        // Input Actions
        this._uiPauseAction = this._userInterfaceActionMap.FindAction(_USERINTERFACE_PAUSEACTION_NAME_);

        this._playerMoveAction = this._playerActionMap.FindAction(_PLAYER_MOVEACTION_NAME_);
        this._playerShootAction = this._playerActionMap.FindAction(_PLAYER_SHOOTACTION_NAME_);
        this._playerSpecialAction = this._playerActionMap.FindAction(_PLAYER_SPECIALACTION_NAME_);

        this.RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        this._playerMoveAction.performed += context => this._playerMoveInput = context.ReadValue<Vector2>();
        this._playerMoveAction.canceled += context => this._playerMoveInput = Vector2.zero;

        this._playerShootAction.performed += context => this._playerShootInput = true;
        this._playerShootAction.canceled += context => this._playerShootInput = false;
    }
}

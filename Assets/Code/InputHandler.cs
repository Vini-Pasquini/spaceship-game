using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : PersistentSingleton<InputHandler>
{
    // https://www.youtube.com/watch?v=lclDl-NGUMg

    [SerializeField] private InputActionAsset _inputActionAsset;
    
    /* Names */
    // Action Maps
    readonly string USERINTERFACE_ACTIONMAP_NAME = "UI";
    readonly string PLAYER_ACTIONMAP_NAME = "Player";
    // Actions
    readonly string PLAYER_MOVEACTION_NAME = "Move";
    readonly string PLAYER_SHOOTACTION_NAME = "Shoot";
    readonly string PLAYER_SPECIALACTION_NAME = "Special";

    /* Action Map References */
    private InputActionMap _userInterfaceActionMap;
    private InputActionMap _playerActionMap;
    
    /* Input Actions */
    // UI
    // Player
    private InputAction _playerMoveAction;
    private InputAction _playerShootAction;
    private InputAction _playerSpecialAction;

    private void Start()
    {
        this._userInterfaceActionMap = this._inputActionAsset.FindActionMap(USERINTERFACE_ACTIONMAP_NAME);
        this._playerActionMap = this._inputActionAsset.FindActionMap(PLAYER_ACTIONMAP_NAME);

        this._playerMoveAction = this._playerActionMap.FindAction(PLAYER_MOVEACTION_NAME);
        this._playerShootAction = this._playerActionMap.FindAction(PLAYER_SHOOTACTION_NAME);
        this._playerSpecialAction = this._playerActionMap.FindAction(PLAYER_SPECIALACTION_NAME);
    }
}

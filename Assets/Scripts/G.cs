using UnityEngine;

public sealed class G
{
    private static volatile G _instance;
    private PlayerMovementController _playerControler;
    private PlayerCameraController _cameraControler;
    private GameManager _gameManager;

    public static G Sys
    {
        get
        {
            if (_instance == null)
                _instance = new G();
            return _instance;
        }
    }

    public void clear()
    {
        _playerControler = null;
        _cameraControler = null;
        _gameManager = null;
    }

    public GameManager gameManager
    {
        get { return _gameManager; }
        set
        {
            if (_gameManager != null)
                Debug.Log("2 GameManager instanciated !");
            _gameManager = value;
        }
    }

    public PlayerMovementController playerControler
    {
        get { return _playerControler; }
        set
        {
            if (_playerControler != null)
                Debug.Log("2 PlayerControler instanciated !");
            _playerControler = value;
        }
    }

    public PlayerCameraController cameraControler
    {
        get {  return _cameraControler; }
        set
        {
            if (_cameraControler != null)
                Debug.Log("2 CameraControler instanciated !");
            _cameraControler = value;
        }
    }

}
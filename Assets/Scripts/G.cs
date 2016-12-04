using UnityEngine;

public sealed class G
{
    private static volatile G _instance;
    private PlayerMovementController _playerControler;
    private PlayerCameraController _cameraControler;

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
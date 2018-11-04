using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager Instance { get; private set; }

    public List<IInputListener> inputListeners = new List<IInputListener>();

    float horizontalArrow;
    float verticalArrow;
    Vector2 arrowMovement = Vector2.zero;
    bool pause;
    Vector3 cameraDirection = new Vector3();
    bool isRightClick;
    Vector2 mousePosition = Vector2.zero;

    private void Awake () {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
	}

    private void Update () {
        //Check buttons pressed associate with each controller.
        DirectionPlayerController();
        DirectionCameraController();
        PauseModeController();
        MouseController();
        //Send a notification of button changes to all subscribed controllers.
        foreach(IInputListener listener in inputListeners.ToArray()){
            listener.NotifyArrowAxis(arrowMovement);
            listener.NotifyCameraMovement(cameraDirection);
            listener.NotifyPause(pause);
            listener.NotifyRightClick(isRightClick);
            listener.NotifyMouseMovement(mousePosition);
        }
        cameraDirection = new Vector3(0, 0, 0);
    }

    public void AddInputListener(IInputListener input)
    {
        inputListeners.Add(input);
    }

    public void RemoveInputListener(IInputListener input)
    {
        inputListeners.Remove(input);
    }

    private void DirectionPlayerController(){
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalArrow = 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalArrow = -1;
        }
        else
        {
            horizontalArrow = 0;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalArrow = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalArrow = -1;
        }
        else
        {
            verticalArrow = 0;
        }
        arrowMovement = new Vector2(horizontalArrow, verticalArrow);
        arrowMovement = Vector2.ClampMagnitude(arrowMovement, 1);
    }

    private void DirectionCameraController(){
        if (Input.GetKey(KeyCode.W))
        {
            cameraDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cameraDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.E))
        {
            cameraDirection += Vector3.up;
        }
    }

    private void PauseModeController(){
        pause = Input.GetButtonDown("Cancel") ? true : false;
    }

    void MouseController(){
        isRightClick = Input.GetMouseButton(1);
        mousePosition = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}

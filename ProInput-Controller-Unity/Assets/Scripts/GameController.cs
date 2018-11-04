using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour,IInputListener{

    public static GameController Instance { get; private set; }
    bool isPause = false;
    private List<IInputListener> pauseListeners = new List<IInputListener>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start(){
        InputManager.Instance.AddInputListener(Instance);
    }

    public void NotifyArrowAxis(Vector2 axis){}

    public void NotifyPause(bool state)
    {
        if(state && !isPause){
            print("Pause");
            foreach(IInputListener inputListener in InputManager.Instance.inputListeners.ToArray())
            {
                if (inputListener != (IInputListener)Instance){
                    pauseListeners.Add(inputListener);
                    InputManager.Instance.RemoveInputListener(inputListener);
                }
            }
            isPause = true;
        }else if(state && isPause){
            print("Continue");
            foreach(IInputListener inputListener in pauseListeners){
                InputManager.Instance.AddInputListener(inputListener);
            }
            pauseListeners.Clear();
            isPause = false;
        }
    }

    public void NotifyCameraMovement(Vector3 direction){}

    public void NotifyMouseMovement(Vector2 mouseAxis) { }

    public void NotifyRightClick(bool isRightClickPressed) { }
}

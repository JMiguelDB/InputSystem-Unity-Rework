using UnityEngine;

public class PlayerInput : MonoBehaviour, IInputListener
{

    Vector2 movement;
    Movement move;
    // Use this for initialization
    void Start()
    {
        move = GetComponent<Movement>();
        InputManager.Instance.AddInputListener(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NotifyArrowAxis(Vector2 axis)
    {
        move.movement = axis;
    }

    public void NotifyPause(bool state){}

    public void NotifyCameraMovement(Vector3 direction){}

    public void NotifyMouseMovement(Vector2 mouseAxis) { }

    public void NotifyRightClick(bool isRightClickPressed){}
}

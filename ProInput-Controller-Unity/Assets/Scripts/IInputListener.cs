using UnityEngine;

public interface IInputListener
{
    void NotifyArrowAxis(Vector2 axis);
    void NotifyPause(bool state);
    void NotifyCameraMovement(Vector3 direction);
    void NotifyRightClick(bool isRightClickPressed);
    void NotifyMouseMovement(Vector2 mouseAxis);
}

using UnityEngine;

public class tramfunctions : MonoBehaviour
{
    public bool inside;
    public PlayerController playerController;

    public void Started()
    {
        inside = true;
    }

    public void Ended()
    {
        inside = false;
        playerController.canMove = true;
    }
}

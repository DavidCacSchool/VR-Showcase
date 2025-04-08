using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = transform.position - player.position;
            directionToPlayer.y = 0;

            Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = rotation;
        }
    }
}

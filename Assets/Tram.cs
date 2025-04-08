using UnityEngine;

public class Tram : MonoBehaviour
{
    [SerializeField] private Transform teleportLocation;
    [SerializeField] private bool reverse;
    [SerializeField] private Animator animator;
    [SerializeField] private bool parentToTram = true;
    [SerializeField] private Transform tram;
    [SerializeField] private Transform player;
    [SerializeField] private tramfunctions func;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleportLocation != null)
            {
                PlayerController playerController = other.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    other.transform.position = teleportLocation.position;
                    if (!reverse)
                    {
                        animator.Play("move");
                    }
                    else
                    {
                        animator.Play("move2");
                    }

                    playerController.canMove = false;
                }

                func.inside = true;
                Debug.Log($"{other.name} teleported to {teleportLocation.position}");
            }
            else
            {
                Debug.LogWarning("Teleport location not set!");
            }
        }
    }

    private void Update()
    {
        if (func.inside)
        {
            player.position = teleportLocation.position;
        }
    }
}

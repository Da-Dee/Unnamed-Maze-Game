using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Player player;
    public float followDistance = 3.0f; // Desired distance from the target
    private NavMeshAgent agent; // Reference to the NavMeshAgent

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 direction = transform.position - player.transform.position;
            direction.y = 0; // Ensure the direction is horizontal

            // Normalize and scale the direction to maintain the follow distance
            direction = direction.normalized * followDistance;

            // Calculate the desired position to maintain the distance
            Vector3 targetPosition = player.transform.position + direction;

            // Set the destination of the agent
            agent.SetDestination(targetPosition);
        }
    }
}

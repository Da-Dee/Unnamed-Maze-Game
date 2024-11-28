using UnityEngine;

public abstract class ProximityInteraction : MonoBehaviour
{
    public bool isPlayerNearby = false;
    void Update()
    {

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Trigger();
        }
    }
        private void OnTriggerEnter(Collider other)
        {
            // Check if the object that entered the trigger is tagged as "Player"
            if (other.CompareTag("Player"))
            {
                isPlayerNearby = true;
            }
        }
    
    public abstract void Trigger();

}  
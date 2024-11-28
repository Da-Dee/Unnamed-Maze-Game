using UnityEngine;

public abstract class ProximityInteraction : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            GameManager.instance.player.onEnterInterractable.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            GameManager.instance.player.onExitInterractable.Invoke();
        }
    }

    public abstract void Trigger();

}
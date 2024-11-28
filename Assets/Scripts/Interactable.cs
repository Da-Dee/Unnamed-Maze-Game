using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public bool isPlayerInRange = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            Interact();
        }
    }
    //TODO: use OnTrigerEnterMethod to interract

  

    public abstract void Interact();
}

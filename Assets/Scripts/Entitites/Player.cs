using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action<ProximityInteraction> onEnterInterractable;
    public Action onExitInterractable;

    public ProximityInteraction interractable;
    // Start is called before the first frame update
    void Start()
    {
        onEnterInterractable += OnEnterInterractable;
        onExitInterractable += OnExitInterractable;
    }
    void OnDisable()
    {
        onEnterInterractable -= OnEnterInterractable;
        onExitInterractable -= OnExitInterractable;
    }

    private void OnEnterInterractable(ProximityInteraction inte)
    {
        interractable = inte;

        Debug.Log($"Enter {interractable}");
    }

    private void OnExitInterractable()
    {
        interractable = null;

        Debug.Log($"Exit {interractable}");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interractable == null)
            {
                Debug.Log("There are no triggers nearby");
                return;
            }

            interractable.Trigger();

            Destroy(interractable.gameObject);
        }
    }
}

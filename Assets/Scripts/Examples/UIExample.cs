using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExample : MonoBehaviour
{
    public GameObject uiElement;

    void Start()
    {
        GameManager.instance.player.onEnterInterractable += EnterInteractable;
        GameManager.instance.player.onExitInterractable += ExitInteractable;
    }
    void OnDisable()
    {
        GameManager.instance.player.onEnterInterractable -= EnterInteractable;
        GameManager.instance.player.onExitInterractable -= ExitInteractable;
    }

    private void EnterInteractable(ProximityInteraction inte) { uiElement.SetActive(true); }
    private void ExitInteractable() { uiElement.SetActive(false); }
}

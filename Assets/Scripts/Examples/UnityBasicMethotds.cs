using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasicMethotds : MonoBehaviour
{
    void OnEnable() => Debug.Log("OnEnable");
    void OnDisable() => Debug.Log("OnDisable");
    void Awake() => Debug.Log("Awake");
    void Start() => Debug.Log("Start");
    void Update() => Debug.Log("Update");
    void OnDestroy() => Debug.Log("OnDestroy");
}

using System;
using UnityEngine;

public class WhatIsAnAction : MonoBehaviour
{
    public Action action;

    public Action<string, int> actionWithData;


    void Start()
    {
        action += MethodOne;
        action += MethodTwo;

        action?.Invoke();

        actionWithData += DataMethod;

        actionWithData?.Invoke("ela kai pou eisai", 32);

    }

    public void MethodOne() { Debug.Log("One"); }
    public void MethodTwo() { Debug.Log("Two"); }


    public void DataMethod(string test, int num)
    {
        Debug.Log(test);
        Debug.Log(num);
    }

}

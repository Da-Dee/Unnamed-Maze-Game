using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSystem : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { Debug.Log("Jump"); }
        //if (Input.GetKeyUp(KeyCode.Space)) { Debug.Log("Jump"); }
        //if (Input.GetKey(KeyCode.Space)) { Debug.Log("Jump"); }
    }
}

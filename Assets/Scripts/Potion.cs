using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : ProximityInteraction
{
    public override void Trigger()
    {
        Debug.Log("Heal");
    }
    
}

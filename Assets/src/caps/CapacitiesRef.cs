using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacitiesRef : MonoBehaviour {

    static public Capacity ember;

    public static void initCapacities()
    {
        ember = new Ember();
    }
}

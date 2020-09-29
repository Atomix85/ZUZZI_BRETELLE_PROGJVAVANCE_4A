using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacitiesRef : MonoBehaviour {

    static public Capacity ember;
    static public Capacity flamethrower;
    static public Capacity watergun;
    static public Capacity hydropump;
    static public Capacity vinewhip;
    static public Capacity solarbeam;
    static public Capacity tackle;


    public static void initCapacities()
    {
        ember = new Ember();
        flamethrower = new Flamethrower();
        watergun = new WaterGun();
        hydropump = new HydroPump();
        vinewhip = new VineWhip();
        solarbeam = new SolarBeam();
        tackle = new Tackle();
    }
}

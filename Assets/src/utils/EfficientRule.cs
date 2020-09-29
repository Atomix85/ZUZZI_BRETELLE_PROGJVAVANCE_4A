using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfficientRule {

    static public EfficientRule basicTableFire
        = new EfficientRule(0.5f, 2f, 1f, 0.5f);
    static public EfficientRule basicTableWater
        = new EfficientRule(0.5f, 0.5f, 1f, 2f);
    static public EfficientRule basicTablePoison
        = new EfficientRule(1f, 1f, 0.5f, 0.5f);
    static public EfficientRule basicTableGrass
        = new EfficientRule(2f, 0.5f, 2f, 0.5f);


    private float fire;
    private float water;
    private float grass;
    private float poison;

    public EfficientRule(float fire, float water,
        float poison,float grass)
    {
        this.fire = fire;
        this.water = water;
        this.grass = grass;
        this.poison = poison;
    }
    public float getEfficient(Capacity capacity)
    {
        float result;
        if (capacity is IFireType)
            result = this.fire;
        else if (capacity is IWaterType)
            result = this.water;
        else if (capacity is IPoisonType)
            result = this.poison;
        else if (capacity is IGrassType)
            result = this.grass;
        else
            result = 1.0f;
        return result;
    }
    public static EfficientRule calculateDoubleType(EfficientRule type1,EfficientRule type2)
    {
        return new EfficientRule(
            type1.fire * type2.fire,
            type1.water * type2.water,
            type1.poison * type2.poison,
            type1.grass * type2.grass);
    }
}

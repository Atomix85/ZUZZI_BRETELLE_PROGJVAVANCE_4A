using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Capacity : ICloneable
{

    protected string name;
    protected int power;
    protected int pp;
    protected Type idType;
    protected int type;
    protected int accuracy;
    
    public Capacity(string name, int power, int pp, int accuracy)
    {
        this.accuracy = accuracy;
        this.name = name;
        this.power = power;
        this.pp = pp;
    }
    public object Clone()
    {
        return this.MemberwiseClone();
    }
    public static int makeDegat(int level, int power, int attack, int defense, float CM, float charge)
    {
        int result = 0;

        result = (int)( ( ( (0.4f * level + 2) * power * attack )/
            (50 * defense) + 2 ) * CM * charge);

        return result;
    }

    public string getName()
    {
        return this.name;
    }

    public int getScoreCapacity(Pokemon from, Pokemon to, float charge){
        int a = 0,d = 0;
        if(this is SpecialAttack){
            a = from.getStats().SpeAttack;
            d = to.getStats().SpeDefense;
        }else{
            a = from.getStats().Attack;
            d = to.getStats().Defense;
        }
        int degat = makeDegat(from.getLevel(), this.power, a,d, 
            calculateCM(to),charge);
        return degat;
    }

    public int getPP()
    {
        return pp;
    }

    public Color getColorCapacity()
    {
        if(this is IFireType)
        {
            return new Color(0.97f, 0.32f, 0.19f);
        }
        else if(this is IWaterType)
        {
            return new Color(0.40f, 0.56f, 0.94f);
        }
        else if(this is IPoisonType)
        {
            return new Color(0.62f, 0.25f, 0.62f);
        }
        else if (this is IGrassType)
        {
            return new Color(0.47f, 0.78f, 0.31f);
        }
        return new Color(1.0F, 1.0f, 1.0f);
    }

    public float calculateChargeLevel(Pokemon emit){
        return emit.charged / 100.0f;
    }

    public float calculateCM(Pokemon target)
    {
        float result = target.resistance.getEfficient(this);
        if (result > 1.0f){
            //Debug.Log("C'est super efficace !");
        }
        else if(result == 0.0f)
        {
            //Debug.Log("Ca n'a aucun effet...");
        }
        else if(result < 1.0f)
        {
            //Debug.Log("Ce n'est très efficace...");
        }
        return result;
    }


    public virtual void use(Pokemon emit,Pokemon target)
    {
        //Debug.Log(emit.getName() + " utilise " + name);
        pp--;
    }
}

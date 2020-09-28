using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirtle : Pokemon, IWaterType
{

    public Squirtle(int level) : base("squirtle", level)
    {
        this.name = "Carapuce";
        setBaseStats();
        setStats();
        resistance = EfficientRule.basicTableWater;
    }

    void setBaseStats()
    {
        baseStats = new Stats();
        baseStats.Pv = 44;
        baseStats.Attack = 48;
        baseStats.Defense = 65;
        baseStats.SpeAttack = 50;
        baseStats.SpeDefense = 64;
        baseStats.Vitess = 43;
    }
}

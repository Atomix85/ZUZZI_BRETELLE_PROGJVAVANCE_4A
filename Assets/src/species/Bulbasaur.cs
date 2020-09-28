using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulbasaur : Pokemon, IPoisonType, IGrassType
{

    public Bulbasaur(int level) : base("bulbasaur", level)
    {
        this.name = "Bulbizarre";
        setBaseStats();
        setStats();
        resistance = EfficientRule.basicTableWater;
    }

    void setBaseStats()
    {
        baseStats = new Stats();
        baseStats.Pv = 45;
        baseStats.Attack = 49;
        baseStats.Defense = 49;
        baseStats.SpeAttack = 65;
        baseStats.SpeDefense = 65;
        baseStats.Vitess = 45;
    }
}

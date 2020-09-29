using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    private int pv;
    private int attack;
    private int defense;
    private int speAttack;
    private int speDefense;
    private int vitess;

    public Stats()
    {

    }

    public int Pv
    {
        get
        {
            return pv;
        }

        set
        {
            pv = value;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int SpeAttack
    {
        get
        {
            return speAttack;
        }

        set
        {
            speAttack = value;
        }
    }

    public int SpeDefense
    {
        get
        {
            return speDefense;
        }

        set
        {
            speDefense = value;
        }
    }

    public int Vitess
    {
        get
        {
            return vitess;
        }

        set
        {
            vitess = value;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : Team {

    public void Start(){
        if (KeepType.Instance.Difficulty == "hard")
        {
            agent = new MCTS(pokemonRenderer);
        }
        else
        {
            agent = new Randomer(pokemonRenderer);
        }
    }

    public override void updateBattle(GameObject obj, Team team)
    {
        base.updateBattle(obj,team);
        if (obj.transform.position.x <= 6)
        {
            obj.transform.Translate(Time.deltaTime * 10f, 0f, 0f);
        }
        else
        {
            canPlay = true;
        }
    }
}

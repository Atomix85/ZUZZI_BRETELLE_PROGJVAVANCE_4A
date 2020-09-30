﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playable : Agent
{
    public Playable(PokemonRender render) : base(render){

    }

    public override int interact(Pokemon pokemonMe, Pokemon pokemonAdv){
        if(pokemonMe != null
               && pokemonAdv != null)
        {
            int i = 0;
            if(Input.GetKeyDown(KeyCode.A)){
                i = pokemonMe.useCapacity(0, pokemonAdv, render);
            }else if(Input.GetKeyDown(KeyCode.Z)){
                i = pokemonMe.useCapacity(1, pokemonAdv, render);
            }else if(Input.GetKeyDown(KeyCode.Q)){
                i = pokemonMe.useCapacity(2, pokemonAdv, render);
            }else if(Input.GetKeyDown(KeyCode.S)){
                i = pokemonMe.useCapacity(3, pokemonAdv, render);
            }
            return i;
        }
        return 0;
    }
}

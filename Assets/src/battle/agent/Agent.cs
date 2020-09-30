using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent
{

    protected PokemonRender render;

    protected float internalHorloge;

    public Agent(PokemonRender render){
        this.render = render;
        internalHorloge = 0.0f;
    }

    public void addTime(float time){
        internalHorloge += time;
    }

    public abstract int interact(Pokemon pokemonMe, Pokemon pokemonAdv);
}

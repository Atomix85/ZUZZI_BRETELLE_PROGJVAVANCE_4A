using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomer : Agent
{
    private double born;
    private System.Random random;
    public Randomer(PokemonRender render) : base(render) {
        born = 0;
        random = new System.Random();
    }

    public override int interact(Pokemon pokemonMe, Pokemon pokemonAdv){
        
        if(internalHorloge > born)
        {
            born = random.NextDouble() * 2.0d + 1d;
            internalHorloge = 0;
            int i = 0;
            if(pokemonMe != null
               && pokemonAdv != null)
            {
                i = pokemonMe.useCapacity(-1, pokemonAdv, render);
            }
            return i;
        }
        return 0;
    }
}

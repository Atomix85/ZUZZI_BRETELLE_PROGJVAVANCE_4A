using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain {

    static public GameObject playerPart, trainerPart;
    private Team adversaire, me;

    public Terrain(Trainer adversaire, PlayerTeam me)
    {
        this.adversaire = adversaire;
        this.me = me;
    }
    public void callPokemon()
    {
        Pokemon pokemonAdv = adversaire.getFirstAlivePokemon();
        Pokemon pokemonMe = me.getFirstAlivePokemon();
        
        if(pokemonAdv != null)
        {
            PokemonBattleRender.makeSprite(trainerPart, pokemonAdv, false);
        }
        if(pokemonMe != null)
        {
            PokemonBattleRender.makeSprite(playerPart, pokemonMe, true);
        }
    }
    public void update(float time)
    {
        adversaire.updateBattle(trainerPart, me);
        me.updateBattle(playerPart, adversaire);

        
        Pokemon pokemonAdv = adversaire.getFirstAlivePokemon();
        Pokemon pokemonMe = me.getFirstAlivePokemon();


        if(pokemonMe != null)
        {
            pokemonMe.charge(time);
            PokemonBattleRender.update(playerPart, pokemonMe, true);
        }
        if(pokemonAdv != null){
            pokemonAdv.charge(time);
        }
    }
}

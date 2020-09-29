using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain {

    static public GameObject playerPart, trainerPart;
    static public float timer = 0;
    static public double born = 0;
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
    public void update(float t)
    {
        adversaire.updateBattle(trainerPart, me);
        me.updateBattle(playerPart, adversaire);

        System.Random rand = new System.Random();
        
        Pokemon pokemonAdv = adversaire.getFirstAlivePokemon();
        Pokemon pokemonMe = me.getFirstAlivePokemon();

        timer += t;

        if(pokemonMe != null
               && pokemonAdv != null)
        {
            int i = 0;
            if(Input.GetKeyDown(KeyCode.A)){
                i = pokemonMe.useCapacity(0, pokemonAdv, null);
                this.callPokemon();
            }else if(Input.GetKeyDown(KeyCode.Z)){
                i = pokemonMe.useCapacity(1, pokemonAdv, null);
                this.callPokemon();
            }else if(Input.GetKeyDown(KeyCode.Q)){
                i = pokemonMe.useCapacity(2, pokemonAdv, null);
                this.callPokemon();
            }else if(Input.GetKeyDown(KeyCode.S)){
                i = pokemonMe.useCapacity(3, pokemonAdv, null);
                this.callPokemon();
            }

            if(i != 0){
                adversaire.recoveryTime();
            }

        }

        if(timer > born)
        {
            born = rand.NextDouble() * 2.0d + 1d;
            timer = 0;
            int i = 0;
            if(pokemonMe != null
               && pokemonAdv != null)
            {
                i = pokemonAdv.useCapacity(-1, pokemonMe, me.pokemonRenderer);
            }
            this.callPokemon();

            if(i != 0){
                me.recoveryTime();
            }
        }


        if(pokemonMe != null)
        {
            pokemonMe.charge(t);
            PokemonBattleRender.update(playerPart, pokemonMe, true);
        }
        if(pokemonAdv != null){
            pokemonAdv.charge(t);
        }
    }
}

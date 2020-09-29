using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {

    public string name;
    Pokemon[] pokemons = new Pokemon[3];
    int nbPokemonInTeam = 0;
    protected bool canPlay = false;

    public int addPokemon(Pokemon pokemon)
    {
        if(nbPokemonInTeam < 3)
        {
            pokemons[nbPokemonInTeam] = pokemon;
            nbPokemonInTeam++;
        }
        return 0;
    }
    public Pokemon getFirstAlivePokemon()
    {
        foreach(Pokemon pokemon in pokemons){
            
            if( pokemon != null && pokemon.getPv() > 0)
            {
                return pokemon;
            }
        }
        return null; // Aucun pokemon vivant = gameover
    }
    public virtual void updateBattle(GameObject obj, Team team)
    {
        
    }

    public void recoveryTime(){
        IEnumerator coroutine = PokemonBattleRender.recoveryTime(gameObject);
        StartCoroutine(coroutine);
    }
}

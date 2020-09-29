using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour {
    public Trainer adversaireTerrain;
    public PlayerTeam meTerrain;

    Terrain terrain;
    float timer = 0;
    float tickDeltaTime = 0;
    // Use this for initialization
    void Start () {

        CapacitiesRef.initCapacities();

        meTerrain.addPokemon(new Bulbasaur(20));

        if (KeepType.Instance.Type == "Grass")
        {
            adversaireTerrain.addPokemon(new Bulbasaur(20));
        } else if (KeepType.Instance.Type == "Water")
        {
            adversaireTerrain.addPokemon(new Squirtle(20));
        }
        

        terrain = new Terrain(adversaireTerrain,meTerrain);
        Terrain.playerPart = meTerrain.gameObject;
        Terrain.trainerPart = adversaireTerrain.gameObject;

    }
	
	// Update is called once per frame
	void Update () {

        terrain.update(tickDeltaTime);
        
        tickDeltaTime = Time.deltaTime;

    }
}

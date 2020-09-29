using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBattleRender {

	public static void makeSprite(GameObject terrain, Pokemon pokemon,bool reversed)
    {
        SpriteRenderer sr;

        GameObject pokemonObject;

        pokemonObject = terrain.transform.
            Find("Combat-pokemon").gameObject;

        if (pokemonObject != null)
        {

            sr = pokemonObject.GetComponent<SpriteRenderer>();

            if (reversed)
            {
                sr.sprite = pokemon.getBackSprite();
            }
            else
            {
                sr.sprite = pokemon.getFrontSprite();
            }

            GameObject life = terrain.transform.Find("backgroundinterface/PV_TEXT").gameObject;
            GameObject pokname = terrain.transform.Find("backgroundinterface/POK_TEXT").gameObject;
            GameObject lifebar = terrain.transform.Find("backgroundinterface/barlife").gameObject;
            GameObject sublifebar = lifebar.transform.Find("barlifedes").gameObject;
            GameObject lv = terrain.transform.Find("backgroundinterface/LVL_TEXT").gameObject;

            float pvratio = (float)pokemon.getPv() / (float)pokemon.getStats().Pv;
            lifebar.transform.localScale = new Vector3( pvratio, 1.0f, 1.0f);

            if(pvratio >= 0.5f)
            {
                sublifebar.GetComponent<SpriteRenderer>().color = Color.green;
            }else if (pvratio >= 0.2f && pvratio < 0.5f)
            {
                sublifebar.GetComponent<SpriteRenderer>().color = Color.yellow;
            }else if (pvratio >= 0.0f && pvratio < 0.2f)
            {
                sublifebar.GetComponent<SpriteRenderer>().color = Color.red;
            }
            lv.GetComponent<TextMesh>().text = "Lv" + pokemon.getLevel();
            pokname.GetComponent<TextMesh>().text = pokemon.getName();
            if (reversed)
            {
                for (int i = 0; i < 4; i++)
                {
                    GameObject cap = terrain.transform.Find("background_cap/cap_" + (i + 1)).gameObject;
                    GameObject pp = cap.transform.Find("pp").gameObject;
                    GameObject back = cap.transform.Find("back").gameObject;
                    if (pokemon.capacities[i] != null)
                    {
                        cap.GetComponent<TextMesh>().text = pokemon.capacities[i].getName();
                        pp.GetComponent<TextMesh>().text = "PP : " + pokemon.capacities[i].getPP();
                        back.GetComponent<SpriteRenderer>().color = pokemon.capacities[i].getColorCapacity();
                    }
                    else
                    {
                        pp.GetComponent<TextMesh>().text = "";
                        cap.GetComponent<TextMesh>().text = "   --";
                    }

                }
                life.GetComponent<TextMesh>().text = "" + pokemon.getPv() + "/" + pokemon.getStats().Pv;
            }  
            else
                life.GetComponent<TextMesh>().text = "";

            
        }
    }
}

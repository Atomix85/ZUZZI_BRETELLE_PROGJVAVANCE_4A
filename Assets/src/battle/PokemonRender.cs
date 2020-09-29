﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonRender : MonoBehaviour
{

    public float minX, maxX;
    public float minY, maxY;

    public Vector2 v;

    public Vector2 originalPosition;

    public float sensibility = 0.5f;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.localPosition;
    }

    public IEnumerator warn(Pokemon p, int degat){
        System.Random rand = new System.Random();
        Vector2 dangerzone = new Vector2(
            (float) rand.NextDouble() * (2) - 1 + transform.position.x,
            (float) rand.NextDouble() * (2) - 1 + transform.position.y
        );

        GameObject targetInstance = Instantiate(target,dangerzone, Quaternion.identity);
        
        yield return new WaitForSeconds(1.0f);
        Debug.Log(Vector2.Distance(gameObject.transform.position, targetInstance.transform.position));
        if(Vector2.Distance(gameObject.transform.position, targetInstance.transform.position) < 1f){
            p.setPv(p.getPv() - degat);
            yield return PokemonBattleRender.recoveryTime(transform.parent.gameObject);
        }
        Destroy(targetInstance);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            v.y += Time.deltaTime * sensibility;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            v.y -= Time.deltaTime * sensibility;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            v.x -= Time.deltaTime * sensibility;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            v.x += Time.deltaTime * sensibility;
        }

        if(v.x > maxX){
            v.x = maxX;
        }
        if(v.x < minX){
            v.x = minX;
        }
        if(v.y < minY){
            v.y = minY;
        }
        if(v.y > maxY){
            v.y = maxY;
        }

        gameObject.transform.localPosition = originalPosition + v;

    }
}
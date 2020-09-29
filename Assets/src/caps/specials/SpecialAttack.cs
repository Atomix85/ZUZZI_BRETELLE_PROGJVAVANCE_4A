using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : Capacity {
    private PokemonRender render;
    public SpecialAttack(string name, int power, int pp, int accuracy) : base(name, power, pp, accuracy)
    {

    }

    public void setRenderTarget(PokemonRender render){
        this.render = render;
    }

    public override void use(Pokemon emit, Pokemon target)
    {
        base.use(emit, target);

        int speAttack = emit.getStats().SpeAttack;
        int speDefense = target.getStats().SpeDefense;
        int degat = makeDegat(emit.getLevel(), this.power, speAttack, speDefense, 
            calculateCM(target), calculateChargeLevel(emit));
        Debug.Log(render);
        if(render != null){
            IEnumerator coroutine = render.warn(target, degat);
            render.StartCoroutine(coroutine);
        }else{
            target.setPv(target.getPv() - degat);
        }
    }
}

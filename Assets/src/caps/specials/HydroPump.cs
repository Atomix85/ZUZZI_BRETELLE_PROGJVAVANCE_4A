using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroPump : Capacity, IWaterType {
    public HydroPump() : base("Hydrocanon", 110, 20, 80)
    {

    }
    public override void use(Pokemon emit, Pokemon target)
    {
        base.use(emit, target);

        int speAttack = emit.getStats().SpeAttack;
        int speDefense = target.getStats().SpeDefense;
        int degat = makeDegat(emit.getLevel(), this.power, speAttack, speDefense,
             calculateCM(target), calculateChargeLevel(emit));
        target.setPv(target.getPv() - degat);
    }
}

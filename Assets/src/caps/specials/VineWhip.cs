using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineWhip : Capacity, IGrassType {
    public VineWhip() : base("Fouet Liane", 45, 25, 100)
    {

    }
    public override void use(Pokemon emit, Pokemon target)
    {
        base.use(emit, target);

        int speAttack = emit.getStats().SpeAttack;
        int speDefense = target.getStats().SpeDefense;
        int degat = makeDegat(emit.getLevel(), this.power, speAttack, speDefense, calculateCM(target));
        target.setPv(target.getPv() - degat);
    }
}

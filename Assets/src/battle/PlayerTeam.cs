﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeam : Team {

    public override void updateBattle(GameObject obj, Team team)
    {
        base.updateBattle(obj,team);
        if (obj.transform.position.x >= -6)
        {
            obj.transform.Translate(Time.deltaTime * -10f, 0f, 0f);
        }
    }
}

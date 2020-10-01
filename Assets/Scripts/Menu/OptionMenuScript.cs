using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuScript : MonoBehaviour
{
    public void AllyFire()
    {
        KeepType.Instance.Pokeplayer = "Fire";
    }
    public void AllyGrass()
    {
        KeepType.Instance.Pokeplayer = "Grass";
    }
    public void AllyWater()
    {
        KeepType.Instance.Pokeplayer = "Water";
    }

    public void EnemyFire()
    {
        KeepType.Instance.Type = "Fire";
    }
    public void EnemyGrass()
    {
        KeepType.Instance.Type = "Grass";
    }
    public void EnemyWater()
    {
        KeepType.Instance.Type = "Water";
    }

    public void DifficultyHard()
    {
        KeepType.Instance.Difficulty = "Hard";
    }
    
    public void DifficultyEasy()
    {
        KeepType.Instance.Difficulty = "Easy";
    }
    
}


using System;
using System.Collections.Generic;
public class GameSimul{

    public static bool isFinished = false;

    public static float chargeAdv=0, chargeMe=0;

    public static int finalSituation = -1; // 0 = gameover; 1 = win

    public static int lifeAdv=100,lifeMe=100;

    public static void Reset(){
        lifeAdv = 100;
        lifeMe = 100;
        isFinished = false;
        finalSituation = -1;
        chargeAdv = 0;
        chargeMe = 0;
    }

    static bool EndGameSimul(Node action){
        return action.data.lifeAdversaire <= 0 || 
            action.data.lifePlayer <= 0;
    }

    public static void PlayAction(Node action, Pokemon pokemonMe, Pokemon pokemonAdv){
        chargeMe += 0.5f * pokemonMe.getStats().Vitess;
        chargeAdv += 0.5f * pokemonAdv.getStats().Vitess;

        if(chargeMe > 100) chargeMe = 0;
        if(chargeAdv > 100) chargeAdv = 0;

        if(chargeMe < 0) chargeMe = 0;
        if(chargeAdv < 0) chargeAdv = 0;

        int lifeToLose = pokemonAdv.simulCapacity(-1, pokemonMe, ref chargeAdv);
        switch(action.state){
            case PossibleAction.CAPACITY0:
                lifeAdv -= pokemonMe.simulCapacity(0,pokemonAdv, ref chargeMe);
                break;
            case PossibleAction.CAPACITY1:
                lifeAdv -= pokemonMe.simulCapacity(1,pokemonAdv, ref chargeMe);
                break;
            case PossibleAction.CAPACITY2:
                lifeAdv -= pokemonMe.simulCapacity(2,pokemonAdv, ref chargeMe);
                break;
            case PossibleAction.CAPACITY3:
                lifeAdv -= pokemonMe.simulCapacity(3,pokemonAdv, ref chargeMe);
                break;
            case PossibleAction.UP:
                lifeToLose = 0;
                chargeMe -= pokemonMe.getStats().Vitess * 0.5f;
                break;
            case PossibleAction.DOWN:
                lifeToLose = 0;
                chargeMe -= pokemonMe.getStats().Vitess * 0.5f;
                break;
            case PossibleAction.LEFT:
                lifeToLose = 0;
                chargeMe -= pokemonMe.getStats().Vitess * 0.5f;
                break;
            case PossibleAction.RIGHT:
                lifeToLose = 0;
                chargeMe -= pokemonMe.getStats().Vitess * 0.5f;
                break;
            case PossibleAction.WAIT:
               // chargeMe += pokemonMe.getStats().Vitess * 0.5f;
                break;
        }
        lifeMe-=lifeToLose;
        if(lifeMe <= 0){
            finalSituation = 0;
            isFinished = true;
        }
        else if(lifeAdv<= 0){
            finalSituation = 1;
            isFinished = true;
        }
        
    }

    public static System.Array GetNextPossibleAction(Node n){
        return PossibleAction.GetValues(typeof(PossibleAction));
    }

    public static object GetRandomAction(System.Array actions){
        System.Random rand = new System.Random();
        int i = 0;
        if(i >= 1){
            return PossibleAction.WAIT;
        }else{
            return actions.GetValue(rand.Next(actions.Length-1));
        }
    }
}

public struct Register{
    //Feed forward
    public int a;
    public int b;

    //Life
    public int lifePlayer;
    public int lifeAdversaire;

    public Register(int a,int b){
        this.a = a;
        this.b = b;
        this.lifePlayer = 100;
        this.lifeAdversaire = 100;
    }
}
public enum PossibleAction{
    UNDETERMINED,
    WAIT,
    UP,
    DOWN,
    LEFT,
    RIGHT,
    CAPACITY0,
    CAPACITY1,
    CAPACITY2,
    CAPACITY3
}
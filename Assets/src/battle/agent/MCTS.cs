using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCTS : Agent
{
    private Node tree;
    public static float FREQUENCY = 0.4f; 
    private int[] a;
    private float born;

    public MCTS(PokemonRender render) : base(render){
        tree = new Node(new Register(0,0));
        born = 0.0f;
        a = new int[4];
    }

    public bool thrust(){
        foreach(Node n in tree.getPossibleAction()){
            if(n.data.b > 20){
                return true;
            }
        }
        return false;
    }

    public override int interact(Pokemon pokemonMe, Pokemon pokemonAdv){


        if(pokemonAdv != null && pokemonMe != null){
            
            
            GameSimul.lifeAdv = pokemonAdv.getStats().Pv;
            GameSimul.lifeMe = pokemonMe.getStats().Pv;
            GameSimul.chargeAdv = pokemonAdv.charged;
            GameSimul.chargeMe = pokemonMe.charged;
            for(int i = 0 ; i < 4 ; i++){
                if(pokemonMe.capacities[i] != null)
                    GameSimul.ppMe[i] = pokemonMe.capacities[i].getPP();
                if(pokemonAdv.capacities[i] != null)
                    GameSimul.ppAdv[i] = pokemonAdv.capacities[i].getPP();
            }

            compute(tree,pokemonMe, pokemonAdv);
        }

        int k = 0;
        if(internalHorloge > born && thrust())
        {
            born = FREQUENCY;
            internalHorloge = 0;

            float max = float.MinValue;
            PossibleAction currentAction = PossibleAction.UNDETERMINED;
            Node n = null;
            bool priorityMove = false;
            foreach(GameObject o in GameObject.FindGameObjectsWithTag("target")){
                if(Vector2.Distance(o.transform.position, render.transform.position) < 2f){
                    priorityMove = true;;
                }
            }

            foreach(Node child in tree.getPossibleAction()){
                if(child.state != PossibleAction.UNDETERMINED){
                    if((float)child.data.a / (float)child.data.b > max ){
                        currentAction = child.state;
                        max = (float)child.data.a / (float)child.data.b;
                        n = child;
                    }
                }
            }


            a = new int[4];
            if(priorityMove || currentAction == PossibleAction.ESQUIVE){
                if(render.v.x >= 0)
                    a[2] = 1;
                else
                    a[3] = 1;
                
                if(render.v.y >= 0)
                    a[1] = 1;
                else
                    a[0] = 1;
            }


            int i = 0;
            if(pokemonMe != null
               && pokemonAdv != null)
                {
                switch(currentAction){
                    case PossibleAction.UNDETERMINED:
                    case PossibleAction.WAIT:
                        break;

                    case PossibleAction.CAPACITY0:
                        i = pokemonMe.useCapacity(0, pokemonAdv, render);
                        break;
                    case PossibleAction.CAPACITY1:
                        i = pokemonMe.useCapacity(1, pokemonAdv, render);
                        break;
                    case PossibleAction.CAPACITY2:
                        i = pokemonMe.useCapacity(2, pokemonAdv, render);
                        break;
                    case PossibleAction.CAPACITY3:
                        i = pokemonMe.useCapacity(3, pokemonAdv, render);
                        break;
                }
            }
            if(n != null)
                tree = n;

            return i;
        }
        if(pokemonMe != null){
            if(a[0] >= 0.8f){
                render.v.y += Time.deltaTime * SENSIBILITY;
                pokemonMe.charge(COST_MOVE);
            }
            if(a[1] >= 0.8f){
                render.v.y -= Time.deltaTime * SENSIBILITY;
                pokemonMe.charge(COST_MOVE);
            }
            if(a[2] >= 0.8f){
                render.v.x -= Time.deltaTime * SENSIBILITY;
                pokemonMe.charge(COST_MOVE);
            }
            if(a[3] >= 0.8f){
                render.v.x += Time.deltaTime * SENSIBILITY;
                pokemonMe.charge(COST_MOVE);
            }
        }
        return 0;
    }
    
    void compute(Node action,Pokemon pokemonMe, Pokemon pokemonAdv){
        int i = 0;
        //Debug.Log(action.data.a + "/" + action.data.b);
        while(!GameSimul.isFinished){
            System.Array actions = GameSimul.GetNextPossibleAction(action);

            PossibleAction choice = (PossibleAction)GameSimul.GetRandomAction(actions);
            
            Node exitanteNode = action.Exist(choice);
            if(exitanteNode == null){
                Node selectedAction = action.AddChild(new Register(0,0));
                selectedAction.parent = action;
                selectedAction.setState(choice);
                
                action = selectedAction;
            }else{
                action = exitanteNode;
            }
            GameSimul.PlayAction(action,pokemonMe,pokemonAdv);
            //Debug.Log(GameSimul.lifeAdv + " | " + GameSimul.lifeMe);
            //if(i++ > 10000) break;
        }
        action.data.b = 1;
        if(GameSimul.finalSituation == 0)//gameover
            action.data.a = 0;
        else                    //win
            action.data.a = 1;

        Node.Retropropagation(action);
        GameSimul.Reset();
    }
}

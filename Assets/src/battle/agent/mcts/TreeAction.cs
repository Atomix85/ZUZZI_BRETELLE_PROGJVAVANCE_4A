using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private LinkedList<Node> children;

    public Node parent;

    public PossibleAction state;
    public Register data;

    public Node(Register data){
        this.data = data;
        this.children = new LinkedList<Node>();
    }
    public Node(Node parent, Register data){
        this.parent = parent;
        this.data = data;
        this.children = new LinkedList<Node>();
    }
    public Node AddChild(Register data)
    {
        Node n = new Node(data);
        children.AddFirst(n);
        return n;
    }

    public LinkedList<Node> getPossibleAction(){
        return children;
    }
    public int nbChilden(){
        return children.Count;
    }

    public void setState(PossibleAction p){
        this.state = p;
    }

    public static void Retropropagation(Node node){
        int i = 0;
        int validate = node.data.a;
        while(node.parent != null){
            node.parent.data.a += validate;
            node.parent.data.b++;
            node = node.parent;
            //if(i++ > 10000) break;

        }
    }

    public Node Exist(PossibleAction p ){
        if(children != null){
            foreach(var child in children){
                if(child.state == p){
                    return child;
                }
            }
        }
        return null;
    }
    public Node GetChild(int i)
    {
        foreach (Node n in children)
            if (--i == 0)
                return n;
        return null;
    }

}

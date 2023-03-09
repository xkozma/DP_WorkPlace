using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMover : ScriptableObj
{
    private Vector3 Direction;
    public bool isGoing = false;

    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator> ();
    
 
    IEnumerator CoroutineCoordinator()
    {
        while (true)
        {
            while (coroutineQueue.Count >0)
            yield return StartCoroutine(coroutineQueue.Dequeue());
            yield return null;
        }
    }

    void Start()
    {
        FindObjectOfType<KeyboardInteraction>().ButtonDown.AddListener(DoAction);
    }
    
    private void DoAction(string input)
    {
        if (Button(input,"m"))
        {
            // u = Up, d = Down, l = Left, r = Right, b = Back, f = Forward
            Go("u",10);
            Go("l",10);
            Go("f",20);

            
            StartCoroutine(CoroutineCoordinator());
        }
    }

    private void Go(string direction,float seconds)
    {
        switch (direction)
        {
            case "u":
                coroutineQueue.Enqueue(GoUp(seconds));
                break;
            case "d":
                coroutineQueue.Enqueue(GoDown(seconds));
                break;
            case "l":
                coroutineQueue.Enqueue(GoLeft(seconds));
                break;
            case "r":
                coroutineQueue.Enqueue(GoRight(seconds));
                break;
            case "b":
                coroutineQueue.Enqueue(GoBack(seconds));
                break;
            case "f":
                coroutineQueue.Enqueue(GoForward(seconds));
                break;
            default:
                // code to handle an invalid direction input
                break;
        }
    }
    
    IEnumerator GoUp(float sec)
    {
        isGoing = true;
        Direction = Vector3.up;
        yield return new WaitForSeconds(sec);
        isGoing = false;
    }
    
    IEnumerator GoDown(float sec)
    {
        isGoing = true;
        Direction = Vector3.down;
        yield return new WaitForSeconds(sec);
        isGoing = false;
    }
    
    IEnumerator GoRight(float sec)
    {
        isGoing = true;
        Direction = Vector3.right;
        yield return new WaitForSeconds(sec);
        isGoing = false;
    }
    
    IEnumerator GoLeft(float sec)
    {
        isGoing = true;
        Direction = Vector3.left;
        yield return new WaitForSeconds(sec);
        isGoing = false;
    }

    IEnumerator GoBack(float sec)
    {
        isGoing = true;
        Direction = Vector3.back;
        yield return new WaitForSeconds(sec);
        isGoing = false;
    }
    
    IEnumerator GoForward(float sec)
    {
        isGoing = true;
        Direction = Vector3.forward;
        yield return new WaitForSeconds(sec);
        isGoing = false;
    }
    
    private void FixedUpdate()
    {
        if(isGoing)
            transform.localPosition += Direction;
    }
}

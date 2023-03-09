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
            coroutineQueue.Enqueue(GoUp(5));
            coroutineQueue.Enqueue(GoDown(1));
            coroutineQueue.Enqueue(GoRight(15));
            
            StartCoroutine(CoroutineCoordinator());
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

    
    
    private void FixedUpdate()
    {
        if(isGoing)
            transform.localPosition += Direction;
    }
}

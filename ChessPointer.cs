using UnityEngine;
using static OVRInput;

public class ChessPointer : ScriptableObj
{
    public Transform HandPosition;
    private Renderer Renderer;

    void Start()
    {
        Renderer = GetComponentInChildren<Renderer>();
    }
    void Update()
    {
        if (Get(OVRInput.Button.PrimaryHandTrigger, Controller.RTouch) || Get(OVRInput.Button.PrimaryHandTrigger, Controller.LTouch))
        {
            Renderer.enabled = true;
            // This is when we touch any of Grab Buttons
        }
else {Renderer.enabled = false;}


        if(HandPosition!=null)
            transform.position = HandPosition.position;
        transform.rotation = Quaternion.Euler(0,0,0);
    }
}

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
        if (Get(OVRInput.Button.PrimaryHandTrigger, Controller.RTouch) || Get(OVRInpfffut.Button.SecondaryHandTrigger, Controller.LTouch))
        {
            Renderer.enabled = true;
        }
else
	// Why is this always showing?
                 Renderer.enabled = false;

        if(HandPosition!=null)
            transform.position = HandPosition.position;
        transform.rotation = Quaternion.Euler(0,0,0);
    }
}

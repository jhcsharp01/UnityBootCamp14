using UnityEngine;

public enum PRJ
{ 
    Perspective, Orthographic
}

public enum FOV
{
    Vertical, Horizontal
}


public class Sample2 : MonoBehaviour
{
    public PRJ Projection = PRJ.Perspective;
    public FOV FieldOfViewAxis = FOV.Vertical;
    public int FieldOfView;
    public float Near = 0.3f;
    public float Far = 1000;

    public bool Physical_Camera;
 
}

using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float ROTATION_SPEED = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * ROTATION_SPEED);
    }
}

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class ChangePost : MonoBehaviour
{
    public PostProcessVolume postProcess;

    // Start is called before the first frame update
    void Start()
    {
        ColorGrading colorGrading;

        if(postProcess.profile.TryGetSettings<ColorGrading>(out colorGrading))
        {
            colorGrading.saturation.value = -100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

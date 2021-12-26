using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class ChangePost : MonoBehaviour
{
    public PostProcessVolume postProcess;

    public ColorGrading colorGrading;
    public ChromaticAberration chromaticAberration;

    // Start is called before the first frame update
    void Start()
    {
        if(postProcess.profile.TryGetSettings<ColorGrading>(out colorGrading))
        {
            colorGrading.saturation.value = 10f;
        }

        if (postProcess.profile.TryGetSettings<ChromaticAberration>(out chromaticAberration))
        {
            chromaticAberration.intensity.value = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

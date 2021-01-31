using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlicker : MonoBehaviour
{
    [SerializeField]
    private bool isScreenOn = true;

    [SerializeField] private Light screenGlow;

    [SerializeField]
    private bool shouldAlwaysUseImage;

    [SerializeField] private Color dominantColour;
    /*[SerializeField]*/ private Color emmissiveColour;
    [SerializeField] private Color textureEmmissiveColour;
    [SerializeField] private Texture[] textureImage;
    [SerializeField] private Material offMaterial;

    [Tooltip("Screen will flicker to new variant after this time.")]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float[] flickerTickRate;

    [Tooltip("Screen will display a non-solid colour image every nth flick.")]
    [SerializeField] private int displayImageEveryNthFlicker;
    private Color white = Color.white;
    private Material onMaterial = null;
    private Renderer renderer = null;
    private Color[] colourVariants;
    private Color[] emmissionVariants;

    private int currentFlickerRateID = 0;
    private int currentFlicker = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        onMaterial = renderer.material;

        colourVariants = new Color[Settings.VAL_NUMBER_SCREEN_FLICKER_COLOUR_VARIANTS];
        emmissionVariants = new Color[Settings.VAL_NUMBER_SCREEN_FLICKER_COLOUR_VARIANTS]; 
        CreateColourVariants(dominantColour, colourVariants);
        CreateColourVariants(emmissiveColour, emmissionVariants);

        ToggleScreen(isScreenOn);
    }

    private IEnumerator ChangeScreen()
    {
        do
        {
            currentFlicker++;
        


            if (shouldAlwaysUseImage || currentFlicker % (displayImageEveryNthFlicker - 1) == 0)
            {
                SetScreen(textureImage[currentFlicker % textureImage.Length], white, textureEmmissiveColour);
            }
            else
            {
                SetScreen(null, colourVariants[currentFlicker % colourVariants.Length/*Random.Range(0, colourVariants.Length - 1)*/] , emmissionVariants[currentFlicker % emmissionVariants.Length/*Random.Range(0, emmissionVariants.Length - 1)]*//*emmissionVariants[currentFlickerRateID]*/]);
            }
            //Debug.Log("current Flicker rate ID: " + currentFlickerRateID);
            
            currentFlickerRateID = currentFlicker % (flickerTickRate.Length);
            yield return new WaitForSeconds(flickerTickRate[currentFlickerRateID]);
        } while (isScreenOn);
        
    }

    private void SetScreen(Texture pTexture, Color pBase, Color pEmmissive)
    {
        onMaterial.SetTexture("_BaseColorMap", pTexture);
        onMaterial.SetColor("_BaseColor", pBase);
       //material.SetFloat("_EmissiveIntensity", Random.Range(0.0f, 100.0f));
         /*material.SetColor("_EmissiveColor", pEmmissive);
         material.SetFloat("_EmissiveIntensity", 50f);
         material.SetFloat("_EmissiveExposureWeight", 1.0f);*/
    }

    /*  private void SetScreenToColour()
      {
          material.SetTexture("_MainTex", null);
          material.SetColor("_Color", colourVariants[currentFlickerRateID]);
          material.SetColor("_EmissionColor", emmissionVariants[currentFlickerRateID]);
      }*/

    private void CreateColourVariants(Color pColour, Color[] pColourArray)
    {
        float h = float.MaxValue;
        float s = float.MaxValue;
        float v = float.MaxValue;
        Color.RGBToHSV(pColour, out h, out s, out v);

        float valueSteps = v / pColourArray.Length;

        for (int i = 0; i < pColourArray.Length; i++)
        {
            float newV = v - (valueSteps * (i));
            Color variant = Color.HSVToRGB(h, s, newV);
            pColourArray[i] = variant;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isScreenOn)
        {
            StopAllCoroutines();
        }
    }

    public void ToggleScreen(bool pIsSwitchingOn)
    {
        if (pIsSwitchingOn)
        {
            currentFlicker = 0;
            currentFlickerRateID = 0;

            //True
            isScreenOn = pIsSwitchingOn;
            screenGlow.enabled = pIsSwitchingOn;
            renderer.material = onMaterial;

            StartCoroutine(ChangeScreen());
        }
        else 
        {
            //False
            isScreenOn = pIsSwitchingOn;
            screenGlow.enabled = pIsSwitchingOn;
            renderer.material = offMaterial;

            StopCoroutine(ChangeScreen());
        }
    }

    public bool IsScreenOn
    {
        get { return isScreenOn; }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlicker : MonoBehaviour
{
    [SerializeField]
    private bool isScreenOn = true;

    [SerializeField] private Color dominantColour;
    /*[SerializeField]*/ private Color emmissiveColour;
    [SerializeField] private Color textureEmmissiveColour;
    [SerializeField] private Texture textureImage;
    
    [Tooltip("Screen will flicker to new variant after this time.")]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float[] flickerTickRate;

    [Tooltip("Screen will display a non-solid colour image every nth flick.")]
    [SerializeField] private int displayImageEveryNthFlicker;
    private Color white = Color.white;
    private Material material = null;
    private Color[] colourVariants;
    private Color[] emmissionVariants;

    private int currentFlickerRateID = 0;
    private int currentFlicker = 0;

    

    // Start is called before the first frame update
    void Start()
    {        
        material = GetComponent<Renderer>().material;

        colourVariants = new Color[Settings.VAL_NUMBER_SCREEN_FLICKER_COLOUR_VARIANTS];
        emmissionVariants = new Color[Settings.VAL_NUMBER_SCREEN_FLICKER_COLOUR_VARIANTS]; 
        CreateColourVariants(dominantColour, colourVariants);
        CreateColourVariants(emmissiveColour, emmissionVariants);

        StartCoroutine(ChangeScreen());
    }

    private IEnumerator ChangeScreen()
    {
        do
        {
            currentFlicker++;
            if (currentFlicker % (displayImageEveryNthFlicker - 1) == 0)
            {
                SetScreen(textureImage, white, textureEmmissiveColour);
            }
            else
            {
                SetScreen(null, colourVariants[currentFlicker % colourVariants.Length/*Random.Range(0, colourVariants.Length - 1)*/] , emmissionVariants[currentFlicker % emmissionVariants.Length/*Random.Range(0, emmissionVariants.Length - 1)]*//*emmissionVariants[currentFlickerRateID]*/]);
            }
            Debug.Log("current Flicker rate ID: " + currentFlickerRateID);
            
            currentFlickerRateID = currentFlicker % (flickerTickRate.Length);
            yield return new WaitForSeconds(flickerTickRate[currentFlickerRateID]);
        } while (isScreenOn);
        
    }

    private void SetScreen(Texture pTexture, Color pBase, Color pEmmissive)
    {
        material.SetTexture("_BaseColorMap", pTexture);
        material.SetColor("_BaseColor", pBase);
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
        
    }

    public bool IsScreenOn
    {
        get { return isScreenOn; }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIHitEffect : MonoBehaviour
{

    public Image hitEffectImage;   // Assign this in the Inspector with the UI Image component for the hit effect
    public float effectDuration = 0.2f; // Duration of the hit effect
    public float maxAlpha = 0.5f; // Maximum alpha value for the hit effect

    private Color originalColor; // Original color of the hit effect image


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(hitEffectImage != null)
            originalColor = hitEffectImage.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerHitEffect()
    {
        StopAllCoroutines(); // Stop any ongoing hit effect coroutines
        StartCoroutine(HitEffectCoroutine());
    }

    private System.Collections.IEnumerator HitEffectCoroutine()
    {
        //turn alpha up
        float t = 0; 
        while (t< effectDuration / 2f)
        {
            t += Time.deltaTime;       //counter
            // -- Blend in Effect --
            float normalized = t / (effectDuration / 2f); 
            Color c = hitEffectImage.color;
            c.a = Mathf.Lerp(0,maxAlpha, normalized); 
            hitEffectImage.color = c;
            yield return null;    //wait 1 Frame then continue
        }

        //turn alpha back down
        t = 0;
        while(t< effectDuration / 2f)
        {
            t += Time.deltaTime;  //counter
            // -- Blend out Effect --
            float normalized = t / (effectDuration / 2f);
            Color c = hitEffectImage.color;
            c.a = Mathf.Lerp(maxAlpha, 0, normalized);
            hitEffectImage.color= c;
            yield return null;      //wait 1 Frame then continue
        }

        hitEffectImage.color = originalColor; //return original colour to the image. 

    }

}

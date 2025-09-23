using UnityEngine;

public class PlayerHitEffect : MonoBehaviour
{

    public Color hitColor = Color.red;
    public float flashDuration = 0.1f; // Duration of the flash effect

    private Color originalColor;
    private Renderer playerRenderer; // Reference to the player's renderer

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRenderer = GetComponent<Renderer>(); // Get the Renderer component
        originalColor = playerRenderer.material.color; // Store the original color
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerHitEffect()
    {
        StopAllCoroutines(); // Stop any ongoing flash effects
        StartCoroutine(FlashEffect());
    }

    private System.Collections.IEnumerator FlashEffect()
    {
        playerRenderer.material.color = hitColor; // Change to hit color
        yield return new WaitForSeconds(flashDuration); // Wait for the duration
        playerRenderer.material.color = originalColor; // Revert to original color
    }

}

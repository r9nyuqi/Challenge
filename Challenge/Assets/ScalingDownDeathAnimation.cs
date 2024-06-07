using UnityEngine;


public class ScaleDown : MonoBehaviour
{
    public float duration = 1.0f; // Duration of the scaling down animation
    private Vector3 originalScale;
    private float timeElapsed = 0;

    private bool start = false;
    void Start()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    void Update()
    {
        
        if (start && timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float scale = Mathf.Lerp(1, 0, timeElapsed / duration);
            transform.localScale = originalScale * scale;

            if (timeElapsed >= duration)
            {
                Destroy(gameObject); // Optionally destroy the object after scaling down
            }
        }
    }

    public void TriggerScaleDown()
    {
        start = true;
    }
}
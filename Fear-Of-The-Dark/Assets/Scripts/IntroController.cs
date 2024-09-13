using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour
{
    public CanvasGroup[] introTexts; // Array to hold all the intro text CanvasGroups
    private int currentTextIndex = 0; // Index to keep track of the current text being shown
    public float fadeDuration = 1.0f; // Duration for each fade in/out
    public float displayDuration = 2.0f; // Duration to display each text before fading out
    public float delayBeforeNextText = 1.0f; // Delay before the next text fades in
    private float displayTimer = 0f;
    private bool isDisplaying = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure all texts are initially transparent and inactive
        foreach (CanvasGroup text in introTexts)
        {
            text.alpha = 0f; // Fully transparent
            text.gameObject.SetActive(false);
        }

        // Activate and start fading in the first text
        if (introTexts.Length > 0)
        {
            introTexts[currentTextIndex].gameObject.SetActive(true);
            StartCoroutine(FadeText(introTexts[currentTextIndex], 0f, 1f, fadeDuration));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisplaying)
        {
            displayTimer += Time.deltaTime;

            // Check if the display duration has been exceeded
            if (displayTimer >= displayDuration)
            {
                // Fade out the current text
                StartCoroutine(FadeText(introTexts[currentTextIndex], 1f, 0f, fadeDuration));
                displayTimer = 0f;
                isDisplaying = false;
            }
        }
    }

    // Coroutine to handle fading in and out
    private IEnumerator FadeText(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;

        // If fade-in is complete, start the display timer
        if (endAlpha == 1f)
        {
            isDisplaying = true;
        }
        // If fade-out is complete, move to the next text after a delay
        else if (endAlpha == 0f)
        {
            canvasGroup.gameObject.SetActive(false);

            // Wait for the delay before the next text fades in
            yield return new WaitForSeconds(delayBeforeNextText);

            currentTextIndex++;

            // If there are more texts, fade in the next one
            if (currentTextIndex < introTexts.Length)
            {
                introTexts[currentTextIndex].gameObject.SetActive(true);
                StartCoroutine(FadeText(introTexts[currentTextIndex], 0f, 1f, fadeDuration));
            }
        }
    }
}

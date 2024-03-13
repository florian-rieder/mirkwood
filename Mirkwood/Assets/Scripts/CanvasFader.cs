using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class CanvasFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 5f;

    [SerializeField] private EndCards endCards;

    private bool isFading = false;

    // Call this function to start the fade-in effect
    public async UniTask FadeToBlack()
    {
        if (!isFading)
        {
            await FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1f, fadeDuration);
        }

        MusicController.Instance.CrossfadeOutro();

        await endCards.LaunchEndCards();
    }

    // Coroutine for fading the canvas group
    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        isFading = true;
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            canvasGroup.alpha = alpha;
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
        isFading = false;
    }
}

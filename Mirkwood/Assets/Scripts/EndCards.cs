using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class EndCards : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> texts;


    public async UniTask LaunchEndCards(){
        await UniTask.Delay(TimeSpan.FromSeconds(2), ignoreTimeScale: false);

        foreach (var text in texts)
        {
            await FadeCanvasGroup(text, 0f, 1f, 1f);

            await UniTask.Delay(TimeSpan.FromSeconds(4), ignoreTimeScale: false);

            await FadeCanvasGroup(text, 1f, 0f, 1f);
        }

        await UniTask.Delay(TimeSpan.FromSeconds(2), ignoreTimeScale: false);

        SceneManager.LoadScene(0);
    }


    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
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
    }
}

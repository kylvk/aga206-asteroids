using System.Collections;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public float flashDuration = 0.33f;
    private Image flashImage;
    private Color imageColor;


    void Start()
    {
        flashImage = GetComponent<Image>();
        //imageColor = flashImage.color;
        //StartCoroutine(FlashRoutine());
    }

    public IEnumerator FlashRoutine()
    {

        float timer = 0f;
        float t = 0f;
        float alphaFrom = 1f;
        float alphaTo = 0;

        Debug.Log("Started Flashing");
        yield return null;
        Debug.Log("Still Flashing");
        yield return new WaitForSeconds(flashDuration);
        Debug.Log("Stopped Flashing");

        while (t < 1f)
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / flashDuration);
            float alpha = Mathf.Lerp(alphaFrom, alphaTo, t);
            Color col = imageColor;
            col.a = alpha;
            flashImage.color = col;
            yield return new WaitForEndOfFrame();

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(FlashRoutine());
    }
}

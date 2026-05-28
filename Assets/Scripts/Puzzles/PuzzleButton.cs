using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleButton : MonoBehaviour, IPointerClickHandler
{
    public int buttonId;
    private Renderer rend;
    private Color originalColor;
    private Color clickedColor = Color.white;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SequencePuzzle.Instance.PressButtonServerRpc(buttonId);
        StartCoroutine(FlashEffect());
    }

    System.Collections.IEnumerator FlashEffect()
    {
        if (rend != null)
        {
            rend.material.color = clickedColor;
            yield return new WaitForSeconds(0.3f);
            rend.material.color = originalColor;
        }
    }
}
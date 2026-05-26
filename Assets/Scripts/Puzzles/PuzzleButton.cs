using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleButton : MonoBehaviour, IPointerClickHandler
{
    public int buttonId;

    public void OnPointerClick(PointerEventData eventData)
    {
        SequencePuzzle.Instance.PressButtonServerRpc(buttonId);
    }
}
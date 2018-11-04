using HighlightingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{

    public static Selector instance = null;

    public KeyCode addSelectHotKey = KeyCode.LeftControl;
    public KeyCode subtractSelectHotKey = KeyCode.LeftShift;

    public Color highlightColor = Color.white;

    public LayerMask layerMask;

    [SerializeField] private Selection selection;
    public GameObject currCollider = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId.Equals(-1))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            HighlightOff(selection.SelectedObjects);

            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, layerMask) && currCollider != null)
            {
                if (hit.collider.gameObject.Equals(currCollider))
                {
                    if (Input.GetKey(addSelectHotKey))
                    {
                        selection.AddClickSelect(hit.collider.gameObject);
                    }
                    else if (Input.GetKey(subtractSelectHotKey))
                    {
                        selection.SubtractClickSelect(hit.collider.gameObject);
                    }
                    else
                    {
                        selection.ClickSelect(hit.collider.gameObject);
                    }

                    HighlightOn(selection.SelectedObjects);
                }
            }
            else
            {
                if (Input.GetKey(addSelectHotKey) || Input.GetKey(subtractSelectHotKey) || Input.GetKey(KeyCode.LeftAlt)) ;
                else selection.Clear();

            }
        }

    }

    private void Awake()
    {
        instance = this;
    }

    private void HighlightOn(List<GameObject> targets)
    {
        if (targets.Count > 0)
        {
            foreach (GameObject g in targets)
            {
                g.GetComponent<Highlighter>().ConstantOnImmediate(highlightColor);
            }
        }

    }

    private void HighlightOff(List<GameObject> targets)
    {
        if (targets.Count > 0)
        {
            foreach (GameObject g in targets)
            {
                g.GetComponent<Highlighter>().ConstantOffImmediate();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, layerMask))
        {
            currCollider = hit.collider.gameObject;
        }
        else
        {
            currCollider = null;
        }
    }
}

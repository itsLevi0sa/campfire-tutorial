using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject mainObject;

    [Header("Highlight")] public GameObject[] objectsToHighlight;
    [SerializeField] private HighlightStyle _style = HighlightStyle.Regular;

    public enum HighlightStyle
    {
        Regular,
        Tree
    }

    public HighlightStyle Style => _style;

    private int _initialLayer;

    private void Awake()
    {
        // Only saving layer of first object (could it be an issue later on?)
        _initialLayer = objectsToHighlight[0].layer;
    }

    public void Highlight()
    {
        foreach (GameObject gameObject in objectsToHighlight) gameObject.layer = LayerMask.NameToLayer("Highlight");
    }

    public void RemoveHighlight()
    {
        foreach (GameObject gameObject in objectsToHighlight) gameObject.layer = _initialLayer;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Selection
{
    [SerializeField] private List<GameObject> selectedObjects = new List<GameObject>();

    public List<GameObject> SelectedObjects
    {
        get
        {
            return selectedObjects;
        }

        set
        {
            selectedObjects = value;
        }
    }

    public void Clear()
    {
        selectedObjects.Clear();
    }

    public void ClickSelect(GameObject target)
    {
        SelectedObjects.Clear();
        SelectedObjects.Add(target);
    }

    public void AddClickSelect(GameObject target)
    {
        if (!SelectedObjects.Contains(target))
        {
            SelectedObjects.Add(target);
        }
        else
            return;
    }

    public void SubtractClickSelect(GameObject target)
    {
        if (SelectedObjects.Contains(target))
        {
            SelectedObjects.Remove(target);
        }
        else
            return;
    }

    public void FrameSelect(GameObject[] targets)
    {
        SelectedObjects.Clear();
        foreach (GameObject g in targets)
        {
            SelectedObjects.Add(g);
        }
    }

    public void AddFrameSelect(GameObject[] targets)
    {
        foreach (GameObject g in targets)
        {
            if (!SelectedObjects.Contains(g))
            {
                SelectedObjects.Add(g);
            }
        }
    }

    public void SubtractFrameSelect(GameObject[] targets)
    {
        foreach (GameObject g in targets)
        {
            if (SelectedObjects.Contains(g))
            {
                SelectedObjects.Remove(g);
            }
        }
    }
}

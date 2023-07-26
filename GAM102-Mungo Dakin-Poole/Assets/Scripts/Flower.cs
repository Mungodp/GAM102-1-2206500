using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private Outline _outline;

    public event Action OnCollectFlower;
    private void Start()
    {
        _outline = GetComponent<Outline>();
    }
    
    public void Interact()
    {
        OnCollectFlower?.Invoke();
        gameObject.SetActive(false);
    }

    public void SetOutline(bool value)
    {
        _outline.enabled = value;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    private float _initialFlowers;
    private float _score;

    private void Start()
    {
        _initialFlowers = transform.childCount;
        UIManager.instance.SetFlowersText($"FLOWERS COLLECTED: 0 / {_initialFlowers}");

        //Subscribe to events
        foreach (Transform flowerTransform in transform)
        {
            if (flowerTransform.TryGetComponent(out Flower flower))
            {
                flower.OnCollectFlower += OnCollectFlower;
            }
        }
    }

    private void OnCollectFlower()
    {
        UIManager.instance.SetFlowersText($"FLOWERS COLLECTED: {++_score} / {_initialFlowers}");
        if(_score >= _initialFlowers) UIManager.instance.WinGame();
    }
    
    private void OnDestroy()
    {
        //Unsubscribe to events
        foreach (Transform flowerTransform in transform)
        {
            if (flowerTransform.TryGetComponent(out Flower flower))
            {
                flower.OnCollectFlower -= OnCollectFlower;
            }
        }
    }

   
}

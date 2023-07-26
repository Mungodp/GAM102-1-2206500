using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowerDetector : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask flowersLayer;

    private Collider[] _flowers;
    private Flower _flower;
    
    private void Update()
    {
        if (_flower != null) _flower.SetOutline(false);
        _flowers = Physics.OverlapSphere(transform.position, radius, flowersLayer);
        SetFlower(true);

        if (Input.GetKeyDown(KeyCode.E) && _flower != null)
        {
            _flower.Interact();
        }
    }

    private void SetFlower(bool value)
    {
        if (_flowers != null && _flowers.Length > 0)
        {
            _flower = _flowers[0].GetComponent<Flower>();
            _flower.SetOutline(value);
        }
        else
        {
            _flower = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

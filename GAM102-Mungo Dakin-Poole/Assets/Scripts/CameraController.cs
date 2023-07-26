using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;
    private float _x, _y;
    
    private Transform _player;
    private Vector3 _playerInitialRotation;

    private void Start()
    {
        _player = transform.parent;
        _playerInitialRotation = _player.localRotation.eulerAngles;
    }

    private void LateUpdate()
    {
        _x -= Input.GetAxisRaw("Mouse Y") * sensitivityY * Time.deltaTime;
        _y += Input.GetAxisRaw("Mouse X") * sensitivityX * Time.deltaTime;
        
        _player.localRotation = Quaternion.Euler(_playerInitialRotation.x+_x, _playerInitialRotation.y+_y, 0f);
    }
}

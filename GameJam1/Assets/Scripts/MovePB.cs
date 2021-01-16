using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePB : MonoBehaviour
{
    private float _playerInput;
    private Rigidbody _rigidbody; // shouldn't this have been rigidBody. Doesn't really matter just naming conventions
    private Transform _transform;
    private float _rotationInput;
    private Vector3 _userRot;
    private bool _userJumped;
    private const float _inputScale = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // project settings can see horizontal axis named Horizontal and Vertical ... Why this works
        _playerInput = Input.GetAxis("Vertical");
        _rotationInput = Input.GetAxis("Horizontal");
        _userJumped = Input.GetButton("Jump");
    }

    void FixedUpdate()
    {
        _userRot = _transform.rotation.eulerAngles;
        _userRot += new Vector3(0, _rotationInput, 0);
        _transform.rotation = Quaternion.Euler(_userRot);
        _rigidbody.velocity += _transform.forward * _playerInput * _inputScale;

        if (_userJumped)
        {
            _rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange);
        }
    }
}

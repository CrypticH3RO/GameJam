using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAA : MonoBehaviour
{
    private float _userHorizontalInput;
    private const float ScaleMovement = 0.25f;
    private Transform playerTransform;
    private float _userRotInput;
    private Vector3 _userRot;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {

        // vertical is up and down
        _userHorizontalInput = Input.GetAxis("Vertical");
        _userRotInput = Input.GetAxis("Horizontal");
        Debug.Log(_userHorizontalInput);
        // by default you get the cartian? 5:30
        // eularAngles are the x y z angles
        _userRot = playerTransform.rotation.eulerAngles;
        // vector 3 is just an object that captures the 3 dimensional inputs of any sorts. 
        _userRot += new Vector3(0, _userRotInput, 0);

        // have to convert to Eular coordinates because playerTransforms.rotation expects a cartian angle
        playerTransform.rotation = Quaternion.Euler(_userRot);
        //playerTransform.rotation = Quaternion.Eular(0,0,0);
        playerTransform.position += transform.forward * _userHorizontalInput * ScaleMovement;

    }
}

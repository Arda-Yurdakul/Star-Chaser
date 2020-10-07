using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using static UnityEngine.ParticleSystem;

public class ShipMovement : MonoBehaviour
{
    [Header ("General")]
    [SerializeField] [Tooltip("How fast it moves")] [Range (0,100)] private float moveSpeed;
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;

    [Header ("Rotation")]
    [SerializeField] [Tooltip("How much it turns")] private float turnAmount;
    [SerializeField] private float positionPitchFactor;
    [SerializeField] private float positionYawFactor;

    [Header ("Lasers")]
    [SerializeField] private GameObject[] guns;


    private float horizontalThrow;
    private float verticalThrow;
    bool canMove;


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;
        GetInput();
        ProcessTranslation();
        ProcessRotation();
        ProcessFire();
       
    }

    private void ProcessFire()
    {
        bool buttonIsDown = CrossPlatformInputManager.GetButton("Fire1");
        int boolValue = buttonIsDown ? 1 : 0;
        foreach (GameObject gun in guns)
        {
            ParticleSystem bullet = gun.GetComponent<ParticleSystem>();
            EmissionModule emission = bullet.emission;
            emission.rateOverTime = boolValue * 10;
        }

    }

    private void GetInput()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

    }

    private void ProcessTranslation()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + horizontalThrow * moveSpeed * Time.deltaTime, -xRange, xRange),
                                    Mathf.Clamp(transform.localPosition.y + verticalThrow * moveSpeed * Time.deltaTime, -yRange, yRange),
                                    transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(verticalThrow * turnAmount + (transform.localPosition.y + 2) * positionPitchFactor,
                                    (transform.localPosition.x * -positionYawFactor),
                                    (horizontalThrow * -turnAmount));
    }

    public void Die()
    {
        print("Im dead");
        canMove = false;
    }
}

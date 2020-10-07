using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            print("feuer frei");
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

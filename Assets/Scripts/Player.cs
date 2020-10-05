using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] [Tooltip("How fast it moves")] private float moveSpeed;
    [SerializeField] [Tooltip("How much it turns")] private float turnAmount;
    [SerializeField] private float positionPitchFactor;
    [SerializeField] private float positionYawFactor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + horizontalThrow * moveSpeed * Time.deltaTime,-14f,14f),
                                    Mathf.Clamp(transform.localPosition.y + verticalThrow * moveSpeed * Time.deltaTime, -11f, 11f), 
                                    transform.localPosition.z);

        transform.localRotation = Quaternion.Euler(verticalThrow * turnAmount + (transform.localPosition.y + 2) * positionPitchFactor,
                                    (transform.localPosition.x * -positionYawFactor), 
                                    (horizontalThrow * -turnAmount));
          
            
         
        //transform.localRotation = Quaternion.Euler(verticalThrow * 10 , 0 , horizontalThrow * -10);

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            print("feuer frei");
    }

    private void ProcessRotation()
    {

    }
}

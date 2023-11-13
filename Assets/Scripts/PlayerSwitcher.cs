using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject AirCharacter;
    private GameObject EarthCharacter;

    private GameObject ActiveCharacter;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetNextChar();
            }

        
    }

    private void SetNextChar()
    {

        if (ActiveCharacter == AirCharacter)
        {
            ActiveCharacter = EarthCharacter;
            
        }
        else
        {
            ActiveCharacter = AirCharacter;
           
        }
    }

}

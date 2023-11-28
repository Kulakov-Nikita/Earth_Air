using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPillarSpawner : MonoBehaviour
{
        [SerializeField]GameObject windPillar;
        public void Spawn()
        {

            GameObject AirObject = GameObject.FindGameObjectWithTag("AirCharacter");
            float dir = AirObject.GetComponent<AirCharScript>().GetDirection();
            float XPosition = dir * (AirObject.transform.position.x + 1.0f);
            float YPosition = AirObject.transform.position.y;

            Instantiate(windPillar, new Vector3(XPosition, YPosition, 0), transform.rotation);
        }
    
}

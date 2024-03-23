using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        // other is ship child component, so get parents then get tag
        if(
            other.gameObject.transform.root.gameObject.name == "PlayerSpaceShip" &&
            other.gameObject.tag != "Laser"
        )
        {
            //RacePoint HitRacePoint = other.gameObject.GetComponent<RacePoint>();
            if(RaceManager.Instance.racePoints[0] == gameObject)
            {
                Debug.Log("next mark collected!");
                Destroy(gameObject);
            }
        }
    }
}

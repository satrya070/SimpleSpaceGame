using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePoint : MonoBehaviour
{
    bool HasHit = false;

    private void OnTriggerEnter(Collider other) {
        // other is ship child component, so get parents then get tag
        if(
            other.gameObject.transform.root.gameObject.name == "PlayerSpaceShip" &&
            other.gameObject.tag != "Laser" &&
            HasHit == false
        )
        {
            // Countdown logic
            if (RaceManager.Instance.OnCount == false)
            {
                RaceManager.Instance.OnCount = true;
                RaceManager.Instance.timerText.gameObject.SetActive(true);
                Debug.Log($"Count starting now!: {RaceManager.Instance.Countdown}");
            }

            // Checkpoint logic
            HasHit = true;
            if(RaceManager.Instance.racePoints[0] == gameObject)
            {
                RaceManager.Instance.racePoints.RemoveAt(0);
                Debug.Log("next mark collected!");
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipGun : MonoBehaviour
{
    public float shootRate;
    private float shootrateTimestamp;
    PlayerSpaceship shipOwner;

    public GameObject m_shotPrefab;
    RaycastHit hit;
    float range = 1000f;

    RectTransform crosshair;
    Camera mainCamera;
    Vector3 CrosshairSceenPos = new Vector3((Screen.width / 2), (Screen.height / 2 + 19.1f), 1f);

    private void Start()
    {
        shipOwner = transform.root.GetComponent<PlayerSpaceship>();
        crosshair = GameObject.Find("crosshair").GetComponent<RectTransform>();
        if(crosshair != null) { 
            Debug.Log( crosshair.TransformPoint(crosshair.anchoredPosition));
            Debug.Log(Screen.currentResolution);
        }
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (
            Input.GetMouseButton(0)
            & !GameManager.GameManagerInstance.LevelPaused
            & GameManager.GameManagerInstance.LevelStarted
            & !GameManager.GameManagerInstance.LevelEnded)
        {
            if(Time.time > shootrateTimestamp)
            {
                shootRay();
                shootrateTimestamp = Time.time + shootRate;
            }
        }
    }

    void shootRay()
    {
        AudioManager.Instance.PlaySfx("LaserGun");

        // direction vector from camera through crosshair
        Vector3 DirectionVector = mainCamera.ScreenToWorldPoint(CrosshairSceenPos) - mainCamera.transform.position;
        
        // constructs the ray to be cast from camera through crossheir in world space
        Ray crossRay = new Ray(mainCamera.transform.position, DirectionVector * range);

        // default laser target if no raycast (ray through crossheir * range 1000f)
        Vector3 laserTarget = mainCamera.transform.position + (DirectionVector * range);
        Debug.DrawRay(mainCamera.transform.position, DirectionVector * range, Color.green, 10f);

        // cast the ray and set laser target if it has a hit
        RaycastHit crossHit;
        bool crossHasHit = Physics.Raycast(crossRay, out crossHit);
        if(crossHasHit)
        {
            // if ray crossheir has hit send laser to point of hit instead
            laserTarget = crossHit.point;
            //Debug.Log($"Cross has a hit!: {crossHit.point}");
        }

        GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
        laser.GetComponent<ShotBehavior>().setTargetComponents(
            shipOwner.gameObject.tag,
            laserTarget,//transform.position + (transform.forward * range),
            shipOwner.GetComponent<Damage>(),
            shipOwner.gameObject.tag
        );

        // TODO delete if no issues
        // draw a line throught the bottom right frustum (adds/subtracts 1f) for 0 start index
        //Debug.DrawLine(mainCamera.transform.position, mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth -1, 1f,1f)), Color.red, 5f, false);

        //Vector3 DirectionVector = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth -1, 1f,1f)) - mainCamera.transform.position; 
        //Debug.DrawLine(mainCamera.transform.position, mainCamera.transform.position + (DirectionVector * 100f), Color.red, 5f, false);

        // get middle of screen then adds crosshair y-offset
        // Vector3 SceenCenter = new Vector3((Screen.width / 2), (Screen.height / 2 + 19.1f), 1f);
        // // convert that screenpoint to a world point & get the direction vector relative to camera position
        // Vector3 DirectionVector2 = mainCamera.ScreenToWorldPoint(SceenCenter) - mainCamera.transform.position;
        // Debug.DrawLine(mainCamera.transform.position, mainCamera.transform.position + (DirectionVector2 * 300f), Color.red, 5f, true);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bounds : MonoBehaviour
{   
    [SerializeField]
    GameObject centerCapsule;

    //[SerializeField]
    private TMP_Text OutboundsText;

    [SerializeField]
    Transform LevelCenter;

    private bool TurningBack;

    // Start is called before the first frame update
    void Start()
    {   
        GameObject player = GameObject.FindWithTag("Player");

        //TMP_Text[] children = player.GetComponentsInChildren<TMP_Text>();
        OutboundsText =  player.GetComponentsInChildren<TMP_Text>()[0];
        OutboundsText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.root.tag != "Player")
        {
            Destroy(other.gameObject);
            return;
        }

        Vector3 LevelDirection = (LevelCenter.position - other.gameObject.transform.root.position);

        Transform PlayerTrans = other.gameObject.transform.root;
        PlayerTrans.position = PlayerTrans.position + (100 * LevelDirection.normalized);
        //PlayerTrans.root.Rotate(LevelDirection);
        PlayerTrans.root.rotation = Quaternion.Euler(LevelDirection);

        StartCoroutine(DisplayOutbounds());
        
    }

    IEnumerator DisplayOutbounds()
    {
        OutboundsText.enabled = true;

        yield return new WaitForSeconds(3f);

        OutboundsText.enabled = false;
    }
}

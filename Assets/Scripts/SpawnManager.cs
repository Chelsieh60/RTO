using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RayCastManager;
    List<ARRaycastHit> m_hits = new List<ARRaycastHit>();
    [SerializeField]
    GameObject spawnObject;
    [SerializeField]
    ARFaceManager faceManager;
    [SerializeField]
    ARPlaneManager planeManager;
    [SerializeField]
    ARCameraManager camManager;
    //AnimationClip animationClip;
    //Animator anim;
    Camera arCam;
    GameObject spawnedObject;
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public bool step1Complete = false;
    public bool step2Complete = false;
    public bool step3Complete = false;
    public bool step1Start = false;
    public bool step2Start = false;
    public bool step3Start = false;
    public bool pawStart = false;
    public bool objectSpawned = false;
    public bool oneObject = false;
    public Camera player;
    public float height;
    
    bool flipCam = false;
    // Start is called before the first frame update
    void Start()
    {
        //anim = spawnObject.GetComponent<Animator>();
        //animationClip = spawnObject.GetComponent<AnimationClip>();
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        /*faceManager.enabled = false;
        planeManager.enabled = true;
        m_RayCastManager.enabled = true;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RayCastManager.Raycast(Input.GetTouch(0).position, m_hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null && oneObject == false)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                    
                    }
                    else
                    {
                        SpawnPrefab(m_hits[0].pose.position);
                        oneObject = true;
                    }
                }
            }
        }
        else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
        {
            spawnedObject.transform.position = m_hits[0].pose.position;
         
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            spawnedObject = null;
        }
        if (step1Start == true && height > 5)
        {
            StartCoroutine(Step1());
        }
        else if (height <= 5)
        {
            step2.SetActive(true);
            step1Complete = true;
            step1Start = false;
            step2Start = true;
        }
        if (step1Complete == true && step2Start == true)
        {
            step2.SetActive(true);
            pawStart = true;
            StartCoroutine(Step2());
        }
 

        }
    private void SpawnPrefab(Vector3 spawnPos)
    {
        spawnedObject = Instantiate(spawnObject, spawnPos, Quaternion.identity);
        objectSpawned = true;
        step1Start = true;
        
        //spawnedObject = Instantiate(textInstructions, spawnPos, Quaternion.identity);
    }
    IEnumerator Step1()
    {
        while (height > 5)
        {
            spawnedObject.SetActive(false);
            yield return new WaitForSeconds(30);
        }
    }
    IEnumerator Step2()
    {
        step3.SetActive(true);
        step3Start = true;
        step2Complete = true;
        yield return new WaitForSeconds(30f);
    }
    public void Flip()
    {
        /*m_RayCastManager.enabled = false;
        faceManager.enabled = true;
        planeManager.enabled = false;*/
        if (camManager.requestedFacingDirection == CameraFacingDirection.User)
        {
            if (m_RayCastManager != null)
                m_RayCastManager.enabled = true;

            Debug.Log("changing to rear facing camera");
            camManager.requestedFacingDirection = CameraFacingDirection.World;
            Debug.Log(camManager.currentFacingDirection);
        }
        else
        {
            if (m_RayCastManager != null)
                m_RayCastManager.enabled = false;

            Debug.Log("changing to front facing camera...");
            camManager.requestedFacingDirection = CameraFacingDirection.User;
            Debug.Log(camManager.currentFacingDirection);
        }
    }
}

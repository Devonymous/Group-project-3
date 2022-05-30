using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagesWallScriptTut : MonoBehaviour
{
    public Camera cam;
    public float detectRange = 20;

    [Space]
    [Header("WALL BUILDING PARAMETERS")]
    public GameObject wallMarker;
    public GameObject wallCube;
    public int wallCubeAmount = 3;
    public float wallCubeDistance = 2;
    public GameObject wallCubeExplosion;
    public Vector3 wallCubeExplosionOffset;
    public float wallBuildingTime = 1;
    public float wallDuration = 10;
    public float updateRate = 0.05f;

    private Vector3 destination;
    private Quaternion rotation;
    private bool inRange;
    private bool wallMarkerActive;
    private bool wallBuilding;

    void Start()
    {
        wallMarker.SetActive(false);        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            wallMarkerActive = true;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            wallMarkerActive = false;
        }

        if(wallMarkerActive)
        {            
            UpdateWallMarker();
        }
        else
        {
            wallMarker.SetActive(false);
        }        

        if(Input.GetButtonDown("Fire1") && inRange && !wallBuilding)
        {
            BuildWall();
        }
    }

     void UpdateWallMarker()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, detectRange))
        {
            inRange = true;
            destination = hit.point;
            rotation = Quaternion.LookRotation(ray.direction);
        }
        else
        {
            inRange = false;
        }
        
        if(inRange)
        {
            wallMarker.transform.position = destination;
            rotation = new Quaternion(wallMarker.transform.rotation.x, rotation.y, wallMarker.transform.rotation.z, wallMarker.transform.rotation.w);
            wallMarker.transform.rotation = rotation;
            wallMarker.SetActive(true);
        }
        else
            wallMarker.SetActive(false);
    }

    void BuildWall ()
    {        
        wallBuilding = true;
        wallMarkerActive = false;
        GameObject wall = new GameObject();
        wall.transform.position = destination;
        wall.name = "Wall";       

        List<Material> cubeMaterials = new List<Material>();
        for(int i=0; i<wallCubeAmount; i++)
        {         
            var cube = Instantiate(wallCube, destination + new Vector3(i*wallCubeDistance,0,0), Quaternion.identity) as GameObject; // CUBE SPAWNING
            cube.transform.SetParent(wall.transform);
            cubeMaterials.Add(cube.transform.GetChild(0).GetComponent<MeshRenderer>().material);
        }

        wall.transform.rotation = rotation;
        wall.transform.Translate(new Vector3(-(int)(wallCubeAmount/2)*wallCubeDistance,0,0), Space.Self);

        wallBuilding = false;

        StartCoroutine(DestroyWall(wall, cubeMaterials));
    }

    IEnumerator DestroyWall (GameObject wallToDestroy, List<Material> materials)
    {
        float duration = wallDuration;
        float cracksAmount = 0;

        while(duration >0)
        {
            duration -= updateRate;

            if(cracksAmount < 1)
            {
                cracksAmount += 1/((wallDuration-0.2f)/updateRate);
                for(int i=0; i<materials.Count; i++)
                    materials[i].SetFloat("CracksAmount_", cracksAmount);
            }

            yield return new WaitForSeconds (updateRate);

            if(duration <= 0)
            {
                for(int j=0; j<wallToDestroy.transform.childCount; j++)
                {
                    var explosion = Instantiate (wallCubeExplosion, wallToDestroy.transform.GetChild(j).transform.position + wallCubeExplosionOffset, Quaternion.identity) as GameObject;
                    Destroy(explosion, 3);
                }

                Destroy(wallToDestroy);
            }             
        }
    }
}

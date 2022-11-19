using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideWalls : MonoBehaviour
{

    public GameObject player;
    public LayerMask layer;
    Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getObjectsInTheWay();
    }

    private void getObjectsInTheWay()
    {
        float cameraPlayerDistance = Vector3.Magnitude(transform.position - player.transform.position);
        RaycastHit hit;
        Physics.Raycast(transform.position, player.transform.position, out hit, cameraPlayerDistance, layer);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            r = hit.collider.GetComponent<Renderer>();
            if (r)
            {
                StartCoroutine(waiter());
               
               
            }


        }

    }

    IEnumerator waiter() {
        r.enabled = false;
        yield return new WaitForSeconds(2);
        r.enabled = true;
    }
   




}

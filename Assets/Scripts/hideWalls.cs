using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideWalls2 : MonoBehaviour
{

    public GameObject player;
    public LayerMask layer;
    private Color originalColor;
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
            //Debug.Log(hit.collider.gameObject.name);
            r = hit.collider.GetComponent<Renderer>();
            originalColor = r.sharedMaterial.color;
            float time = 0;
            if (r)
            {
               
                //Debug.Log("Hit object" + hit.collider.gameObject.name);
                // Change the material of all hit colliders
                // to use a transparent shader.
                r.material.shader = Shader.Find("Transparent/Diffuse");
                 Color tempColor = r.material.color;
                 tempColor.a = 0.3F;
                 
               
                 r.material.color = tempColor;   
                
            }
            


        }
        else {
                
                //hit.collider.gameObject.GetComponent<Material>().color = originalColor;
            }

    }

    IEnumerator waiter() {
        r.enabled = false;
        yield return new WaitForSeconds(2);
        r.enabled = true;
    }
   




}

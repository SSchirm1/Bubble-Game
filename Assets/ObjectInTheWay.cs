using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInTheWay : MonoBehaviour
{
    [SerializeField] private List<GameObject> currentlyInTheWay;
    [SerializeField] private List<GameObject> alreadyTransparent;
    [SerializeField] private List<Shader> originalShader;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask layerMask;
    private Transform camera;

    private void Awake()
    {
        currentlyInTheWay = new List<GameObject>();
        alreadyTransparent = new List<GameObject>();

        camera = this.gameObject.transform;
    }

    private void Update()
    {
      GetAllObjectsInTheWay();

      MakeObjectsTransparent();
      MakeObjectsSolid();
    }

    private void GetAllObjectsInTheWay()
    {
  
        currentlyInTheWay.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(camera.position - player.position);

        Ray ray1_Forward = new Ray(camera.position, player.position - camera.position);
        Ray ray1_Backward = new Ray(player.position, camera.position - player.position);

        var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance, layerMask);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance, layerMask);
        
        foreach (var hit in hits1_Forward)
        {
            // kanskje endre til layer type sjekk eller lignende
            Debug.Log(hit.collider.gameObject.name);
            GameObject gameObject = hit.collider.gameObject;
            
            if (!currentlyInTheWay.Contains(gameObject)) 
            {
                currentlyInTheWay.Add(gameObject);
            }
        }


    }

    private void MakeObjectsTransparent()
    {
      for (int i = 0; i < currentlyInTheWay.Count; i++)
      {
        GameObject gameObject = currentlyInTheWay[i];

        if (!alreadyTransparent.Contains(gameObject))
        {
          Renderer r = gameObject.GetComponent<Renderer>();
          Shader original = r.material.shader;
          r.material.shader = Shader.Find("Transparent/Diffuse");
          Color tempColor = r.material.color;
          tempColor.a = 0.3f;
          r.material.color = tempColor;

          alreadyTransparent.Add(gameObject);
          originalShader.Add(original);
        }
      }

    }

    private void MakeObjectsSolid()
    {
        for (int i = alreadyTransparent.Count-1; i >= 0; i--)
        {
          GameObject gameObject = alreadyTransparent[i];

          if (!currentlyInTheWay.Contains(gameObject))
          {
              // might need shader
              Shader shader = originalShader[i];
              Renderer r = gameObject.GetComponent<Renderer>();
              r.material.shader = shader;
              
              alreadyTransparent.Remove(gameObject);
              originalShader.Remove(shader);
          }
        }
    }

}

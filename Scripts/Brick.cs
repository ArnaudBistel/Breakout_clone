using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 100;
    public Vector3 rotator;
    public Material hitMaterial;

    private Material _orgMaterial;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        // offsetting the rotation of the bricks depending on position
        transform.Rotate(rotator * (transform.position.x + transform.position.y) * .1f);
        _renderer = GetComponent<Renderer>();
        _orgMaterial = _renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        
        if (hits <= 0)
        {
            // score points
            GameManager.Instance.Score += points;

            Destroy(gameObject);
        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }

    void RestoreMaterial()
    {
        _renderer.material = _orgMaterial;
    }
}

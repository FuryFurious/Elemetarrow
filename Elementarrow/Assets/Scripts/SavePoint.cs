using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {
    public static SavePoint currentActivePoint;
    public static Vector2 currentSpawnpoint;



    private ParticleSystem particleSystem;
    private bool isActive = false;
    private Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8 && !isActive)
        {
            if (SavePoint.currentActivePoint != null)
                SavePoint.currentActivePoint.SetAllActive(false);


            SavePoint.currentActivePoint = this;
            SavePoint.currentSpawnpoint = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
            GameObject.FindObjectOfType<LevelHandler>().currentSpawnposition = new Vector2(spawnPoint.position.x, spawnPoint.position.y);

            SetAllActive(true);

            Debug.Log("Lallala");
        }
    }

    void Start()
    {
        particleSystem = transform.FindChild("ParticleStart").GetComponent<ParticleSystem>();
        spawnPoint = transform.FindChild("SpawnPoint").transform;
    }

    void SetAllActive(bool val)
    {
        isActive = val;
        particleSystem.gameObject.SetActive(val);
    }


    
}

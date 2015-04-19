using UnityEngine;
using System.Collections;

public class LevelHandler  : MonoBehaviour{

    public Vector3 currentSpawnposition;
    public string levelName;


    void Start()
    {
        currentSpawnposition = new Vector3(0.5f, 1, 0);

        levelName = "Level1";

        DontDestroyOnLoad(this.gameObject);

        resetLevel();
    }



    public void resetLevel()
    {
        //currentSpawnposition = new Vector2(0,0);

        Application.LoadLevel(levelName);


        

        

        
        }

    public void changeLevel(string levelNameKKK)
    {
        Application.LoadLevel(levelNameKKK);

        switch (levelNameKKK)
        {
            case "SceneGerd":
                currentSpawnposition = new Vector3(-4.725304f, 2.004747f, -0.466938f);
                break;
            case "SceneLisa":
                currentSpawnposition = new Vector3(-6.15f, 1, 0);
                break;
            case "Level4":
                currentSpawnposition = new Vector3(0.8f, 0.4f, 0);
                break;


        }

        levelName = levelNameKKK;

        GameObject.FindObjectOfType<PlayerMovement>().gameObject.transform.position = new Vector3(currentSpawnposition.x, currentSpawnposition.y, 0);

  //      currentActivePoint;
    //    currentSpawnpoint;

    }
}

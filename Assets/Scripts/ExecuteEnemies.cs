using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ExecuteEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Execute()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
                enemy.GetComponent<Enemy>().BlowUp();
        }
        Invoke("LoadMenu", 2.0f);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}

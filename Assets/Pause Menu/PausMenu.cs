using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void PlayGame(PlayerController player)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        SceneManager.LoadScene("Main Menu");
    }

        public void SaveGame(PlayerController player) {
        SaveSystem.SavePlayer(player); 
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
    }
    public void LoadGame(PlayerController player){
        GameData data = SaveSystem.LoadPlayer();
        
        player.level = data.level;
        player.currentHealth = data.currentHealth;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position; 

        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
    }
}

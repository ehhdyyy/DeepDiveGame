using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateUI : MonoBehaviour
{
    [Header("UI")]
    public GameObject startScreen;
    public GameObject gameUI;
    public GameObject startCam;
    public GameObject startCamVFX;

    [Header("Audio")]
    public GameObject startScreenAudio;
    public GameObject gameAudio;

    [Header("Gameplay")]
    public GameObject player;
    public GameObject spawnZone;
    public GameObject fishZone;
    public GameObject hud;
    public GameObject starterItems;
    public GameObject enemy;
    public GameObject spawnedObjectFolder;

    public void StartGame()
    {
        if (gameUI != null) gameUI.SetActive(true);
        if (startCam != null) startCam.SetActive(false);
        if (startScreen != null) startScreen.SetActive(false);
        if (startCamVFX != null) startCamVFX.SetActive(false);
        if (startScreenAudio != null) startScreenAudio.SetActive(false);
        if (gameAudio != null) gameAudio.SetActive(true);
        if (player != null) player.SetActive(true);
        if (spawnZone != null) spawnZone.SetActive(true);
        if (fishZone != null) fishZone.SetActive(true);
        if (hud != null) hud.SetActive(true);
        if (starterItems != null) starterItems.SetActive(true);
        if (enemy != null) enemy.SetActive(true);
        if (spawnedObjectFolder != null) spawnedObjectFolder.SetActive(true);

        Time.timeScale = 1f;
    }

    public void ResetToFreshScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
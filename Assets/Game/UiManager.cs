using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject levelFailPanel;
    [SerializeField] private GameObject levelWinPanel;


    private void OnEnable()
    {
        TowerManager.OnFillingCompleted += OnLevelComplete;
        CustomLaser.OnCollisionWthHurdle += OnLevelFail;
    }
    private void OnLevelFail()
    {
        OnLevelEnd(levelFailPanel);
    }
    private void OnLevelComplete(bool _)
    {
        OnLevelEnd(levelWinPanel);
    }
    private void OnLevelEnd(GameObject panel)
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    #region Ui Click
    public void OnClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }
    #endregion
    private void OnDisable()
    {
        TowerManager.OnFillingCompleted -= OnLevelComplete;
        CustomLaser.OnCollisionWthHurdle -= OnLevelFail;
    }
}

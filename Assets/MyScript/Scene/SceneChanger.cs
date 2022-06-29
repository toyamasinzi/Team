using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] float _count = 0f;
    [SerializeField] string _Scene = "Game";
    private float _timer = 0f;
    bool _istimer = false;
    void Update()
    {
        if (_istimer)
        {
            _timer += Time.deltaTime;
        }

        if (_count < _timer)
        {
            SceneManager.LoadScene(_Scene);
        }
    }

    public void StartTimer()
    {
        _istimer = true;
    }
}

using UnityEngine;
using UnityEngine.Playables;

public class TimelineOpenScene : MonoBehaviour
{
    [SerializeField] private PlayableDirector pd;

    private void Awake()
    {
        if (TryGetComponent(out PlayableDirector playD))
            pd = playD;

        FirstOpenChexk();
    }

    private void Start() 
    {
        GlobalEventManager.RiseEvOpenSceneStarted();
        GlobalEventManager.eFinish.AddListener(ChangeKeyOpenScene);
    }

    private void Update()
    {
        if (pd.state != PlayState.Playing)
        {
            GlobalEventManager.RiseEvOpenSceneFinished();
            OnDisable();
        }
    }

    private void OnDisable() 
    {
        ChangeKeyOpenScene();
        gameObject.SetActive(false);
    }

    private void FirstOpenChexk()
    {
        if (PlayerPrefs.GetInt(Const.OPENSCENE) == 1)
            OnDisable();
    }

    private void ChangeKeyOpenScene() => PlayerPrefs.SetInt(Const.OPENSCENE, 1);
}

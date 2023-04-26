using UnityEngine;

public class Bomber : MonoBehaviour
{
    private readonly float delay2Deastroy = 4f;

    [SerializeField] private BombContainer bombContainer;
    [SerializeField] private GameObject bomb;
    [SerializeField] private bool shot = false;
    private Transform shotTransform;



    private float reload = 4f;
    private Timer timer = new Timer();
    private void Start()
    {
        shotTransform = transform.GetChild(0);
        bombContainer = FindObjectOfType<BombContainer>();
    }

    private void Shot() 
    {
        GameObject b = Instantiate(bomb, shotTransform.position, Quaternion.identity, bombContainer.transform);
        Destroy(b, delay2Deastroy);
    }

    private void Update()
    {
        shot = timer.StartT(reload);

        if (shot)
            Shot();
    }
}

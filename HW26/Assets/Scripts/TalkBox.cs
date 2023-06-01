using UnityEngine;
using UnityEngine.Playables;

public class TalkBox : MonoBehaviour
{
    private Vector3 talkPos = new Vector3(-3f, 0f, 6.5f);
    [SerializeField] private PlayableDirector director;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement mv)) 
        {
            mv.enabled = false;
        }

        if (other.TryGetComponent(out Animator anim))
        {
            //anim.enabled = false;
            other.gameObject.transform.position = talkPos;
            director.Play();
        }
    }
}

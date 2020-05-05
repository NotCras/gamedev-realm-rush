using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float dwellTime = 1f;
    [SerializeField] private ParticleSystem goalExplode;
    [SerializeField] private AudioClip baseAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPathFound();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> pathway)
    {
        print(gameObject.name + " starting movement.");

        foreach (var w in pathway)
        {
            transform.position = w.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }

        AttackBase();
    }

    private void AttackBase()
    {
        var vfx = Instantiate(goalExplode, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        GetComponent<AudioSource>().PlayOneShot(baseAttack);
        Destroy(vfx.gameObject, destroyDelay);

        Destroy(this.gameObject);
    }
}
using System;
using System.Collections;
using UnityEngine;

public sealed class Enemy : Instance
{
    public const float vision = 1f;
    public const float defaultDelay = 0.5f;

    private bool Alerted;

    //TODO : creates default behaviour

    // Start is called before the first frame update
    new void Start()
    {
        StartCoroutine(Main());
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

    }

    private IEnumerator Main()
    {
        //StartCoroutine(SearchTargets());
        while (this.Health > 0)
        {
            yield return SearchTarget();
        }
    }
    /// <summary>
    /// Search for players near, if found, go to LookToTarget
    /// </summary>
    /// <returns></returns>
    private IEnumerator SearchTarget()
    {
        Player target = FindNearestByTag<Player>("Player", vision);

        if (target == null)
        {
            Alerted = false;
            yield return new WaitForEndOfFrame();
            StopCoroutine(LookToTarget(Target));
        }
        else
        {
            Alerted = true;
            if (Alerted)
            {
                Target = target.gameObject.transform.position;
                StartCoroutine(LookToTarget(Target));
            }
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Points to current target and shoot on it
    /// </summary>
    /// <param name="target">The position of the target founded in SearchTarget</param>
    /// <returns></returns>
    private IEnumerator LookToTarget(Vector3 target)
    {
        Vector3 dir = target - weapon.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //dir.y = 0;
        //var finDir = Convert.ToInt32(weapon.transform.rotation.eulerAngles.z);
        var a = Quaternion.AngleAxis(Convert.ToInt32(angle), Vector3.forward);
        var b = weapon.transform.rotation;
        while (a != b)
        {
            weapon.transform.rotation = Quaternion.RotateTowards(b,a, Time.time * 1);
            Debug.DrawLine(weapon.transform.position, target);
            yield return new WaitForEndOfFrame();
        }
        weapon.Shoot(Target);
        yield return new WaitForEndOfFrame();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(this.transform.position, vision);
    }

}

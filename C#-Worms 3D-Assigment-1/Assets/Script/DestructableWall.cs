
using UnityEngine;

public class DestructableWall : MonoBehaviour
{
    

    [SerializeField] private Transform pfWallBroken;
    
    public int ObjectHealth;

    public void TakeObjectDamage(int objectDamage)
    {
        ObjectHealth -= objectDamage;

        if (ObjectHealth <= 0)
        {
            Transform wallBrokenTransform = Instantiate(pfWallBroken, transform.position, transform.rotation);

            foreach (Transform child in wallBrokenTransform)
            {
                if (child.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody))
                {
                    childRigidbody.AddExplosionForce(200f, childRigidbody.transform.position , 10f);
                }
            }
            Destroy(gameObject);
        }
    }

    
    
}

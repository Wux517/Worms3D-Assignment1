
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Throwing : MonoBehaviour
{
    [SerializeField] private Camera playerAimCamera;
    [SerializeField] private TrajectoryLine lineRenderer;
    
    [SerializeField] private int playerIndex;
    
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    
    

    public int totalThrows;
    public float throwCooldown;

    private KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;
    
    

    bool readyToThrow;

    private void Start()
    {
        
            readyToThrow = true;
            
    }

    private void Update()
    {
        
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex) && Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 force = cam.forward * throwForce + transform.up * throwUpwardForce;
        
            lineRenderer.DrawCurvedTrajectory(force);
        
            if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
            {
                Throw();

                
            }
        }
        
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        

        Vector3 forceDirection = cam.forward;
        
        Ray ray = playerAimCamera.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            //Direction Point A -> B = B - A
            
            //Linerenderer
           /* Vector3 start = transform.position;

            Vector3 end = transform.position + transform.forward * 50f;
      
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end); */
           

            forceDirection = (raycastHit.point - attackPoint.position).normalized;
        }
        
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        
        
        
        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    

}
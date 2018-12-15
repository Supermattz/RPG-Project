using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;


   
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

   

    // Move player to what we hit
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

         //If pressing left mouse
        if (Input.GetMouseButtonDown(0))
        {
            //Creates a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if ray hits
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point); //move to where we hit



                // Stop focusing any objects
                RemoveFocus();
            }
        }

        //if pressing right mouse
        if (Input.GetMouseButtonDown(1))
        {
            //Create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           
            //If ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check if hitting interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                //If we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
       if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }


    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}


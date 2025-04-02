using UnityEngine;

public class CatChecker : MonoBehaviour
{
   private RacoonMover _racoonMover;

   private void Start()
   {
      _racoonMover = GetComponentInParent<RacoonMover>();
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<BaseCat>())
      {
         _racoonMover.CanMove(false);
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<BaseCat>())
      {
         _racoonMover.CanMove(true);
      }
   }
}

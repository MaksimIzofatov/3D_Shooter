using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
   private const string Horizontal = nameof(Horizontal);
   private const string Vertical = nameof(Vertical);
   private const string MouseX = "Mouse X";
   private const string MouseY = "Mouse Y";

   public event Action<float, float> Moved;
   public event Action<float, float> Looked;

   private void Update()
   {
      float horizontal = Input.GetAxis(Horizontal);
      float vertical = Input.GetAxis(Vertical);
      Moved?.Invoke(horizontal, vertical);

      float mouseX = Input.GetAxis(MouseX);
      float mouseY = Input.GetAxis(MouseY);
      Looked?.Invoke(mouseX, mouseY);
   }
}

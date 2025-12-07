using System.ComponentModel.DataAnnotations;

namespace ProyectoLaRuta.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario o correo es obligatorio")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

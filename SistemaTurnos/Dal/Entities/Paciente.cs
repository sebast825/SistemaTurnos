using System.ComponentModel.DataAnnotations;

namespace SistemaTurnos.Dal.Entities
{
    public class Paciente : Persona
    {
        public Paciente() : base() // Llama al constructor de la clase base
        {
        }
        public string TelefonoEmergencia { get; set; }
        public string NombreEmergencia { get; set; }

        public void ValidarAtributos()
        {
            base.ValidarAtributos();
            ValidateNombreEmergencia();
            ValidateTelefonoEmergencia();

        }
        private void ValidateTelefonoEmergencia()
        {

            try
            {
                long esNumero = long.Parse(this.TelefonoEmergencia);

            }
            catch (Exception ex)
            {
                throw new ValidationException("El telefono es invalido");

            }


        }
        private void ValidateNombreEmergencia()
        {
            if (string.IsNullOrWhiteSpace(this.NombreEmergencia))
            {
                throw new ValidationException("El nombre no puede estar vacío.");
            }
            if (this.Nombre.Length > 100) // Asumiendo un máximo de 100 caracteres
            {
                throw new ValidationException("El nombre no puede exceder los 150 caracteres.");
            }

        }

    }
}

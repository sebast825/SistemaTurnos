using SistemaTurnos.Common;
using SistemaTurnos.Dto.Persona;
using System.ComponentModel.DataAnnotations;

namespace SistemaTurnos.Dal.Entities
{
    public class Persona : ClaseBase
    {
        public Persona() : base() { 
            FechaCreacion = DateTime.Now;
            EstadoPersona = EstadoPersona.Activo;
        }
        public string Nombre {get;set;}
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string NumeroDocumento { get; set; }
        public int SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EstadoPersona EstadoPersona { get; set; }


        public void ValidarAtributos()
        {
            ValidateNombre();
            ValidateApellido();
            ValidateFechaNac();
            ValidateNumeroDocumento();
            ValidateSexoId();
            ValidateTelefono();
        }

    private void ValidateNombre()
    {
        if (string.IsNullOrWhiteSpace(this.Nombre))
        {
            throw new ValidationException("El nombre no puede estar vacío.");
        }
        if (this.Nombre.Length > 100) // Asumiendo un máximo de 100 caracteres
        {
            throw new ValidationException("El nombre no puede exceder los 100 caracteres.");
        }

    }
    private void ValidateApellido()
    {
        if (string.IsNullOrWhiteSpace(this.Apellido))
        {
            throw new ValidationException("El apellido no puede estar vacío.");
        }
        if (this.Apellido.Length > 100)
        {
            throw new ValidationException("El apellido no puede exceder los 100 caracteres.");
        }
    }

    private void ValidateFechaNac()
    {

        if (this.FechaNacimiento > DateTime.Now)
        {
            throw new ValidationException("La fecha de nacimiento no puede ser en el futuro.");
        }
        if (this.FechaNacimiento.Year < 1900)
        {
            throw new ValidationException("La fecha de nacimiento no puede ser anterior a} 1900.");
        }
    }

        //modificar numDoc
    private void ValidateNumeroDocumento()
    {
        if (string.IsNullOrWhiteSpace(this.NumeroDocumento))
        {
            throw new ValidationException("El número de documento no puede estar vacío.");
        }

         
            if (!int.TryParse(this.NumeroDocumento, out int numero))
            {
                // Conversion exitosa, el número está en la variable 'numero'
                throw new ValidationException("El documento debe ser un valor numerico");
            }

        }

    private void ValidateSexoId()
    {
            int sexoId = this.SexoId;
        //hombre,mujer,otro
        if (sexoId != 1 && sexoId != 2 && sexoId != 3)
        {
            throw new ValidationException("El sexo seleccionado noe xiste");

        }
    }
    private void ValidateTelefono()
    {

        try
        {
            long esNumero = long.Parse(this.Telefono);

        }
            catch (Exception ex)
        {
            throw new ValidationException("El telefono es invalido");

        }


    }

  
}

}
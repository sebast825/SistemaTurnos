namespace SistemaTurnos.Common
{
    public static class RolePermissionMapping
    {
        public static Dictionary<Role, List<Permission>> RolePermissions = new Dictionary<Role, List<Permission>>
    {
        { Role.Paciente, new List<Permission>
            {
                Permission.CreateTurno
            }
        },
        { Role.Medico, new List<Permission>
            {
                Permission.CreateDisponibilidadMedico,
                Permission.GetEstadosTurno,
                Permission.FilterByDoctorTurno,
                Permission.FilterByDateTimeTurno
            }
        },
        { Role.Secretario, new List<Permission>
            {
                Permission.GetAllTurno,
                Permission.GetEstadosTurno,
                Permission.FilterByDoctorTurno,
                Permission.FilterByDateTimeTurno,
                Permission.CreateTurno
            }
        },
        { Role.Admin, new List<Permission>
            {
                Permission.CrearMedico,
                Permission.CrearAdministrativo,
                Permission.CreateDisponibilidadMedico,
                Permission.GetEstadosTurno,
                Permission.FilterByDoctorTurno,
                Permission.FilterByDateTimeTurno,
                Permission.GetAllTurno,
                Permission.CreateTurno
            }
        }
    };
    }

}

public class DtoCrearCliente
{ 
    /// <summary>
    /// DTO NUEVO SIN LISTAS VACIAS
    /// </summary>
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Telefono { get; set; }
    public string Email { get; set; }
    public string Constrasenia { get; set; }
    public string Rol { get; set; }
    public DateTime FechaCreacion { get; set; }

    public DtoCrearCliente() { }
}

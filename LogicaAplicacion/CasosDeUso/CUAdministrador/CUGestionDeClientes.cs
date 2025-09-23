using DTOs;
using DTOs.ClienteDTOs;
using LogicaAccesoDatos;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios.InterfacesAPI;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;
namespace LogicaAplicacion.CasosDeUso.CUAdministrador
{
    public class CUGestionDeClientes : ICUGestionDeClientes
    {
        private IRepositorioCliente _RepoCliente;
        private IRepositorioClienteAPI _RepoClienteAPI;
        private IUnitOfWork _unitOfWork;

        public CUGestionDeClientes(IRepositorioCliente _RepositorioCliente,IRepositorioClienteAPI a,IUnitOfWork U)
        {
            _RepoCliente = _RepositorioCliente;
            _RepoClienteAPI = a;
            _unitOfWork = U;
        }
        public void CrearCliente(DtoCrearCliente dtoCli)
        {
            ValidarCliente(dtoCli);

            Cliente NuevoCliente = MapperCliente.DeDtoACliente(dtoCli);

            _RepoCliente.Add(NuevoCliente);
        }

        public int EncontrarIdDeCliente(string email)
        {
            int IdCli = _RepoCliente.FindByEmailParaId(email);
            return IdCli;
        }

        public DtoClienteAEditar EncontrarCliente(string email)
        {
            Cliente cli=_RepoCliente.FindByEmail(email);
            DtoClienteAEditar dto=MapperCliente.DeClienteADto(cli);
            return dto;
        }


        public List<DtoListarCliente> TodosLosClientes()
        {
            List<Cliente>Clientes=_RepoCliente.FindAll();

            List<DtoListarCliente> DtoClientes=MapperCliente.DeListaClienteAListaDto(Clientes);

            return DtoClientes;
        }


        



        public DtoClienteAEditar GetEditar(int id)
        {
           Cliente cli= _RepoCliente.FindById(id);
                
            DtoClienteAEditar dto = MapperCliente.DeClienteADto(cli);

            return dto;
        }


        public void PostEditar(DtoClienteAEditar dto)
        {
            Cliente cli=_RepoCliente.FindById(dto.Id);
            if (cli == null)
            {
                throw new Exception("El Usuario no es válido o no existe.");
            }

            cli.Nombre = dto.Nombre;
            cli.Apellido = dto.Apellido;    
            cli.FechaCreacion = dto.FechaCreacion;
            cli.constrasenia = dto.constrasenia;
            cli.Email = dto.Email;
            cli.Telefono = dto.Telefono;

            _RepoCliente.Update(cli);

        }


        public DtoClienteAEditar GetEliminar(int id)
        {
            Cliente cli = _RepoCliente.FindById(id);

            DtoClienteAEditar dto = MapperCliente.DeClienteADto(cli);

            return dto;
        }


        public void PostEliminar(DtoClienteAEditar dtoo)
        {
            Cliente cli = MapperCliente.DeDtoACliente(dtoo);
            _RepoCliente.Remove(cli.Id);
        }


        public void ValidarCliente(DtoCrearCliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío o ser solo espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new ArgumentException("El apellido no puede estar vacío o ser solo espacios en blanco.");
            }

            if (cliente.Telefono.ToString().Length < 8)
            {
                throw new ArgumentException("El número de teléfono debe tener al menos 8 dígitos.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Email) || !cliente.Email.Contains("@"))
            {
                throw new ArgumentException("El email debe ser válido y contener un '@'.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Constrasenia) || cliente.Constrasenia.Length < 6)
            {
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            }

            if (cliente.FechaCreacion > DateTime.Now)
            {
                throw new ArgumentException("La fecha de creación no puede ser en el futuro.");
            }

        }



                            //CASOS DE USO ASYNC PARA LA API

        public async Task<int> CrearClienteAPI(DtoCrearCliente dto,CancellationToken ct)
        {
            ValidarCliente(dto);

            var entity = MapperCliente.DeDtoACliente(dto);

            await _RepoClienteAPI.AddAsync(entity,ct);
            await _unitOfWork.SaveChangesAsync(); // decide el CU cuándo confirmar

            return entity.Id;
        }

        public Task<Cliente?> FindByIdAsync(int id, CancellationToken ct)
        {
            var entity = _RepoClienteAPI.FindByIdAsync(id, ct);
            if(entity == null)
            {
                throw new Exception("El Cliente no es válido o no existe.");
            }
            return entity;
        }

        public Task<Cliente?> FindByEmailAsync(string email, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> FindIdByEmailAsync(string email, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }

}


using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Commands.Colaboradores;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;

public class ColaboradoresCreateHandler
{
    private readonly IColaboradorService _colaboradorService;

    public ColaboradoresCreateHandler(IColaboradorService colaboradorService)
    {
        _colaboradorService = colaboradorService;
    }

    public async Task<Response<int>> Handle(ColaboradoresCreateCommand command, CancellationToken cancellationToken)
    {
        return await _colaboradorService.CreateColaborador(command);
    }
}

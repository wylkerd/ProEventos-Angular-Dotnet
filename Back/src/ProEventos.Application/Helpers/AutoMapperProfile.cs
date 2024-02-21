using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain.Models;

namespace ProEventos.API.Helpers;

// Configuracoes do AutoMapper para passar na Startup
public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<Evento, EventoDto>().ReverseMap(); // Mapping pode ser feito de ambas direcoes
    CreateMap<Lote, LoteDto>().ReverseMap();
    CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
    CreateMap<Palestrante, PalestranteDto>().ReverseMap();
    CreateMap<Palestrante, PalestranteAddDto>().ReverseMap();
    CreateMap<Palestrante, PalestranteUpdateDto>().ReverseMap();
  }
}

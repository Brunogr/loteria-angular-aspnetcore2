using AutoMapper;
using Loteria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loteria.Application.Model.AutoMapper.Profiles
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Sorteio, SorteioViewModel>()
                .ConstructUsing(c =>
                new SorteioViewModel()
                {
                    Data = c.Data,
                    Id = c.Id,
                    Numero = c.Numero,
                    Ganhadores = c.Ganhadores.Select<Ganhador, GanhadorViewModel>(ganhador =>
                    new GanhadorViewModel()
                    {
                        Acertos = ganhador.Acertos,
                        Cartela = new CartelaViewModel()
                        {
                            Id = ganhador.Cartela.Id,
                            Data = ganhador.Cartela.Data,
                            Numero = ganhador.Cartela.Numero
                        }
                    }).ToList()
                });
        }
    }
}

using Loteria.Application.Service.Interface;
using Loteria.Infra.Data.Interface;
using System;
using Loteria.Application.Model;
using Loteria.Domain.Model;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;

namespace Loteria.Application.Service
{
    public class SorteioService : ISorteioService
    {
        ISorteioRepository _sorteioRepository;
        ICartelaRepository _cartelaRepository;
        IMapper _mapper;
        public SorteioService(ISorteioRepository sorteioRepository, ICartelaRepository cartelaRepository, IMapper mapper)
        {
            _sorteioRepository = sorteioRepository;
            _cartelaRepository = cartelaRepository;
            _mapper = mapper;
        }

        public SorteioViewModel GerarSorteio()
        {
            Sorteio sorteio;
            List<Cartela> cartelas = new List<Cartela>();

            var dataUltimoSorteio = _sorteioRepository.GetAll().Any() ? _sorteioRepository.GetAll().Max(s => s.Data) : DateTime.MinValue;

            var ultimoSorteio = _sorteioRepository.GetByFilter(s => s.Data == dataUltimoSorteio).FirstOrDefault();

            if (ultimoSorteio != null)
            {
                sorteio = new Sorteio(ultimoSorteio.Id + 1);

                cartelas = _cartelaRepository
                    .GetByFilter(c => c.Data > ultimoSorteio.Data 
                    && c.Data < sorteio.Data).ToList();                
            }
            else
            {
                sorteio = new Sorteio(1);

                cartelas = _cartelaRepository.GetAll().ToList();
            }

            foreach (var cartela in cartelas)
            {
                var ganhador = ValidarGanhador(sorteio, cartela);

                if (ganhador != null)
                    sorteio.AdicionarGanhador(ganhador);
            }

            _sorteioRepository.Insert(sorteio);

            return _mapper.Map<SorteioViewModel>(sorteio);

        }

        private Ganhador ValidarGanhador(Sorteio sorteio, Cartela cartela)
        {
            var acertos = sorteio.Numero.Intersect(cartela.Numero).Count();

            if (acertos >= 4)
                return new Ganhador(cartela, acertos);

            return null;
        }
    }
}

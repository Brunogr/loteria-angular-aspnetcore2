using Loteria.Application.Service.Interface;
using Loteria.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Loteria.Application.Model;
using Loteria.Domain.Model;
using System.Linq;
using AutoMapper;

namespace Loteria.Application.Service
{
    public class CartelaService : ICartelaService
    {
        ICartelaRepository _cartelaRepository;
        IMapper _mapper;
        public CartelaService(ICartelaRepository cartelaRepository, IMapper mapper)
        {
            _cartelaRepository = cartelaRepository;
            _mapper = mapper;
        }

        public CartelaViewModel FazerJogo(int[] numeros)
        {          
            var cartela = new Cartela(GerarProximoId(), numeros);

            cartela = _cartelaRepository.Insert(cartela);

            return _mapper.Map<CartelaViewModel>(cartela);
        }

        public CartelaViewModel FazerJogoAutomatico()
        {
            var cartela = new Cartela(GerarProximoId());

            cartela = _cartelaRepository.Insert(cartela);

            return _mapper.Map<CartelaViewModel>(cartela);
        }

        public List<CartelaViewModel> GetAll()
        {
            return _mapper.Map<List<CartelaViewModel>>(_cartelaRepository.GetAll());
        }

        private int GerarProximoId()
        {
            return _cartelaRepository.GetAll().Any() ? _cartelaRepository.GetAll().Max(c => c.Id) + 1 : 1;
        }
    }
}

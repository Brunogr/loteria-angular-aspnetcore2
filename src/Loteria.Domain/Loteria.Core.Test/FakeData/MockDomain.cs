using Bogus;
using Loteria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Core.Test.FakeData
{
    public static class MockDomain
    {
        public static List<Cartela> Cartelas(int quantidade)
        {
            return new Faker<Cartela>()
                .CustomInstantiator(f =>
                    new Loteria.Domain.Model.Cartela(f.Random.Int(1))
                    ).Generate(quantidade);
        }
    }
}

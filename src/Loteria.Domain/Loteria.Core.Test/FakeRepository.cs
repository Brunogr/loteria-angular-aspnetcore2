using Loteria.Core.Domain.Model.Base;
using Loteria.Infra.Data.Base;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loteria.Core.Test
{
    public static class FakeRepository<TModel> where TModel : BaseModel
    {
        public static Mock<TRepository> GetMock<TRepository>() where TRepository : Repository<TModel>, IRepository<TModel>
        {
            var items = new List<TModel>();

            var mock = new Mock<TRepository>();

            mock.Setup(mr => mr.Insert(It.IsAny<TModel>())).Returns(
                (TModel target) =>
                {
                    items.Add(target);
                    return target;
                });

            mock.Setup(mr => mr.Get(It.IsAny<int>())).Returns(
                (int id) => items.FirstOrDefault(c => c.Id == id));

            mock.Setup(mr => mr.GetAll()).Returns(() => items);

            mock.Setup(mr => mr.GetByFilter(It.IsAny<Func<TModel, bool>>())).Returns(
                (Func<TModel, bool> filter) => items.Where(filter).ToList());
            
            mock.Setup(mr => mr.Delete(It.IsAny<int>())).Returns(
                (int id) =>
                {
                    var item = items.FirstOrDefault(i => i.Id == id);
                    return items.Remove(item);
                }
            );

            return mock;
        }

        public static Mock<TRepository> GetMock<TRepository>(List<TModel> itemsList) where TRepository : Repository<TModel>, IRepository<TModel>
        {
            var items = itemsList;

            var mock = new Mock<TRepository>();

            mock.Setup(mr => mr.Insert(It.IsAny<TModel>())).Returns(
                (TModel target) =>
                {
                    items.Add(target);
                    return target;
                });

            mock.Setup(mr => mr.Get(It.IsAny<int>())).Returns(
                (int id) => items.FirstOrDefault(c => c.Id == id));

            mock.Setup(mr => mr.GetAll()).Returns(() => items);

            mock.Setup(mr => mr.GetByFilter(It.IsAny<Func<TModel, bool>>())).Returns(
                (Func<TModel, bool> filter) => items.Where(filter).ToList());
            
            mock.Setup(mr => mr.Delete(It.IsAny<int>())).Returns(
                (int id) =>
                {
                    var item = items.FirstOrDefault(i => i.Id == id);
                    return items.Remove(item);
                }
            );

            return mock;
        }
    }
}
